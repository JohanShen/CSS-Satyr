using System;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using CSSSatyr.Models;

namespace CSSSatyr
{
    public static class Global
    {
        static Global(){}


        private static int _GridSizeNum = 25;
        private static int _AutoAlignSpaceNum = 25;
        private static AlignMode _AlignMode = AlignMode.FreeAlign;
        private static string _lang = "en-US";

        /// <summary>
        /// Grid Size Number
        /// </summary>
        public static int GridSizeNum
        {
            get { return _GridSizeNum; }
            set { _GridSizeNum = value; }
        }

        /// <summary>
        /// Auto Align Number
        /// </summary>
        public static int AutoAlignSpaceNum
        {
            get { return _AutoAlignSpaceNum; }
            set { _AutoAlignSpaceNum = value; }
        }

        /// <summary>
        /// Align Mode
        /// </summary>
        public static AlignMode AlignMode
        {
            get { return _AlignMode; }
            set { _AlignMode = value; }
        }

        /// <summary>
        /// Location Language
        /// </summary>
        public static string Lang
        {
            get { return _lang; }
            set { _lang = value; }
        }
    }
}
