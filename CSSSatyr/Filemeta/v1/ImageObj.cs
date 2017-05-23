using System;
using System.Collections.Generic;
using System.Text;

namespace CSSSatyr.Filemeta.v1
{
    /// <summary>
    /// 图片对象
    /// </summary>
    internal class ImageObj
    {
        public long CreateTime { get; set; }
        public long Key { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int ShowWidth { get; set; }
        public int ShowHeight { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int ImageType { get; set; }
        public string CssName { get; set; }
        public string Mark { get; set; }
        public byte[] Content { get; set; }
    }
}
