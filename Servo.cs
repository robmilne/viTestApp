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
using viServoMaster;
#endregion

namespace viTestApp
{
  /// <summary>
  /// Class to encapsulate viServoMaster.Slave object and tuning feedback
  /// </summary>
  public class Servo
  {
    #region Public Enumerations
    /******************************************************************************/
    public enum ControlPoints
    {
      A_ERROR,
      B_ERROR,
      A_CHANGE,
      B_CHANGE,
      A_OUTPUT,
      B_OUTPUT,
      /*********/
      MAX_CTL_PTS
    };

    public enum StatsSet
    {
      CURRENT,
      PREVIOUS
    };
    #endregion

    #region Private Variables
    /******************************************************************************/
    private Slave _slave = null;
    private List<StatStruct> _listStatCur = null;
    private List<StatStruct> _listStatPrev = null;
    private List<byte> _cur_ctl_pts = null;
    private List<byte> _prev_ctl_pts = null;

    private StatsSet _stats_set = StatsSet.CURRENT; 
    #endregion

    #region Public Properties
    /******************************************************************************/
    public Slave ServoSlave
    {
      get { return _slave; }
    }

    public StatsSet StatSet
    {
      set { _stats_set = value; }
      get { return _stats_set; }
    }

    public List<StatStruct> StatsCur
    {
      set { _listStatCur = value; }
      get
      {
        if(_listStatCur == null)
        {
          _listStatCur = new List<StatStruct>();
        }
        return (_listStatCur);
      }
    }
    public List<StatStruct> StatsPrev
    {
      set { _listStatPrev = value; }
      get
      {
        if(_listStatPrev == null)
        {
          _listStatPrev = new List<StatStruct>();
        }
        return (_listStatPrev);
      }
    }

    public List<byte> CtlPtsCur
    {
      set { _cur_ctl_pts = value; }
      get 
      {
        if(_cur_ctl_pts == null)
        {
          _cur_ctl_pts = new List<byte>();
        }
        return _cur_ctl_pts; 
      }
    }
    public List<byte> CtlPtsPrev
    {
      set { _prev_ctl_pts = value; }
      get
      {
        if(_prev_ctl_pts == null)
        {
          _prev_ctl_pts = new List<byte>();
        }
        return _prev_ctl_pts;
      }
    }
    #endregion

    #region Constructors
    /******************************************************************************/
    public Servo(Slave slave)
    {
      _slave = slave;
    }
    #endregion
  }
}
