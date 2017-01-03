using System;
using System.ComponentModel;
using CSSSatyr.MyControls;
using CSSSatyr.Extends;
using System.Drawing.Imaging;
using System.Drawing;

namespace CSSSatyr.Models
{
    public delegate void ValueChangedEventHandler(object sender, ValueChangedArgs e);

    [DefaultProperty("ClassName")]
    public class ImageItem : PropertyBase
    {
        #region - 事件 -
        public event ValueChangedEventHandler ValueChanged;
        private void OnChanged(ValueChangedArgs s)
        {
            ValueChanged?.Invoke(this, s);
        }
        private void OnChanged(string property, object oldValue, object newValue)
        {
            ValueChangedArgs args = new ValueChangedArgs()
            {
                NewValue = newValue,
                Object = this,
                OldValue = oldValue,
                Property = property
            };
            OnChanged(args);
        }
        public bool IsBindEvent()
        {
            return ValueChanged == null;
        }
        #endregion

        private long id = 0;
        public ImageItem(int w, int h, int x, int y, ImageFormat imageFormat, long id=0):this(w,h,x,y,CommonLib.GetImageType(imageFormat), id)
        { }
        public ImageItem(int w, int h, int x, int y, ImageType imageType, long id = 0)
        {
            width = w;
            height = h;
            this.x = x;
            this.y = y;
            this.imageType = imageType;
            this.id = id;
        }

        internal void SetLocation(int x, int y) {
            this.x = x;
            this.y = y;
        }

        internal void SetLocation(Point p)
        {
            SetLocation(p.X, p.Y);
        }

        [PropertyAttibute("ID", "唯一ID")]
        public long Id
        {
            get
            {
                if (id == 0)
                {
                    id = BitConverter.ToInt64(Guid.NewGuid().ToByteArray(), 0);
                }
                return id;
            }
        }


        private string className;
        /// <summary>
        /// 类名
        /// </summary>
        [PropertyAttibute("Class", "定义调用的类名")]
        public string ClassName
        {
            get { return className; }
            set
            {
                //TODO: 检测ClassName的合法性
                //命名规则 字母开头，包含字母 数字 - _ 50位长度
                if (className != value)
                {
                    string oldValue = className;
                    className = value;
                    OnChanged("ClassName", oldValue, className);
                }
            }
        }


        private string mark;
        /// <summary>
        /// 备注
        /// </summary>
        [ReadOnly(false), PropertyAttibute("备注", "可以给图片添加备注")]
        public string Mark
        {
            get { return mark; }
            set
            {
                if (mark != value)
                {
                    string oldValue = mark;
                    mark = value;
                    OnChanged("Mark", oldValue, mark);
                }
            }
        }

        private ImageType imageType;
        /// <summary>
        /// 图片类型
        /// </summary>
        [ReadOnly(true), PropertyAttibute("类型", "图片类型")]
        public ImageType ImageType { get { return imageType; } }

        private int width;
        /// <summary>
        /// 实际宽度
        /// </summary>
        [ReadOnly(true),PropertyAttibute("实际宽", "图片的实际宽度")]
        public int Width { get { return width; } }

        private int height;
        /// <summary>
        /// 实际高度
        /// </summary>
        [ReadOnly(true), PropertyAttibute("实际高", "图片的实际高度")]
        public int Height { get { return height; } }

        private int x;
        /// <summary>
        /// 在面板中的X坐标
        /// </summary>
        [ReadOnly(true),PropertyAttibute("X", "X 坐标点，可以通过移动图片改变改值。")]
        public int X { get { return x; } }

        private int y;
        /// <summary>
        /// 在面板中的Y坐标
        /// </summary>
        [ReadOnly(true), PropertyAttibute("Y", "Y 坐标点，可以通过移动图片改变改值。")]
        public int Y { get { return y; } }
    }

    public class ValueChangedArgs : EventArgs
    {
        public object Object;
        public string Property;
        public object OldValue;
        public object NewValue;
    }
}
