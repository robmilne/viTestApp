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
  /// Class to encapsulate viServoMaster.Gate object
  /// </summary>
  class Gateway
  {
    #region Private Variables
    /******************************************************************************/
    private Gate _gate = null;
    #endregion

    #region Public Properties
    /******************************************************************************/
    public Gate ServoGateway
    {
      get { return _gate; }
    }
    #endregion

    #region Constructors
    /******************************************************************************/
    public Gateway(Gate gate)
    {
      _gate = gate;
    }
    #endregion
  }
}
