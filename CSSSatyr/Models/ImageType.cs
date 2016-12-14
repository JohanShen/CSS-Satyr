using System;
using System.Drawing.Imaging;
using CSSSatyr.Extends;

namespace CSSSatyr.Models
{
    public class ImageType
    {
        private ImageCodecInfo _codecInfo;
        /// <summary>
        /// CodecInfo
        /// </summary>
        public ImageCodecInfo CodecInfo { get { return _codecInfo; } }

        /// <summary>
        /// Image Format
        /// </summary>
        public ImageFormat Format { get; set; }

        private string _mimeType;
        /// <summary>
        /// Image MimeType
        /// </summary>
        public string  MimeType { get { return _mimeType; } set { _mimeType = value; _codecInfo = CommonLib.GetCodecInfo(_mimeType); } }

        /// <summary>
        /// 扩展名
        /// </summary>
        public string ExtName { get; set; }

        /// <summary>
        /// 图标索引
        /// </summary>
        public int ImageIndex { get; set; }

        public override string ToString()
        {
            return MimeType;
        }

    }
}
