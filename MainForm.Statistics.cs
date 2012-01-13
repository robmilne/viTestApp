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
    private bool suppress_plot_event;

    private Bitmap offScreenBitMap = null;
    #endregion

    #region Helper Methods
    /******************************************************************************/
    /// <summary>
    /// plotData - Display statistics
    /// </summary>
    private void plotData(Servo servo)
    {
      if(cbxShowStatsPrev.Checked)
      {
        plot(servo.StatsPrev, Slave.STATS_SIZE);
        setCtlPts(servo.CtlPtsPrev);
      }
      else
      {
        plot(servo.StatsCur, Slave.STATS_SIZE);
        setCtlPts(servo.CtlPtsCur);
      }
    }
    private void plot(List<StatStruct> stats, int size)
    {
      if(stats.Count == 0)
      {
        return;
      }

      // Make height sizeof byte + 2 to see curves at satuaration
      picbxStats.Size = new Size(size, 257);
      int width = picbxStats.Size.Width > pnlStats.Size.Width ? picbxStats.Size.Width : pnlStats.Size.Width;
      pnlStats.AutoScrollMinSize = new Size(width, picbxStats.Size.Height);

      // Render graph as a bitmap - use paint event to paste into picbxStats
      if(offScreenBitMap == null)
      {
        offScreenBitMap = new Bitmap(picbxStats.Width, picbxStats.Height);
      }
      Graphics g = Graphics.FromImage(offScreenBitMap);
      g.Clear(System.Drawing.Color.White);

      // draw a horizontal line at 0x80 (signed zero)
      Pen p = new Pen(Color.LightGray);
      g.DrawLine(p, 0, 128, size, 128);
      // dashed lines at 0xC0 and 0x40
      float[] dashValues = { 5, 5 };
      Pen dashPen = new Pen(Color.LightGray, 1);
      dashPen.DashPattern = dashValues;
      g.DrawLine(dashPen, 0, 64, size, 64);
      g.DrawLine(dashPen, 0, 192, size, 192);

      int pt1, pt2;
      if(cbxStatInfoDuty.Checked)
      {
        for(int i = 0; i < stats.Count - 1; i++)
        {
          p = new Pen(Color.DimGray);
          pt1 = Convert.ToInt32(stats[i].duty);
          pt2 = Convert.ToInt32(stats[i + 1].duty);
          g.DrawLine(p, i, pt1, i + 1, pt2);
        }
      }
      if(cbxStatInfoChange.Checked)
      {
        for(int i = 0; i < stats.Count - 1; i++)
        {
          p = new Pen(Color.Blue);
          pt1 = Convert.ToInt32(stats[i].change);
          pt2 = Convert.ToInt32(stats[i + 1].change);
          g.DrawLine(p, i, pt1, i + 1, pt2);
        }
      }
      if(cbxStatInfoErr.Checked)
      {
        for(int i = 0; i < stats.Count - 1; i++)
        {
          p = new Pen(Color.Red);
          pt1 = Convert.ToInt32(stats[i].err);
          pt2 = Convert.ToInt32(stats[i + 1].err);
          g.DrawLine(p, i, pt1, i + 1, pt2);
        }
      }

      g.TranslateTransform(pnlStats.AutoScrollPosition.X, pnlStats.AutoScrollPosition.Y);
      g.Dispose();
      p.Dispose();
      dashPen.Dispose();
      // Raise paint event
      picbxStats.Invalidate();
    }

    private void setCtlPts(List<byte> pts)
    {
      // Display control points only if checked in "Fuzzy Tuning" tab
      if(cbxMemFuncCtlPts.Checked && pts.Count == (int)Servo.ControlPoints.MAX_CTL_PTS)
      {
        gbStatCtlPts.Enabled = true;
        SetText(tbxStatPosCtlPtA, pts[(int)Servo.ControlPoints.A_ERROR].ToString("X2"));
        SetText(tbxStatPosCtlPtB, pts[(int)Servo.ControlPoints.B_ERROR].ToString("X2"));
        SetText(tbxStatSpdCtlPtA, pts[(int)Servo.ControlPoints.A_CHANGE].ToString("X2"));
        SetText(tbxStatSpdCtlPtB, pts[(int)Servo.ControlPoints.B_CHANGE].ToString("X2"));
        SetText(tbxStatOutCtlPtA, pts[(int)Servo.ControlPoints.A_OUTPUT].ToString("X2"));
        SetText(tbxStatOutCtlPtB, pts[(int)Servo.ControlPoints.B_OUTPUT].ToString("X2"));
      }
      else
      {
        gbStatCtlPts.Enabled = false;
        ClrText(tbxStatPosCtlPtA);
        ClrText(tbxStatPosCtlPtB);
        ClrText(tbxStatSpdCtlPtA);
        ClrText(tbxStatSpdCtlPtB);
        ClrText(tbxStatOutCtlPtA);
        ClrText(tbxStatOutCtlPtB);
      }
    }

    #endregion

    #region Statistics Events
    /******************************************************************************/
    /// <summary>
    /// pnlStats_Paint - Paint stats if available
    /// </summary>
    private void pnlStats_Paint(object sender, PaintEventArgs e)
    {
      Panel panel = sender as Panel;
      if(offScreenBitMap != null)
      {
        e.Graphics.DrawImage(offScreenBitMap, new Point(panel.AutoScrollPosition.X, panel.AutoScrollPosition.Y));
      } 
    }
    private void pnlStats_Scroll(object sender, ScrollEventArgs e)
    {
      Panel panel = sender as Panel;
      if(offScreenBitMap != null)
      {
        Graphics g = Graphics.FromImage(offScreenBitMap);
        g.TranslateTransform(panel.AutoScrollPosition.X, panel.AutoScrollPosition.Y);
        g.Dispose();
      }
    }

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
      _statistics_ev = new AutoResetEvent(false);

      Graphics g = picbxStats.CreateGraphics();
      try
      {
        if(_active_servo.ServoSlave.StatsRead(GetStatistics_callback))
        {       
          g.Clear(System.Drawing.Color.White);
          g.DrawString("Wait for Statistics", new Font("Verdana", 14),
          new SolidBrush(Color.Black), 10, 10);
          if(_statistics_ev.WaitOne(15000, false) == false)
          {
            MsgBox.Show(this, "Stats timeout\n");
            g.Clear(System.Drawing.Color.White);
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
      ClrText(tbxStats);

      if(_active_servo.ServoSlave.StatBuf != null && _active_servo.ServoSlave.StatBuf.Count > 0)
      {
        // We've got valid stats data - copy stats buffer to StatsCur
        _active_servo.StatsCur = _active_servo.ServoSlave.StatBuf;

        // Build control points from mem funcs
        _active_servo.CtlPtsCur.Clear();
        // Derive PosErr Ctl points from bytes 4 and 1 of PosMembershipFunctionArray
        _active_servo.CtlPtsCur.Add(_active_servo.ServoSlave.PosMemFuncArray[4]);
        _active_servo.CtlPtsCur.Add(_active_servo.ServoSlave.PosMemFuncArray[1]);

        // Derive Change Ctl points from bytes 4 and 1 of SpdMembershipFunctionArray
        _active_servo.CtlPtsCur.Add(_active_servo.ServoSlave.SpdMemFuncArray[4]);
        _active_servo.CtlPtsCur.Add(_active_servo.ServoSlave.SpdMemFuncArray[1]);

        // Derive Output Ctl points from bytes 0 and 1 of OutSingletonArray
        _active_servo.CtlPtsCur.Add(_active_servo.ServoSlave.OutSingletonArray[0]);
        _active_servo.CtlPtsCur.Add(_active_servo.ServoSlave.OutSingletonArray[1]);
      }
      else
      {
        if(_active_servo.StatsCur.Count == 0)
        {
          g.Clear(System.Drawing.Color.White);
          Log(LogMsgType.Warning, "Statistics Buffer empty - initiate a move to fill\n");
          MsgBox.Show(this, "Statistics Buffer empty - initiate a move to fill");
          return;
        }
      }

      // Build text box output     
      StringBuilder sb = new StringBuilder();
      foreach(StatStruct stat in _active_servo.StatsCur)
      {
        sb.Append(stat.err.ToString("X2") + " ");
        sb.Append(stat.change.ToString("X2") + " ");
        sb.Append(stat.duty.ToString("X2") + "\r\n");
      }
      SetText(tbxStats, sb.ToString());

      plotData(_active_servo);

      g.Dispose();
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

      if(_active_servo.StatsCur.Count > 0)
      {
        _active_servo.StatsPrev = _active_servo.StatsCur;

        byte[] arr = _active_servo.CtlPtsCur.ToArray();
        if(arr.Length == (int)Servo.ControlPoints.MAX_CTL_PTS)
        {
          _active_servo.CtlPtsPrev.Clear();
          for(int i = 0; i < (int)Servo.ControlPoints.MAX_CTL_PTS; i++)
          {
            _active_servo.CtlPtsPrev.Add(arr[i]);
          }
        }
        cbxShowStatsPrev.Visible = true;
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

        List<StatStruct> stats = null;
        if(cbxShowStatsPrev.Checked)
        {
          if(_active_servo.StatsPrev.Count == 0)
          {
            cbxShowStatsPrev.Checked = false;
            MsgBox.Show(this, "No previous motion stats stored");
            return;
          }
          else
          {
            stats = _active_servo.StatsPrev;
          }
        }
        else
        {
          if(_active_servo.StatsCur.Count == 0)
          {
            MsgBox.Show(this, "No motion stats stored");
            return;
          }
          else
          {
            stats = _active_servo.StatsCur;
          }
        }

        if(stats != null)
        {
          // Build text box output
          ClrText(tbxStats);
          StringBuilder sb = new StringBuilder();
          foreach(StatStruct stat in stats)
          {
            sb.Append(stat.err.ToString("X2") + " ");
            sb.Append(stat.change.ToString("X2") + " ");
            sb.Append(stat.duty.ToString("X2") + "\r\n");
          }
          SetText(tbxStats, sb.ToString());

          plotData(_active_servo);
        }
      }
    }

    private void cbxStatInfoErr_CheckedChanged(object sender, EventArgs e)
    {
      if(!suppress_plot_event)
      {
        suppress_plot_event = true;
        UpdatePlot();
        suppress_plot_event = false;
      }
    }
    private void cbxStatInfoChange_CheckedChanged(object sender, EventArgs e)
    {
      if(!suppress_plot_event)
      {
        suppress_plot_event = true;
        UpdatePlot();
        suppress_plot_event = false;
      }
    }
    private void cbxStatInfoDuty_CheckedChanged(object sender, EventArgs e)
    {
      if(!suppress_plot_event)
      {
        suppress_plot_event = true;
        UpdatePlot();
        suppress_plot_event = false;
      }
    }
    private void UpdatePlot()
    {
      if(_active_servo == null)
      {
        MsgBox.Show(this, "Select a Node");
        return;
      }
      plotData(_active_servo);
    }
    #endregion
  }
}
