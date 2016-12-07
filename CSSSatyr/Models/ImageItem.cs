using System;
using System.ComponentModel;
using CSSSatyr.MyControls;
using CSSSatyr.Extends;
using System.Drawing.Imaging;
using System.Drawing;

namespace CSSSatyr.Models
{
    [DefaultProperty("ClassName")]
    public class ImageItem : PropertyBase
    {
        private long _id = BitConverter.ToInt64(Guid.NewGuid().ToByteArray(), 0);
        public ImageItem(int w, int h, int x, int y, ImageFormat imageFormat):this(w,h,x,y,CommonLib.GetImageType(imageFormat))
        { }
        public ImageItem(int w, int h, int x, int y, ImageType imageType)
        {
            _width = w;
            _height = h;
            _x = x;
            _y = y;
            _imageType = imageType;
        }

        internal void SetLocation(int x, int y) {
            _x = x;
            _y = y;
        }

        internal void SetLocation(Point p)
        {
            SetLocation(p.X, p.Y);
        }

        [PropertyAttibute("ID", "唯一ID")]
        public long Id { get { return _id; } }

        /// <summary>
        /// 类名
        /// </summary>
        [PropertyAttibute("Class", "定义调用的类名")]
        public string ClassName { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
       // [ReadOnly(true), PropertyAttibute("文件名", "文件的源名称")]
        //public string FileName { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
      //  [ReadOnly(true), PropertyAttibute("路径", "文件的源路径")]
      //  public string OriginalUri { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ReadOnly(false), PropertyAttibute("备注", "可以给图片添加备注")]
        public string Mark { get; set; }

        private ImageType _imageType;
        /// <summary>
        /// 图片类型
        /// </summary>
        [ReadOnly(true), PropertyAttibute("类型", "图片类型")]
        public ImageType ImageType { get { return _imageType; } }

        private int _width;
        /// <summary>
        /// 实际宽度
        /// </summary>
        [ReadOnly(true),PropertyAttibute("实际宽", "图片的实际宽度")]
        public int Width { get { return _width; } }

        private int _height;
        /// <summary>
        /// 实际高度
        /// </summary>
        [ReadOnly(true), PropertyAttibute("实际高", "图片的实际高度")]
        public int Height { get { return _height; } }

        /// <summary>
        /// 显示宽
        /// </summary>
        [PropertyAttibute("显示宽","图片的显示宽度")]
        public int ShowWidth { get; set; }

        /// <summary>
        /// 显示高
        /// </summary>
        [PropertyAttibute("显示高", "图片的显的宽度")]
        public int ShowHeight { get; set; }

        private int _x;
        /// <summary>
        /// 在面板中的X坐标
        /// </summary>
        [ReadOnly(true),PropertyAttibute("X", "X 坐标点，可以通过移动图片改变改值。")]
        public int X { get { return _x; } }

        private int _y;
        /// <summary>
        /// 在面板中的Y坐标
        /// </summary>
        [ReadOnly(true), PropertyAttibute("Y", "Y 坐标点，可以通过移动图片改变改值。")]
        public int Y { get { return _y; } }
    }
}
