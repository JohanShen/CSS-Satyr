using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace CSSSatyr.MyControls
{
    /// <summary>
    /// 值变化的委托
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e"></param>
    public delegate void ValueChangeHandler<T>(T e) where T : EventArgs;
    /// <summary>
    /// @author : JohanShen
    /// @date : 2016/12/06
    /// 
    /// 2016/12/7 
    /// 修改 将 bar 改为绘制方式（老方式使用子Control）
    /// 新增 根据点击位置判断所点击子控件
    /// 新增 点击进度条来改变值和调节条位置
    /// </summary>
    [DefaultEvent("ValueChanged")]
    public class EasyTrackBar : Control
    {
        /// <summary>
        /// 拖动控件
        /// </summary>
        private Point _nowPoint = new Point(0), _offsetPoint = new Point(0);
        private int _barMinX = 0, _barMaxX = 0, _barHeight = 0;
        private int _oldWidth = 0, _oldHeight = 0;
        private ChildControl _clickChildControl = ChildControl.None;
        private Dictionary<ChildControl, RectangleF> _childControls = new Dictionary<ChildControl, RectangleF>();

        public EasyTrackBar()
        {
            base.MouseDown += new MouseEventHandler(EasyTrackBar_MouseDown);
            base.MouseUp += new MouseEventHandler(EasyTrackBar_MouseUp);
            base.MouseMove += new MouseEventHandler(EasyTrackBar_MouseMove);
            _borderStyle = new BorderStyle() { Color = SystemColors.ControlDark, Width = 0 };
            _barStyle = new BarStyle() { Width = 15, Color = SystemColors.ControlDark, ClickColor = Color.Blue, BorderStyle = new BorderStyle() { Width = 0, Color = SystemColors.ControlDarkDark } };
            _progressBarStyle = new ProgressBarStyle() { BackColor = SystemColors.InactiveCaption, BorderStyle = new BorderStyle() { Width = 1, Color = SystemColors.ControlDarkDark } };

            //按照检查的优先级添加
            //有时多个控件坐标相互重叠，相同位置坐标的优先级
            _childControls[ChildControl.Bar] = new RectangleF();
            _childControls[ChildControl.Progress] = new RectangleF();
            _childControls[ChildControl.LabelText] = new RectangleF();

        }


        #region - 内部事件 -
        /// <summary>
        /// 鼠标按下事件
        /// 用于判断点中的子控件和计算鼠标偏移值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EasyTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            var ctrl = sender as Control;
            if (ctrl != null)
            {
                _offsetPoint = new Point(e.X - _nowPoint.X, e.Y - _nowPoint.Y);

                //判断点中了哪个控件
                foreach (KeyValuePair<ChildControl, RectangleF> c in _childControls)
                {
                    RectangleF r = c.Value;
                    if ((r.X <= e.X && e.X <= r.X + r.Width) && (r.Y <= e.Y && e.Y <= r.Y + r.Height))
                    {
                        _clickChildControl = c.Key;
                        break;
                    }
                }
                Invalidate();
            }
        }

        /// <summary>
        /// 鼠标弹起事件
        /// 主要用于点击进度条改变值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EasyTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("点中：" + _clickChildControl);
            var ctrl = sender as Control;
            if (ctrl != null && MouseButtons.Left == e.Button)
            {
                if (_clickChildControl == ChildControl.Progress)
                {
                    Point point = new Point(e.X, e.Y);
                    updateBarLocation(point);
                }
                else
                {
                    _clickChildControl = ChildControl.None;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// 鼠标移动
        /// 主要用于按下调节条后的事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EasyTrackBar_MouseMove(object sender, MouseEventArgs e)
        {
            var ctrl = sender as Control;
            if (ctrl != null && MouseButtons.Left == e.Button)
            {
                if (_clickChildControl == ChildControl.Bar)
                {
                    Point point = new Point(e.X- _offsetPoint.X, e.Y);
                    updateBarLocation(point);
                }
            }
        }

        #endregion

        #region - 自定义事件 -
        public event ValueChangeHandler<EasyTrackBarValueChangedArgs> ValueChanged;
        private void ValueChange(EasyTrackBarValueChangedArgs s)
        {
            ValueChanged?.Invoke(s);
        }
        #endregion

        #region - 属性 -
        private string text;
        [DefaultValue("")]
        public new string Text
        {
            get { return text; }
            set { text = value;
                updateBarMinMaxX();
                Invalidate();
            }
        }

        private int _value = 0;
        public int Value
        {
            get { return _value; }
            set
            {
                if (value != _value)
                {
                    int _oldValue = _value;
                    _value = value > _maxValue ? _maxValue : value < _minValue ? _minValue : value;
                    updateBarLocation(_value, _minValue, _maxValue);
                    
                    float _percent = 0f;
                    if (value - _minValue != 0)
                        _percent = (float)(value - _minValue) / (_maxValue - _minValue);
                    ValueChange(new EasyTrackBarValueChangedArgs() { OldValue = _oldValue, NewValue = _value, Percent = _percent });

                    Invalidate();
                }
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
                updateBarLocation(_value, _minValue, _maxValue);
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
                _maxValue = value; updateBarLocation(_value, _minValue, _maxValue); Invalidate();
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
                _barStyle.Color = value; Invalidate();
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

        #endregion

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
                //加入文字
                updateChildControl(ChildControl.LabelText, new RectangleF(0, (Height - fontSize.Height) / 2, fontSize.Width, fontSize.Height));
            }
            barWidth = Width - textWidth - Padding.Left - Padding.Right - _progressBarStyle.BorderStyle.Width * 2 - 2;
            barX = textWidth;

            //绘制刻度条
            if (_progressBarStyle.BorderStyle.Width > 0)
            {
                e.Graphics.DrawRectangle(new Pen(_progressBarStyle.BorderStyle.Color, _progressBarStyle.BorderStyle.Width), barX, barY, barWidth, barHeight);
            }
            e.Graphics.FillRectangle(new SolidBrush(_progressBarStyle.BackColor), new RectangleF(barX, barY, barWidth, barHeight));
            updateChildControl(ChildControl.Progress, new RectangleF(barX, barY, barWidth, barHeight));

            //绘制刻度数字
            if (_showValue)
            {
                int total = MaxValue - MinValue;

                //TODO: 完善刻度表的显示
                //e.Graphics.DrawString(MinValue.ToString(), Font, new SolidBrush(ForeColor), new PointF(barX, 0));
                //e.Graphics.DrawString(MaxValue.ToString(), Font, new SolidBrush(ForeColor), new PointF(Width - 12, 0));
            }

            _barMinX = Convert.ToInt32(barX-2);
            _barMaxX = Convert.ToInt32(barX + barWidth - _barStyle.Width +2);

            //绘制调节条
            if (_oldWidth != Width || _oldHeight != Height)
            {
                _barHeight = Convert.ToInt32(Height - Height / 3);
                _nowPoint = new Point(_nowPoint.X < _minValue ? _minValue : _nowPoint.X, Convert.ToInt32(Math.Round((double)(Height - _barHeight) / 3)) + Padding.Top);
                _oldWidth = Width;
                _oldHeight = Height;
            }
            e.Graphics.FillRectangle(new SolidBrush(_clickChildControl== ChildControl.Bar?_barStyle.ClickColor: _barStyle.Color), _nowPoint.X, _nowPoint.Y, _barStyle.Width, _barHeight - Padding.Top - Padding.Bottom);
            updateChildControl(ChildControl.Bar, new RectangleF(_nowPoint.X, _nowPoint.Y, _barStyle.Width, _barHeight - Padding.Top - Padding.Bottom));

            if (_borderStyle.Width > 0)
            {
                //绘制边框
                e.Graphics.DrawRectangle(new Pen(_borderStyle.Color, _borderStyle.Width), 0, 0, Width - _borderStyle.Width, Height - _borderStyle.Width);
            }
            e.Graphics.Dispose();
        }


        #region - 私有方法 -

        #region - 更新调节条位置 -

        /// <summary>
        /// 更新滑动条的位置
        /// 根据值计算位置
        /// </summary>
        private void updateBarLocation(int value, int minValue, int maxValue)
        {
            float _percent = 0f;
            if (value - minValue != 0)
                _percent = (float)(value - minValue) / (maxValue - minValue);
            _nowPoint = new Point(Convert.ToInt32((_barMaxX - _barMinX) * _percent) + _barMinX, _nowPoint.Y);
        }

        /// <summary>
        /// 更新滑动条的位置
        /// </summary>
        /// <param name="point">更新到的坐标</param>
        private void updateBarLocation(Point point)
        {

            int _oldValue = _value;
            float _percent = 0f;
            if (_nowPoint.X < _barMinX)
            {
                _nowPoint = new Point(_barMinX, _nowPoint.Y);
                _value = _minValue;
            }
            else if (_nowPoint.X > _barMaxX)
            {
                _nowPoint = new Point(_barMaxX, _nowPoint.Y);
                _value = _maxValue;
                _percent = 100;
            }
            else
            {
                if (point.X < _barMinX)
                    point.X = _barMinX;
                if (point.X > _barMaxX)
                    point.X = _barMaxX;

                _nowPoint = new Point(point.X, _nowPoint.Y);
                if (point.X - _barMinX > 0)
                    _percent = (float)(point.X - _barMinX) / (_barMaxX - _barMinX);

                _value = Convert.ToInt32(_percent * (_maxValue - _minValue)) + _minValue;
            }
            if (_oldValue != _value)
            {
                ValueChange(new EasyTrackBarValueChangedArgs() { OldValue = _oldValue, NewValue = _value, Percent = _percent });
                Invalidate();
            }

        }

        #endregion

        /// <summary>
        /// 更新调节条的最大最小值
        /// </summary>
        private void updateBarMinMaxX()
        {
            //计算初始状态下的值
            using (Graphics g = CreateGraphics())
            {
                SizeF fontSize = g.MeasureString(Text, Font, 1000, StringFormat.GenericTypographic);
                float textWidth = fontSize.Width + 5;
                float barWidth = Width - textWidth - Padding.Left - Padding.Right - _progressBarStyle.BorderStyle.Width * 2 - 2;

                float barX = textWidth;
                _barMinX = Convert.ToInt32(barX - 2);
                _barMaxX = Convert.ToInt32(barX + barWidth - _barStyle.Width + 2);

                _barHeight = Convert.ToInt32(Height - Height / 3);
                _nowPoint = new Point(_nowPoint.X, Convert.ToInt32(Math.Round((double)(Height - _barHeight) / 3)) + Padding.Top);

            }
        }

        /// <summary>
        /// 更新空间坐标尺寸信息
        /// </summary>
        /// <param name="cc"></param>
        /// <param name="r"></param>
        private void updateChildControl(ChildControl cc, RectangleF r) {
            _childControls[cc] = r;
        }

        #endregion

        /// <summary>
        /// 子控件名
        /// </summary>
        public enum ChildControl
        {
            None = 0,
            LabelText = 1,
            Bar = 2,
            Progress = 3
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
