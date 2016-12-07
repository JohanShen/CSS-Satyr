using System;
using System.Collections.Generic;
using System.Text;

namespace CSSSatyr.Models
{
    /// <summary>
    /// 程序配置 文件结构
    /// </summary>
    internal class ApplicationConfig
    {
        public static readonly byte[] Header = new byte[] { (byte)'C', (byte)'S', (byte)'S', (byte)'C' };
        public static readonly byte Version = 0x01;

        public string Language { get; set; }
        public int GridNum { get; set; }
        public bool ShowGrid { get; set; }
        public bool AutoSorption { get; set; }
        public bool ShowSider { get; set; }
        public long LastCheckTime { get; set; }
        public string DefaultCssName { get; set; }
    }
}
