using System;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using CSSSatyr.Models;
using CSSSatyr.Extends;

namespace CSSSatyr
{
    public static class Global
    {
        static Global(){}

        private static int _gridSizeNum = 25;
        private static int _autoAlignSpaceNum = 25;
        private static AlignMode _alignMode = AlignMode.FreeAlign;
        private static string _lang = "en-US";
        private static GridStyle _gridStyle = CommonLib.GetGridStyle();

        public static GridStyle GridStyle
        {
            get { return _gridStyle; }
            set { _gridStyle = value; }
        }

        public static bool ProjectSaved
        {
            get;set;
        }

        /// <summary>
        /// Grid Size Number
        /// </summary>
        public static int GridSizeNum
        {
            get { return _gridSizeNum; }
            set { _gridSizeNum = value; }
        }

        /// <summary>
        /// Auto Align Number
        /// </summary>
        public static int AutoAlignSpaceNum
        {
            get { return _autoAlignSpaceNum; }
            set { _autoAlignSpaceNum = value; }
        }

        /// <summary>
        /// Align Mode
        /// </summary>
        public static AlignMode AlignMode
        {
            get { return _alignMode; }
            set { _alignMode = value; }
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
