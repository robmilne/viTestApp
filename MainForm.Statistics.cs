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
using System.Drawing;
using System.Text;
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
    // Event to timeout statistics callback response
    private EventWaitHandle _statistics_ev;

    private bool suppress_stored_plot_checkbox;
    #endregion

    #region Helper Methods
    /******************************************************************************/
    /// <summary>
    /// pnlStats_Paint - Paint stats if available
    /// </summary>
    private void pnlStats_Paint(object sender, PaintEventArgs e)
    {
      if(cboSlaveNode.SelectedValue == null || _servo_ht == null)
      {
        return;
      }
      byte node = (byte)Convert.ToByte(cboSlaveNode.SelectedValue);
      if(_servo_ht.ContainsKey(node))
      {
        Slave slave = _servo_ht[node].ServoSlave;
        plotData(slave);
      }
    }

    /// <summary>
    /// plotData - Display statistics
    /// </summary>
    private void plotData(Slave slave)
    {
      if(cbxShowStatsPrev.Checked)
      {
        if(slave.StatsPrev.Count > 0)
        {
          plot(slave.StatsPrev);
        }
      }
      else if(slave.StatsCur.Count > 0)
      {
        plot(slave.StatsCur);
      }
    }
    private void plot(List<StatStruct> stats)
    {
      StringBuilder sb = new StringBuilder();
      foreach(StatStruct stat in stats)
      {
        sb.Append(stat.err.ToString("X2") + " ");
        sb.Append(stat.change.ToString("X2") + " ");
        sb.Append(stat.duty.ToString("X2") + "\r\n");
      }
      SetText(tbxStats, sb.ToString());

      // ready to draw
      System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Black);
      Graphics formGraphics;
      picbxStats.Size = new Size(stats.Count, 257);
      int width = picbxStats.Size.Width > pnlStats.Size.Width ? picbxStats.Size.Width : pnlStats.Size.Width;
      pnlStats.AutoScrollMinSize = new Size(width, picbxStats.Size.Height);
      formGraphics = picbxStats.CreateGraphics();
      formGraphics.Clear(System.Drawing.Color.White);

      // draw a horizontal line at zero
      myPen = new System.Drawing.Pen(System.Drawing.Color.LightGray);
      formGraphics.DrawLine(myPen, 0, 128, stats.Count, 128);

      int pt1, pt2;
      if(cbxStatInfoDuty.Checked)
      {
        for(int i = 0; i < stats.Count - 1; i++)
        {
          myPen = new System.Drawing.Pen(System.Drawing.Color.DimGray);
          pt1 = Convert.ToInt32(stats[i].duty);
          pt2 = Convert.ToInt32(stats[i + 1].duty);
          formGraphics.DrawLine(myPen, i, pt1, i + 1, pt2);
        }
      }
      if(cbxStatInfoChange.Checked)
      {
        for(int i = 0; i < stats.Count - 1; i++)
        {
          myPen = new System.Drawing.Pen(System.Drawing.Color.Blue);
          pt1 = Convert.ToInt32(stats[i].change);
          pt2 = Convert.ToInt32(stats[i + 1].change);
          formGraphics.DrawLine(myPen, i, pt1, i + 1, pt2);
        }
      }
      if(cbxStatInfoErr.Checked)
      {
        for(int i = 0; i < stats.Count - 1; i++)
        {
          myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
          pt1 = Convert.ToInt32(stats[i].err);
          pt2 = Convert.ToInt32(stats[i + 1].err);
          formGraphics.DrawLine(myPen, i, pt1, i + 1, pt2);
        }
      }

      formGraphics.TranslateTransform(pnlStats.AutoScrollPosition.X, pnlStats.AutoScrollPosition.Y);
      picbxStats.Update();

      // clean up
      myPen.Dispose();
      formGraphics.Dispose();
    }
    private void StatsHandleScroll(object sender, ScrollEventArgs e)
    {
      if(sender is Panel)
      {
        Panel panel = sender as Panel;
        Graphics g = picbxStats.CreateGraphics();
        g.TranslateTransform(panel.AutoScrollPosition.X, panel.AutoScrollPosition.Y);
        picbxStats.Update();
      }
    }

    #endregion

    #region Statistics Events
    /******************************************************************************/
    private void btnGetStats_Click(object sender, EventArgs e)
    {
      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }

      // Uncheck 'Show Stored Statistics' radio button
      suppress_stored_plot_checkbox = true;
      cbxShowStatsPrev.Checked = false;
      suppress_stored_plot_checkbox = false;
      Graphics formGraphics;
      formGraphics = picbxStats.CreateGraphics();
      formGraphics.Clear(System.Drawing.Color.White);
      formGraphics.DrawString("Wait for Statistics", new Font("Verdana", 14),
      new SolidBrush(Color.Black), 10, 10);

      Log(LogMsgType.Normal, "Wait for statistics\n");
      _statistics_ev = new AutoResetEvent(false);

      try
      {
        string err;
        if(!_active_servo.ServoSlave.GetStats(GetStatistics_callback))
        {
          err = "Statistics flushed - start new move to fill stats buffer";
          MsgBox.Show(this, err);
          Log(LogMsgType.Error, err.ToString() + "\n");
        }
        else
        {
          if(_statistics_ev.WaitOne(30000, false) == false)
          {
            MsgBox.Show(this, "Stats timeout\n");
            formGraphics.Clear(System.Drawing.Color.White);
            _statistics_ev.Close();
            _statistics_ev = null;
            return;
          }
        }
      }
      catch(Exception error)
      {
        MsgBox.Show(this, error.ToString());
        Log(LogMsgType.Error, error.ToString() + "\n");
      }

      _statistics_ev.Close();
      _statistics_ev = null;

      if(_active_servo.ServoSlave.StatBuf != null && _active_servo.ServoSlave.StatBuf.Count > 0)
      {
        _active_servo.ServoSlave.StatsCur = _active_servo.ServoSlave.StatBuf;
        formGraphics.Dispose();
        ClrText(tbxStats);

        plotData(_active_servo.ServoSlave);
      }
      else
      {
        formGraphics.Clear(System.Drawing.Color.White);
        formGraphics.Dispose();
        Log(LogMsgType.Warning, "Statistics Buffer empty - initiate a new move to fill\n");
        MsgBox.Show(this, "Statistics Buffer empty - initiate a new move to fill");
      }
    }

    private void GetStatistics_callback(bool ok)
    {
      if(_statistics_ev != null)
        _statistics_ev.Set();

      if(ok)
      {
        Log(LogMsgType.Warning, "Stats done\n");
      }
      else
      {
        Log(LogMsgType.Warning, "Stats disabled or buffer empty\n");
      }
    }

    private void btnStoreStats_Click(object sender, EventArgs e)
    {
      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }

      if(_active_servo.ServoSlave.StatsCur.Count > 0)
      {
        _active_servo.ServoSlave.StatsPrev = _active_servo.ServoSlave.StatsCur;
        cbxShowStatsPrev.Enabled = true;
      }
      else
      {
        MsgBox.Show(this, "No motion stats available");
      }
    }

    private void cbxShowStatsPrev_CheckedChanged(object sender, EventArgs e)
    {
      if(!suppress_stored_plot_checkbox)
      {
        if(_active_servo == null)
        {
          MsgBox.Show(this, "Select a Node");
          return;
        }

        if(cbxShowStatsPrev.Checked)
        {
          if(_active_servo.ServoSlave.StatsPrev.Count == 0)
          {
            cbxShowStatsPrev.Checked = false;
            MsgBox.Show(this, "No motion stats stored");
            return;
          }
        }
        plotData(_active_servo.ServoSlave);
      }
    }

    private void cbxStatInfoErr_CheckedChanged(object sender, EventArgs e)
    {
      UpdatePlot();
    }
    private void cbxStatInfoChange_CheckedChanged(object sender, EventArgs e)
    {
      UpdatePlot();
    }
    private void cbxStatInfoDuty_CheckedChanged(object sender, EventArgs e)
    {
      UpdatePlot();
    }
    private void UpdatePlot()
    {
      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }
      plotData(_active_servo.ServoSlave);
    }
    #endregion
  }
}
