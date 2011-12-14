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
using System.Text;
using System.Windows.Forms;
using viServoMaster;
#endregion

namespace viTestApp
{
  /// <summary>
  /// Startup Form for selecting USB to CAN gateway device
  /// </summary>
  public partial class StartForm : Form
  {
    #region Private Variables
    /******************************************************************************/
    private string[] portNames;
    private string portName = string.Empty;
    private bool small_network = true;
    #endregion

    #region Constructors
    /******************************************************************************/
    public StartForm()
    {
      InitializeComponent();
      ShowPorts();
    }
    #endregion

    #region Public Properties
    /******************************************************************************/
    public string Port
    {
      get { return portName; }
    }
    public bool SmallNetwork
    {
      get { return small_network; }
    }
    #endregion

    #region Private Methods
    /******************************************************************************/
    /// <summary>
    /// ShowPorts - list available ports for user selection
    /// </summary>
    private void ShowPorts()
    {
      // Close port if open
      if(Master.ComportOpen)
      {
        // Get open port name
        portName = (string)Master.PortName;
        try
        {
          string err_str;
          Master.OpenCloseComPort(portName, out err_str, cbxStartSmallNetwork.Checked);
        }
        catch(Exception ex)
        {
          MsgBox.Show(this, String.Format("Master.OpenCloseComPort({0}) err:\n {1}\n", portName, ex.ToString()), "Comport Close Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }

      // List available ports
      portNames = Master.GetComPorts();
      cboPorts.Items.Clear();
      foreach(string s in portNames)
        cboPorts.Items.Add(s);
      // Show gateway if only one detected
      if(portNames.Length == 1)
      {
        cboPorts.SelectedIndex = 0;
      }
    }
    #endregion

    #region Event Handlers
    /******************************************************************************/
    /// <summary>
    /// btnPort_Click - Select the COM port for access to slave network
    /// </summary>
    private void btnPort_Click(object sender, EventArgs e)
    {
      if(cboPorts.SelectedIndex != -1)
      {
        string port = (string)this.cboPorts.SelectedItem;

        try
        {
          string err_str;

          if(Master.OpenCloseComPort(port, out err_str, cbxStartSmallNetwork.Checked))
          {
            // Get open COM port name - null if closed
            portName = (string)Master.PortName;

            if(portName == null)
            {
              btnPort.Text = "Open Port";
              cboPorts.Items.Clear();
              ShowPorts();
            }
            else
            {
              this.DialogResult = DialogResult.OK;
              small_network = cbxStartSmallNetwork.Checked;
            }
          }
          else
          {
            MsgBox.Show(this, String.Format("Master.OpenCloseFTDIPort({0}) err:\n {1}\n", port, err_str), "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        catch(ApplicationException app_ex)
        {
          string err_str = (app_ex.InnerException == null) ? app_ex.ToString() : app_ex.InnerException.ToString();
          MsgBox.Show(this, String.Format("Master.OpenCloseComPort({0}) err:\n {1}\n", port, err_str), "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Dispose();
        }
        catch(Exception ex)
        {
          MsgBox.Show(this, String.Format("Master.OpenCloseComPort({0}) err:\n {1}\n", port, ex.ToString()), "Comport Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Dispose();
        }
      }
      else
      {
        MsgBox.Show(this, "Select a port\n");
      }
    }
    #endregion
  }
}