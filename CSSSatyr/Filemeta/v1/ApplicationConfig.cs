using CSSSatyr.Filemeta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSSSatyr.Models
{
    /// <summary>
    /// 程序配置 文件结构
    /// </summary>
    public class ApplicationConfig
    {
        public static readonly byte[] Header = new byte[] { (byte)'C', (byte)'S', (byte)'S', (byte)'C' };
        public static readonly byte Version = 0x01;

        public long LastCheckTime { get; set; }
        public string DefaultCssName { get; set; }
        public string Language { get; set; }
        public bool ShowSider { get; set; }
        public bool ShowGrid { get; set; }
        public bool AutoSorption { get; set; }
        public int GridSizeNum { get; set; }
        public int SorptionNum { get; set; }

        #region - 2016/12/9 新增 -
        public string GridStyleName { get; set; }
        public int GridBgColor { get; set; }
        public int GridLineColor { get; set; }
        #endregion


        #region - 2017/1/3 新增 -
        /// <summary>
        /// 最近打开的项目
        /// </summary>
        public List<string> LastProjects = new List<string>();
        #endregion


        public static ApplicationConfig ReadFromBytes(byte[] buffer)
        {
            ApplicationConfig ac = new ApplicationConfig();

            using (BinaryReader br = new BinaryReader(new MemoryStream(buffer)))
            {
                br.BaseStream.Position = 0;
                byte[] head = br.ReadBytes(4);
                byte version = br.ReadByte();
                if (FilemetaCommon.EqualsBytes(head, ApplicationConfig.Header) == false)
                    throw new Exception("文件格式不支持，不是所支持的配置文件。");
                if (version != ApplicationConfig.Version)
                    throw new Exception("版本 " + version + " 不支持");

                ac.LastCheckTime = br.ReadInt64();
                ac.DefaultCssName = FilemetaCommon.ReadString(br);
                ac.Language = FilemetaCommon.ReadString(br);
                ac.ShowSider = br.ReadBoolean();
                ac.ShowGrid = br.ReadBoolean();
                ac.AutoSorption = br.ReadBoolean();
                ac.GridSizeNum = br.ReadInt32();
                ac.SorptionNum = br.ReadInt32();
                ac.GridStyleName = FilemetaCommon.ReadString(br);//网格样式名称
                ac.GridBgColor = br.ReadInt32();//网格背景颜色
                ac.GridLineColor = br.ReadInt32();//网格线条颜色

                //2017-1-3
                int lastprojectsCount = br.ReadInt32();
                if (ac.LastProjects == null)
                    ac.LastProjects = new List<string>();

                for (int i = 0; i < lastprojectsCount; i++)
                {
                    string path = FilemetaCommon.ReadString(br);
                    ac.LastProjects.Add(path);
                }
            }
            return ac;
        }


        public void SaveToFile(string filePath, bool reWrite = false)
        {
            byte[] result;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(ms);
                bw.Write(Header);//文件头
                bw.Write(Version);//版本
                bw.Write(LastCheckTime);//创建时间
                FilemetaCommon.WriteString(bw, DefaultCssName); //默认CSS名称
                FilemetaCommon.WriteString(bw, Language); //语言
                bw.Write(ShowSider);//是否显示边
                bw.Write(ShowGrid);//是否显示网格
                bw.Write(AutoSorption);//是否自动给停靠
                bw.Write(GridSizeNum);//网格大小
                bw.Write(SorptionNum);//自定停靠数值
                FilemetaCommon.WriteString(bw, GridStyleName);//网格样式名称
                bw.Write(GridBgColor);//网格背景颜色
                bw.Write(GridLineColor);//网格线条颜色
                //2017-1-3
                bw.Write(LastProjects.Count);
                foreach (string path in LastProjects)
                {
                    FilemetaCommon.WriteString(bw, path);
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

        private static string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CSS-SATYR");
        private static string configFileName = "config.cssc";
        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="ac"></param>
        public void Save()
        {
            if (Directory.Exists(configPath) == false)
                Directory.CreateDirectory(configPath);

            string filePath = Path.Combine(configPath, configFileName);
            SaveToFile(filePath, true);
        }

        public static ApplicationConfig Load()
        {
            string filePath = Path.Combine(configPath, configFileName);
            ApplicationConfig ac = null;
            if (File.Exists(filePath))
            {
                byte[] buffer = null;
                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, (int)fs.Length);
                        fs.Close();
                    }
                    ac = ReadFromBytes(buffer);
                }
                catch (Exception ex)
                {
                }
            }
            return ac;
        }
    }
}
