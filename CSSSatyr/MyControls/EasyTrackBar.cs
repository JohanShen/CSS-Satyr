using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace CSSSatyr.MyControls
{
    public delegate void ValueChangeHandler<T>(T e) where T : EventArgs;
    /// <summary>
    /// @author : JohanShen
    /// @date : 2016/12/06
    /// </summary>
    [DefaultEvent("ValueChanged")]
    public class EasyTrackBar : Control
    {
        /// <summary>
        /// 拖动控件
        /// </summary>
        //TODO: 要更改控件为GDI绘制方式
        private Control _bar = new Control();
        private Point mouseOffset = new Point(0, 0), nowPoint = new Point(0);
        private int _barMinX = 0, _barMaxX = 0;
        private int _oldWidth = 0, _oldHeight = 0;
        public EasyTrackBar()
        {
            /*
            //_bar.Visible = false;
            _bar.MouseDown += new MouseEventHandler(Bar_MouseDown);
            _bar.MouseUp += new MouseEventHandler(Bar_MouseUp);
            _bar.MouseMove += new MouseEventHandler(Bar_MouseMove);
            this.Controls.Add(_bar);
            */
            base.MouseDown += new MouseEventHandler(EasyTrackBar_MouseDown);
            base.MouseUp += new MouseEventHandler(EasyTrackBar_MouseUp);
            base.MouseMove += new MouseEventHandler(EasyTrackBar_MouseMove);
            _borderStyle = new BorderStyle() { Color = SystemColors.ControlDark, Width = 0 };
            _barStyle = new BarStyle() { Width = 15, Color = SystemColors.ControlDark, ClickColor = Color.Blue, BorderStyle = new BorderStyle() { Width = 0, Color = SystemColors.ControlDarkDark } };
            _progressBarStyle = new ProgressBarStyle() { BackColor = SystemColors.InactiveCaption, BorderStyle = new BorderStyle() { Width = 1, Color = SystemColors.ControlDarkDark } };
        }

        private void EasyTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            var ctrl = sender as Control;
            if (ctrl != null && MouseButtons.Left == e.Button)
            {
                mouseOffset = new Point(-e.X, -e.Y);
                //ctrl.BackColor = BarClickColor;
            }
        }

        private void EasyTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void EasyTrackBar_MouseMove(object sender, MouseEventArgs e)
        {
           // Console.WriteLine(String.Format("x {0}  y {1}", MousePosition.X, MousePosition.Y));
            var ctrl = sender as Control;
            if (ctrl != null && MouseButtons.Left == e.Button)
            {
                //Console.WriteLine(String.Format("min:{0} max {1} now {2}", _barMinX, _barMaxX, ctrl.Location.X));
                int _oldValue = _value;
                float _percent = 0f;
                if (nowPoint.X < _barMinX)
                {
                    //ctrl.Location = new Point(_barMinX, ctrl.Location.Y);
                    nowPoint = new Point(_barMinX, nowPoint.Y);
                    _value = _minValue;
                }
                else if (nowPoint.X > _barMaxX)
                {
                    //ctrl.Location = new Point(_barMaxX, ctrl.Location.Y);
                    nowPoint = new Point(_barMaxX, nowPoint.Y);
                    _value = _maxValue;
                    _percent = 100;
                }
                else
                {
                    Point mousePosition = Control.MousePosition;
                    mousePosition.Offset(mouseOffset);
                    Point point = this.PointToClient(mousePosition);
                    Console.WriteLine(String.Format("x {0}  y {1}", point.X, point.Y));
                    if (point.X < _barMinX)
                        point.X = _barMinX;
                    if (point.X > _barMaxX)
                        point.X = _barMaxX;
                    //ctrl.Location = new Point(point.X, ctrl.Location.Y);

                    nowPoint = new Point(point.X, nowPoint.Y);
                    if (point.X - _barMinX > 0)
                        _percent = (float)(point.X - _barMinX) / (_barMaxX - _barMinX);

                    _value = Convert.ToInt32(_percent * (_maxValue - _minValue)) + _minValue;

                    //Console.WriteLine(String.Format("value {0}", _value));
                }
                ValueChange(new EasyTrackBarValueChangedArgs() { OldValue = _oldValue, NewValue = _value, Percent = _percent });
                Invalidate();
            }
        }




        public event ValueChangeHandler<EasyTrackBarValueChangedArgs> ValueChanged;
        private void ValueChange(EasyTrackBarValueChangedArgs s)
        {
            ValueChanged?.Invoke(s);
        }


        private string text;
        [DefaultValue("")]
        public new string Text
        {
            get { return text; }
            set { text = value;
                Invalidate();
            }
        }

        private int _value = 0;
        public int Value
        {
            get { return _value; }
            set
            {
                if (value > _maxValue)
                {
                    value = _maxValue;
                }
                else if (value < _minValue)
                {
                    value = _minValue;
                }
                _value = value;
                updateBarLocationg();
                Invalidate();
            }
        }

        private int _minValue = 0;
        public int MinValue
        {
            get { return _minValue; }
            set
            {
                if (value > _maxValue)
                {
                    throw new Exception("MinValue 不能大于 MaxValue，且不能大于 Value");
                }
                _minValue = value;
                updateBarLocationg();
                Invalidate();
            }
        }

        private int _maxValue = 10;
        public int MaxValue
        {
            get { return _maxValue; }
            set
            {
                if (value < _minValue)
                {
                    throw new Exception("MinValue 不能大于 MaxValue，且不能小于 Value");
                }
                _maxValue = value; updateBarLocationg(); Invalidate();
            }
        }

        private bool _showValue = true;
        [Browsable(false)]
        public  bool ShowValue
        {
            get { return _showValue; }
            set { _showValue = value; Invalidate(); }
        }

        private BorderStyle _borderStyle;
        [Description("边框样式"), Category("外观")]
        public Color BorderColor
        {
            get { return _borderStyle.Color; }
            set { _borderStyle.Color = value; Invalidate(); }
        }
        
        public bool BorderWidth
        {
            get { return _borderStyle.Width>0; }
            set { _borderStyle.Width = value ? 1 : 0; Invalidate(); }
        }
        
        private BarStyle _barStyle;
        [Description("调节条样式"), Category("外观")]
        public Color BarColor
        {
            get { return _barStyle.Color; }
            set
            {
                _barStyle.Color = value;
                _bar.BackColor = BarColor; Invalidate();
            }
        }

        public int BarWidth
        {
            get { return _barStyle.Width; }
            set
            {
                _barStyle.Width = value;
                Invalidate();
            }
        }

        public Color BarClickColor
        {
            get { return _barStyle.ClickColor; }
            set { _barStyle.ClickColor = value; Invalidate(); }
        }

        public Color BarBorderColor
        {
            get { return _barStyle.BorderStyle.Color; }
            set { _barStyle.BorderStyle.Color = value; Invalidate(); }
        }
        
        public bool BarBorderWidth
        {
            get { return _barStyle.BorderStyle.Width>1; }
            set { _barStyle.BorderStyle.Width = value ? 1 : 0; Invalidate(); }
        }
        

        private ProgressBarStyle _progressBarStyle;
        [Description("刻度条背景色"), Category("外观")]
        public Color ProgressBarBackColor
        {
            get { return _progressBarStyle.BackColor; }
            set { _progressBarStyle.BackColor = value; Invalidate(); }
        }

        public Color ProgressBarBorderColor
        {
            get { return _progressBarStyle.BorderStyle.Color; }
            set { _progressBarStyle.BorderStyle.Color = value; Invalidate(); }
        }
        
        public bool ProgressBarBorderWidth
        {
            get { return _progressBarStyle.BorderStyle.Width > 0; }
            set { _progressBarStyle.BorderStyle.Width = value ? 1 : 0; Invalidate(); }
        }
        /*
        private void Bar_MouseUp(object sender, MouseEventArgs e)
        {
            var ctrl = sender as Control;
            if (ctrl != null && MouseButtons.Left == e.Button)
            {
                ctrl.BackColor = BarColor;
            }
        }
        private void Bar_MouseDown(object sender, MouseEventArgs e)
        {
            var ctrl = sender as Control;
            if (ctrl != null && MouseButtons.Left == e.Button)
            {
                mouseOffset = new Point(-e.X, -e.Y);
                ctrl.BackColor = BarClickColor;
            }
        }

        private void Bar_MouseMove(object sender, MouseEventArgs e)
        {
            var ctrl = sender as Control;
            if (ctrl != null && MouseButtons.Left == e.Button)
            {
                //Console.WriteLine(String.Format("min:{0} max {1} now {2}", _barMinX, _barMaxX, ctrl.Location.X));
                int _oldValue = _value;
                float _percent = 0f;
                if (ctrl.Location.X < _barMinX)
                {
                    ctrl.Location = new Point(_barMinX, ctrl.Location.Y);
                    _value = _minValue;
                }
                else if (ctrl.Location.X > _barMaxX)
                {
                    ctrl.Location = new Point(_barMaxX, ctrl.Location.Y);
                    _value = _maxValue;
                    _percent = 100;
                }
                else
                {
                    Point mousePosition = Control.MousePosition;
                    mousePosition.Offset(mouseOffset);
                    Point point = this.PointToClient(mousePosition);
                    if (point.X < _barMinX)
                        point.X = _barMinX;
                    if (point.X > _barMaxX)
                        point.X = _barMaxX;
                    ctrl.Location = new Point(point.X, ctrl.Location.Y);
                    if (point.X - _barMinX > 0)
                        _percent = (float)(point.X - _barMinX) / (_barMaxX - _barMinX);

                    _value = Convert.ToInt32(_percent * (_maxValue - _minValue)) + _minValue;

                    Console.WriteLine(String.Format("value {0}", _value));
                }
                ValueChange(new EasyTrackBarValueChangedArgs() { OldValue = _oldValue, NewValue = _value, Percent = _percent });
            }
        }
        */
        protected override void OnPaint(PaintEventArgs e)
        {
            float barHeight = Height / 4;
            float barWidth = 0;

            float barX = 0;
            float barY = (Height - barHeight) / 2 - _progressBarStyle.BorderStyle.Width * 2;

            float textWidth = 0;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //绘制文字
            if (String.IsNullOrEmpty(Text) == false)
            {
                SizeF fontSize = e.Graphics.MeasureString(Text, Font, 1000, StringFormat.GenericTypographic);
                textWidth = fontSize.Width + 5;
                e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), new PointF(0, (Height - fontSize.Height) / 2));
            }
            barWidth = Width - textWidth - Padding.Left - Padding.Right - _progressBarStyle.BorderStyle.Width * 2;
            barX = textWidth;

            //绘制刻度条
            if (_progressBarStyle.BorderStyle.Width > 0)
            {
                e.Graphics.DrawRectangle(new Pen(_progressBarStyle.BorderStyle.Color, _progressBarStyle.BorderStyle.Width), barX, barY, barWidth, barHeight);
            }
            e.Graphics.FillRectangle(new SolidBrush(_progressBarStyle.BackColor), new RectangleF(barX, barY, barWidth, barHeight));

            //绘制刻度数字
            if (_showValue)
            {
                int total = MaxValue - MinValue;

                //TODO: 完善刻度表的显示
                //e.Graphics.DrawString(MinValue.ToString(), Font, new SolidBrush(ForeColor), new PointF(barX, 0));
                //e.Graphics.DrawString(MaxValue.ToString(), Font, new SolidBrush(ForeColor), new PointF(Width - 12, 0));
            }

            _barMinX = Convert.ToInt32(barX-3);
            _barMaxX = Convert.ToInt32(barX + barWidth - _barStyle.Width +3);

            //设置调节条
            /*
            if (_oldWidth != Width || _oldHeight != Height)
            {
                _bar.Size = new Size(_barStyle.Width, Convert.ToInt32(Height - Height / 3) - Padding.Top - Padding.Bottom);
                _bar.Location = new Point(_barMinX, Convert.ToInt32(Math.Round((double)(Height - _bar.Height) / 3)) + Padding.Top);
                _oldWidth = Width;
                _oldHeight = Height;
            }*/
            //绘制调节条

            if (_oldWidth != Width || _oldHeight != Height)
            {
                _bar.Height = Convert.ToInt32(Height - Height / 3);
                nowPoint = new Point(_barMinX, Convert.ToInt32(Math.Round((double)(Height - _bar.Height) / 3)) + Padding.Top);
                _oldWidth = Width;
                _oldHeight = Height;
            }
            e.Graphics.FillRectangle(new SolidBrush(_barStyle.Color), nowPoint.X, nowPoint.Y, _barStyle.Width, _bar.Height - Padding.Top - Padding.Bottom);

            //Console.WriteLine(String.Format("x {0}  y {1}", nowPoint.X, nowPoint.Y));

            if (_borderStyle.Width > 0)
            {
                //绘制边框
                e.Graphics.DrawRectangle(new Pen(_borderStyle.Color, _borderStyle.Width), 0, 0, Width - _borderStyle.Width, Height - _borderStyle.Width);
            }
        }


        private void updateBarLocationg()
        {
            //TODO:移动滑动条位置
            float v = 0;
            if (_value - _minValue != 0)
                v = (float)(_value - _minValue) / (_maxValue - _minValue);
            //_bar.Location = new Point(Convert.ToInt32((_barMaxX - _barMinX) * v) + _barMinX, _bar.Location.Y);
            nowPoint = new Point(Convert.ToInt32((_barMaxX - _barMinX) * v) + _barMinX, _bar.Location.Y);
        }

    }
    
    public class BarStyle
    {
        [Description("默认颜色")]
        public Color Color { get; set; }

        [Description("鼠标按下颜色")]
        public Color ClickColor { get; set; }

        [Description("宽")]
        public int Width { get; set; }

        [Description("边框样式")]
        public BorderStyle BorderStyle { get; set; }

        public override string ToString()
        {
            return String.Format("");
        }
    }
    
    public class BorderStyle
    {
        [Description("边框颜色")]
        public Color Color { get; set; }
        [Description("边框颜色")]
        public int Width { get; set; }

        public override string ToString()
        {
            return String.Format("");
        }
    }
    
    public class ProgressBarStyle
    {
        [Description("背景颜色")]
        public Color BackColor { get; set; }

        [Description("变宽样式")]
        public BorderStyle BorderStyle { get; set; }

        public override string ToString()
        {
            return String.Format("");
        }
    }


    public class EasyTrackBarValueChangedArgs: EventArgs
    {
        /// <summary>
        /// 老值
        /// </summary>
        public int OldValue { get; set; }
        /// <summary>
        /// 新值
        /// </summary>
        public int NewValue { get; set; }
        /// <summary>
        /// 百分比
        /// </summary>
        public float Percent { get; set; }

    }
}
