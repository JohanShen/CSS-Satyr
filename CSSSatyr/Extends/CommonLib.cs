using CSSSatyr.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;

namespace CSSSatyr.Extends
{
    public static partial class CommonLib
    {
        private static Dictionary<ImageFormat, ImageType> imageTypes = new Dictionary<ImageFormat, ImageType>();
        private static ImageCodecInfo[] codecInfos = ImageCodecInfo.GetImageEncoders();
        private static string[] mimes = { "Image/Png", "Image/Jpg", "Image/Gif", "Image/Bmp", "Image/X-Icon" };
        private static Dictionary<string, GridStyle> _gridStyles = new Dictionary<string, GridStyle>();
        private static Regex checkClassName = new Regex("^[a-zA-Z][\\w-_]*$", RegexOptions.Compiled | RegexOptions.Singleline);
        private static string[] allowExtension = { ".jpg", ".jpeg", ".gif", ".bmp", ".ico", ".png" };

        static CommonLib()
        {
            InitLanguage();

            imageTypes[ImageFormat.Bmp] = new ImageType() { Format = ImageFormat.Bmp, MimeType = "Image/Bmp", ExtName = ".bmp", ImageIndex = 0 };
            imageTypes[ImageFormat.Jpeg] = new ImageType() { Format = ImageFormat.Jpeg, MimeType = "Image/Jpeg", ExtName = ".jpg", ImageIndex = 1 };
            imageTypes[ImageFormat.Gif] = new ImageType() { Format = ImageFormat.Gif, MimeType = "Image/Gif", ExtName = ".gif", ImageIndex = 2 };
            imageTypes[ImageFormat.Png] = new ImageType() { Format = ImageFormat.Png, MimeType = "Image/Png", ExtName = ".png", ImageIndex = 3 };
            imageTypes[ImageFormat.Icon] = new ImageType() { Format = ImageFormat.Icon, MimeType = "Image/X-Icon", ExtName = ".ico", ImageIndex = 4 };

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
            
            foreach (ImageCodecInfo ici in codecInfos)
            {
                if (String.Compare(ici.MimeType, mimeType, true) == 0)
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
        public static ImageType GetImageType(ImageFormat imageFormat)
        {
            if (imageTypes.ContainsKey(imageFormat))
                return imageTypes[imageFormat];
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
        public static long ToUnixTime(DateTime dt)
        {
            long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
            return epoch;
        }

        /// <summary>
        /// Convert Timeamp to DateTime
        /// </summary>
        /// <param name="epoch"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(long epoch)
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
            return Array.IndexOf(mimes, imageMime);
        }

        public static string GetImageMimeTypeFromIndex(int index)
        {
            return mimes[index];
        }

        /// <summary>
        /// 是否允许的扩展名
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static bool IsAllowExtension(string extension)
        {
            return Array.IndexOf(allowExtension, extension) >= 0;
        }

        /// <summary>
        /// 便利出所有允许的文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetAllAllowFiles(string path)
        {
            List<string> r = new List<string>();
            if (Directory.Exists(path))
            {
                DirectoryInfo info = new DirectoryInfo(path);
                foreach (FileInfo info2 in info.GetFiles())
                {
                    string path1 = info2.FullName;
                    if (IsAllowExtension(Path.GetExtension(path1)))
                        r.Add(path1);
                }
                foreach (DirectoryInfo info2 in info.GetDirectories())
                {
                    string path1 = info2.FullName;
                    r.AddRange(GetAllAllowFiles(path1));
                }
            }
            else if (File.Exists(path))
            {
                if (IsAllowExtension(Path.GetExtension(path)))
                    r.Add(path);
            }

            return r.ToArray();
        }

        /// <summary>
        /// 颜色转成INT
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int ColorToInt(Color c)
        {
            return c.ToArgb();
        }

        /// <summary>
        /// INT 转颜色
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color IntToColor(int color)
        {
            return Color.FromArgb(color & 0x0000ff, (color & 0x00ff00) >> 8, (color & 0xff0000) >> 16);
        }

        /// <summary>
        /// 是否是CLASS名称
        /// 目前限制 字母开头 字母数字-_
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsClassName(string name)
        {
            return checkClassName.Match(name).Success;
        }
    }
}
