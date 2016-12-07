using System;
using System.Collections.Generic;
using System.Text;

namespace CSSSatyr.Filemeta.v1
{
    /// <summary>
    /// 画板对象
    /// </summary>
    internal class ImagePanel
    {
        public string Name { get; set; }
        private List<ImageObj> _images = new List<ImageObj>();
        public List<ImageObj> Images { get { return _images; } }
    }
}
