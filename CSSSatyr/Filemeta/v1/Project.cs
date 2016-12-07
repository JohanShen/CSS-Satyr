using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSSSatyr.Filemeta.v1
{
    /// <summary>
    /// 项目文件结构
    /// </summary>
    internal class Project
    {
        public static readonly byte[] Header = new byte[] { (byte)'C', (byte)'S', (byte)'S', (byte)'P' };
        public static readonly byte Version = 0x01;

        public long CreateTime { get; set; }
        public long LastTime { get; set; }
        public byte CompressType { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string DefaultCssName { get; set; }
        public string Language { get; set; }
        public bool ShowSider { get; set; }
        public bool ShowGrid { get; set; }
        public bool AutoSorption { get; set; }
        public int GridSizeNum { get; set; }
        public int SorptionNum { get; set; }

        private List<ExtendInfo> _extendInfos = new List<ExtendInfo>();
        /// <summary>
        /// 扩展信息
        /// </summary>
        public List<ExtendInfo> ExtendInfos { get { return _extendInfos; } }


        private List<ImagePanel> _Panels = new List<ImagePanel>();
        /// <summary>
        /// 图片面板
        /// </summary>
        public List<ImagePanel> Panels { get { return _Panels; } }

        public static Project ReadFromBytes(byte[] buffer)
        {
            Project p = new Project();
            using (BinaryReader br = new BinaryReader(new MemoryStream(buffer)))
            {
                br.BaseStream.Position = 0;
                byte[] head = br.ReadBytes(4);
                byte version = br.ReadByte();
                if (EqualsBytes(head,Project.Header) == false)
                    throw new Exception("文件格式不支持，不是所支持的项目文件。");
                if (version != Project.Version)
                    throw new Exception("版本 " + version + " 不支持");

                p.CreateTime = br.ReadInt64();
                p.LastTime = br.ReadInt64();
                p.CompressType = br.ReadByte();
                p.Name = ReadString(br);
                p.Author = ReadString(br);
                p.DefaultCssName = ReadString(br);
                p.Language = ReadString(br);
                p.ShowSider = br.ReadBoolean();
                p.ShowGrid = br.ReadBoolean();
                p.AutoSorption = br.ReadBoolean();
                p.GridSizeNum = br.ReadInt32();
                p.SorptionNum = br.ReadInt32();

                int extCount = br.ReadInt32();
                for (int i = 0; i < extCount; i++)
                {
                    p.ExtendInfos.Add(new ExtendInfo()
                    {
                        Name = ReadString(br),
                        Value = ReadString(br)
                    });
                }

                int panelCount = br.ReadInt32();
                for (int i = 0; i < panelCount; i++)
                {
                    ImagePanel ip = new ImagePanel();
                    ip.Name = ReadString(br);
                    int imgCount = br.ReadInt32();
                    for (int j = 0; j < imgCount; j++)
                    {
                        ImageObj io = new ImageObj();
                        io.CreateTime = br.ReadInt64();
                        io.Key = br.ReadInt64();
                        io.Width = br.ReadInt32();
                        io.Height = br.ReadInt32();
                        io.ShowWidth = br.ReadInt32();
                        io.ShowHeight = br.ReadInt32();
                        io.X = br.ReadInt32();
                        io.Y = br.ReadInt32();
                        io.ImageType = br.ReadInt32();
                        io.CssName = ReadString(br);
                        io.Mark = ReadString(br);
                        int cLen = br.ReadInt32();
                        io.Content = br.ReadBytes(cLen);
                        ip.Images.Add(io);
                    }
                    p.Panels.Add(ip);
                }
            }


            return p;
        }

        public void SaveToFile(string filePath, bool reWrite = false)
        {
            byte[] result;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(ms);
                bw.Write(Header);//文件头
                bw.Write(Version);//版本
                bw.Write(CreateTime);//创建时间
                bw.Write(LastTime);//创建时间
                bw.Write(CompressType);//压缩类型
                WriteString(bw, Name); //名称
                WriteString(bw, Author); //作者
                WriteString(bw, DefaultCssName); //默认CSS名称
                WriteString(bw, Language); //语言
                bw.Write(ShowSider);//是否显示边
                bw.Write(ShowGrid);//是否显示网格
                bw.Write(AutoSorption);//是否自动给停靠
                bw.Write(GridSizeNum);//网格大小
                bw.Write(SorptionNum);//自定停靠数值
                //写入扩展信息
                bw.Write(_extendInfos.Count);
                foreach (ExtendInfo ei in _extendInfos)
                {
                    WriteString(bw, ei.Name);
                    WriteString(bw, ei.Value);
                }
                //写入面板
                bw.Write(_Panels.Count);
                foreach (ImagePanel ip in _Panels)
                {
                    WriteString(bw, ip.Name);
                    bw.Write(ip.Images.Count);
                    //写入面板里的图片对象
                    foreach (ImageObj i in ip.Images)
                    {
                        bw.Write(i.CreateTime);
                        bw.Write(i.Key);
                        bw.Write(i.Width);
                        bw.Write(i.Height);
                        bw.Write(i.ShowWidth);
                        bw.Write(i.ShowHeight);
                        bw.Write(i.X);
                        bw.Write(i.Y);
                        bw.Write(i.ImageType);
                        WriteString(bw, i.CssName);
                        WriteString(bw, i.Mark);
                        bw.Write(i.Content.Length);
                        bw.Write(i.Content);
                    }
                }

                bw.Flush();
                result = ms.ToArray();
                bw.Close();
            }

            using (FileStream fss = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fss.Write(result, 0, result.Length);
                fss.Flush();
            }


        }

        /// <summary>
        /// Write String to Stream
        /// </summary>
        /// <param name="bw"></param>
        /// <param name="str"></param>
        private static void WriteString(BinaryWriter bw, string str )
        {
            if (String.IsNullOrEmpty(str))
            {
                bw.Write(0);
                return;
            }
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            bw.Write(bytes.Length);
            bw.Write(bytes);
        }
        
        /// <summary>
        /// Read String From Stream
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        private static string ReadString(BinaryReader br)
        {
            int len = br.ReadInt32();
            if (len <= 0)
                return "";
            byte[] bytes = br.ReadBytes(len);
            string str = Encoding.UTF8.GetString(bytes);
            return str;
        }

        private static bool EqualsBytes(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;

            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }
    }
}
