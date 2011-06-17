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
  public class FuzzyRules : IDisposable
  {
    #region Private Variables
    /******************************************************************************/
    // Container object that FuzzyRule objects are dynamically created inside
    private Panel _container = null;

    // Control that allows unfocus of combobox after selection
    private Label _unfocus = null;

    private Slave.PosRules[] _fuzzy_rules = null;

    // Collection of FuzzyRule objects (one per fuzzy rule)
    private Dictionary<int, FuzzyRule> _rules_ht;

    // Track whether Dispose has been called.
    private bool disposed = false;
    #endregion

    #region Public Properties
    /******************************************************************************/
    public Slave.PosRules[] FuzzyPositionRules
    {
      set
      {
        if(value.Length.Equals(Slave.RULES_POS_SIZE))
        {
          _fuzzy_rules = new Slave.PosRules[Slave.RULES_POS_SIZE];
          _fuzzy_rules = value;
        }
      }
      get { return _fuzzy_rules; }
    }
    #endregion

    #region Constructors
    /******************************************************************************/
    public FuzzyRules(Panel container, Label unfocus)
    {
      _container = container;
      _unfocus = unfocus;
      _rules_ht = new Dictionary<int, FuzzyRule>();
    }

    // Use C# destructor syntax for finalization code.
    // This destructor will run only if the Dispose method 
    // does not get called.
    // It gives your base class the opportunity to finalize.
    // Do not provide destructors in types derived from this class.
    ~FuzzyRules()      
    {
        // Do not re-create Dispose clean-up code here.
        // Calling Dispose(false) is optimal in terms of
        // readability and maintainability.
        Dispose(false);
    }
    #endregion

    #region Public Methods
    /******************************************************************************/
    public void Build()
    {
      if(_fuzzy_rules != null)
      {
        int j;
        int k = 0;
        for(int i = 0; i < Slave.RULES_POS_SIZE; i++)
        {
          FuzzyRule rule;
          k = i / 3;
          if(!_rules_ht.ContainsKey(k))
          {
            rule = new FuzzyRule(_container, k, UpdateRules);
            _rules_ht.Add(k, rule);
            // Build unique combobox lists per combobox
            rule.PosSelectList = GetPosSelector();
            rule.SpdSelectList = GetSpdSelector();
            rule.OutSelectList = GetOutSelector();
          }
          else
          {
            rule = _rules_ht[k];
          }
          j = i % 3;
          switch(j)
          {
            // Set index for the combobox list
            case 0:
              rule.PosSelectIdx = (int)_fuzzy_rules[i];
              break;
            case 1:
              rule.SpdSelectIdx = (int)_fuzzy_rules[i] - (int)Slave.PosRulePositions.MAX_POS;
              break;
            case 2:
              rule.OutSelectIdx = (int)_fuzzy_rules[i] - (int)Slave.PosRuleSpeeds.MAX_SPEED; ;
              break;
          }
        }
        if(_rules_ht.Count > k + 1)
        {
          int cnt = _rules_ht.Count;
          for(int i = k + 1; i < cnt; i++)
          {
            FuzzyRule rule = _rules_ht[i];
            rule.Dispose();
            _rules_ht.Remove(i);
          }
        }

        // Programmatically build combobox rule triad (vertical position set by hash key)
        Dictionary<int, FuzzyRule>.ValueCollection valueColl = _rules_ht.Values;
        foreach(FuzzyRule rule in valueColl)
        {
          rule.Build();
        }
      }
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
          if(_rules_ht.Count > 0)
          {
            for(int i = 0; i < _rules_ht.Count; i++)
            {
              FuzzyRule rule = _rules_ht[i];
              rule.Dispose();
              rule = null;
            }
            _rules_ht.Clear();
            _rules_ht = null;
            _fuzzy_rules = null;
          }
        }
        // Call the appropriate methods to clean up 
        // unmanaged resources here.
        // If disposing is false, 
        // only the following code is executed.
      }
      disposed = true;
    }
    #endregion

    #region Private Methods
    /******************************************************************************/
    private void UpdateRules(int column, int row, int selection)
    {
      // Move focus from combobox to hidden label
      _unfocus.Focus();
      //MsgBox.Show("col:" + column.ToString() + " row:" + row.ToString() + " selection:" + selection.ToString());
      switch(column)
      {
        //Verify that selection is in correct column
        case 0:
          if(selection < (int)Slave.PosRulePositions.NEGLRG ||
             selection > (int)Slave.PosRulePositions.POSLRG)
          {
            MsgBox.Show("invalid pos selection");
            return;
          }
          break;
        case 1:
          if(selection < (int)Slave.PosRuleSpeeds.NEGFST ||
             selection > (int)Slave.PosRuleSpeeds.POSFST)
          {
            MsgBox.Show("invalid spd selection");
            return;
          }
          break;
        case 2:
          if(selection < (int)Slave.PosRuleOutputs.NEGHI ||
             selection > (int)Slave.PosRuleOutputs.POSHI)
          {
            MsgBox.Show("invalid out selection");
            return;
          }
          break;
      }
      // _fuzzy_rules indexed from 0 to 74 (75 total)
      // ..1st element is col:0, row:0 (((0 + 1) * (0 + 1)) - 1) = 0
      // ..last element is col:2, row:24 (((2 + 1) * (24 + 1)) - 1) = 74
      int idx = ((column + 1) * (row + 1)) - 1;
      _fuzzy_rules[idx] = (Slave.PosRules)selection;
    }

    // Unique List<CboSelector> required per each combobox
    private List<CboSelector> GetPosSelector()
    {
      List<CboSelector> _pos_select_list = new List<CboSelector>();
      CboSelector selector;
      // Build position combobox selections
      selector = new CboSelector((int)Slave.PosRulePositions.NEGLRG,
                                 Strings.fuzzyPosRuleStrings[(int)Slave.PosRulePositions.NEGLRG]);
      _pos_select_list.Add(selector);
      selector = new CboSelector((int)Slave.PosRulePositions.NEGSML,
                                 Strings.fuzzyPosRuleStrings[(int)Slave.PosRulePositions.NEGSML]);
      _pos_select_list.Add(selector);
      selector = new CboSelector((int)Slave.PosRulePositions.OK,
                                 Strings.fuzzyPosRuleStrings[(int)Slave.PosRulePositions.OK]);
      _pos_select_list.Add(selector);
      selector = new CboSelector((int)Slave.PosRulePositions.POSSML,
                                 Strings.fuzzyPosRuleStrings[(int)Slave.PosRulePositions.POSSML]);
      _pos_select_list.Add(selector);
      selector = new CboSelector((int)Slave.PosRulePositions.POSLRG,
                                 Strings.fuzzyPosRuleStrings[(int)Slave.PosRulePositions.POSLRG]);
      _pos_select_list.Add(selector);

      return _pos_select_list;
    }

    private List<CboSelector> GetSpdSelector()
    {
      List<CboSelector> _spd_select_list = new List<CboSelector>();
      CboSelector selector;
      // Build speed combobox selections
      selector = new CboSelector((int)Slave.PosRuleSpeeds.NEGFST,
                                 Strings.fuzzyPosRuleStrings[(int)Slave.PosRuleSpeeds.NEGFST]);
      _spd_select_list.Add(selector);
      selector = new CboSelector((int)Slave.PosRuleSpeeds.NEGSLW,
                                 Strings.fuzzyPosRuleStrings[(int)Slave.PosRuleSpeeds.NEGSLW]);
      _spd_select_list.Add(selector);
      selector = new CboSelector((int)Slave.PosRuleSpeeds.SAME,
                                 Strings.fuzzyPosRuleStrings[(int)Slave.PosRuleSpeeds.SAME]);
      _spd_select_list.Add(selector);
      selector = new CboSelector((int)Slave.PosRuleSpeeds.POSSLW,
                                 Strings.fuzzyPosRuleStrings[(int)Slave.PosRuleSpeeds.POSSLW]);
      _spd_select_list.Add(selector);
      selector = new CboSelector((int)Slave.PosRuleSpeeds.POSFST,
                                 Strings.fuzzyPosRuleStrings[(int)Slave.PosRuleSpeeds.POSFST]);
      _spd_select_list.Add(selector);

      return _spd_select_list;
    }

    private List<CboSelector> GetOutSelector()
    {
      List<CboSelector> _out_select_list = new List<CboSelector>();
      CboSelector selector;
      // Build output combobox selections
      selector = new CboSelector((int)Slave.PosRuleOutputs.NEGHI,
                                 Strings.fuzzyPosRuleStrings[(int)Slave.PosRuleOutputs.NEGHI]);
      _out_select_list.Add(selector);
      selector = new CboSelector((int)Slave.PosRuleOutputs.NEGLO,
                                 Strings.fuzzyPosRuleStrings[(int)Slave.PosRuleOutputs.NEGLO]);
      _out_select_list.Add(selector);
      selector = new CboSelector((int)Slave.PosRuleOutputs.ZERO,
                                 Strings.fuzzyPosRuleStrings[(int)Slave.PosRuleOutputs.ZERO]);
      _out_select_list.Add(selector);
      selector = new CboSelector((int)Slave.PosRuleOutputs.POSLO,
                                 Strings.fuzzyPosRuleStrings[(int)Slave.PosRuleOutputs.POSLO]);
      _out_select_list.Add(selector);
      selector = new CboSelector((int)Slave.PosRuleOutputs.POSHI,
                                 Strings.fuzzyPosRuleStrings[(int)Slave.PosRuleOutputs.POSHI]);
      _out_select_list.Add(selector);

      return _out_select_list;
    }
    #endregion
  }
}
