using CSSSatyr.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CSSSatyr.Extends
{
    public static partial class CommonLib
    {
        private static Dictionary<ImageFormat, ImageType> _imageTypes = new Dictionary<ImageFormat, ImageType>();
        private static ImageCodecInfo[] _codecInfo = ImageCodecInfo.GetImageEncoders();
        private static string[] _mimes = { "Image/Png", "Image/Jpg", "Image/Gif", "Image/Bmp", "Image/X-Icon" };
        private static Dictionary<string, GridStyle> _gridStyles = new Dictionary<string, GridStyle>();

        static CommonLib()
        {
            InitLanguage();

            _imageTypes[ImageFormat.Bmp] = new ImageType() { Format = ImageFormat.Bmp, MimeType = "Image/Bmp" };
            _imageTypes[ImageFormat.Jpeg] = new ImageType() { Format = ImageFormat.Jpeg, MimeType = "Image/Jpeg" };
            _imageTypes[ImageFormat.Gif] = new ImageType() { Format = ImageFormat.Gif, MimeType = "Image/Gif" };
            _imageTypes[ImageFormat.Png] = new ImageType() { Format = ImageFormat.Png, MimeType = "Image/Png" };
            _imageTypes[ImageFormat.Icon] = new ImageType() { Format = ImageFormat.Icon, MimeType = "Image/X-Icon" };

            _gridStyles["default"] = new GridStyle() { BgColor = Color.White, ShowGrid = true, LineColor = Color.Silver, LineWidth = 1, Name = "White(Default)" };
            _gridStyles["gray"] = new GridStyle() { BgColor = Color.Gray, ShowGrid = true, LineColor = Color.Silver, LineWidth = 1, Name = "Gray" };
            _gridStyles["black"] = new GridStyle() { BgColor = Color.Black, ShowGrid = true, LineColor = Color.DarkGray, LineWidth = 1, Name = "Black" };

        }

        public static GridStyle GetGridStyle(string name = "default")
        {
            if (_gridStyles.ContainsKey(name))
                return _gridStyles[name];
            return null;
        }

        public static void SetGridStyle(string name, GridStyle gridStyle)
        {
            _gridStyles[name] = gridStyle;
        }


        /// <summary>
        /// 根据 mimeType 或图片解码信息
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        public static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            if (String.IsNullOrEmpty(mimeType))
                return null;

            foreach (ImageCodecInfo ici in _codecInfo)
            {
                if (String.Compare(ici.MimeType, mimeType, false) == 0)
                    return ici;
            }
            return null;
        }

        public static ImageCodecInfo GetCodecInfo(ImageFormat imageFormat)
        {
            ImageType it = GetImageType(imageFormat);
            return GetCodecInfo(it?.MimeType);
        }

        /// <summary>
        /// 获取图片格式
        /// </summary>
        /// <param name="imageFormat"></param>
        /// <returns></returns>
        public static ImageType GetImageType(ImageFormat imageFormat) {
            if (_imageTypes.ContainsKey(imageFormat))
                return _imageTypes[imageFormat];
            return null;
        }

        /// <summary>
        /// 创建矩形笔刷
        /// </summary>
        /// <param name="gridSizeNumW">宽</param>
        /// <param name="gridSizeNumH">高</param>
        /// <returns></returns>
        public static TextureBrush DrawRectangle(int gridSizeNumW, int gridSizeNumH, GridStyle gridStyle)
        {
            return DrawRectangle(-1, -1, gridSizeNumW, gridSizeNumH, gridStyle);
        }


        /// <summary>
        /// 创建矩形笔刷
        /// </summary>
        /// <param name="x">起点X坐标</param>
        /// <param name="y">起点Y坐标</param>
        /// <param name="gridSizeNumW">宽</param>
        /// <param name="gridSizeNumH">高</param>
        /// <returns></returns>
        public static TextureBrush DrawRectangle(int x, int y, int gridSizeNumW, int gridSizeNumH, GridStyle gridStyle)
        {
            Bitmap bit = new Bitmap(gridSizeNumW, gridSizeNumH);
            Graphics g = Graphics.FromImage(bit);
            g.Clear(gridStyle.BgColor);
            g.DrawRectangle(new Pen(gridStyle.ShowGrid ? gridStyle.LineColor : gridStyle.BgColor, gridStyle.LineWidth), new Rectangle(-1, -1, gridSizeNumW, gridSizeNumH));
            g.Dispose();
            TextureBrush textureBrush = new TextureBrush(bit);
            textureBrush.TranslateTransform(x, y);

            return textureBrush;
        }

        /// <summary>
        /// 计算自动对齐的X、Y值
        /// </summary>
        /// <param name="x_y">x or y</param>
        /// <returns></returns>
        public static int GetSpaceNum(int x_y)
        {
            int r = Convert.ToInt32((int)(x_y / Global.AutoAlignSpaceNum)) * Global.AutoAlignSpaceNum;
            return r;
        }

        /// <summary>
        /// Convter DateTime to Timeamp
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long ToUnixTime( DateTime dt)
        {
            long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
            return epoch;
        }

        /// <summary>
        /// Convert Timeamp to DateTime
        /// </summary>
        /// <param name="epoch"></param>
        /// <returns></returns>
        public static DateTime ToDateTime( long epoch)
        {
            DateTime dt = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(621355968000000000));
            return dt.AddMilliseconds(epoch);
        }

        /// <summary>
        /// 图片转bytes
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] ImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                ms.Seek(0, SeekOrigin.Begin);
                byte[] buffer = new byte[ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        public static int GetImageMimeTypeIndex(string imageMime)
        {
            return Array.IndexOf(_mimes, imageMime);
        }

        public static string GetImageMimeTypeFromIndex(int index)
        {
            return _mimes[index];
        }

    }
}
