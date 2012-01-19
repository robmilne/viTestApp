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
using System.Drawing.Imaging;
using viServoMaster;
#endregion

namespace viTestApp
{
  public class FuzzyMemFuncs : IDisposable
  {
    #region Constants
    /******************************************************************************/
    private const int LOC_POS_TOP = 35;
    private const int LOC_SPD_TOP = 165;
    private const int LOC_OUT_TOP = 295;
    private const int LOC_LEFT = 120;

    private const int LABEL_LEFT = 65;
    private const int LABEL_WIDTH = 54;
    private const int LABEL_HEIGHT = 12;

    private const int TB_WIDTH = 20;
    private const int TB_HEIGHT = 20;

    // 2 pixel padding + 2 pixel border
    private const int BM_WIDTH = 132;
    // 2 pixel border
    private const int BM_HEIGHT = 66;
    private const int BM_LEFT = 227;
    #endregion

    #region Struct
    /******************************************************************************/
    public struct TrapezoidalFunc
    {
      public byte p0, p1, s0, s1;
      public TrapezoidalFunc(byte point_0, byte point_1, byte slope_0, byte slope_1) 
      {
        p0 = point_0;
        p1 = point_1;
        s0 = slope_0;
        s1 = slope_1;
      }
      public TrapezoidalFunc(byte[] arr, int index)
      {
        p0 = arr[index];
        p1 = arr[index + 1];
        s0 = arr[index + 2];
        s1 = arr[index + 3];
      }
    }
    #endregion

    #region Private Variables
    /******************************************************************************/
    // Container inside which Fuzzy membership rule objects are dynamically created. 
    // Method of determining container is manual drill down through controls inside 
    // ..MainForm() constructor.
    private GroupBox _container = null;

    private byte[] _pos_mf_array;
    private byte[] _spd_mf_array;
    private byte[] _out_singleton_array;

    private Dictionary<int, FuzzyMemFunc> _pos_funcs_ht = null;
    private Dictionary<int, FuzzyMemFunc> _spd_funcs_ht = null;
    private List<TextBox> _output_text_box_list = null;

    private bool _enable_mem_funcs = true;

    private PictureBox _picBxPosErr = null;
    private PictureBox _picBxSpd = null;
    private PictureBox _picBxOutput = null;

    // Track whether Dispose has been called.
    private bool disposed = false;
    #endregion

    #region Public Properties
    /******************************************************************************/
    public byte[] PosMembershipFunctionArray
    {
      set
      {
        if(value.Length.Equals(Slave.MF_5_SIZE))
        {
          _pos_mf_array = new byte[Slave.MF_5_SIZE];
          _pos_mf_array = value;
        }
        else
        {
          _pos_mf_array = null;
        }
      }
      get { return _pos_mf_array; }
    }
    public byte[] SpdMembershipFunctionArray
    {
      set
      {
        if(value.Length.Equals(Slave.MF_5_SIZE))
        {
          _spd_mf_array = new byte[Slave.MF_5_SIZE];
          _spd_mf_array = value;
        }
        else
        {
          _spd_mf_array = null;
        }
      }
      get { return _spd_mf_array; }
    }
    public byte[] OutSingletonArray
    {
      set
      {
        if(value.Length.Equals(Slave.OUT_SNGLTN_SIZE))
        {
          _out_singleton_array = new byte[Slave.OUT_SNGLTN_SIZE];
          _out_singleton_array = value;
        }
        else
        {
          _out_singleton_array = null;
        }
      }
      get { return _out_singleton_array; }
    }

    public bool CtlPtsActive
    {
      set 
      { 
        _enable_mem_funcs = value;
        this.Enable(_enable_mem_funcs);
      }
      get { return _enable_mem_funcs; }
    }
    #endregion

    #region Constructors
    /******************************************************************************/
    public FuzzyMemFuncs(GroupBox container)
    {
      _container = container;

      // Create fuzzy membership function and output singleton arrays
      _pos_mf_array = new byte[Slave.MF_5_SIZE];
      _spd_mf_array = new byte[Slave.MF_5_SIZE];
      _out_singleton_array = new byte[Slave.OUT_SNGLTN_SIZE];

      _pos_funcs_ht = new Dictionary<int, FuzzyMemFunc>();
      _spd_funcs_ht = new Dictionary<int, FuzzyMemFunc>();
      _output_text_box_list = new List<TextBox>();
    }

    // Use C# destructor syntax for finalization code.
    // This destructor will run only if the Dispose method 
    // does not get called.
    // It gives your base class the opportunity to finalize.
    // Do not provide destructors in types derived from this class.
    ~FuzzyMemFuncs()      
    {
        // Do not re-create Dispose clean-up code here.
        // Calling Dispose(false) is optimal in terms of
        // readability and maintainability.
        Dispose(false);
    }
    #endregion

    #region EventHandler
    /******************************************************************************/
    // out0
    public void out0_TextChanged(object sender, EventArgs e)
    {
      if(!IsHexByte(_output_text_box_list[0].Text))
      {
        // Restore original value;
        _output_text_box_list[0].Text = _out_singleton_array[0].ToString("X2");
      }
    }
    public void out0_LostFocus(object sender, EventArgs e)
    {
      int val;
      string s = _output_text_box_list[0].Text;
      if(Int32.TryParse(s, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val))
      {
        if(val <= _out_singleton_array[1])
        {
          _out_singleton_array[0] = (byte)val;
          _output_text_box_list[0].Text = val.ToString("X2");
          //_picBxOutput.Image = DrawOutputGraph();
          _picBxOutput.Image = ResizeImage(DrawOutputGraph(), BM_WIDTH, BM_HEIGHT);
          return;
        }
      }
      // Restore original value;
      _output_text_box_list[0].Text = _out_singleton_array[0].ToString("X2");
    }

    // out1
    private void out1_TextChanged(object sender, EventArgs e)
    {
      if(!IsHexByte(_output_text_box_list[1].Text))
      {
        _output_text_box_list[1].Text = _out_singleton_array[1].ToString("X2");
      }
    }
    public void out1_LostFocus(object sender, EventArgs e)
    {
      int val;
      string s = _output_text_box_list[1].Text;
      if(Int32.TryParse(s, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val))
      {
        if(val <= _out_singleton_array[2] && val >= _out_singleton_array[0])
        {
          _out_singleton_array[1] = (byte)val;
          _output_text_box_list[1].Text = val.ToString("X2");
          //_picBxOutput.Image = DrawOutputGraph();
          _picBxOutput.Image = ResizeImage(DrawOutputGraph(), BM_WIDTH, BM_HEIGHT);
          return;
        }
      }
      // Restore original value;
      _output_text_box_list[1].Text = _out_singleton_array[1].ToString("X2");
    }

    // out2
    private void out2_TextChanged(object sender, EventArgs e)
    {
      if(!IsHexByte(_output_text_box_list[2].Text))
      {
        _output_text_box_list[2].Text = _out_singleton_array[2].ToString("X2");
      }
    }
    public void out2_LostFocus(object sender, EventArgs e)
    {
      int val;
      string s = _output_text_box_list[2].Text;
      if(Int32.TryParse(s, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val))
      {
        if(val <= _out_singleton_array[3] && val >= _out_singleton_array[1])
        {
          _out_singleton_array[2] = (byte)val;
          _output_text_box_list[2].Text = val.ToString("X2");
          //_picBxOutput.Image = DrawOutputGraph();
          _picBxOutput.Image = ResizeImage(DrawOutputGraph(), BM_WIDTH, BM_HEIGHT);
          return;
        }
      }
      // Restore original value;
      _output_text_box_list[2].Text = _out_singleton_array[2].ToString("X2");
    }

    //out3
    private void out3_TextChanged(object sender, EventArgs e)
    {
      if(!IsHexByte(_output_text_box_list[3].Text))
      {
        _output_text_box_list[3].Text = _out_singleton_array[3].ToString("X2");
      }
    }
    public void out3_LostFocus(object sender, EventArgs e)
    {
      int val;
      string s = _output_text_box_list[3].Text;
      if(Int32.TryParse(s, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val))
      {
        if(val <= _out_singleton_array[4] && val >= _out_singleton_array[2])
        {
          _out_singleton_array[3] = (byte)val;
          _output_text_box_list[3].Text = val.ToString("X2");
          //_picBxOutput.Image = DrawOutputGraph();
          _picBxOutput.Image = ResizeImage(DrawOutputGraph(), BM_WIDTH, BM_HEIGHT);
          return;
        }
      }
      // Restore original value;
      _output_text_box_list[3].Text = _out_singleton_array[3].ToString("X2");
    }

    //out4
    private void out4_TextChanged(object sender, EventArgs e)
    {
      if(!IsHexByte(_output_text_box_list[4].Text))
      {
        _output_text_box_list[4].Text = _out_singleton_array[4].ToString("X2");
      }
    }
    public void out4_LostFocus(object sender, EventArgs e)
    {
      int val;
      string s = _output_text_box_list[4].Text;
      if(Int32.TryParse(s, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val))
      {
        if(val >= _out_singleton_array[3])
        {
          _out_singleton_array[4] = (byte)val;
          _output_text_box_list[4].Text = val.ToString("X2");
          //_picBxOutput.Image = DrawOutputGraph();
          _picBxOutput.Image = ResizeImage(DrawOutputGraph(), BM_WIDTH, BM_HEIGHT);
          return;
        }
      }
      // Restore original value;
      _output_text_box_list[4].Text = _out_singleton_array[4].ToString("X2");
    }

    #endregion

    #region Public Methods
    /******************************************************************************/
    public void Build()
    {
      if(_pos_mf_array != null && _spd_mf_array != null && _out_singleton_array != null)
      {
        // pos has 5 trapezoidal functions consisting of 4 bytes
        for(int i = 0; i < (_pos_mf_array.Length / 4); i++)
        {
          FuzzyMemFunc pos_mem_func;
          // Programmatically create FuzzyMemFunc objects if not already existent
          if(_pos_funcs_ht.ContainsKey(i))
          {
            pos_mem_func = _pos_funcs_ht[i];
          }
          else
          {
            pos_mem_func = new FuzzyMemFunc(_container, Strings.fuzzyPosRuleStrings[i], i, LOC_POS_TOP, LOC_LEFT, UpdatePosFuncs);
            _pos_funcs_ht.Add(i, pos_mem_func);
          }

          // TrapezoidalFunc struct uses 4 consecutive elements from byte array
          TrapezoidalFunc pos_trap_func = new TrapezoidalFunc(_pos_mf_array, 4 * i);
          pos_mem_func.TrapezoidalFunc = pos_trap_func;
        }
        if(_picBxPosErr == null)
        {
          _picBxPosErr = new PictureBox();
          _picBxPosErr.Size = new Size(BM_WIDTH, BM_HEIGHT);
          _picBxPosErr.Location = new Point(BM_LEFT, LOC_POS_TOP);
          _picBxPosErr.BorderStyle = BorderStyle.FixedSingle;
          _container.Controls.Add(_picBxPosErr);
        }
        // Resize the graph width by .5 to fit in UI
        //_picBxPosErr.Image = DrawPosGraph();
        _picBxPosErr.Image = ResizeImage(DrawPosGraph(), BM_WIDTH, BM_HEIGHT);

        // spd has 5 trapezoidal functions consisting of 4 bytes
        for(int i = 0; i < (_spd_mf_array.Length / 4); i++)
        {
          FuzzyMemFunc spd_mem_func;

          // Programmatically create FuzzyMemFunc objects if not extant
          if(_spd_funcs_ht.ContainsKey(i))
          {
            spd_mem_func = _spd_funcs_ht[i];
          }
          else
          {
            spd_mem_func = new FuzzyMemFunc(_container, Strings.fuzzyPosRuleStrings[i + 5], i, LOC_SPD_TOP, LOC_LEFT, UpdateSpdFuncs);
            _spd_funcs_ht.Add(i, spd_mem_func);
          }

          // TrapezoidalFunc struct uses 4 consecutive elements from byte array
          TrapezoidalFunc spd_trap_func = new TrapezoidalFunc(_spd_mf_array, 4 * i);
          spd_mem_func.TrapezoidalFunc = spd_trap_func;
        }
        if(_picBxSpd == null)
        {
          _picBxSpd = new PictureBox();
          _picBxSpd.Size = new Size(BM_WIDTH, BM_HEIGHT);
          _picBxSpd.Location = new Point(BM_LEFT, LOC_SPD_TOP);
          _picBxSpd.BorderStyle = BorderStyle.FixedSingle;
          _container.Controls.Add(_picBxSpd);
        }
        //_picBxSpd.Image = DrawSpdGraph();
        _picBxSpd.Image = ResizeImage(DrawSpdGraph(), BM_WIDTH, BM_HEIGHT);

        // Programmatically build controls to hold output singleton values
        Font f_reg = new Font("Microsoft Sans Serif", 7);
        for(int i = 0; i < _out_singleton_array.Length; i++)
        {
          if(_output_text_box_list.Count < i + 1)
          {
            Label lbl = new Label();
            lbl.Font = f_reg;
            lbl.Location = new Point(LABEL_LEFT, LOC_OUT_TOP + (TB_HEIGHT * i) + 2);
            lbl.AutoSize = false;
            lbl.RightToLeft = RightToLeft.Yes;
            lbl.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            lbl.Text = Strings.fuzzyPosRuleStrings[i + 10];
            _container.Controls.Add(lbl);

            TextBox tb = new TextBox();
            tb.Font = f_reg;
            tb.Size = new Size(TB_WIDTH, TB_HEIGHT);
            tb.Location = new Point(LOC_LEFT, LOC_OUT_TOP + (TB_HEIGHT * i));
            _container.Controls.Add(tb);
            _output_text_box_list.Add(tb);
          }
        }
        if(_picBxOutput == null)
        {
          _picBxOutput = new PictureBox();
          _picBxOutput.Size = new Size(BM_WIDTH, BM_HEIGHT);
          _picBxOutput.Location = new Point(BM_LEFT, LOC_OUT_TOP);
          _picBxOutput.BorderStyle = BorderStyle.FixedSingle;
          _container.Controls.Add(_picBxOutput);
        }
        if(SetOutputText())
        {
          //_picBxOutput.Image = DrawOutputGraph();
          _picBxOutput.Image = ResizeImage(DrawOutputGraph(), BM_WIDTH, BM_HEIGHT);
        }

        this.Enable(_enable_mem_funcs);
      }
      else
      {
        MsgBox.Show("Membership Function arrays are not initialized");
      }
    }

    public void Enable(bool is_enable)
    {
      if(_pos_funcs_ht != null && _pos_funcs_ht.Count > 0)
      {
        Dictionary<int, FuzzyMemFunc>.ValueCollection valueColl = _pos_funcs_ht.Values;
        foreach(FuzzyMemFunc func in valueColl)
        {
          func.Enable = is_enable;
        }
      }
      if(_spd_funcs_ht != null && _spd_funcs_ht.Count > 0)
      {
        Dictionary<int, FuzzyMemFunc>.ValueCollection valueColl = _spd_funcs_ht.Values;
        foreach(FuzzyMemFunc func in valueColl)
        {
          func.Enable = is_enable;
        }
      }
      if(_output_text_box_list != null && _output_text_box_list.Count > 0)
      {
        foreach(TextBox tbx in _output_text_box_list)
        {
          tbx.Enabled = is_enable;
        }
      }
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
          if(_pos_funcs_ht != null)
          {
            if(_pos_funcs_ht.Count > 0)
            {
              for(int i = 0; i < _pos_funcs_ht.Count; i++)
              {
                FuzzyMemFunc func = _pos_funcs_ht[i];
                func.Dispose();
              }
              _pos_funcs_ht.Clear();
            }
            _pos_funcs_ht = null;
          }
          if(_spd_funcs_ht != null)
          {
            if(_spd_funcs_ht.Count > 0)
            {
              for(int i = 0; i < _spd_funcs_ht.Count; i++)
              {
                FuzzyMemFunc func = _spd_funcs_ht[i];
                func.Dispose();
              }
              _spd_funcs_ht.Clear();
            }
            _spd_funcs_ht = null;
          }
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

    /// <summary>
    /// Callback function to update _pos_mf_array from position FuzzyMemFunc
    /// </summary>
    private void UpdatePosFuncs(int index, FuzzyMemFuncs.TrapezoidalFunc func)
    {
      _pos_mf_array[0 + (index * 4)] = func.p0;
      _pos_mf_array[1 + (index * 4)] = func.p1;
      _pos_mf_array[2 + (index * 4)] = func.s0;
      _pos_mf_array[3 + (index * 4)] = func.s1;
      if(_picBxPosErr != null)
      {
        //_picBxPosErr.Image = DrawPosGraph();
        _picBxPosErr.Image = ResizeImage(DrawPosGraph(), BM_WIDTH, BM_HEIGHT);
      }
    }
    /// <summary>
    /// Callback function to update _spd_mf_array from speed FuzzyMemFunc
    /// </summary>
    private void UpdateSpdFuncs(int index, FuzzyMemFuncs.TrapezoidalFunc func)
    {
      _spd_mf_array[0 + (index * 4)] = func.p0;
      _spd_mf_array[1 + (index * 4)] = func.p1;
      _spd_mf_array[2 + (index * 4)] = func.s0;
      _spd_mf_array[3 + (index * 4)] = func.s1;
      if(_picBxSpd != null)
      {
        //_picBxSpd.Image = DrawSpdGraph();
        _picBxSpd.Image = ResizeImage(DrawSpdGraph(), BM_WIDTH, BM_HEIGHT);
      }
    }

    private Bitmap DrawPosGraph()
    {
      return DrawMemFuncGraph(_pos_mf_array, LOC_POS_TOP);
    }
    private Bitmap DrawSpdGraph()
    {
      return DrawMemFuncGraph(_spd_mf_array, LOC_SPD_TOP);
    }
    private Bitmap DrawMemFuncGraph(byte[] mf_array, int top)
    {
      Graphics g;
      Pen p;
      Bitmap bitmap = new Bitmap(BM_WIDTH * 2, BM_HEIGHT);
      g = Graphics.FromImage(bitmap);
      g.Clear(System.Drawing.Color.White);
      p = new Pen(Color.LightGray);
      //g.DrawLine(p, 130, 1, 130, BM_HEIGHT - 1);
      g.DrawLine(p, BM_WIDTH, 1, BM_WIDTH, BM_HEIGHT - 1);
      p.Color = Color.Red;

      // pos has 5 trapezoidal functions consisting of 4 bytes
      TrapezoidalFunc trap_func;
      for(int i = 0; i < (mf_array.Length / 4); i++)
      {
        // TrapezoidalFunc struct uses 4 consecutive elements from byte array
        trap_func = new TrapezoidalFunc(mf_array, 4 * i);
        
        // Draw trapezoid
        DrawTrapezoid(g, p, i, trap_func);
      }

      g.Dispose();
      p.Dispose();

      return bitmap;
    }
    private void DrawTrapezoid(Graphics g, Pen p, int index, TrapezoidalFunc trap_func)
    {
      int tmp0, tmp1;

      // Add 2 for border + padding
      if(index == 0)
      {
        tmp1 = (int)trap_func.p1 - (0xFF / (int)trap_func.s1);
        g.DrawLine(p, tmp1 + 2, 1, (int)trap_func.p1 + 2, BM_HEIGHT - 1);
        g.DrawLine(p, 1, 1, tmp1 + 2, 1);
      }
      else if(index == 4)
      {
        tmp1 = (int)trap_func.p0 + (0xFF / (int)trap_func.s0);
        g.DrawLine(p, tmp1 + 2, 1, (int)trap_func.p0 + 2, BM_HEIGHT - 1);
        g.DrawLine(p, tmp1 + 2, 1, 0xFF + 1, 1);
      }
      else
      {
        tmp0 = (int)trap_func.p0 + (0xFF / (int)trap_func.s0);
        g.DrawLine(p, tmp0 + 2, 1, (int)trap_func.p0 + 2, BM_HEIGHT - 1);
        tmp1 = (int)trap_func.p1 - (0xFF / (int)trap_func.s1);
        g.DrawLine(p, tmp1 + 2, 1, (int)trap_func.p1 + 2, BM_HEIGHT - 1);
        g.DrawLine(p, tmp0 + 2, 1, tmp1 + 2, 1);
      }
    }

    private Bitmap DrawOutputGraph()
    {
      Graphics g;
      Pen p;
      Bitmap bitmap = new Bitmap(BM_WIDTH * 2, BM_HEIGHT);
      g = Graphics.FromImage(bitmap);
      g.Clear(System.Drawing.Color.White);
      p = new Pen(Color.LightGray);
      g.DrawLine(p, BM_WIDTH, 1, BM_WIDTH, 65);
      p.Color = Color.Red;

      // Add 2 for border + padding
      for(int i = 0; i < _out_singleton_array.Length; i++)
      {
        g.DrawLine(p, _out_singleton_array[i] + 2, 1, _out_singleton_array[i] + 2, 65);
      }

      g.Dispose();
      p.Dispose();

      return bitmap;
    }

    private Bitmap ResizeImage(Image image, int width, int height)
    {
      Bitmap bitmap = new Bitmap(width, height);

      //use a graphics object to draw the resized image into the bitmap
      using(Graphics g = Graphics.FromImage(bitmap))
      {
        //set the resize quality modes to high quality
        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //draw the image into the target bitmap
        g.DrawImage(image, 0, 0, bitmap.Width, bitmap.Height);
      }

      //return the resulting bitmap
      return bitmap;
    } 

    private bool SetOutputText()
    {
      if(_output_text_box_list.Count == 5 &&
         (int)_out_singleton_array[0] <= (int)_out_singleton_array[1] &&
         (int)_out_singleton_array[1] <= (int)_out_singleton_array[2] &&
         (int)_out_singleton_array[2] <= (int)_out_singleton_array[3] &&
         (int)_out_singleton_array[3] <= (int)_out_singleton_array[4] &&
         (int)_out_singleton_array[4] < unchecked((int)256))
      {
        _output_text_box_list[0].TextChanged -= new EventHandler(out0_TextChanged);
        _output_text_box_list[0].Text = _out_singleton_array[0].ToString("X2");
        _output_text_box_list[0].TextChanged += new EventHandler(out0_TextChanged);
        _output_text_box_list[0].LostFocus += new EventHandler(out0_LostFocus);

        _output_text_box_list[1].TextChanged -= new EventHandler(out1_TextChanged);
        _output_text_box_list[1].Text = _out_singleton_array[1].ToString("X2");
        _output_text_box_list[1].TextChanged += new EventHandler(out1_TextChanged);
        _output_text_box_list[1].LostFocus += new EventHandler(out1_LostFocus);

        _output_text_box_list[2].TextChanged -= new EventHandler(out2_TextChanged);
        _output_text_box_list[2].Text = _out_singleton_array[2].ToString("X2");
        _output_text_box_list[2].TextChanged += new EventHandler(out2_TextChanged);
        _output_text_box_list[2].LostFocus += new EventHandler(out2_LostFocus);

        _output_text_box_list[3].TextChanged -= new EventHandler(out3_TextChanged);
        _output_text_box_list[3].Text = _out_singleton_array[3].ToString("X2");
        _output_text_box_list[3].TextChanged += new EventHandler(out3_TextChanged);
        _output_text_box_list[3].LostFocus += new EventHandler(out3_LostFocus);

        _output_text_box_list[4].TextChanged -= new EventHandler(out4_TextChanged);
        _output_text_box_list[4].Text = _out_singleton_array[4].ToString("X2");
        _output_text_box_list[4].TextChanged += new EventHandler(out4_TextChanged);
        _output_text_box_list[4].LostFocus += new EventHandler(out4_LostFocus);

        return true;
      }
      else
      {
        MsgBox.Show("Output singleton array is invalid");
        return false;
      }
    }

    /// <summary>
    /// SetOutputMembershipFunction
    /// Function to create output singleton array from 2 control points
    /// </summary>
    private byte[] SetOutputMembershipFunction(int ctlPointA, int ctlPointB)
    {
      byte negA, negB;
      byte[] table = new byte[Slave.OUT_SNGLTN_SIZE];
      // Middle value (no voltage) is always centre of range
      table[2] = 0x80;

      // Control point A
      table[0] = (byte)ctlPointA;

      negA = (byte)(0xFF - (byte)ctlPointA);
      if(negA < 0xFF)
        // Add one to make output singletons symmetric at 0x80
        negA++;
      table[4] = negA;

      // Control point B
      table[1] = (byte)ctlPointB;

      negB = (byte)(0xFF - (byte)ctlPointB);
      if(negB < 0xFF)
        // Add one to make output singletons symmetric at 0x80
        negB++;
      table[3] = negB;

      return table;
    }

    /// <summary>
    /// Set5ptMembershipFunction
    /// Function to create 5x5 membership function array from 2 control points
    /// </summary>
    private byte[] Set5ptMembershipFunction(int ctlPointA, int ctlPointB)
    {
      byte negA, negB, slopeA, slopeB;
      double slA, slB;

      // Position and Speed membership functions 1&5, 2&4 and 3 are symmetric about centre (0x80)
      byte[] table = new byte[Slave.MF_5_SIZE];
      // func_1 point_1 starts at 0
      table[0] = 0x0;
      // func_2 point_2 & func_4 point_1 at centre
      table[5] = table[12] = 0x80;
      // func_5 point_2 ends at 0xFF
      table[17] = 0xFF;
      // func_2 point_1
      table[4] = (byte)ctlPointA;
      // func_4 point_1 is symmetric about 0x80
      negA = (byte)(0xFF - (byte)ctlPointA);
      if(negA < 0xFF)
        // Add one to make membership rules symmetric at 0x80
        negA++;
      table[13] = negA;
      // func_2 point_2
      table[1] = table[8] = (byte)ctlPointB;
      // func_4 point_2 is symmetric about 0x80
      negB = (byte)(0xFF - (byte)ctlPointB);
      if(negB < 0xFF)
        // Add one to make membership rules symmetric at 0x80
        negB++;
      table[9] = table[16] = negB;

      // func_1 slope_1 & func_5 slope_2
      table[2] = table[19] = 0x0;

      // func_1 slope_2, func_2 slope_1, func_4 slope_2, func_5 slope_1
      // Round to 2 decimal points
      slA = Math.Round((double)(0xFF / (double)(ctlPointB - ctlPointA)), 2);
      slopeA = (byte)(0xFF / (byte)(ctlPointB - ctlPointA));
      // Add one to normalize slope if fractional component (integer math truncates)
      if((slA - (double)slopeA > 0.0) && slopeA < 0xFF)
        slopeA++;
      table[3] = table[6] = table[15] = table[18] = slopeA;

      // func_2 slope_2, func_3 slope_1, func_3 slope_2, func_4 slope_1
      // Round to 2 decimal points
      slB = Math.Round((double)(0xFF / (double)(0x80 - ctlPointB)), 2);
      slopeB = (byte)(0xFF / (byte)(0x80 - ctlPointB));
      // Add one to normalize slope if fractional component (integer math truncates)
      if((slB - (double)slopeB > 0.0) && slopeB < 0xFF)
        slopeB++;
      table[7] = table[10] = table[11] = table[14] = slopeB;
      return table;
    }

    #endregion
  }
}
