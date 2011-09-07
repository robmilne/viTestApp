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
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using viServoMaster;
using System.Text;
using System.Text.RegularExpressions;
#endregion

namespace viTestApp
{
  public partial class MainForm : Form
  {
    #region Public Enumerations
    /******************************************************************************/
    public enum MemFuncType
    {
      POS,
      SPD,
      OUT
    };
    #endregion

    #region Private Functions
    /******************************************************************************/
    private void CtlPtsActive(bool is_active)
    {
      if(_fuzzy_mem_funcs_obj != null)
      {
        string str;

        tbxPosErrCtlPtA.Enabled = is_active;
        tbxPosErrCtlPtB.Enabled = is_active;
        tbxSpdCtlPtA.Enabled = is_active;
        tbxSpdCtlPtB.Enabled = is_active;
        tbxPosOutCtlPtA.Enabled = is_active;
        tbxPosOutCtlPtB.Enabled = is_active;
        _fuzzy_mem_funcs_obj.CtlPtsActive = !is_active;

        // Convert FuzzyMemFunc objects to Ctl points
        // ..this will destroy custom settings - user must restore from target to undo this action
        _update_flag = true;

        // Derive PosErr Ctl points from bytes 4 and 1 of PosMembershipFunctionArray
        if(tbxPosErrCtlPtA != null)
        {
          if(is_active)
          {
            str = _fuzzy_mem_funcs_obj.PosMembershipFunctionArray[4].ToString("X2");
          }
          else
          {
            str = string.Empty;
          }
          SetText(tbxPosErrCtlPtA, str);
        }
        if(tbxPosErrCtlPtB != null)
        {
          if(is_active)
          {
            str = _fuzzy_mem_funcs_obj.PosMembershipFunctionArray[1].ToString("X2");
          }
          else
          {
            str = string.Empty;
          }
          SetText(tbxPosErrCtlPtB, str);
        }
        // Derive Change Ctl points from bytes 4 and 1 of SpdMembershipFunctionArray
        if(tbxSpdCtlPtA != null)
        {
          if(is_active)
          {
            str = _fuzzy_mem_funcs_obj.SpdMembershipFunctionArray[4].ToString("X2");
          }
          else
          {
            str = string.Empty;
          }
          SetText(tbxSpdCtlPtA, str);
        }
        if(tbxSpdCtlPtB != null)
        {
          if(is_active)
          {
            str = _fuzzy_mem_funcs_obj.SpdMembershipFunctionArray[1].ToString("X2");
          }
          else
          {
            str = string.Empty;
          }
          SetText(tbxSpdCtlPtB, str);
        }
        // Derive Output Ctl points from bytes 0 and 1 of OutSingletonArray
        if(tbxPosOutCtlPtA != null)
        {
          if(is_active)
          {
            str = _fuzzy_mem_funcs_obj.OutSingletonArray[0].ToString("X2");
          }
          else
          {
            str = string.Empty;
          }
          SetText(tbxPosOutCtlPtA, str);
        }
        if(tbxPosOutCtlPtB != null)
        {
          if(is_active)
          {
            str = _fuzzy_mem_funcs_obj.OutSingletonArray[1].ToString("X2");
          }
          else
          {
            str = string.Empty;
          }
          SetText(tbxPosOutCtlPtB, str);
        }

        _update_flag = false;
      }
    }

    /// <summary>
    /// Function to build fuzzy arrays from control points
    /// </summary>
    private string SetMembershipFunction(MemFuncType type, string pt_a_str, string pt_b_str)
    {
      // Trapezoidal Fuzzy Membership functions for position servo
      // ..4bytes -> point_1, point_2, slope_1, slope_2
      // ..Based on 0xFF x 0xFF x-y plot where point_1 and 2 are the x positions
      // ..slope_1 = (0xFF/(x-position-of-saturation - point_1))
      // ..slope_2 = (0xFF/(point_2 - x-position-of-saturation))
      // ..zero slope at point_1 means starts at grade of 0xFF
      // ..zero slope at point_2 means ends at grade of 0xFF
      int ctlPointA, ctlPointB = 0;
      bool singleCtlPt = true;
      if(pt_a_str.Length > 0 && pt_a_str.Length <= 2)
      {
        // Validate text string from control point text box
        try
        {
          ctlPointA = Convert.ToInt32(pt_a_str, 16);
          if(ctlPointA < 0 || ctlPointA >= 0x80)
          {
            return "Invalid CtlPtA\n";
          }
        }
        catch(System.FormatException format_exception)
        {
          return "Invalid CtlPtA " + format_exception.ToString();
        }
        catch(Exception exception)
        {
          return exception.ToString() + "\n";
        }
      }
      else
      {
        return "Invalid CtlPtA\n";
      }

      if(pt_b_str.Length > 0)
      {
        if(pt_b_str.Length <= 2)
        {
          // Validate text string from control point text box
          try
          {
            ctlPointB = Convert.ToInt32(pt_b_str, 16);
            if(ctlPointB < 0 || ctlPointB >= 0x80)
            {
              return "Invalid CtlPtB\n";
            }
            singleCtlPt = false;
          }
          catch(System.FormatException format_exception)
          {
            return "Invalid ctlPointB " + format_exception.ToString();
          }
          catch(Exception exception)
          {
            return exception.ToString() + "\n";
          }
        }
        else
        {
          return "Invalid data\n";
        }
      }

      if(!singleCtlPt)
      {
        if(ctlPointA >= ctlPointB)
        {
          return "Invalid CtlPts\n";
        }
      }

      switch(type)
      {
        case MemFuncType.POS:
          if(singleCtlPt)
          {
            return "Missing CtlPtB\n";
          }
          _fuzzy_mem_funcs_obj.PosMembershipFunctionArray = Set5ptMembershipFunction(ctlPointA, ctlPointB);
          break;

        case MemFuncType.SPD:
          if(singleCtlPt)
          {
            return "Missing CtlPtB\n";
          }
          _fuzzy_mem_funcs_obj.SpdMembershipFunctionArray = Set5ptMembershipFunction(ctlPointA, ctlPointB);
          break;

        case MemFuncType.OUT:
          if(singleCtlPt)
          {
            return "Missing CtlPtB\n";
          }
          _fuzzy_mem_funcs_obj.OutSingletonArray = SetOutputMembershipFunction(ctlPointA, ctlPointB);
          break;

        default:
          return "Unknown type\n";
      }
      // Success
      return string.Empty;
    }

    /// <summary>
    /// SetOutputMembershipFunction
    /// Function to create output singleton array from 2 control points
    /// </summary>
    private byte[] SetOutputMembershipFunction(int ctlPointA, int ctlPointB)
    {
      byte negA, negB;
      byte[] table = new byte[Slave.OUT_SNGLTN_SIZE];
      // Middle value (no voltage) is always centre of range
      table[2] = 0x80;

      // Control point A
      table[0] = (byte)ctlPointA;

      negA = (byte)(0xFF - (byte)ctlPointA);
      if(negA < 0xFF)
        // Add one to make output singletons symmetric at 0x80
        negA++;
      table[4] = negA;

      // Control point B
      table[1] = (byte)ctlPointB;
      negB = (byte)(0xFF - (byte)ctlPointB);
      if(negB < 0xFF)
        // Add one to make output singletons symmetric at 0x80
        negB++;
      table[3] = negB;

      return table;
    }

    /// <summary>
    /// Set5ptMembershipFunction
    /// Function to create 5x5 membership function array from 2 control points
    /// </summary>
    private byte[] Set5ptMembershipFunction(int ctlPointA, int ctlPointB)
    {
      byte negA, negB, slopeA, slopeB;
      double slA, slB;

      // Position and Speed membership functions 1&5, 2&4 and 3 are symmetric about centre (0x80)
      byte[] table = new byte[Slave.MF_5_SIZE];
      // func_1 point_1 starts at 0
      table[0] = 0x0;
      // func_2 point_2 & func_4 point_1 at centre
      table[5] = table[12] = 0x80;
      // func_5 point_2 ends at 0xFF
      table[17] = 0xFF;
      // func_2 point_1
      table[4] = (byte)ctlPointA;
      // func_4 point_1 is symmetric about 0x80
      negA = (byte)(0xFF - (byte)ctlPointA);
      if(negA < 0xFF)
        // Add one to make membership rules symmetric at 0x80
        negA++;
      table[13] = negA;
      // func_2 point_2
      table[1] = table[8] = (byte)ctlPointB;
      // func_4 point_2 is symmetric about 0x80
      negB = (byte)(0xFF - (byte)ctlPointB);
      if(negB < 0xFF)
        // Add one to make membership rules symmetric at 0x80
        negB++;
      table[9] = table[16] = negB;

      // func_1 slope_1 & func_5 slope_2
      table[2] = table[19] = 0x0;

      // func_1 slope_2, func_2 slope_1, func_4 slope_2, func_5 slope_1
      // Round to 2 decimal points
      slA = Math.Round((double)(0xFF / (double)(ctlPointB - ctlPointA)), 2);
      slopeA = (byte)(0xFF / (byte)(ctlPointB - ctlPointA));
      // Add one to normalize slope if fractional component (integer math truncates)
      if((slA - (double)slopeA > 0.0) && slopeA < 0xFF)
        slopeA++;
      table[3] = table[6] = table[15] = table[18] = slopeA;

      // func_2 slope_2, func_3 slope_1, func_3 slope_2, func_4 slope_1
      // Round to 2 decimal points
      slB = Math.Round((double)(0xFF / (double)(0x80 - ctlPointB)), 2);
      slopeB = (byte)(0xFF / (byte)(0x80 - ctlPointB));
      // Add one to normalize slope if fractional component (integer math truncates)
      if((slB - (double)slopeB > 0.0) && slopeB < 0xFF)
        slopeB++;
      table[7] = table[10] = table[11] = table[14] = slopeB;
      return table;
    }

    #endregion

    #region Fuzzy Tuning Events
    /******************************************************************************/
    /// <summary>
    /// btnSetRules_Click - Set/Get fuzzy rules to/from slave
    /// </summary>
    private void btnSetRules_Click(object sender, EventArgs e)
    {
      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }

      if(_fuzzy_rules_obj != null) // Need this since IDisposable
      {
        if(_fuzzy_rules_obj.FuzzyPositionRules != null)
        {
          // confirmation dialog
          if(MsgBox.Show(this, "Write Fuzzy Rules?", "Confirm Fuzzy Rule Write", MessageBoxButtons.YesNo) == DialogResult.Yes)
          {
            _active_servo.ServoSlave.Rules = _fuzzy_rules_obj.FuzzyPositionRules;
            string err;
            if(!_active_servo.ServoSlave.SetFuzzyRules(out err))
            {
              MsgBox.Show(this, err);
              Log(LogMsgType.Error, err + "\n");
            }
          }
        }
        else
        {
          MsgBox.Show(this, "Fuzzy Rules Not Set");
        }
      }

    }
    private void btnGetRules_Click(object sender, EventArgs e)
    {
      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }

      if(_fuzzy_rules_obj != null) // Need this since IDisposable
      {
        string err;
        if(_active_servo.ServoSlave.GetFuzzyRules(out err))
        {
          // Build rules
          {
            _fuzzy_rules_obj.FuzzyPositionRules = _active_servo.ServoSlave.Rules;
            _fuzzy_rules_obj.Build();
          }
        }
        else
        {
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err + "\n");
        }
      }
    }

    /// <summary>
    /// btnSetMF_Click - Set/Get membership functions to/from slave
    /// </summary>
    private void btnSetMF_Click(object sender, EventArgs e)
    {
      if(_fuzzy_mem_funcs_obj != null)
      {
        if(_active_servo == null)
        {
          MsgBox.Show(this, "Select a Node");
          return;
        }

        _active_servo.ServoSlave.PosMemFuncArray = _fuzzy_mem_funcs_obj.PosMembershipFunctionArray;
        _active_servo.ServoSlave.SpdMemFuncArray = _fuzzy_mem_funcs_obj.SpdMembershipFunctionArray;
        _active_servo.ServoSlave.OutSingletonArray = _fuzzy_mem_funcs_obj.OutSingletonArray;

        string err;
        if(!_active_servo.ServoSlave.SetFuzzyMemFuncs(out err))
        {
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err + "\n");
        }
      }
    }
    private void btnGetMF_Click(object sender, EventArgs e)
    {
      //FillMemFuncTextBoxes(_active_servo); // Old method
      if(_fuzzy_mem_funcs_obj != null)
      {
        if(_active_servo == null)
        {
          MsgBox.Show(this, "Select a Node");
          return;
        }

        string err;
        if(!_active_servo.ServoSlave.GetFuzzyMemFuncs(out err))
        {
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err + "\n");
          return;
        }

        if(cbxMemFuncCtlPts.Checked)
        {
          // Disable control points since mem funcs textboxes are populated
          cbxMemFuncCtlPts.CheckState = CheckState.Unchecked;
        }
        _fuzzy_mem_funcs_obj.PosMembershipFunctionArray = _active_servo.ServoSlave.PosMemFuncArray;
        _fuzzy_mem_funcs_obj.SpdMembershipFunctionArray = _active_servo.ServoSlave.SpdMemFuncArray;
        _fuzzy_mem_funcs_obj.OutSingletonArray = _active_servo.ServoSlave.OutSingletonArray;
        _fuzzy_mem_funcs_obj.Build();
      }
    }

    /// <summary>
    /// Use Control points to create symmetric member funcs
    /// </summary>
    private void cbxMemFuncCtlPts_CheckedChanged(object sender, EventArgs e)
    {
      this.CtlPtsActive(cbxMemFuncCtlPts.Checked);
      // Hide ctl pts display on stats page if not used
      gbStatCtlPts.Visible = cbxMemFuncCtlPts.Checked;
    }

    private void tbxPosErrCtlPtA_TextChanged(object sender, EventArgs e)
    {
      if(!_update_flag)
      {
        Regex r = new Regex(@"^[A-Fa-f0-9]{1,2}$");
        string s = r.Match(tbxPosErrCtlPtA.Text).Value;
        if(s.Equals(string.Empty))
        {
          if(_fuzzy_mem_funcs_obj != null)
          {
            tbxPosErrCtlPtA.Text = _fuzzy_mem_funcs_obj.PosMembershipFunctionArray[4].ToString("X2");
          }
          else
          {
            tbxPosErrCtlPtA.Text = string.Empty;
          }
        }
      }
    }
    private void tbxPosErrCtlPtB_TextChanged(object sender, EventArgs e)
    {
      if(!_update_flag)
      {
        Regex r = new Regex(@"^[A-Fa-f0-9]{1,2}$");
        string s = r.Match(tbxPosErrCtlPtB.Text).Value;
        if(s.Equals(string.Empty))
        {
          if(_fuzzy_mem_funcs_obj != null)
          {
            tbxPosErrCtlPtB.Text = _fuzzy_mem_funcs_obj.PosMembershipFunctionArray[1].ToString("X2");
          }
          else
          {
            tbxPosErrCtlPtB.Text = string.Empty;
          }
        }
      }
    }
    public void PosCtlPoint_LostFocus(object sender, EventArgs e)
    {
      if(_fuzzy_mem_funcs_obj != null)
      {
        string ret_str = SetMembershipFunction(MemFuncType.POS, tbxPosErrCtlPtA.Text.Trim(), tbxPosErrCtlPtB.Text.Trim());
        if(ret_str.Length > 0)
        {
          MsgBox.Show(ret_str);
          Log(LogMsgType.Error, ret_str);
          _update_flag = true;
          tbxPosErrCtlPtA.Text = _fuzzy_mem_funcs_obj.PosMembershipFunctionArray[4].ToString("X2");
          tbxPosErrCtlPtB.Text = _fuzzy_mem_funcs_obj.PosMembershipFunctionArray[1].ToString("X2");
          _update_flag = false;
        }
        else
        {
          _fuzzy_mem_funcs_obj.Build();
        }
      }
    }

    private void tbxSpdCtlPtA_TextChanged(object sender, EventArgs e)
    {
      if(!_update_flag)
      {
        Regex r = new Regex(@"^[A-Fa-f0-9]{1,2}$");
        string s = r.Match(tbxSpdCtlPtA.Text).Value;
        if(s.Equals(string.Empty))
        {
          if(_fuzzy_mem_funcs_obj != null)
          {
            tbxSpdCtlPtA.Text = _fuzzy_mem_funcs_obj.SpdMembershipFunctionArray[4].ToString("X2");
          }
          else
          {
            tbxSpdCtlPtA.Text = string.Empty;
          }
        }
      }
    }
    private void tbxSpdCtlPtB_TextChanged(object sender, EventArgs e)
    {
      if(!_update_flag)
      {
        Regex r = new Regex(@"^[A-Fa-f0-9]{1,2}$");
        string s = r.Match(tbxSpdCtlPtB.Text).Value;
        if(s.Equals(string.Empty))
        {
          if(_fuzzy_mem_funcs_obj != null)
          {
            tbxSpdCtlPtB.Text = _fuzzy_mem_funcs_obj.SpdMembershipFunctionArray[1].ToString("X2");
          }
          else
          {
            tbxSpdCtlPtB.Text = string.Empty;
          }
        }
      }
    }
    public void SpdCtlPoint_LostFocus(object sender, EventArgs e)
    {
      if(_fuzzy_mem_funcs_obj != null)
      {
        string ret_str = SetMembershipFunction(MemFuncType.SPD, tbxSpdCtlPtA.Text.Trim(), tbxSpdCtlPtB.Text.Trim());
        if(ret_str.Length > 0)
        {
          MsgBox.Show(ret_str);
          Log(LogMsgType.Error, ret_str);
          _update_flag = true;
          tbxSpdCtlPtA.Text = _fuzzy_mem_funcs_obj.SpdMembershipFunctionArray[4].ToString("X2");
          tbxSpdCtlPtB.Text = _fuzzy_mem_funcs_obj.SpdMembershipFunctionArray[1].ToString("X2");
          _update_flag = false;
        }
        else
        {
          _fuzzy_mem_funcs_obj.Build();
        }
      }
    }

    private void tbxPosOutCtlPtA_TextChanged(object sender, EventArgs e)
    {
      if(!_update_flag)
      {
        Regex r = new Regex(@"^[A-Fa-f0-9]{1,2}$");
        string s = r.Match(tbxPosOutCtlPtA.Text).Value;
        if(s.Equals(string.Empty))
        {
          if(_fuzzy_mem_funcs_obj != null)
          {
            tbxPosOutCtlPtA.Text = _fuzzy_mem_funcs_obj.OutSingletonArray[0].ToString("X2");
          }
          else
          {
            tbxPosOutCtlPtA.Text = string.Empty;
          }
        }
      }
    }
    private void tbxPosOutCtlPtB_TextChanged(object sender, EventArgs e)
    {
      if(!_update_flag)
      {
        Regex r = new Regex(@"^[A-Fa-f0-9]{1,2}$");
        string s = r.Match(tbxPosOutCtlPtB.Text).Value;
        if(s.Equals(string.Empty))
        {
          if(_fuzzy_mem_funcs_obj != null)
          {
            tbxPosOutCtlPtB.Text = _fuzzy_mem_funcs_obj.OutSingletonArray[1].ToString("X2");
          }
          else
          {
            tbxPosOutCtlPtB.Text = string.Empty;
          }
        }
      }
    }
    public void OutCtlPoint_LostFocus(object sender, EventArgs e)
    {
      if(_fuzzy_mem_funcs_obj != null)
      {
        string ret_str = SetMembershipFunction(MemFuncType.OUT, tbxPosOutCtlPtA.Text.Trim(), tbxPosOutCtlPtB.Text.Trim());
        if(ret_str.Length > 0)
        {
          MsgBox.Show(ret_str);
          Log(LogMsgType.Error, ret_str);
          _update_flag = true;
          tbxPosOutCtlPtA.Text = _fuzzy_mem_funcs_obj.OutSingletonArray[0].ToString("X2");
          tbxPosOutCtlPtB.Text = _fuzzy_mem_funcs_obj.OutSingletonArray[1].ToString("X2");
          _update_flag = false;
        }
        else
        {
          _fuzzy_mem_funcs_obj.Build();
        }
      }
    }
    #endregion
  }
}
