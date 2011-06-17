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
using System.Windows.Forms;
using System.Threading;
using viServoMaster;
#endregion

namespace viTestApp
{
  public partial class MainForm : Form
  {
    #region Private Variables
    /******************************************************************************/
    private bool _cbo_bitrate_enable = false;
    #endregion

    #region Event Handlers
    /******************************************************************************/
    /// <summary>
    /// btnGatewayGetStatus_Click - Get gateway status
    /// </summary>
    private void btnGatewayGetStatus_Click(object sender, EventArgs e)
    {
      string err;
      if(!_gateway.ServoGateway.GetStatus(out err))
      {
        tbxGatewayStatus.Clear();
        MsgBox.Show(err);
      }
      else
      {
        string str;
        int status = (int)_gateway.ServoGateway.Status;
        if(status < 0)
        {
          Log(LogMsgType.Error, "Gateway CAN Err: " + Strings.GetErrorString(_gateway.ServoGateway.Status) + "\n");
          str = "-0x";
          status = -status;
          cbxCanBusOff.Checked = true;
        }
        else
        {
          str = "0x";
          cbxCanBusOff.Checked = false;
        }
        tbxGatewayStatus.Text = str + status.ToString("X");
        btnGatewayClearStatus.Enabled = cbxCanBusOff.Checked;

        if(_gateway.ServoGateway.Time == 0)
        {
          tbxGatewayTurnaround.Text = "No response";
        }
        else
        {
          // get 8KHz timer turnaround
          double tim = .125 * (double)_gateway.ServoGateway.Time;
          tbxGatewayTurnaround.Text = tim.ToString();
        }

        // Prevent bitrate write on change
        _cbo_bitrate_enable = false;

        // Get gateway bitrate
        if(_gateway.ServoGateway.GetBitrate(out err))
        {
          SetComboBox(cboCANBitrate, (int)_gateway.ServoGateway.Bitrate);
        }
        else
        {
          SetComboBox(cboCANBitrate, -1);
          MsgBox.Show(err);
        }
        _cbo_bitrate_enable = true;
      }
    }

    /// <summary>
    /// btnGatewayClearStatus_Click - Clear CAN bus error
    /// </summary>
    private void btnGatewayClearStatus_Click(object sender, EventArgs e)
    {
      // Execute GatewayStatusCommand object
      string err;
      if(!_gateway.ServoGateway.SetStatus(out err))
      {
        tbxGatewayStatus.Clear();
        MsgBox.Show(err);
      }
      else
      {
        string str;
        int status = (int)_gateway.ServoGateway.Status;
        if(status < 0)
        {
          str = "-0x";
          status = -status;
          cbxCanBusOff.Checked = true;
        }
        else
        {
          str = "0x";
          cbxCanBusOff.Checked = false;
        }
        tbxGatewayStatus.Text = str + status.ToString("X");
        btnGatewayClearStatus.Enabled = cbxCanBusOff.Checked;
      }
    }

    /// <summary>
    /// cboCANBitrate_SelectedIndexChanged - change network bitrate
    /// 
    ///   Master will issue group enum command to network x 10 with new
    ///   bitrate enum after which the master will change the bitrate of
    ///   the gateway.  
    ///   Each slave is responsible to alter its own bitrate 
    ///   after counting the tenth enum.
    ///   Bus faults will occur if some slave nodes do not hear all ten
    ///   group enum messages and are thus not synchronized.
    /// </summary>
    private void cboCANBitrate_SelectedIndexChanged(object sender, EventArgs e)
    {
      //if(_cbo_bitrate_enable && _group != null)
      if(_cbo_bitrate_enable)
      {
        int i = 0;
        string err;

        //MsgBox.Show("string: " + cboCANBitrate.SelectedItem.ToString() + " index: " + cboCANBitrate.SelectedIndex.ToString());
        for(; i < 10; i++)
        {
          if(_group != null)
          {
            if(_group.EnumGroup((Group.CANBitrate)cboCANBitrate.SelectedIndex, out err) == false)
            {
              MsgBox.Show(err);
              break;
            }
            Thread.Sleep(5);
          }
        }
        if(i == 10)
        {
          if(_gateway.ServoGateway.SetBitrate((Group.CANBitrate)cboCANBitrate.SelectedIndex, out err))
          {
            MsgBox.Show("Bitrate change success");
          }
          else
          {
            MsgBox.Show(err);
          }
        }
      }
    }

    #endregion
  }
}
