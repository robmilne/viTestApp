/*
 * Project:   viTestApp
 * Company:   Vera Ikona, http://vera-ikona.com
 * Author:    Robert Milne
 * Created:   June 2011
 *
 * Notes:
 */
#region Namespace Inclusions
/******************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using viServoMaster;
using System.Threading;
#endregion

namespace viTestApp
{
  public partial class MainForm : Form
  {
    #region Public Enumerations
    /******************************************************************************/
    #endregion

    #region Private Variables
    /******************************************************************************/
    #endregion

    #region Helper Methods
    /******************************************************************************/
    private Slave.MoveModes GetMotionMode()
    {
      if(rbMotionStartPos.Checked)
        return Slave.MoveModes.SRV_POSITION_MODE;
      else if(rbMotionStartVel.Checked)
        return Slave.MoveModes.SRV_VELOCITY_MODE;
      else if(rbMotionStartTrapezoidal.Checked)
        return Slave.MoveModes.SRV_TRAPEZOIDAL_MODE;
      else if(rbMotionStartPwm.Checked)
        return Slave.MoveModes.SRV_PWM_MODE;
      else if(rbMotionStartPwmLim.Checked)
        return Slave.MoveModes.SRV_PWM_POS_MODE;
      //rbMotionStartZero.Checked)
      else
      {
        // invalid move mode used to signal move to zero position (group OK)
        // Slave will not move if zero not explicitly set
        return Slave.MoveModes.SRV_NO_INIT_MODE;
      }
    }
    public void StartGroupMotion()
    {
      string err;
      if(!_group.MoveCtlStart(GetMotionMode(), out err))
      {
        MsgBox.Show(this, err);
        Log(LogMsgType.Error, err + "\n");
      }
    }
    public void HaltGroup()
    {
      string err;
      if(!_group.MoveCtlStop(rbTestMotionStopHard.Checked, out err))
      {
        MsgBox.Show(this, err);
        Log(LogMsgType.Error, err + "\n");
      }
    }
    public void HaltSlave(Slave slave, bool hard_stop)
    {
      bool hs = hard_stop;
      if(!hs)
      {
        // Let interface decide type of stop
        if(rbTestMotionStopHard.Checked)
          hs = true;
      }

      string err;
      if(!slave.MoveCtlStop(hs, out err))
      {
        MsgBox.Show(this, err);
        Log(LogMsgType.Error, err + "\n");
      }
    }

    private void btnStatusCmd(bool write)
    {
      string err = string.Empty;

      // Write according to UI checkboxes
      if(write)
      {
        _active_servo.ServoSlave.FlagIRQErr = cbxStatIrqErr.Checked;
        _active_servo.ServoSlave.FlagLimErr = cbxStatLimErr.Checked;
        _active_servo.ServoSlave.FlagSysErr = cbxStatSysErr.Checked;
        _active_servo.ServoSlave.FlagCANErr = cbxStatCANErr.Checked;
        _active_servo.ServoSlave.FlagPosErr = cbxStatPosErr.Checked;
        _active_servo.ServoSlave.FlagATDErr = cbxStatATDErr.Checked;
        // Write StatusCommand object of this slave
        if(!_active_servo.ServoSlave.StatusReadWriteAll(true, out err))
        {
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err + "\n");
        }
      }

      // Read StatusCommand object of this slave
      if(!_active_servo.ServoSlave.StatusReadWriteAll(false, out err))
      {
        MsgBox.Show(this, err);
        Log(LogMsgType.Error, err + "\n");
      }

      // Servo state
      SetText(tbxStatServoState, viServoMaster.Strings.ServoStateStrings[(int)_active_servo.ServoSlave.ServoState]);

      // Sticky error flags (cleared by write to status cmd)
      SetCheckbox(cbxStatIrqErr, _active_servo.ServoSlave.FlagIRQErr);
      SetCheckbox(cbxStatLimErr, _active_servo.ServoSlave.FlagLimErr);
      SetCheckbox(cbxStatSysErr, _active_servo.ServoSlave.FlagSysErr);
      SetCheckbox(cbxStatCANErr, _active_servo.ServoSlave.FlagCANErr);
      SetCheckbox(cbxStatPosErr, _active_servo.ServoSlave.FlagPosErr);
      SetCheckbox(cbxStatATDErr, _active_servo.ServoSlave.FlagATDErr);
      if(_active_servo.ServoSlave.FlagLimErr)
      {
        lblLimitPos.Visible = true;
        tbxLimitPos.Visible = true;
        SetText(tbxLimitPos, _active_servo.ServoSlave.LimitPosition.ToString());
      }
      else
      {
        lblLimitPos.Visible = false;
        tbxLimitPos.Visible = false;
      }

      // system error code (0 = SUCCESS)
      short err_code;
      string err_str;
      if(_active_servo.ServoSlave.Errcode < 0)
      {
        err_str = "-0x";
        err_code = (short)-_active_servo.ServoSlave.Errcode;
        Log(LogMsgType.Error, "Read Status Sys Err: " + Strings.GetErrorString(_active_servo.ServoSlave.Errcode) + "\n");
      }
      else
      {
        err_str = "0x";
        err_code = _active_servo.ServoSlave.Errcode;
      }
      SetText(tbxStatErrCode, err_str + err_code.ToString("X4"));

      // Current servo position
      SetText(tbxStatCurPos, _active_servo.ServoSlave.CurrentPosition.ToString());

      // Current servo velocity and stored peak velocity/acceleration
      SetText(tbxStatCurVel, _active_servo.ServoSlave.CurrentVelocity.ToString());
      SetText(tbxStatPeakVel, _active_servo.ServoSlave.PeakChange.ToString());
      SetText(tbxStatPeakAcc, _active_servo.ServoSlave.PeakChangeChange.ToString());

      // Limit pin states and values
      SetText(tbxStatLimAVal, (_active_servo.ServoSlave.IsLimitAPinSet ? "1" : "0"));
      SetText(tbxStatLimBVal, (_active_servo.ServoSlave.IsLimitBPinSet ? "1" : "0"));
      SetText(tbxStatEncIdxVal, (_active_servo.ServoSlave.IsLimitEncPinSet ? "1" : "0"));
      SetCheckbox(cbxStatLimA, _active_servo.ServoSlave.IsLimitASet);
      SetCheckbox(cbxStatLimB, _active_servo.ServoSlave.IsLimitBSet);
      SetCheckbox(cbxStatEncIdx, _active_servo.ServoSlave.IsLimitEncSet);

      // Current ATD value
      SetText(tbxStatATDVal, _active_servo.ServoSlave.CurrentATDValue.ToString());
    }
    #endregion

    #region Status Control Events
    /******************************************************************************/
    /// <summary>
    /// btnStatusRead_Click - Send the 'Read' status command
    /// </summary>
    private void btnStatusRead_Click(object sender, EventArgs e)
    {
      if(_active_servo != null)
      {
        btnStatusCmd(false);
      }
      else
      {
        MsgBox.Show(this, "Select a Node");
      }
    }

    /// <summary>
    /// btnStatusWrite_Click - Write to sticky bits to clear
    /// </summary>
    private void btnStatusWrite_Click(object sender, EventArgs e)
    {
      if(_active_servo != null)
      {
        btnStatusCmd(true);
      }
      else
      {
        MsgBox.Show(this, "Select a Node");
      }
    }

    /// <summary>
    /// btnSetEncZero_Click - Set Servo zero in slave and update position status with read
    /// </summary>
    private void btnSetEncZero_Click(object sender, EventArgs e)
    {
      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }

      string err;
      if(!_active_servo.ServoSlave.ZeroSlave(out err))
      {
        MsgBox.Show(this, err);
        Log(LogMsgType.Error, err + "\n");
        return;
      }
    }
    #endregion

    #region Servo Control Events
    /******************************************************************************/
    /// <summary>
    /// btnServoCtlSave_Click - Set servo controls in slave
    /// </summary>
    private void btnServoCtlSave_Click(object sender, EventArgs e)
    {
      Slave.ServoRates rate = Slave.ServoRates.MAX_SERVO_RATE;
      Slave.HBridges hbridge = Slave.HBridges.MAX_SERVO_HBRIDGE;
      Slave.PWMRate hb_pwm = Slave.PWMRate.MAX_SERVO_PWM_RATE;
      Slave.EncoderDivider enc_div = Slave.EncoderDivider.MAX_EVT_COUNT_DIV;
      Slave.GpioStates gpio_state = Slave.GpioStates.MAX_GPIO_STATE;

      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }

      StringBuilder err_sb = new StringBuilder("Servo Control Write Error\n");
      bool err = false;
      if(cboSetServoRate.SelectedIndex == -1)
      {
        err_sb.Append("\nSelect a Servo Rate");
        err = true;
      }
      else
      {
        // Add 4 for uninitialized vals
        rate = (Slave.ServoRates)cboSetServoRate.SelectedIndex + 4;
      }

      if(cboSetHBridge.SelectedIndex == -1)
      {
        err_sb.Append("\nSelect a h-bridge");
        err = true;
      }
      else
      {
        // Add 1 for first uninitialized val
        hbridge = (Slave.HBridges)cboSetHBridge.SelectedIndex + 1;
      }
      if(cboSetPWMRate.SelectedIndex == -1)
      {
        err_sb.Append("\nSelect a h-bridge pwm");
        err = true;
      }
      else
      {
        // Add 1 for first uninitialized val
        hb_pwm = (Slave.PWMRate)cboSetPWMRate.SelectedIndex + 1;
      }

      if(cboSetEncDiv.SelectedIndex == -1)
      {
        err_sb.Append("\nSelect an encoder divide value");
        err = true;
      }
      else
      {
        enc_div = (Slave.EncoderDivider)cboSetEncDiv.SelectedIndex;
      }

      if(cbxGpioEnOut.Checked)
      {
        if(cbxGpioSuspendToggle.Checked)
        {
          gpio_state = rbSetGPIOHi.Checked ? Slave.GpioStates.OUTPUT_HI_SUSPEND_TOGGLE : Slave.GpioStates.OUTPUT_LO_SUSPEND_TOGGLE;
        }
        else
        {
          gpio_state = rbSetGPIOHi.Checked ? Slave.GpioStates.OUTPUT_HI : Slave.GpioStates.OUTPUT_LO;
        }
      }
      else
      {
        gpio_state = rbSetGPIOHi.Checked ? Slave.GpioStates.INPUT_HI : Slave.GpioStates.INPUT_LO;
      }

      if(err)
      {
        MsgBox.Show(this, err_sb.ToString());
      }
      else
      {
        // Execute Slave object of this slave
        string err_str;
        if(!_active_servo.ServoSlave.ServoCtlWrite(rate, hbridge, hb_pwm, enc_div,
                                                 rbSetKickOn.Checked, 
                                                 rbSetPowerOff.Checked,
                                                 gpio_state, out err_str))
        {
          MsgBox.Show(this, err_str);
        }
      }
    }

    /// <summary>
    /// btnServoCtlLoad_Click - Get servo controls from slave
    /// </summary>
    private void btnServoCtlLoad_Click(object sender, EventArgs e)
    {
      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }

      string err;
      if(_active_servo.ServoSlave.ServoCtlRead(out err))
      {
        StringBuilder err_sb = new StringBuilder("Servo Control Load Error\n");
        bool err_flag = false;

        if((int)_active_servo.ServoSlave.ServoRate > 1)
        {
          // Subtract 4 for non-init rates
          SetComboBox(cboSetServoRate, (int)(_active_servo.ServoSlave.ServoRate - 4));
        }
        else
        {
          err_sb.Append("\nServo rate not initialized");
          err_flag = true;
        }

        if((int)_active_servo.ServoSlave.HBridge > 0)
        {
          // Subtract 1 for non-init values
          SetComboBox(cboSetHBridge, (int)(_active_servo.ServoSlave.HBridge - 1));
        }
        else
        {
          err_sb.Append("\nH-Bridge rate not initialized");
          err_flag = true;
        }

        if((int)_active_servo.ServoSlave.HbPwmRate > 0)
        {
          SetComboBox(cboSetPWMRate, (int)(_active_servo.ServoSlave.HbPwmRate - 1));
        }
        else
        {
          err_sb.Append("\nPWM rate not initialized");
          err_flag = true;
        }

        // Add one to returned EncDiv value since zero value is actually divide by 1 
        SetComboBox(cboSetEncDiv, (int)(_active_servo.ServoSlave.EncDiv + 1));

        SetRadioButton(rbSetKickOn, _active_servo.ServoSlave.KickEnable);
        SetRadioButton(rbSetKickOff, !_active_servo.ServoSlave.KickEnable);

        SetRadioButton(rbSetPowerOff, _active_servo.ServoSlave.PwrDoneEnable);
        SetRadioButton(rbSetPowerOn, !_active_servo.ServoSlave.PwrDoneEnable);

        Slave.GpioStates gpio_state = _active_servo.ServoSlave.GpioState;
        switch(gpio_state)
        {
          case Slave.GpioStates.OUTPUT_LO:
            SetCheckbox(cbxGpioEnOut, true);
            SetCheckbox(cbxGpioSuspendToggle, false);
            SetRadioButton(rbSetGPIOLo, true);
            break;
          case Slave.GpioStates.OUTPUT_HI:
            SetCheckbox(cbxGpioEnOut, true);
            SetCheckbox(cbxGpioSuspendToggle, false);
            SetRadioButton(rbSetGPIOHi, true);
            break;
          case Slave.GpioStates.OUTPUT_LO_SUSPEND_TOGGLE:
            SetCheckbox(cbxGpioEnOut, true);
            SetCheckbox(cbxGpioSuspendToggle, true);
            SetRadioButton(rbSetGPIOLo, true);
            break;
          case Slave.GpioStates.OUTPUT_HI_SUSPEND_TOGGLE:
            SetCheckbox(cbxGpioEnOut, true);
            SetCheckbox(cbxGpioSuspendToggle, true);
            SetRadioButton(rbSetGPIOHi, true);
            break;
          case Slave.GpioStates.INPUT_LO:
            SetCheckbox(cbxGpioEnOut, false);
            SetCheckbox(cbxGpioSuspendToggle, false);
            SetRadioButton(rbSetGPIOLo, true);
            break;
          case Slave.GpioStates.INPUT_HI:
            SetCheckbox(cbxGpioEnOut, false);
            SetCheckbox(cbxGpioSuspendToggle, false);
            SetRadioButton(rbSetGPIOHi, true);
            break;
        }

        if(err_flag)
        {
          //MsgBox.Show(err_sb.ToString(), "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          MsgBox.Show(err_sb.ToString(), "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      else
      {
        MsgBox.Show(this, err);
        Log(LogMsgType.Error, err + "\n");
      }
    }

    private void cbxGpioEnOut_CheckedChanged(object sender, EventArgs e)
    {
      cbxGpioSuspendToggle.Visible = cbxGpioEnOut.Checked;
    }
    #endregion

    #region Motion Control Events
    /******************************************************************************/
    /// <summary>
    /// btnTestMotionStop_Click - Set servo halt in slave
    ///                           This control registered as 
    /// </summary>
    private void btnTestMotionStop_Click(object sender, EventArgs e)
    {
      if(cbxGroup.Checked)
      {
        HaltGroup();
        return;
      }
      else if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }
      HaltSlave(_active_servo.ServoSlave, false);
    }

    /// <summary>
    /// btnMotionCtlSave_Click - Set servo motion controls in slave
    /// </summary>
    private void btnMotionCtlSave_Click(object sender, EventArgs e)
    {
      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }
      if(GetMotionMode() == Slave.MoveModes.SRV_NO_INIT_MODE)
      {
        MsgBox.Show(this, "\"Goto Zero\" cannot be selected for this command!");
        return;
      }
      Slave.PwmDir pwm_dir = Slave.PwmDir.OFF;
      if(rbSetPwmInc.Checked)
        pwm_dir = Slave.PwmDir.INC;
      else if(rbSetPwmDec.Checked)
        pwm_dir = Slave.PwmDir.DEC;

      string err;
      if(!_active_servo.ServoSlave.MoveCtlSetAll((int)nudSetPos.Value,
                                                 (int)nudSetVel.Value, 
                                                 (uint)nudSetAcc.Value, 
                                                 pwm_dir,(byte)nudSetPWM.Value,
                                                 (uint)nudHardDecel.Value,
                                                 (cbxMoveCtlGo.Checked ? true : false),
                                                 GetMotionMode(),
                                                 out err))
      {
        MsgBox.Show(this, err);
        Log(LogMsgType.Error, err + "\n");
      }
    }

    /// <summary>
    /// btnMotionCtlLoad_Click - Get servo motion controls from slave
    /// </summary>
    private void btnMotionCtlLoad_Click(object sender, EventArgs e)
    {
      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }
      string err;
      if(!_active_servo.ServoSlave.MoveCtlGetAll(out err))
      {
        MsgBox.Show(this, err);
        Log(LogMsgType.Error, err + "\n");
      }
      else
      {
        // Update controls
        SetText(nudSetPos, _active_servo.ServoSlave.Position.ToString());
        SetText(nudSetVel, _active_servo.ServoSlave.Velocity.ToString());
        SetText(nudSetAcc, _active_servo.ServoSlave.Acceleration.ToString());
        SetText(nudSetPWM, _active_servo.ServoSlave.PwmDuty.ToString());
        SetText(nudHardDecel, _active_servo.ServoSlave.HardStopDeceleration.ToString());
        SetRadioButton(rbSetPwmOff, _active_servo.ServoSlave.PwmDirection.Equals(Slave.PwmDir.OFF));
        SetRadioButton(rbSetPwmInc, _active_servo.ServoSlave.PwmDirection.Equals(Slave.PwmDir.INC));
        SetRadioButton(rbSetPwmDec, _active_servo.ServoSlave.PwmDirection.Equals(Slave.PwmDir.DEC));

        rbMotionStartTrapezoidal.Checked = false;
        rbMotionStartVel.Checked = false;
        rbMotionStartPwm.Checked = false;
        rbMotionStartPos.Checked = false;
        rbMotionStartPwmLim.Checked = false;
        rbMotionStartZero.Checked = false;
        switch(_active_servo.ServoSlave.MoveMode)
        {
          case Slave.MoveModes.SRV_TRAPEZOIDAL_MODE:
            rbMotionStartTrapezoidal.Checked = true;
            break;
          case Slave.MoveModes.SRV_VELOCITY_MODE:
            rbMotionStartVel.Checked = true;
            break;
          case Slave.MoveModes.SRV_PWM_MODE:
            rbMotionStartPwm.Checked = true;
            break;
          case Slave.MoveModes.SRV_PWM_POS_MODE:
            rbMotionStartPwmLim.Checked = true;
            break;
          case Slave.MoveModes.SRV_POSITION_MODE:
            rbMotionStartPos.Checked = true;
            break;
        }
      }
    }

    /// <summary>
    /// rbMotionStart_CheckedChanged - Set motion type for motion buttona
    /// </summary>
    private void rbMotionStart_CheckedChanged(object sender, EventArgs e)
    {
      if(sender is RadioButton)
      {
        RadioButton rb = sender as RadioButton;
        if(rb.Checked)
        {
          if(rb.Name.Equals("rbMotionStartPos") || rb.Name.Equals("rbMotionStartTrapezoidal"))
          {
            btnMotionCtlRevPos.Enabled = true;
            btnMotionCtlDoublePos.Enabled = true;
            btnMotionCtlHalfPos.Enabled = true;
            btnRand.Enabled = true;
          }
          else
          {
            btnMotionCtlRevPos.Enabled = false;
            btnMotionCtlDoublePos.Enabled = false;
            btnMotionCtlHalfPos.Enabled = false;
            btnRand.Enabled = false;
          }
        }
      }
    }
    /// <summary>
    /// btnTestMotionStart_Click - Start servo with selected motion type
    /// </summary>
    private void btnTestMotionStart_Click(object sender, EventArgs e)
    {
      if(cbxGroup.Checked)
      {
        StartGroupMotion();
        return;
      }
      else if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }
      string err;
      if(!_active_servo.ServoSlave.MoveCtlStart(GetMotionMode(), out err))
      {
        MsgBox.Show(this, err);
        Log(LogMsgType.Error, err + "\n");
      }
    }

    /// <summary>
    /// btnMotionCtlRevPos_Click - Test that negates target position in slave and initiates trapezoidal or position move
    /// </summary>
    private void btnMotionCtlRevPos_Click(object sender, EventArgs e)
    {
      Slave.MoveModes mode = GetMotionMode();
      if(mode != Slave.MoveModes.SRV_POSITION_MODE && mode != Slave.MoveModes.SRV_TRAPEZOIDAL_MODE)
        return;

      int pos;
      string err;
      if(cbxGroup.Checked == false)
      {
        if(_active_servo == null)
        {
          MsgBox.Show(this, "Select a Node");
          return;
        }
        if(!_active_servo.ServoSlave.MoveCtlGetPos(out pos, out err))
        {
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err + "\n");
          return;
        }
        // Negate position and write back
        if(!_active_servo.ServoSlave.MoveCtlSetPos(-pos, mode, true, out err))
        {
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err + "\n");
          return;
        }
        else
        {
          nudSetPos.Value = -pos;
        }
      }
      else
      {
        SortedDictionary<byte, Servo>.ValueCollection slaves = _servo_ht.Values;
        foreach(Servo slave in slaves)
        {
          if(!slave.ServoSlave.MoveCtlGetPos(out pos, out err))
          {
            MsgBox.Show(this, err);
            Log(LogMsgType.Error, err + "\n");
            continue;
          }
          // Negate position and write back
          if(!slave.ServoSlave.MoveCtlSetPos(-pos, mode, false, out err))
          {
            MsgBox.Show(this, err);
            Log(LogMsgType.Error, err + "\n");
            continue;
          }
        }
        StartGroupMotion();
      }
    }

    /// <summary>
    /// btnMotionCtlRevPos_Click - Test that doubles target position in slave and initiates trapezoidal or position move
    /// </summary>
    private void btnMotionCtlDoublePos_Click(object sender, EventArgs e)
    {
      Slave.MoveModes mode = GetMotionMode();
      if(mode != Slave.MoveModes.SRV_POSITION_MODE && mode != Slave.MoveModes.SRV_TRAPEZOIDAL_MODE)
        return;

      int pos;
      string err;
      if(cbxGroup.Checked == false)
      {
        if(_active_servo == null)
        {
          MsgBox.Show(this, "Select a Node");
          return;
        }
        if(!_active_servo.ServoSlave.MoveCtlGetPos(out pos, out err))
        {
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err + "\n");
          return;
        }
        // Negate position and write back
        if(!_active_servo.ServoSlave.MoveCtlSetPos(pos * 2, mode, true, out err))
        {
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err + "\n");
          return;
        }
        else
        {
          nudSetPos.Value = pos * 2;
        }
      }
      else
      {
        SortedDictionary<byte, Servo>.ValueCollection slaves = _servo_ht.Values;
        foreach(Servo slave in slaves)
        {
          if(!slave.ServoSlave.MoveCtlGetPos(out pos, out err))
          {
            MsgBox.Show(this, err);
            Log(LogMsgType.Error, err + "\n");
            continue;
          }
          // Negate position and write back
          if(!slave.ServoSlave.MoveCtlSetPos(pos * 2, mode, false, out err))
          {
            MsgBox.Show(this, err);
            Log(LogMsgType.Error, err + "\n");
            continue;
          }
        }
        StartGroupMotion();
      }
    }

    /// <summary>
    /// btnMotionCtlHalfPos_Click - Test that halves target position in slave and initiates trapezoidal or position move
    /// </summary>
    private void btnMotionCtlHalfPos_Click(object sender, EventArgs e)
    {
      Slave.MoveModes mode = GetMotionMode();
      if(mode != Slave.MoveModes.SRV_POSITION_MODE && mode != Slave.MoveModes.SRV_TRAPEZOIDAL_MODE)
        return;

      int pos;
      string err;
      if(cbxGroup.Checked == false)
      {
        if(_active_servo == null)
        {
          MsgBox.Show(this, "Select a Node");
          return;
        }
        if(!_active_servo.ServoSlave.MoveCtlGetPos(out pos, out err))
        {
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err + "\n");
          return;
        }
        // Negate position and write back
        if(!_active_servo.ServoSlave.MoveCtlSetPos(pos / 2, mode, true, out err))
        {
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err + "\n");
          return;
        }
        else
        {
          nudSetPos.Value = pos / 2;
        }
      }
      else
      {
        SortedDictionary<byte, Servo>.ValueCollection slaves = _servo_ht.Values;
        foreach(Servo slave in slaves)
        {
          if(!slave.ServoSlave.MoveCtlGetPos(out pos, out err))
          {
            MsgBox.Show(this, err);
            Log(LogMsgType.Error, err + "\n");
            continue;
          }
          // Negate position and write back
          if(!slave.ServoSlave.MoveCtlSetPos(pos / 2, mode, false, out err))
          {
            MsgBox.Show(this, err);
            Log(LogMsgType.Error, err + "\n");
            continue;
          }
        }
        StartGroupMotion();
      }
    }

    /// <summary>
    /// btnRand_Click - Test that uses the current pos, vel and acc settings as an envelope for 
    ///                 random trapezoidal moves that execute for between .5 and user set seconds
    /// </summary>
    private void btnRand_Click(object sender, EventArgs e)
    {
      string err;

      cbxGroup.Checked = false;

      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }

      // Soft stop
      _active_servo.ServoSlave.MoveCtlStop(false, out err);

      // Get current pos, vel, acc settings - use as envelope
      if(!_active_servo.ServoSlave.MoveCtlGetAll(out err))
      {
        MsgBox.Show(this, err);
        Log(LogMsgType.Error, err + "\n");
        return;
      }

      if(_active_servo.ServoSlave.Position == 0)
      {
        MsgBox.Show(this, "Position not set - travel is between set position and its negative value");
        return;
      }
      if(_active_servo.ServoSlave.Velocity == 0)
      {
        MsgBox.Show(this, "Velocity not set");
        return;
      }
      if(_active_servo.ServoSlave.Acceleration == 0)
      {
        MsgBox.Show(this, "Acceleration not set");
        return;
      }

      RndForm rndForm = new RndForm(_active_servo);
      rndForm.ShowDialog(Form.ActiveForm);
    }

    // Homing to zero is group command
    private void cbxGroup_CheckedChanged(object sender, EventArgs e)
    {
      rbMotionStartZero.Enabled = cbxGroup.Checked;
    }
    #endregion

    #region Limit Control Events
    /******************************************************************************/
    /// <summary>
    /// btnLimitCtlSave_Click - Set servo limit controls in slave
    /// </summary>
    private void btnLimitCtlSave_Click(object sender, EventArgs e)
    {
      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }

      Slave.LimitStruct ls;
      ls = new Slave.LimitStruct(cbxSetLimAEn.Checked,
                                 rbSetLimAValHi.Checked,
                                 rbSetLimAHaltHard.Checked,
                                 cbxSetLimAZero.Checked);
      _active_servo.ServoSlave.LimAStruct = ls;

      ls = new Slave.LimitStruct(cbxSetLimBEn.Checked,
                                 rbSetLimBValHi.Checked,
                                 rbSetLimBHaltHard.Checked,
                                 cbxSetLimBZero.Checked);
      _active_servo.ServoSlave.LimBStruct = ls;

      ls = new Slave.LimitStruct(cbxSetEncIdxEn.Checked,
                                 rbSetEncIdxValHi.Checked,
                                 rbSetEncIdxHaltHard.Checked,
                                 cbxSetEncIdxZero.Checked);
      _active_servo.ServoSlave.LimZStruct = ls;

      _active_servo.ServoSlave.IRQEnable = cbxIRQEn.Checked;
      _active_servo.ServoSlave.IRQStopType = rbIRQhard.Checked;

      _active_servo.ServoSlave.ATDValue = (byte)Convert.ToByte(nudSetAtdLimVal.Text);
      _active_servo.ServoSlave.ATDPeriod = (short)Convert.ToUInt16(nudSetAtdLimDwell.Text);

      string err;
      if(!_active_servo.ServoSlave.LimitCtlWrite(out err))
      {
        MsgBox.Show(this, err);
        Log(LogMsgType.Error, err + "\n");
      }
    }

    /// <summary>
    /// btnLimitCtlLoad_Click
    /// </summary>
    private void btnLimitCtlLoad_Click(object sender, EventArgs e)
    {
      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }
      string err;
      if(!_active_servo.ServoSlave.LimitCtlRead(out err))
      {
        MsgBox.Show(this, err);
        Log(LogMsgType.Error, err + "\n");
      }
      else
      {
        SetCheckbox(cbxSetLimAEn, _active_servo.ServoSlave.LimAStruct.enable);
        SetCheckbox(cbxSetLimBEn, _active_servo.ServoSlave.LimBStruct.enable);
        SetCheckbox(cbxSetEncIdxEn, _active_servo.ServoSlave.LimZStruct.enable);
        SetCheckbox(cbxIRQEn, _active_servo.ServoSlave.IRQEnable);

        SetRadioButton(rbIRQhard, _active_servo.ServoSlave.IRQStopType);
        SetRadioButton(rbIRQsoft, !_active_servo.ServoSlave.IRQStopType);

        SetRadioButton(rbSetLimAValHi, _active_servo.ServoSlave.LimAStruct.pin_state);
        SetRadioButton(rbSetLimAValLo, !_active_servo.ServoSlave.LimAStruct.pin_state);
        SetRadioButton(rbSetLimBValHi, _active_servo.ServoSlave.LimBStruct.pin_state);
        SetRadioButton(rbSetLimBValLo, !_active_servo.ServoSlave.LimBStruct.pin_state);
        SetRadioButton(rbSetEncIdxValHi, _active_servo.ServoSlave.LimZStruct.pin_state);
        SetRadioButton(rbSetEncIdxValLo, !_active_servo.ServoSlave.LimZStruct.pin_state);

        SetRadioButton(rbSetLimAHaltHard, _active_servo.ServoSlave.LimAStruct.hard_stop);
        SetRadioButton(rbSetLimAHaltSoft, !_active_servo.ServoSlave.LimAStruct.hard_stop);
        SetRadioButton(rbSetLimBHaltHard, _active_servo.ServoSlave.LimBStruct.hard_stop);
        SetRadioButton(rbSetLimBHaltSoft, !_active_servo.ServoSlave.LimBStruct.hard_stop);
        SetRadioButton(rbSetEncIdxHaltHard, _active_servo.ServoSlave.LimZStruct.hard_stop);
        SetRadioButton(rbSetEncIdxHaltSoft, !_active_servo.ServoSlave.LimZStruct.hard_stop);

        SetCheckbox(cbxSetLimAZero, _active_servo.ServoSlave.LimAStruct.zero);
        SetCheckbox(cbxSetLimBZero, _active_servo.ServoSlave.LimBStruct.zero);
        SetCheckbox(cbxSetEncIdxZero, _active_servo.ServoSlave.LimZStruct.zero);

        SetText(nudSetAtdLimVal, _active_servo.ServoSlave.ATDValue.ToString());
        SetText(nudSetAtdLimDwell, _active_servo.ServoSlave.ATDPeriod.ToString());
      }
    }
    #endregion

    #region Filesystem Events
    /******************************************************************************/
    private void btnStoreCfg_Click(object sender, EventArgs e)
    {
      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }

      string err;
      if(cbxEeErr.Checked)
      {
        if(!_active_servo.ServoSlave.FileCtlResetErr(out err))
        {
          ClrText(tbxEeErr);
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err + "\n");
        }
        else
        {
          short err_code;
          string err_str;
          if(_active_servo.ServoSlave.Errcode < 0)
          {
            err_str = "-0x";
            err_code = (short)-_active_servo.ServoSlave.FileErrcode;
            Log(LogMsgType.Error, "File Err: " + Strings.GetErrorString(_active_servo.ServoSlave.Errcode) + "\n");
          }
          else
          {
            err_str = "0x";
            err_code = _active_servo.ServoSlave.FileErrcode;
          }
          SetText(tbxEeErr, err_str + err_code.ToString("X4"));
        }
      }
      else
      {
        if(!_active_servo.ServoSlave.FileCtlStoreCfg(out err))
        // Example of single file write
        //if(!_active_servo.ServoSlave.FileCtlStore(Slave.FileType.FILE_MEM_FUNCS_CTL, 1, out err))
        {
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err + "\n");
        }
      }
    }

    private void btnLoadCfg_Click(object sender, EventArgs e)
    {
      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }
      string err;
      if(cbxEeErr.Checked)
      {
        if(!_active_servo.ServoSlave.FileCtlReadErr(out err))
        {
          ClrText(tbxEeErr);
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err + "\n");
        }
        else
        {
          short err_code;
          string err_str;
          if(_active_servo.ServoSlave.Errcode < 0)
          {
            err_str = "-0x";
            err_code = (short)-_active_servo.ServoSlave.FileErrcode;
            Log(LogMsgType.Error, "File Err: " + Strings.GetErrorString(_active_servo.ServoSlave.Errcode) + "\n");
          }
          else
          {
            err_str = "0x";
            err_code = _active_servo.ServoSlave.FileErrcode;
          }
          SetText(tbxEeErr, err_str + err_code.ToString("X4"));
        }
      }
      else
      {
        if(!_active_servo.ServoSlave.FileCtlLoadCfg(out err))
        // Example of single file read
        //if(!_active_servo.ServoSlave.FileCtlLoad(Slave.FileType.FILE_MEM_FUNCS_CTL, 1, out err))
        {
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err + "\n");
        }
      }
    }

    private void btnRebuildFs_Click(object sender, EventArgs e)
    {
      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }
      string err;
      if(cbxEeErr.Checked)
      {
        if(!_active_servo.ServoSlave.FileCtlResetErr(out err))
        {
          ClrText(tbxEeErr);
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err + "\n");
        }
        else
        {
          short err_code;
          string err_str;
          if(_active_servo.ServoSlave.Errcode < 0)
          {
            err_str = "-0x";
            err_code = (short)-_active_servo.ServoSlave.FileErrcode;
            Log(LogMsgType.Error, "File Err: " + Strings.GetErrorString(_active_servo.ServoSlave.Errcode) + "\n");
          }
          else
          {
            err_str = "0x";
            err_code = _active_servo.ServoSlave.FileErrcode;
          }
          SetText(tbxEeErr, err_str + err_code.ToString("X4"));
        }
      }
      else
      {
        if(!_active_servo.ServoSlave.FileCtlEraseAll(out err))
        {
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err + "\n");
        }
      }
    }

    private void cbxEeErr_CheckedChanged(object sender, EventArgs e)
    {
      if(cbxEeErr.Checked)
      {
        tbxEeErr.Visible = true;
        btnStoreCfg.Text = "Clear Err";
        btnLoadCfg.Text = "Read Err";
        btnRebuildFs.Enabled = false;
        // Read file errcode
        btnLoadCfg.PerformClick();
      }
      else
      {
        tbxEeErr.Visible = false;
        btnStoreCfg.Text = "Write All";
        btnLoadCfg.Text = "Read All";
        btnRebuildFs.Enabled = true;
      }
    }
    #endregion

    #region Sleep Control Events
    /******************************************************************************/
    private void btnSleep_Click(object sender, EventArgs e)
    {
      string err;
      Group.WakeupType wu_type;

      wu_type = (rbCommWakeUp.Checked == true) ? Group.WakeupType.COMMS : Group.WakeupType.IRQ;
      if(!_group.NetworkSleep(wu_type, out err))
      {
        MsgBox.Show(this, err);
        Log(LogMsgType.Error, err + "\n");
      }
    }
    #endregion
  }
}
