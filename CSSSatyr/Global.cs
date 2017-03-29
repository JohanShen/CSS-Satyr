using System;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using CSSSatyr.Models;
using CSSSatyr.Extends;
using System.Windows.Forms;
using System.Reflection;
using CSSSatyr.Filemeta.v1;

namespace CSSSatyr
{
    public static class Global
    {
        static Global(){}

        private static int _gridSizeNum = 25;
        private static AlignMode _alignMode = AlignMode.FreeAlign;
        private static string _lang = "en-US";
        private static GridStyle _gridStyle = CommonLib.GetGridStyle();

        /// <summary>
        /// 软件名
        /// </summary>
        public static string ProductName { get { return Application.ProductName; } }

        /// <summary>
        /// 软件版本
        /// </summary>
        public static string ProductVersion { get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); } }

        /// <summary>
        /// 网格样式
        /// </summary>
        public static GridStyle GridStyle
        {
            get { return _gridStyle; }
            set { _gridStyle = value; }
        }


        private static Project currentProject = null;
        /// <summary>
        /// 当前项目
        /// </summary>
        internal static Project CurrentProject
        {
            get
            {
                if (currentProject == null)
                {
                    currentProject = new Project() { Name = CommonLib.GetLocalString("main_default_project_name"), DefaultCssName = "cssr_", Author= Environment.UserName, CreateTime = CommonLib.ToUnixTime(DateTime.Now) };

                }
                return currentProject;
            }
        }
        /// <summary>
        /// 设置当前项目
        /// </summary>
        /// <param name="project"></param>
        internal static void SetCurrentProject(Project project)
        {
            currentProject = project;
        }

        /// <summary>
        /// 是否保存
        /// </summary>
        public static bool ProjectSaved
        {
            get;set;
        }

        /// <summary>
        /// 保存路径
        /// </summary>
        public static string SavedPath { get; set; }

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
            get { return _gridSizeNum; }
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
