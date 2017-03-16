using System;
using System.ComponentModel;
using CSSSatyr.MyControls;
using CSSSatyr.Extends;
using System.Drawing.Imaging;
using System.Drawing;
using System.Collections.Generic;

namespace CSSSatyr.Models
{
    [DefaultProperty("ClassName")]
    public class ImageItem : PropertyBase
    {
        private List<ImageItem> parentCollection = null;
        public ImageItem(int w, int h, int x, int y, ImageFormat imageFormat, long id = 0) : this(w, h, x, y, CommonLib.GetImageType(imageFormat), id)
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

        private long id = 0;
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
                if (className != value)
                {
                    if (CommonLib.IsClassName(value) == false)
                    {
                        throw new ArgumentException(CommonLib.GetLocalString("class_name_is_vaild"), "ClassName");
                    }

                    if (parentCollection != null)
                    {
                        //ClassName 排他性检测
                        IList<ImageItem> items = parentCollection.FindAll(item => item.ClassName.ToLower() == value && item.Id != Id);
                        if (items.Count > 0)
                        {
                            throw new ArgumentException(CommonLib.GetLocalString("class_name_is_exits"), "ClassName");
                        }
                    }

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

        [ReadOnly(false), PropertyAttibute("显示宽度", "显示宽度")]
        public int ShowWidth { get; set; }

        [ReadOnly(false), PropertyAttibute("显示高度", "显示高度")]
        public int ShowHeight { get; set; }

        [ReadOnly(false), PropertyAttibute("显示模式", "Contain: 保护, Cover: 拉伸")]
        public ImageShowModel ShowModel { get; set; } = ImageShowModel.Contain;

        private int width;
        /// <summary>
        /// 实际宽度
        /// </summary>
        [ReadOnly(true), PropertyAttibute("实际宽", "图片的实际宽度")]
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
        [ReadOnly(true), PropertyAttibute("X", "X 坐标点，可以通过移动图片改变改值。")]
        public int X { get { return x; } }

        private int y;
        /// <summary>
        /// 在面板中的Y坐标
        /// </summary>
        [ReadOnly(true), PropertyAttibute("Y", "Y 坐标点，可以通过移动图片改变改值。")]
        public int Y { get { return y; } }


        #region - 事件 -
        public event ChangedEventHandler<ValueChangedArgs> ValueChanged;
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
        #endregion

        #region - 方法 -
        /// <summary>
        /// 判断是否绑定过事件
        /// </summary>
        /// <returns></returns>
        public bool IsBindEvent()
        {
            return ValueChanged == null;
        }

        /// <summary>
        /// 设置坐标值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        internal void SetLocation(int x, int y) {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// 设置坐标值
        /// </summary>
        /// <param name="p"></param>
        internal void SetLocation(Point p)
        {
            SetLocation(p.X, p.Y);
        }

        /// <summary>
        /// 设置附属集合
        /// </summary>
        /// <param name="parent"></param>
        public void SetParentCollection(List<ImageItem> parent)
        {
            parentCollection = parent;
        }
        #endregion
    }

    public class ValueChangedArgs : EventArgs
    {
        public object Object;
        public string Property;
        public object OldValue;
        public object NewValue;
    }

    public enum ImageShowModel
    {
        Cover = 0,
        Contain = 1
    }
}
