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
using viServoMaster;
#endregion

namespace viTestApp
{
  /// <summary>
  /// Class to encapsulate viServoMaster.Slave object 
  /// </summary>
  class Servo
  {
    #region Private Variables
    /******************************************************************************/
    private Slave _slave = null;
    #endregion

    #region Public Properties
    /******************************************************************************/
    public Slave ServoSlave
    {
      get { return _slave; }
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
