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
      if(rbTestMotionStartPos.Checked)
        return Slave.MoveModes.SRV_POSITION_MODE;
      else if(rbTestMotionStartVel.Checked)
        return Slave.MoveModes.SRV_VELOCITY_MODE;
      else if(rbTestMotionStartTrapezoidal.Checked)
        return Slave.MoveModes.SRV_TRAPEZOIDAL_MODE;
      else if(rbTestMotionStartPwm.Checked)
        return Slave.MoveModes.SRV_PWM_MODE;
      else
        return Slave.MoveModes.SRV_PWM_POS_MODE;
    }
    public void StartGroupMotion()
    {
      string err;
      if(!_group.StartMotion(GetMotionMode(), out err))
      {
        MsgBox.Show(this, err);
      }
    }
    public void HaltGroup()
    {
      string err;
      if(!_group.HaltMotion(rbTestMotionStopHard.Checked, out err))
      {
        MsgBox.Show(this, err);
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
      if(!slave.HaltMotion(hs, out err))
      {
        MsgBox.Show(this, err);
      }
    }

    private void btnStatusCmd(bool write)
    {
      // Write according to UI checkboxes
      if(write)
      {
        _active_servo.ServoSlave.FlagIRQErr = cbxStatIrqErr.Checked;
        _active_servo.ServoSlave.FlagLimErr = cbxStatLimErr.Checked;
        _active_servo.ServoSlave.FlagSysErr = cbxStatSysErr.Checked;
        _active_servo.ServoSlave.FlagCANErr = cbxStatCANErr.Checked;
        _active_servo.ServoSlave.FlagPosErr = cbxStatPosErr.Checked;
        _active_servo.ServoSlave.FlagISRErr = cbxStatFuzzyErr.Checked;
        _active_servo.ServoSlave.FlagATDErr = cbxStatATDErr.Checked;
      }

      // Execute StatusCommand object of this slave
      string err;
      if(!_active_servo.ServoSlave.Status(write, out err))
      {
        MsgBox.Show(this, err);
      }

      // Servo state
      SetText(tbxStatServoState, viServoMaster.Strings.ServoStateStrings[(int)_active_servo.ServoSlave.ServoState]);

      // Sticky error flags (cleared by write to status cmd)
      SetCheckbox(cbxStatIrqErr, _active_servo.ServoSlave.FlagIRQErr);
      SetCheckbox(cbxStatLimErr, _active_servo.ServoSlave.FlagLimErr);
      SetCheckbox(cbxStatSysErr, _active_servo.ServoSlave.FlagSysErr);
      SetCheckbox(cbxStatCANErr, _active_servo.ServoSlave.FlagCANErr);
      SetCheckbox(cbxStatPosErr, _active_servo.ServoSlave.FlagPosErr);
      SetCheckbox(cbxStatFuzzyErr, _active_servo.ServoSlave.FlagISRErr);
      SetCheckbox(cbxStatATDErr, _active_servo.ServoSlave.FlagATDErr);

      // system error code (0 = SUCCESS)
      short err_code;
      string err_str;
      if(_active_servo.ServoSlave.SysErrcode < 0)
      {
        err_str = "-0x";
        err_code = (short)-_active_servo.ServoSlave.SysErrcode;
        Log(LogMsgType.Error, "Read Status Sys Err: " + Strings.GetErrorString(_active_servo.ServoSlave.SysErrcode) + "\n");
      }
      else
      {
        err_str = "0x";
        err_code = _active_servo.ServoSlave.SysErrcode;
      }
      SetText(tbxStatErrCode, err_str + err_code.ToString("X4"));

      // Current servo position
      SetText(tbxStatCurPos, _active_servo.ServoSlave.CurrentPosition.ToString());

      // Current servo velocity and stored peak velocity/acceleration
      SetText(tbxStatCurVel, _active_servo.ServoSlave.CurrentVelocity.ToString());
      SetText(tbxStatPeakVel, _active_servo.ServoSlave.PeakVelocity.ToString());
      SetText(tbxStatPeakAcc, _active_servo.ServoSlave.PeakAcceleration.ToString());

      // Limit pin states and values
      SetText(tbxStatLimAVal, (_active_servo.ServoSlave.IsLimitAPinSet ? "0" : "1"));
      SetText(tbxStatLimBVal, (_active_servo.ServoSlave.IsLimitBPinSet ? "0" : "1"));
      SetText(tbxStatEncIdxVal, (_active_servo.ServoSlave.IsLimitEncPinSet ? "0" : "1"));
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
      if(!_active_servo.ServoSlave.ZeroNode(out err))
      {
        MsgBox.Show(this, err);
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
        // Add 2 for first two uninitialized vals
        rate = (Slave.ServoRates)cboSetServoRate.SelectedIndex + 2;
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
        if(!_active_servo.ServoSlave.SetServoCtl(rate, hbridge, hb_pwm, enc_div,
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
      if(_active_servo.ServoSlave.GetServoCtl(out err))
      {
        StringBuilder err_sb = new StringBuilder("Servo Control Load Error\n");
        bool err_flag = false;

        if((int)_active_servo.ServoSlave.ServoRate > 1)
        {
          // Subtract 2 for non-init rates
          SetComboBox(cboSetServoRate, (int)(_active_servo.ServoSlave.ServoRate - 2));
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
      Slave.PwmDir pwm_dir = Slave.PwmDir.OFF;
      if(rbSetPwmCW.Checked)
        pwm_dir = Slave.PwmDir.CW;
      else if(rbSetPwmCCW.Checked)
        pwm_dir = Slave.PwmDir.CCW;

      string err;
      if(!_active_servo.ServoSlave.SetPosVelAccPwm((int)nudSetPos.Value,
                                        (int)nudSetVel.Value, 
                                        (uint)nudSetAcc.Value, 
                                        pwm_dir,(byte)nudSetPWM.Value,
                                        (cbxMoveCtlGo.Checked ? true : false),
                                        GetMotionMode(),
                                        out err))
      {
        MsgBox.Show(this, err);
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
      if(!_active_servo.ServoSlave.ReadMoveControl(out err))
      {
        MsgBox.Show(this, err);
        Log(LogMsgType.Error, err);
      }
      else
      {
        // Update controls
        SetText(nudSetPos, _active_servo.ServoSlave.Position.ToString());
        SetText(nudSetVel, _active_servo.ServoSlave.Velocity.ToString());
        SetText(nudSetAcc, _active_servo.ServoSlave.Acceleration.ToString());
        SetText(nudSetPWM, _active_servo.ServoSlave.PwmDuty.ToString());
        SetRadioButton(rbSetPwmOff, _active_servo.ServoSlave.PwmDirection.Equals(Slave.PwmDir.OFF));
        SetRadioButton(rbSetPwmCW, _active_servo.ServoSlave.PwmDirection.Equals(Slave.PwmDir.CW));
        SetRadioButton(rbSetPwmCCW, _active_servo.ServoSlave.PwmDirection.Equals(Slave.PwmDir.CCW));
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
          if(rb.Name.Equals("rbTestMotionStartPos") || rb.Name.Equals("rbTestMotionStartTrapezoidal"))
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
      if(!_active_servo.ServoSlave.StartMotion(GetMotionMode(), out err))
      {
        MsgBox.Show(this, err);
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
        if(!_active_servo.ServoSlave.GetSetPos(out pos, out err))
        {
          MsgBox.Show(this, err);
          return;
        }
        // Negate position and write back
        if(!_active_servo.ServoSlave.SetPos(-pos, mode, true, out err))
        {
          MsgBox.Show(this, err);
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
          if(!slave.ServoSlave.GetSetPos(out pos, out err))
          {
            MsgBox.Show(this, err);
            continue;
          }
          // Negate position and write back
          if(!slave.ServoSlave.SetPos(-pos, mode, false, out err))
          {
            MsgBox.Show(this, err);
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
        if(!_active_servo.ServoSlave.GetSetPos(out pos, out err))
        {
          MsgBox.Show(this, err);
          return;
        }
        // Negate position and write back
        if(!_active_servo.ServoSlave.SetPos(pos * 2, mode, true, out err))
        {
          MsgBox.Show(this, err);
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
          if(!slave.ServoSlave.GetSetPos(out pos, out err))
          {
            MsgBox.Show(this, err);
            continue;
          }
          // Negate position and write back
          if(!slave.ServoSlave.SetPos(pos * 2, mode, false, out err))
          {
            MsgBox.Show(this, err);
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
        if(!_active_servo.ServoSlave.GetSetPos(out pos, out err))
        {
          MsgBox.Show(this, err);
          return;
        }
        // Negate position and write back
        if(!_active_servo.ServoSlave.SetPos(pos / 2, mode, true, out err))
        {
          MsgBox.Show(this, err);
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
          if(!slave.ServoSlave.GetSetPos(out pos, out err))
          {
            MsgBox.Show(this, err);
            continue;
          }
          // Negate position and write back
          if(!slave.ServoSlave.SetPos(pos / 2, mode, false, out err))
          {
            MsgBox.Show(this, err);
            continue;
          }
        }
        StartGroupMotion();
      }
    }

    /// <summary>
    /// btnRand_Click - Test that uses the current pos, vel and acc settings as an envelope for 
    ///                 30 random trapezoidal moves that execute for between .5 and 2 seconds
    /// </summary>
    private void btnRand_Click(object sender, EventArgs e)
    {
      int pos_max, new_pos;
      int vel_max, new_vel;
      uint acc_max, new_acc;
      string err;

      cbxGroup.Checked = false;

      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }

      // Get current pos, vel, acc settings - use as envelope
      if(!_active_servo.ServoSlave.ReadMoveControl(out err))
      {
        MsgBox.Show(this, err);
        return;
      }
      if(_active_servo.ServoSlave.Position != 0)
      {
        pos_max = _active_servo.ServoSlave.Position;
        if(pos_max < 0)
          pos_max = -pos_max;
      }
      else
      {
        MsgBox.Show(this, "Max position not set");
        return;
      }
      if(_active_servo.ServoSlave.Velocity != 0)
      {
        vel_max = _active_servo.ServoSlave.Velocity;
        if(vel_max < 0)
          vel_max = -vel_max;
      }
      else
      {
        MsgBox.Show(this, "Max velocity not set");
        return;
      }
      if(_active_servo.ServoSlave.Acceleration != 0)
      {
        acc_max = _active_servo.ServoSlave.Acceleration;
      }
      else
      {
        MsgBox.Show(this, "Max acceleration not set");
        return;
      }

      Random rnd = new Random();
      int tim;
      for(int i = 0; i < 100; i++)
      {
        // Position range between original set position and negative of set position
        new_pos = rnd.Next(0 - pos_max, pos_max);
        new_vel = rnd.Next(0, vel_max);
        new_acc = (uint)(rnd.Next(0, (int)acc_max));

        if(_active_servo.ServoSlave.SetPosVelAcc(new_pos, new_vel, new_acc, true, Slave.MoveModes.SRV_TRAPEZOIDAL_MODE, out err))
        {
          // Wait between .5 and 2 seconds before next move
          tim = rnd.Next(500, 2000);
          Thread.Sleep(tim);
        }
      }
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
      _active_servo.ServoSlave.LimitStructHT[Slave.LimitType.A] = ls;

      ls = new Slave.LimitStruct(cbxSetLimBEn.Checked,
                                 rbSetLimBValHi.Checked,
                                 rbSetLimBHaltHard.Checked,
                                 cbxSetLimBZero.Checked);
      _active_servo.ServoSlave.LimitStructHT[Slave.LimitType.B] = ls;

      ls = new Slave.LimitStruct(cbxSetEncIdxEn.Checked,
                                 rbSetEncIdxValHi.Checked,
                                 rbSetEncIdxHaltHard.Checked,
                                 cbxSetEncIdxZero.Checked);
      _active_servo.ServoSlave.LimitStructHT[Slave.LimitType.IDX] = ls;

      _active_servo.ServoSlave.IRQEnable = cbxIRQEn.Checked;
      _active_servo.ServoSlave.IRQStopType = rbIRQhard.Checked;

      _active_servo.ServoSlave.ATDValue = (byte)Convert.ToByte(nudSetAtdLimVal.Text);
      _active_servo.ServoSlave.ATDPeriod = (byte)Convert.ToByte(nudSetAtdLimDwell.Text);

      string err;
      if(!_active_servo.ServoSlave.WriteLimitControls(out err))
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
      if(!_active_servo.ServoSlave.ReadLimitControls(out err))
      {
        MsgBox.Show(this, err);
        Log(LogMsgType.Error, err + "\n");
      }
      else
      {
        SetCheckbox(cbxSetLimAEn, _active_servo.ServoSlave.LimitStructHT[Slave.LimitType.A].enable);
        SetCheckbox(cbxSetLimBEn, _active_servo.ServoSlave.LimitStructHT[Slave.LimitType.B].enable);
        SetCheckbox(cbxSetEncIdxEn, _active_servo.ServoSlave.LimitStructHT[Slave.LimitType.IDX].enable);
        SetCheckbox(cbxIRQEn, _active_servo.ServoSlave.IRQEnable);

        SetRadioButton(rbIRQhard, _active_servo.ServoSlave.IRQStopType);
        SetRadioButton(rbIRQsoft, !_active_servo.ServoSlave.IRQStopType);

        SetRadioButton(rbSetLimAValHi, _active_servo.ServoSlave.LimitStructHT[Slave.LimitType.A].hi_polarity);
        SetRadioButton(rbSetLimAValLo, !_active_servo.ServoSlave.LimitStructHT[Slave.LimitType.A].hi_polarity);
        SetRadioButton(rbSetLimBValHi, _active_servo.ServoSlave.LimitStructHT[Slave.LimitType.B].hi_polarity);
        SetRadioButton(rbSetLimBValLo, !_active_servo.ServoSlave.LimitStructHT[Slave.LimitType.B].hi_polarity);
        SetRadioButton(rbSetEncIdxValHi, _active_servo.ServoSlave.LimitStructHT[Slave.LimitType.IDX].hi_polarity);
        SetRadioButton(rbSetEncIdxValLo, !_active_servo.ServoSlave.LimitStructHT[Slave.LimitType.IDX].hi_polarity);

        SetRadioButton(rbSetLimAHaltHard, _active_servo.ServoSlave.LimitStructHT[Slave.LimitType.A].hard_stop);
        SetRadioButton(rbSetLimAHaltSoft, !_active_servo.ServoSlave.LimitStructHT[Slave.LimitType.A].hard_stop);
        SetRadioButton(rbSetLimBHaltHard, _active_servo.ServoSlave.LimitStructHT[Slave.LimitType.B].hard_stop);
        SetRadioButton(rbSetLimBHaltSoft, !_active_servo.ServoSlave.LimitStructHT[Slave.LimitType.B].hard_stop);
        SetRadioButton(rbSetEncIdxHaltHard, _active_servo.ServoSlave.LimitStructHT[Slave.LimitType.IDX].hard_stop);
        SetRadioButton(rbSetEncIdxHaltSoft, !_active_servo.ServoSlave.LimitStructHT[Slave.LimitType.IDX].hard_stop);

        SetCheckbox(cbxSetLimAZero, _active_servo.ServoSlave.LimitStructHT[Slave.LimitType.A].zero);
        SetCheckbox(cbxSetLimBZero, _active_servo.ServoSlave.LimitStructHT[Slave.LimitType.B].zero);
        SetCheckbox(cbxSetEncIdxZero, _active_servo.ServoSlave.LimitStructHT[Slave.LimitType.IDX].zero);

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
        if(!_active_servo.ServoSlave.ResetFileErr(out err))
        {
          ClrText(tbxEeErr);
          MsgBox.Show(this, err);
        }
        else
        {
          short err_code;
          string err_str;
          if(_active_servo.ServoSlave.SysErrcode < 0)
          {
            err_str = "-0x";
            err_code = (short)-_active_servo.ServoSlave.FileErrcode;
            Log(LogMsgType.Error, "File Err: " + Strings.GetErrorString(_active_servo.ServoSlave.SysErrcode) + "\n");
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
        if(!_active_servo.ServoSlave.StoreCfg(out err))
        // Example of single file write
        //if(!_active_servo.ServoSlave.WriteFile(Slave.FileType.FILE_MEM_FUNCS_CTL, 1, out err))
        {
          MsgBox.Show(this, err);
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
        if(!_active_servo.ServoSlave.ReadFileErr(out err))
        {
          ClrText(tbxEeErr);
          MsgBox.Show(this, err);
        }
        else
        {
          short err_code;
          string err_str;
          if(_active_servo.ServoSlave.SysErrcode < 0)
          {
            err_str = "-0x";
            err_code = (short)-_active_servo.ServoSlave.FileErrcode;
            Log(LogMsgType.Error, "File Err: " + Strings.GetErrorString(_active_servo.ServoSlave.SysErrcode) + "\n");
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
        if(!_active_servo.ServoSlave.LoadCfg(out err))
        // Example of single file read
        //if(!_active_servo.ServoSlave.ReadFile(Slave.FileType.FILE_MEM_FUNCS_CTL, 1, out err))
        {
          MsgBox.Show(this, err);
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
        if(!_active_servo.ServoSlave.ResetFileErr(out err))
        {
          ClrText(tbxEeErr);
          MsgBox.Show(this, err);
        }
        else
        {
          short err_code;
          string err_str;
          if(_active_servo.ServoSlave.SysErrcode < 0)
          {
            err_str = "-0x";
            err_code = (short)-_active_servo.ServoSlave.FileErrcode;
            Log(LogMsgType.Error, "File Err: " + Strings.GetErrorString(_active_servo.ServoSlave.SysErrcode) + "\n");
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
        if(!_active_servo.ServoSlave.DeleteFs(out err))
        {
          MsgBox.Show(this, err);
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
      }
    }
    #endregion
  }
}
