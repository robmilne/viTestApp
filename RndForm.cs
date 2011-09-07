/*
 * Project:   viTestApp
 * Company:   Vera Ikona, http://vera-ikona.com
 * Author:    Robert Milne
 * Created:   Sept 2011
 *
 * Notes:
 */
#region Namespace Inclusions
/******************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using viServoMaster;
using System.Threading;
#endregion

namespace viTestApp
{
  public partial class RndForm : Form
  {
    #region Private Variables
    /******************************************************************************/
    // Current servo node
    private Servo _servo;
    private int _sec_delay = 1;
    private int _num_move = 0;
    private bool _status_read = false;
    private bool _done_move = true;
    private bool _done_status = true;

    private Thread _rnd_thread = null;
    private Thread _rnd_status_thread = null;
    #endregion

    #region Constructors
    /******************************************************************************/
    public RndForm(Servo servo)
    {
      InitializeComponent();
      _servo = servo;
    }
    #endregion

    #region Private Methods
    /******************************************************************************/
    delegate void RndSetTextCallback(Control ctl, string text);
    private void RndSetText(Control ctl, string text)
    {
      if(ctl.InvokeRequired)
      {
        RndSetTextCallback d = new RndSetTextCallback(RndSetText);
        try
        {
          this.Invoke(d, new object[] { ctl, text });
        }
        catch
        {
          return;
        }
      }
      else
      {
        ctl.Text = text;
      }
    }

    private void RndMoveThread()
    {
      int pos_max, new_pos;
      int vel_max, new_vel;
      uint acc_max, new_acc;
      string err;
      int tim;
      Random rnd = new Random();

      pos_max = _servo.ServoSlave.Position;
      if(pos_max < 0)
        pos_max = -pos_max;

      vel_max = _servo.ServoSlave.Velocity;
      if(vel_max < 0)
        vel_max = -vel_max;

      acc_max = _servo.ServoSlave.Acceleration;

      while(_num_move-- > 0)
      {
        RndSetText(tbxRndMoveNum, _num_move.ToString());
        // Position range between original set position and negative of set position
        new_pos = rnd.Next(0 - pos_max, pos_max);
        // Prevent vel & acc from having zero value
        do
        {
          new_vel = rnd.Next(0, vel_max);
        } while(new_vel == 0);
        do
        {
          new_acc = (uint)(rnd.Next(0, (int)acc_max));
        } while(new_acc == 0);

        if(_servo.ServoSlave.SetPosVelAcc(new_pos, new_vel, new_acc, true, Slave.MoveModes.SRV_TRAPEZOIDAL_MODE, out err))
        {
          // Wait between .5 and _sec_delay seconds before next move
          tim = rnd.Next(500, _sec_delay * 1000);
          Thread.Sleep(tim);
        }
        else
        {
          continue;
        }
      }
      _done_move = true;
      return;
    }

    private void RndStatusThread()
    { 
      string err;

      while(_status_read)
      {
        if(_servo.ServoSlave.Status(false, out err))
        {
          RndSetText(tbxRndPos, _servo.ServoSlave.CurrentPosition.ToString());
          // Kill process if limit detected
          if(_servo.ServoSlave.FlagLimErr || _servo.ServoSlave.FlagATDErr || _servo.ServoSlave.FlagIRQErr)
          {
            _num_move = 0;
            break;
          }
        }
        Thread.Sleep(100);
      }
      _done_status = true;
      return;
    }
    #endregion

    #region Event Handlers
    /******************************************************************************/
    private void btnRndStart_Click(object sender, EventArgs e)
    {
      if(nudRndNumExec.Value > 0)
      {
        _num_move = (int)nudRndNumExec.Value;
        _sec_delay = (int)nudRndSecDelay.Value;
        _status_read = true;
        _done_move = false;
        _done_status = false;

        // Create and start move and status checking threads
        _rnd_thread = new Thread(RndMoveThread);
        _rnd_thread.Start();
        _rnd_status_thread = new Thread(RndStatusThread);
        _rnd_status_thread.Start();
      }
      else
      {
        // Return to main form
        this.DialogResult = DialogResult.OK;
      }
    }

    private void btnRndStop_Click(object sender, EventArgs e)
    {
      string err;

      _num_move = 0;
      _status_read = false;

      // Soft stop
      _servo.ServoSlave.HaltMotion(false, out err);

      while(!_done_move && !_done_status) { };

      // Return to main form
      this.DialogResult = DialogResult.OK;
    }
    #endregion
  }
}
