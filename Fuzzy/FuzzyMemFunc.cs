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
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing;
using viServoMaster;
#endregion

namespace viTestApp
{
  public class FuzzyMemFunc : IDisposable
  {
    #region Public Delegates
    /******************************************************************************/
    public delegate void MemFuncEventHandler(int index, FuzzyMemFuncs.TrapezoidalFunc func);
    #endregion

    #region Constants
    /******************************************************************************/
    private const int LABEL_LEFT = 2;
    private const int LABEL_WIDTH = 54;
    private const int LABEL_HEIGHT = 12;

    private const int TB_WIDTH = 20;
    private const int TB_HEIGHT = 20;
    #endregion

    #region Public Enumerations
    /******************************************************************************/
    private enum FuncVars
    {
      POINT_0,
      POINT_1,
      SLOPE_0,
      SLOPE_1
    };
    #endregion

    #region Private Variables
    /******************************************************************************/
    // Control that contains programmatically built UI objects
    private GroupBox _container;

    // Index of membership function (row#)
    private int _index;

    // values for textboxes
    private FuzzyMemFuncs.TrapezoidalFunc _trapezoidal_func;

    private List<TextBox> _text_box_list;

    private MemFuncEventHandler _handler;

    private bool _enabled = true;

    // Track whether Dispose has been called.
    private bool disposed = false;
    #endregion

    #region Public Properties
    /******************************************************************************/
    public FuzzyMemFuncs.TrapezoidalFunc TrapezoidalFunc
    {
      set 
      {
        if(SetText(value))
        {
          _trapezoidal_func = value;
        }
      }
      get 
      { 

        return _trapezoidal_func; 
      }
    }
    public bool Enable
    {
      set 
      { 
        _enabled = value;
        foreach(TextBox tbx in _text_box_list)
        {
          tbx.Enabled = _enabled;
        }
      }
      get { return _enabled; }
    }
    #endregion

    #region Constructors
    /******************************************************************************/
    public FuzzyMemFunc(Control parent, string caption, int index, int top, int left, MemFuncEventHandler handler)
    {
      _container = (GroupBox)parent;
      _index = index;
      _handler = handler;
      _text_box_list = new List<TextBox>();

      Font f_reg = new Font("Microsoft Sans Serif", 7);

      Label lbl = new Label();
      lbl.Font = f_reg;
      lbl.Location = new Point(LABEL_LEFT, top + (TB_HEIGHT * index) + 2);
      lbl.AutoSize = false;
      lbl.RightToLeft = RightToLeft.Yes;
      lbl.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
      lbl.Text = caption;
      parent.Controls.Add(lbl);

      // Build 4 textboxes to hold trapezoidal func elements
      for(int i = 0; i < 4; i++)
      {
        TextBox tb = new TextBox();
        tb.Font = f_reg;
        tb.Size = new Size(TB_WIDTH, TB_HEIGHT);
        tb.Location = new Point(left + (TB_WIDTH * i), top + (TB_HEIGHT * index));
        tb.Text = string.Empty;
        parent.Controls.Add(tb);

        _text_box_list.Add(tb);
      }
    }

    // Use C# destructor syntax for finalization code.
    // This destructor will run only if the Dispose method 
    // does not get called.
    // It gives your base class the opportunity to finalize.
    // Do not provide destructors in types derived from this class.
    ~FuzzyMemFunc()      
    {
        // Do not re-create Dispose clean-up code here.
        // Calling Dispose(false) is optimal in terms of
        // readability and maintainability.
        Dispose(false);
    }
    #endregion

    #region EventHandler
    /******************************************************************************/
    public void p0_TextChanged(object sender, EventArgs e)
    {
      // 1 or 2 hex characters
      if(!IsHexByte(_text_box_list[0].Text))
      {
        // Restore original value;
        _text_box_list[0].Text = _trapezoidal_func.p0.ToString("X2");
      }
    }
    public void p0_LostFocus(object sender, EventArgs e)
    {
      bool retval = false;
      int val;
      string s = _text_box_list[0].Text;
      if(Int32.TryParse(s, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val))
      {
        retval = Validate(FuncVars.POINT_0, val);
      }
      if(retval == false)
      {
        // Restore original value;
        _text_box_list[0].Text = _trapezoidal_func.p0.ToString("X2");
      }
    }

    private void p1_TextChanged(object sender, EventArgs e)
    {
      if(!IsHexByte(_text_box_list[1].Text))
      {
        _text_box_list[1].Text = _trapezoidal_func.p1.ToString("X2");
      }
    }
    public void p1_LostFocus(object sender, EventArgs e)
    {
      bool retval = false;
      int val;
      string s = _text_box_list[1].Text;
      if(Int32.TryParse(s, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val))
      {
            retval = Validate(FuncVars.POINT_1, val);
      }
      if(retval == false)
      {
        // Restore original value;
        _text_box_list[1].Text = _trapezoidal_func.p1.ToString("X2");
      }
    }

    private void s0_TextChanged(object sender, EventArgs e)
    {
      if(!IsHexByte(_text_box_list[2].Text))
      {
        _text_box_list[2].Text = _trapezoidal_func.s0.ToString("X2");
      }        
    }
    public void s0_LostFocus(object sender, EventArgs e)
    {
      bool retval = false;
      int val;
      string s = _text_box_list[2].Text;
      if(Int32.TryParse(s, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val))
      {
        retval = Validate(FuncVars.SLOPE_0, val);
      }
      if(retval == false)
      {
        // Restore original value;
        _text_box_list[2].Text = _trapezoidal_func.s0.ToString("X2");
      }
    }

    private void s1_TextChanged(object sender, EventArgs e)
    {
      if(!IsHexByte(_text_box_list[3].Text))
      {
        _text_box_list[3].Text = _trapezoidal_func.s1.ToString("X2");
      }      
    }
    public void s1_LostFocus(object sender, EventArgs e)
    {
      bool retval = false;
      int val;
      string s = _text_box_list[3].Text;
      if(Int32.TryParse(s, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val))
      {
        retval = Validate(FuncVars.SLOPE_1, val);
      }
      if(retval == false)
      {
        // Restore original value;
        _text_box_list[3].Text = _trapezoidal_func.s1.ToString("X2");
      }
    }
    #endregion

    #region Public Methods
    /******************************************************************************/
    public void Build()
    {
    }

    // Implement IDisposable.
    public void Dispose()
    {
      Dispose(true);
      // This object will be cleaned up by the Dispose method.
      // Therefore, you should call GC.SupressFinalize to
      // take this object off the finalization queue 
      // and prevent finalization code for this object
      // from executing a second time.
      GC.SuppressFinalize(this);
    }

    // Dispose(bool disposing) executes in two distinct scenarios.
    // If disposing equals true, the method has been called directly
    // or indirectly by a user's code. Managed and unmanaged resources
    // can be disposed.
    // If disposing equals false, the method has been called by the 
    // runtime from inside the finalizer and you should not reference 
    // other objects. Only unmanaged resources can be disposed.
    private void Dispose(bool disposing)
    {
      // Check to see if Dispose has already been called.
      if(!this.disposed)
      {
        // If disposing equals true, dispose all managed 
        // and unmanaged resources.
        if(disposing)
        {
          // Dispose managed resources.
          _text_box_list.Clear();
          _text_box_list = null;
        }
        // Call the appropriate methods to clean up 
        // unmanaged resources here.
        // If disposing is false, 
        // only the following code is executed.
      }
      disposed = true;
    }
    #endregion

    #region Private Methods
    /******************************************************************************/
    private bool IsHexByte(string str)
    {
      Regex r = new Regex(@"^[A-Fa-f0-9]{1,2}$");
      string s = r.Match(str).Value;
      return (s.Equals(string.Empty)) ? false : true;
    }

    private bool SetText(FuzzyMemFuncs.TrapezoidalFunc func)
    {
      int pt0_top, pt1_top;
      if((int)func.p0 >= (int)func.p1)
      {
        return false;
      }

      pt0_top = (int)func.p0;
      if(func.s0 != 0)
      {
        pt0_top += (0xFF / (int)func.s0);
      }

      pt1_top = (int)func.p1;
      if(func.s1 != 0)
      {
        pt1_top -= (0xFF / (int)func.s1);
      }

      if(pt0_top > pt1_top)
      {
        return false;
      }

      _text_box_list[0].TextChanged -= new EventHandler(p0_TextChanged);
      _text_box_list[0].Text = func.p0.ToString("X2");
      _text_box_list[0].SelectionStart = _text_box_list[0].Text.Length;
      _text_box_list[0].TextChanged += new EventHandler(p0_TextChanged);
      _text_box_list[0].LostFocus += new EventHandler(p0_LostFocus);
      _text_box_list[0].Enabled = _enabled;

      _text_box_list[1].TextChanged -= new EventHandler(p1_TextChanged);
      _text_box_list[1].Text = func.p1.ToString("X2");
      _text_box_list[1].SelectionStart = _text_box_list[1].Text.Length;
      _text_box_list[1].TextChanged += new EventHandler(p1_TextChanged);
      _text_box_list[1].LostFocus += new EventHandler(p1_LostFocus);
      _text_box_list[1].Enabled = _enabled;

      _text_box_list[2].TextChanged -= new EventHandler(s0_TextChanged);
      _text_box_list[2].Text = func.s0.ToString("X2");
      _text_box_list[2].SelectionStart = _text_box_list[2].Text.Length;
      _text_box_list[2].TextChanged += new EventHandler(s0_TextChanged);
      _text_box_list[2].LostFocus += new EventHandler(s0_LostFocus);
      _text_box_list[2].Enabled = _enabled;

      _text_box_list[3].TextChanged -= new EventHandler(s1_TextChanged);
      _text_box_list[3].Text = func.s1.ToString("X2");
      _text_box_list[3].SelectionStart = _text_box_list[3].Text.Length;
      _text_box_list[3].TextChanged += new EventHandler(s1_TextChanged);
      _text_box_list[3].LostFocus += new EventHandler(s1_LostFocus);
      _text_box_list[3].Enabled = _enabled;

      return true;
    }
    private Boolean Validate(FuncVars var, int value)
    {
      //MsgBox.Show(_container, var.ToString() + ":" + value.ToString("X2"));
      if(value >= 0 && value < 0x100)
      {
        int pt0_top, pt1_top;
        switch(var)
        {
          case FuncVars.POINT_0:
            //Test pt0 < pt1
            if(value >= _trapezoidal_func.p1)
            {
              MsgBox.Show("Invalid Point1 position (must be < Point2)");
              return false;
            }
            // If not veritical line (infinite slope => _trapezoidal_func.s0 = 0) test 
            // ..intersection with right side of trapezoid is above or at 0xFF
            if(_trapezoidal_func.s0 > 0)
            {
              //Test Slope intersection
              pt0_top = (0xFF / (int)_trapezoidal_func.s0) + value;
              if(_trapezoidal_func.s1 > 0)
              {
                pt1_top = (int)_trapezoidal_func.p1 - (0xFF / (int)_trapezoidal_func.s1);
              }
              else
              {
                // infinite slope
                pt1_top = (int)_trapezoidal_func.p1;
              }
              if(pt0_top > pt1_top)
              {
                MsgBox.Show("Invalid Point1 position (slope intersection below 0xFF)");
                return false;
              }
            }
            _trapezoidal_func.p0 = (byte)value;
            break;
          case FuncVars.POINT_1:
            //Test pt1 > pt0
            if(value <= _trapezoidal_func.p0)
            {
              MsgBox.Show("Invalid Point2 position (must be > Point1)");
              return false;
            }
            // If not vertical line (infinite slope => _trapezoidal_func.s0 = 0) test 
            // ..intersection with left side of trapezoid is above or at 0xFF
            if(_trapezoidal_func.s1 > 0)
            {
              //Test Slope intersection
              if(_trapezoidal_func.s0 > 0)
              {
                pt0_top = (0xFF / (int)_trapezoidal_func.s0) + (int)_trapezoidal_func.p0;
              }
              else
              {
                // infinite slope
                pt0_top = (int)_trapezoidal_func.p0;
              }
              pt1_top = value - (0xFF / (int)_trapezoidal_func.s1);
              if(pt0_top > pt1_top)
              {
                MsgBox.Show("Invalid Point2 position (slope intersection below 0xFF)");
                return false;
              }
            }
            _trapezoidal_func.p1 = (byte)value;
            break;
          case FuncVars.SLOPE_0:
            // If not veritical line (infinite slope => _trapezoidal_func.s0 = 0) test 
            // ..intersection with right side of trapezoid is above or at 0xFF
            if(value > 0)
            {
              //Test Slope intersection
              pt0_top = (0xFF / value) + (int)_trapezoidal_func.p0;
              if(_trapezoidal_func.s1 > 0)
              {
                pt1_top = (int)_trapezoidal_func.p1 - (0xFF / (int)_trapezoidal_func.s1);
              }
              else
              {
                // infinite slope
                pt1_top = (int)_trapezoidal_func.p1;
              }
              if(pt0_top > pt1_top)
              {
                MsgBox.Show("Invalid Slope1 (intersection with Slope2 below 0xFF)");
                return false;
              }
            }
            _trapezoidal_func.s0 = (byte)value;
            break;
          case FuncVars.SLOPE_1:
            // If not veritical line (infinite slope => _trapezoidal_func.s0 = 0) test 
            // ..intersection with left side of trapezoid is above or at 0xFF
            if(value > 0)
            {
              //Test Slope intersection
              if(_trapezoidal_func.s0 > 0)
              {
                pt0_top = (0xFF / (int)_trapezoidal_func.s0) + (int)_trapezoidal_func.p0;
              }
              else
              {
                // infinite slope
                pt0_top = (int)_trapezoidal_func.p0;
              }
              pt1_top = (int)_trapezoidal_func.p1 - (0xFF / value);
              if(pt0_top > pt1_top)
              {
                MsgBox.Show("Invalid Slope2 (intersection with Slope1 below 0xFF)");
                return false;
              }
            }
            _trapezoidal_func.s1 = (byte)value;
            break;
        }
        _handler(_index, _trapezoidal_func);
        return true;
      }
      return false;
    }
    #endregion
  }
}
