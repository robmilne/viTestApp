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
#endregion

namespace viTestApp
{
  /// <summary>
  /// ComboBox selector object
  /// </summary>
  public class CboSelector
  {
    #region Private Variables
    /******************************************************************************/
    private int _idx;
    private string _desc;
    #endregion

    #region Public Properties
    /******************************************************************************/
    public int Idx
    {
      set { _idx = value; }
      get { return _idx; }
    }
    public string Description
    {
      set { _desc = value; }
      get { return (_desc); }
    }
    #endregion

    #region Constructors
    /******************************************************************************/
    public CboSelector(int idx, string name)
    {
      _idx = idx;
      _desc = name;
    }
    #endregion
  }
}
