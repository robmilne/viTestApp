/*
 * Project:   viTestApp
 * Company:   Vera Ikona, http://vera-ikona.com
 * Author:    Robert Milne
 * Created:   June 2011
 *
 * Notes:
 */
#region Inclusions
/******************************************************************************/
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using viServoMaster;
#endregion

namespace viTestApp
{
  public partial class MainForm : Form
  {
    #region Constants
    /******************************************************************************/
    // Invalid servo network address
    public const byte NULL_NODE = 255;
    #endregion

    #region Public Enumerations
    /******************************************************************************/
    public enum LogMsgType
    {
      Attention,
      Outgoing,
      Normal,
      Warning,
      Error
    };

    #endregion

    #region Private Variables
    /******************************************************************************/
    // Comport string
    private string _port = string.Empty;

    // XML file directory
    private string XMLDir = string.Empty;

    private SortedDictionary<byte, Servo> _servo_ht = null;
    //private Servos _servos_obj = null;

    // FuzzyRules object to handle dynamic creation of comboboxes for setting fuzzy rules
    private FuzzyRules _fuzzy_rules_obj = null;

    // FuzzyMemFuncs object to handle dynamic creation of textboxes for setting fuzzy membership functions
    private FuzzyMemFuncs _fuzzy_mem_funcs_obj = null;

    // Gateway
    private Gateway _gateway;

    // Group command object
    private Group _group;

    // Current servo node
    private Servo _active_servo;

    // Various colors for logging info
    private Color[] LogMsgTypeColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };

    // ControlList used for Slave ComboBox DataSource
    private List<slaveSelector> _slave_selector;

    private bool _update_flag = false;

    Version _app_ver;
    Version _dll_ver;
    #endregion

    #region Constructors
    /******************************************************************************/
    public MainForm()
    {
      _app_ver = Assembly.GetExecutingAssembly().GetName().Version;
      _dll_ver = Master.Version;

      InitializeComponent();

      // Hide settings menus and controls until servo network is detected
      tabControl1.Hide();

      _servo_ht = new SortedDictionary<byte, Servo>();

      _active_servo = null;

      // Drill down to locate containers where programatically constructed elements located (yuck!)
      Panel _rules_container = null;
      // Unfocus label required to remove focus from rules comboboxes after selection - hide under another control (yuck!)
      Label _unfocus_lbl = null;
      foreach(Control c_0 in this.Controls)
      {
        if(c_0.Name == "tabControl1")
        {
          TabControl tab_ctl_0 = (TabControl)c_0;
          foreach(Control c_1 in tab_ctl_0.Controls)
          {
            if(c_1.Name == "tabPageSetup")
            {
              TabPage tab_page_0 = (TabPage)c_1;
              foreach(Control c_2 in tab_page_0.Controls)
              {
                if(c_2.Name == "tabServoSettings")
                {
                  TabControl tab_ctl_1 = (TabControl)c_2;
                  foreach(Control c_3 in tab_ctl_1.Controls)
                  {
                    if(c_3.Name == "tabPageSetupFuzzy")
                    {
                      TabPage tab_page_1 = (TabPage)c_3;
                      foreach(Control c_4 in tab_page_1.Controls)
                      {
                        if(c_4.Name == "gbSetFuzzyRules")
                        {
                          GroupBox gbx = (GroupBox)c_4;
                          foreach(Control c_5 in gbx.Controls)
                          {
                            if(c_5.Name == "pnlFuzzyRules")
                            {
                              _rules_container = (Panel)c_5;
                            }
                            if(c_5.Name == "lblUnfocus")
                            {
                              _unfocus_lbl = (Label)c_5;
                            }
                          }
                        }
                        if(c_4.Name == "gbSetFuzzyMF")
                        {
                          _fuzzy_mem_funcs_obj = new FuzzyMemFuncs((GroupBox)c_4);
                        }
                      }

                      if(_rules_container != null && _unfocus_lbl != null)
                      {
                        _fuzzy_rules_obj = new FuzzyRules(_rules_container, _unfocus_lbl);
                      }
                      else
                      {
                        _fuzzy_rules_obj = null;
                        MsgBox.Show("Fuzzy Rules Panel not found");
                      }

                      if(_fuzzy_mem_funcs_obj == null)
                      {
                        MsgBox.Show("Fuzzy Mem Func groupbox not found");
                      }
                    }

                    if(c_3.Name == "tabPageSetupControl")
                    {
                      // Set top level groupboxes in "Servo Control" tab to have bold text
                      TabPage tab_page_2 = (TabPage)c_3;
                      foreach(Control c_5 in tab_page_2.Controls)
                      {
                        if(c_5 is GroupBox)
                        {
                          c_5.Font = new Font(c_5.Font, FontStyle.Bold);
                          foreach(Control c_5_ctl in c_5.Controls)
                          {
                            c_5_ctl.Font = new Font(c_5.Font, FontStyle.Regular);
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }

      // Populate comboboxes
      InitializeControls();

      // Disable symmetric control points.
      cbxMemFuncCtlPts.Checked = false;
      CtlPtsActive(false);
    }
    #endregion

    #region Private Methods
    /******************************************************************************/
    private bool GetGateway()
    {
      _gateway = new Gateway(Master.Gateway);
      // Instantiate gateway after successful detection of Master.GatewayNode inside StartForm
      if(_gateway.ServoGateway == null)
      {
        MsgBox.Show("No Gateway detected");
        return false;
      }
      else
      {
        //this.lblGatewayVer.Text = _gateway.Node.Version.Version.ToString();
        this.lblGatewayVer.Text = _gateway.ServoGateway.Description;

        SetComboBox(cboCANBitrate, (int)_gateway.ServoGateway.Bitrate);
      }
      return true;
    }

    /// <summary>
    /// GetServoNodes - Build slave hashtables from viServoMaster library
    /// </summary>
    [RefreshProperties(RefreshProperties.Repaint)]
    private bool GetServoNodes()
    {
      // First slave selector is "no slave" selection
      _slave_selector = new List<slaveSelector>();
      Slave _null_slave = null;
      _slave_selector.Add(new slaveSelector(_null_slave));

      if(Master.SlaveHashtable != null)
      {
        // Node zero always exists if any non-zero nodes present
        _group = Master.GroupNode;

        Dictionary<byte, Slave>.ValueCollection valueColl = Master.SlaveHashtable.Values;
        foreach(Slave slave in valueColl)
        {
          // Build new Servo object if not already existent
          if(!_servo_ht.ContainsKey(slave.Id) && slave.IsReady)
          {
            Servo servo = new Servo(slave);
            _servo_ht.Add(slave.Id, servo);
            _slave_selector.Add(new slaveSelector(slave));
          }
        }
      }
      else
      {
        MsgBox.Show(this, String.Format("{0} does not connect to a slave network\n", _port), "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }

      // Populate Slave Node combobox
      cboSlaveNode.DataSource = _slave_selector;
      cboSlaveNode.DisplayMember = "Description";
      cboSlaveNode.ValueMember = "Id";
      if(_slave_selector.Count == 2)
      {
        // Single servo node - Update controls with selection
        cboSlaveNode.SelectedIndex = 1;
      }

      return true;
    }

    private void InitializeControls()
    {
      //NB: String arrays used to populate combobox selections MUST match the control enum

      // Get Servo Rate Enums (first three correspond to 'NO_INIT')
      ClrComboBox(cboSetServoRate);
      for(int i = 3; i < Strings.ServoRateStrings.Length; i++)
      {
        cboSetServoRate.Items.Add(Strings.ServoRateStrings[i]);
      }
      cboSetServoRate.Text = "";

      // Get Encoder Divider
      ClrComboBox(cboSetEncDiv);
      for(int i = 0; i < Strings.EncoderDividerStrings.Length; i++)
      {
        cboSetEncDiv.Items.Add(Strings.EncoderDividerStrings[i]);
      }
      cboSetEncDiv.Text = "";

      // Get H-Bridge Enums (first corresponds to 'NO_INIT')
      ClrComboBox(cboSetHBridge);
      for(int i = 0; i < Strings.HBridgeStrings.Length; i++)
      {
        cboSetHBridge.Items.Add(Strings.HBridgeStrings[i]);
      }
      cboSetHBridge.Text = "";

      // Get H-Bridge PWM Rate Enums (first corresponds to 'NO_INIT')
      ClrComboBox(cboSetPWMRate);
      for(int i = 0; i < Strings.PWMRateStrings.Length; i++)
      {
        cboSetPWMRate.Items.Add(Strings.PWMRateStrings[i]);
      }
      cboSetPWMRate.Text = "";

      ClrComboBox(cboCANBitrate);
      for(int i = 0; i < Strings.CANBitrateStrings.Length; i++)
      {
        cboCANBitrate.Items.Add(Strings.CANBitrateStrings[i]);
      }
      cboCANBitrate.Text = "";
    }

    /// <summary>
    /// Log - Log data to the terminal window.
    /// </summary>
    private void Log(LogMsgType msgtype, string msg)
    {
      rtbMessageLog.Invoke(new EventHandler(delegate
      {
        rtbMessageLog.SelectedText = string.Empty;
        rtbMessageLog.SelectionFont = new Font(rtbMessageLog.SelectionFont, FontStyle.Bold);
        rtbMessageLog.SelectionColor = LogMsgTypeColor[(int)msgtype];
        rtbMessageLog.AppendText(msg);
        rtbMessageLog.ScrollToCaret();
      }));
    }

    // Delegates that enable asynchronous calls to UI controls
    delegate void SetTextCallback(Control ctl, string text);
    delegate void ClrTextCallback(TextBoxBase ctl);
    delegate void SetCheckboxCallback(CheckBox ctl, bool val);
    delegate void SetRadioButtonCallback(RadioButton ctl, bool val);
    delegate void SetListBoxCallback(ListBox ctl, int idx);
    delegate void ClrListBoxCallback(ListBox ctl);
    delegate void SetComboBoxCallback(ComboBox ctl, int idx);
    delegate void ClrComboBoxCallback(ComboBox ctl);

    // If the calling thread is different from the thread that
    // created the TextBox control, this method creates a
    // SetTextCallback and calls itself asynchronously using the
    // Invoke method.
    //
    // If the calling thread is the same as the thread that created
    // the TextBox control, the Text property is set directly.
    private void SetText(Control ctl, string text)
    {
      // InvokeRequired required compares the thread ID of the
      // calling thread to the thread ID of the creating thread.
      // If these threads are different, it returns true.
      if(ctl.InvokeRequired)
      {
        SetTextCallback d = new SetTextCallback(SetText);
        this.Invoke(d, new object[] { ctl, text });
      }
      else
      {
        ctl.Text = text;
      }
    }
    private void ClrText(TextBoxBase ctl)
    {
      if(ctl.InvokeRequired)
      {
        ClrTextCallback d = new ClrTextCallback(ClrText);
        this.Invoke(d, new object[] { ctl });
      }
      else
      {
        ctl.Clear();
      }
    }
    private void SetCheckbox(CheckBox ctl, bool val)
    {
      if(ctl.InvokeRequired)
      {
        SetCheckboxCallback d = new SetCheckboxCallback(SetCheckbox);
        this.Invoke(d, new object[] { ctl, val });
      }
      else
      {
        ctl.Checked = val;
      }
    }
    private void SetRadioButton(RadioButton ctl, bool val)
    {
      if(ctl.InvokeRequired)
      {
        SetRadioButtonCallback d = new SetRadioButtonCallback(SetRadioButton);
        this.Invoke(d, new object[] { ctl, val });
      }
      else
      {
        ctl.Checked = val;
      }
    }
    private void SetListBox(ListBox ctl, int idx)
    {
      if(ctl.InvokeRequired)
      {
        SetListBoxCallback d = new SetListBoxCallback(SetListBox);
        this.Invoke(d, new object[] { ctl, idx });
      }
      else
      {
        ctl.SelectedIndex = idx;
      }
    }
    private void ClrListBox(ListBox ctl)
    {
      if(ctl.InvokeRequired)
      {
        ClrListBoxCallback d = new ClrListBoxCallback(ClrListBox);
        this.Invoke(d, new object[] { ctl });
      }
      else
      {
        ctl.ClearSelected();
      }
    }
    private void SetComboBox(ComboBox ctl, int idx)
    {
      if(ctl.InvokeRequired)
      {
        SetComboBoxCallback d = new SetComboBoxCallback(SetComboBox);
        this.Invoke(d, new object[] { ctl, idx });
      }
      else
      {
        ctl.SelectedIndex = idx;
      }
    }
    private void ClrComboBox(ComboBox ctl)
    {
      // Note: cannot be used for ComboBox with a bound list control (DataSource property)
      if(ctl.InvokeRequired)
      {
        ClrComboBoxCallback d = new ClrComboBoxCallback(ClrComboBox);
        this.Invoke(d, new object[] { ctl });
      }
      else
      {
        ctl.Items.Clear();
      }
    }
    #endregion

    #region Event Handlers
    /******************************************************************************/
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      // Dispose Node, Slave and FTDI objects
      Master.Dispose();
    }

    /// <summary>
    /// openMenuItem_Click - 'Open Servo Network' menu selection under 'File'
    /// </summary>
    private void openMenuItem_Click(object sender, EventArgs e)
    {
      // app & dll versions must match
      if(_app_ver != _dll_ver)
      {
        MsgBox.Show(this, "Application and dll versions do not match!\nSee \"About\" menu item");
      }
      else
      {

        // Build slave network (hashtable) in start form if
        // selected comport opens and detects servo network
        if(_port == string.Empty)
        {
          // Port Dialog to select Serial Port
          StartForm startForm = new StartForm();

          if(startForm.ShowDialog(Form.ActiveForm) == DialogResult.OK)
          {
            _port = startForm.Port;

            if(GetGateway())
            {
              tabControl1.Show();
              tabControl1.DeselectTab(tabPageSetup);
              tabControl1.SelectedTab = tabPageGateWay;
              tabPageSetup.Hide();
              cboSlaveNode.Hide();
              lblEnumNodes.Hide();
              tabPageLog.Hide();
              tabPageGateWay.BringToFront();

              // programmatically click gateway 'get status' button (enables bitrate cbo)
              this.InvokeOnClick(btnGatewayGetStatus, EventArgs.Empty);

              // Send ENUM command to servo network to discover nodes
              if(GetServoNodes())
              {
                // Show settings selection menu item
                Log(LogMsgType.Normal, _port + " opened\n");

                tabPageSetup.Show();
                tabServoSettings.Show();
                cboSlaveNode.Show();
                lblEnumNodes.Show();
                tabPageLog.Show();
                tabControl1.Show();
                tabControl1.SelectedTab = tabPageSetup;

                openMenuItem.Enabled = false;
              }
            }
            else
            {
              CloseComPort(ref _port);
            }
          }
        }
        else
        {
          Master.ReEnumerateNodes();
          // Send ENUM command to servo network to discover nodes
          if(GetServoNodes())
          {
            // Show settings selection menu item
            Log(LogMsgType.Normal, _port + " opened\n");

            tabPageSetup.Show();
            tabServoSettings.Show();
            cboSlaveNode.Show();
            lblEnumNodes.Show();
            tabPageLog.Show();
            tabControl1.Show();
            tabControl1.SelectedTab = tabPageSetup;

            openMenuItem.Enabled = false;
          }
        }
      }
    }

    /// <summary>
    /// aboutToolStripMenuItem_Click - 'About' menu selection under 'File'
    /// </summary>
    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MsgBox.Show(this, String.Format("Created by Rob Milne\nVera Ikona Ltd\nhttp://vera-ikona.com\nviTestApp Ver: {0}\nviServoMaster.dll Ver: {1}\nCopyright © 2011", Assembly.GetExecutingAssembly().GetName().Version.ToString(), _dll_ver.ToString()), "About viTestApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void CloseComPort(ref string port)
    {
      try
      {
        string err_str;
        Master.OpenCloseComPort(port, out err_str, true);
      }
      catch(Exception ex)
      {
        MsgBox.Show(this, String.Format("Master.OpenCloseComPort({0}) err:\n {1}\n", port, ex.ToString()), "Comport Close Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      port = string.Empty;

      tabControl1.Hide();
    }

    /// <summary>
    /// btnMessageLogClear_Click - Clear log messages from the message window
    /// </summary>
    private void btnMessageLogClear_Click(object sender, EventArgs e)
    {
      rtbMessageLog.Clear();
    }

    private void cboSlaveNode_SelectedIndexChanged(object sender, EventArgs e)
    {
      // first "null" selection returns obj instead of value ?!?
      if(cboSlaveNode.SelectedValue is slaveSelector)
      {
        _active_servo = null;
      }
      else
      {
        if((byte)cboSlaveNode.SelectedValue != NULL_NODE &&
           _servo_ht != null &&
           _servo_ht.ContainsKey((byte)cboSlaveNode.SelectedValue))
        {
          _active_servo = _servo_ht[(byte)cboSlaveNode.SelectedValue];

          // Prevent calling this if combobox selections not initialized
          this.InvokeOnClick(btnServoCtlLoad, EventArgs.Empty);

          this.InvokeOnClick(btnStatusRead, EventArgs.Empty);
          this.InvokeOnClick(btnMotionCtlLoad, EventArgs.Empty);
          this.InvokeOnClick(btnLimitCtlLoad, EventArgs.Empty);

          // Automatically populate fuzzy vars
          this.InvokeOnClick(btnGetMF, EventArgs.Empty);
          this.InvokeOnClick(btnGetRules, EventArgs.Empty);
        }
        else
        {
          _active_servo = null;
        }
      }
    }
    private void cboSlaveNode_DataSourceChanged(Object sender, EventArgs e)
    {
      ComboBox ctlLIST = (ComboBox)sender;
      if(ctlLIST.DataSource == null)
        ctlLIST.Items.Clear();
    }
    #endregion

    #region Private Class
    /******************************************************************************/
    /// <summary>
    /// slaveSelector - nested private class
    ///                 Used in slave combobox list to display node/version and select by nodeId rather than combobox index
    /// </summary>
    private class slaveSelector : ISlave
    {
      private byte _id;
      private string _desc;

      public byte Id {
        set { _id = value; }
        get { return _id; }
      }
      public string Description {
        set { _desc = value; }
        get { return (_desc); }
      }
      public slaveSelector(ISlave slave)
      {
        if(slave == null)
        {
          // There should only be one of these per combobox (top selection)
          // Id is invalid node Id
          _id = NULL_NODE;
          _desc = " ";
        }
        else
        {
          _id = slave.Id;
          _desc = slave.Description;
        }
      }
    }
    #endregion
  }
}
