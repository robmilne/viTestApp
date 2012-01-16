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
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using viServoMaster;
#endregion

namespace viTestApp
{
  class FuzzyRule : IDisposable
  {
    #region Public Delegates
    /******************************************************************************/
    public delegate void RuleEventHandler(int column, int row, int selection);
    #endregion

    #region Constants
    /******************************************************************************/
    private const int LABEL_TOP = 34;
    private const int LABEL_HEIGHT = 12;

    private const int LABEL_IF_LEFT = 6;
    private const int LABEL_IF_WIDTH = 14;
    private const string LABEL_IF_STR = "IF";

    private const int LABEL_AND_LEFT = 86;
    private const int LABEL_AND_TOP = 18;
    private const int LABEL_AND_WIDTH = 26;
    private const string LABEL_AND_STR = "AND";

    private const int LABEL_THEN_LEFT = 176;
    private const int LABEL_THEN_TOP = 18;
    private const int LABEL_THEN_WIDTH = 30;
    private const string LABEL_THEN_STR = "THEN";

    private const int CBO_WIDTH = 60;
    private const int CBO_HEIGHT = 17;
    private const int CBO_TOP = 30;

    private const int CBO_POS_LEFT = 24;
    private const int CBO_SPD_LEFT = 114;
    private const int CBO_OUT_LEFT = 208;
    #endregion

    #region Private Variables
    /******************************************************************************/
    private Label _label_if = null;
    private Label _label_and = null;
    private Label _label_then = null;

    private ComboBox _cbo_pos = null;
    private ComboBox _cbo_spd = null;
    private ComboBox _cbo_out = null;

    private List<CboSelector> _pos_select_list = null;
    private List<CboSelector> _spd_select_list = null;
    private List<CboSelector> _out_select_list = null;

    private int _pos_select_idx = -1;
    private int _spd_select_idx = -1;
    private int _out_select_idx = -1;

    private int _rule_index;
    private RuleEventHandler _handler;

    // Track whether Dispose has been called.
    private bool disposed = false;
    #endregion

    #region Public Properties
    /******************************************************************************/
    public List<CboSelector> PosSelectList
    {
      set { _pos_select_list = value; }
    }
    public List<CboSelector> SpdSelectList
    {
      set { _spd_select_list = value; }
    }
    public List<CboSelector> OutSelectList
    {
      set { _out_select_list = value; }
    }
    public int PosSelectIdx
    {
      set { _pos_select_idx = value; }
      get { return _pos_select_idx; }
    }
    public int SpdSelectIdx
    {
      set { _spd_select_idx = value; }
      get { return _spd_select_idx; }
    }
    public int OutSelectIdx
    {
      set { _out_select_idx = value; }
      get { return _out_select_idx; }
    }
    #endregion

    #region Constructors
    /******************************************************************************/
    public FuzzyRule(Control parent, int rule_index, RuleEventHandler handler)
    {
      _rule_index = rule_index;
      _handler = handler;

      Font f_reg = new Font("Microsoft Sans Serif", 6);

      if(_label_if == null)
      {
        _label_if = new Label();
        _label_if.Font = f_reg;
        _label_if.Text = LABEL_IF_STR;
        _label_if.AutoSize = false;
        _label_if.Size = new Size(LABEL_IF_WIDTH, LABEL_HEIGHT);
        _label_if.Location = new Point(LABEL_IF_LEFT,
                                      LABEL_TOP + (CBO_HEIGHT * rule_index));
        parent.Controls.Add(_label_if);
      }
      if(_cbo_pos == null)
      {
        _cbo_pos = new ComboBox();
        _cbo_pos.Name = "cbo_pos_" + rule_index.ToString();
        _cbo_pos.Font = f_reg;
        _cbo_pos.Size = new Size(CBO_WIDTH, CBO_HEIGHT);
        _cbo_pos.Location = new Point(CBO_POS_LEFT,
                                    CBO_TOP + (CBO_HEIGHT * rule_index));
        // Prevent user from editing drop down list
        _cbo_pos.DropDownStyle = ComboBoxStyle.DropDownList;
        parent.Controls.Add(_cbo_pos);
      }
      if(_label_and == null)
      {
        _label_and = new Label();
        _label_and.Font = f_reg;
        _label_and.Text = LABEL_AND_STR;
        _label_and.AutoSize = false;
        _label_and.Size = new Size(LABEL_AND_WIDTH, LABEL_HEIGHT);
        _label_and.Location = new Point(LABEL_AND_LEFT,
                                      LABEL_TOP + (CBO_HEIGHT * rule_index));
        parent.Controls.Add(_label_and);
      }
      if(_cbo_spd == null)
      {
        _cbo_spd = new ComboBox();
        _cbo_spd.Name = "cbo_spd_" + rule_index.ToString();
        _cbo_spd.Font = f_reg;
        _cbo_spd.Size = new Size(CBO_WIDTH, CBO_HEIGHT);
        _cbo_spd.Location = new Point(CBO_SPD_LEFT,
                                    CBO_TOP + (CBO_HEIGHT * rule_index));
        _cbo_spd.DropDownStyle = ComboBoxStyle.DropDownList;
        parent.Controls.Add(_cbo_spd);
      }
      if(_label_then == null)
      {
        _label_then = new Label();
        _label_then.Font = f_reg;
        _label_then.Text = LABEL_THEN_STR;
        _label_then.AutoSize = false;
        _label_then.Size = new Size(LABEL_THEN_WIDTH, LABEL_HEIGHT);
        _label_then.Location = new Point(LABEL_THEN_LEFT,
                                      LABEL_TOP + (CBO_HEIGHT * rule_index));
        parent.Controls.Add(_label_then);
      }
      if(_cbo_out == null)
      {
        _cbo_out = new ComboBox();
        _cbo_out.Name = "cbo_out_" + rule_index.ToString();
        _cbo_out.Font = f_reg;
        _cbo_out.Size = new Size(CBO_WIDTH, CBO_HEIGHT);
        _cbo_out.Location = new Point(CBO_OUT_LEFT,
                                    CBO_TOP + (CBO_HEIGHT * rule_index));
        _cbo_out.DropDownStyle = ComboBoxStyle.DropDownList;
        parent.Controls.Add(_cbo_out);
      }
    }

    // Use C# destructor syntax for finalization code.
    // This destructor will run only if the Dispose method 
    // does not get called.
    // It gives your base class the opportunity to finalize.
    // Do not provide destructors in types derived from this class.
    ~FuzzyRule()      
    {
        // Do not re-create Dispose clean-up code here.
        // Calling Dispose(false) is optimal in terms of
        // readability and maintainability.
        Dispose(false);
    }
    #endregion

    #region EventHandler
    /******************************************************************************/
    private void _cbo_pos_SelectedIndexChanged(object sender, EventArgs e)
    {
      _pos_select_idx = _cbo_pos.SelectedIndex;
      // Since cbo DataSource ValueMember is CboSelector.Idx which is type int...
      _handler(0, _rule_index, (int)_cbo_pos.SelectedValue);
    }
    private void _cbo_spd_SelectedIndexChanged(object sender, EventArgs e)
    {
      _spd_select_idx = _cbo_spd.SelectedIndex;
      _handler(1, _rule_index, (int)_cbo_spd.SelectedValue); 
    }
    private void _cbo_out_SelectedIndexChanged(object sender, EventArgs e)
    {
      _out_select_idx = _cbo_out.SelectedIndex;
      _handler(2, _rule_index, (int)_cbo_out.SelectedValue);
    }
    #endregion

    #region Public Methods
    /******************************************************************************/
    public void Build()
    {
      // Remove combobox SelectedIndexChanged handlers to prevent events during setup
      _cbo_pos.SelectedIndexChanged -= new EventHandler(_cbo_pos_SelectedIndexChanged);
      _cbo_spd.SelectedIndexChanged -= new EventHandler(_cbo_spd_SelectedIndexChanged);
      _cbo_out.SelectedIndexChanged -= new EventHandler(_cbo_out_SelectedIndexChanged);

      _cbo_pos.DataSource = null;
      _cbo_pos.SelectedIndex = -1;
      _cbo_pos.Items.Clear();
      _cbo_spd.DataSource = null;
      _cbo_spd.SelectedIndex = -1;
      _cbo_spd.Items.Clear();
      _cbo_out.DataSource = null;
      _cbo_out.SelectedIndex = -1;
      _cbo_out.Items.Clear();

      if(_pos_select_list.Count > 0)
      {
        _cbo_pos.DataSource = _pos_select_list;
        _cbo_pos.DisplayMember = "Description";
        _cbo_pos.ValueMember = "Idx";
        if(_pos_select_idx >= 0 && _pos_select_idx < _pos_select_list.Count)
          _cbo_pos.SelectedIndex = _pos_select_idx;
      }

      if(_spd_select_list.Count > 0)
      {
        _cbo_spd.DataSource = _spd_select_list;
        _cbo_spd.DisplayMember = "Description";
        _cbo_spd.ValueMember = "Idx";
        if(_spd_select_idx >= 0 && _spd_select_idx < _spd_select_list.Count)
          _cbo_spd.SelectedIndex = _spd_select_idx;
      }

      if(_out_select_list.Count > 0)
      {
        _cbo_out.DataSource = _out_select_list;
        _cbo_out.DisplayMember = "Description";
        _cbo_out.ValueMember = "Idx";
        if(_out_select_idx >= 0 && _out_select_idx < _out_select_list.Count)
          _cbo_out.SelectedIndex = _out_select_idx;
      }

      _cbo_pos.SelectedIndexChanged += new EventHandler(_cbo_pos_SelectedIndexChanged);
      _cbo_spd.SelectedIndexChanged += new EventHandler(_cbo_spd_SelectedIndexChanged);
      _cbo_out.SelectedIndexChanged += new EventHandler(_cbo_out_SelectedIndexChanged);
    }

    // Implement IDisposable.
    public void Dispose()
    {
      Dispose(true);
      // This object will be cleaned up by the Dispose method.
      // Therefore, you should call GC.SupressFinalize to
      // take this object off the finalization queue 
      // and prevent finalization code for this object
      // from executing a second time.
      GC.SuppressFinalize(this);
    }

    // Dispose(bool disposing) executes in two distinct scenarios.
    // If disposing equals true, the method has been called directly
    // or indirectly by a user's code. Managed and unmanaged resources
    // can be disposed.
    // If disposing equals false, the method has been called by the 
    // runtime from inside the finalizer and you should not reference 
    // other objects. Only unmanaged resources can be disposed.
    private void Dispose(bool disposing)
    {
      // Check to see if Dispose has already been called.
      if(!this.disposed)
      {
        // If disposing equals true, dispose all managed 
        // and unmanaged resources.
        if(disposing)
        {
          // Dispose managed resources.
          _cbo_pos.Dispose();
          _cbo_spd.Dispose();
          _cbo_out.Dispose();
          _label_if.Dispose();
          _label_and.Dispose();
          _label_then.Dispose();
        }
        // Call the appropriate methods to clean up 
        // unmanaged resources here.
        // If disposing is false, 
        // only the following code is executed.
      }
      disposed = true;
    }
    #endregion
  }
}
