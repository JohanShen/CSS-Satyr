using CSSSatyr.Extends;
using CSSSatyr.Thread;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using static CSSSatyr.Thread.ChcekNewVersionThread;

namespace CSSSatyr
{
    partial class frmAbout : Form
    {
        string last_version_str = "";
        private ChcekNewVersionThread checkNewThread = new ChcekNewVersionThread();
        public frmAbout()
        {
            InitializeComponent();
            this.llabDownUrl.Visible = false;
            this.llabDownUrl.Tag = null;
            this.Text = String.Format("关于 {0}", AssemblyTitle);
            //this.labelProductName.Text = AssemblyProduct;
            //this.labelVersion.Text = String.Format("版本 {0}", AssemblyVersion);
            //this.labelCopyright.Text = AssemblyCopyright;
            //this.labelCompanyName.Text = AssemblyCompany;
            //this.textBoxDescription.Text = AssemblyDescription;
            checkNewThread.OnCompleted += new ChcekNewVersionThread.CompletedHandler(CheckNewThread_OnCompleted);

            checkNewThread.Start();

            ChangeLanguage();
        }

        private void CheckNewThread_OnCompleted(CompletedArgs args)
        {
            if (this.IsHandleCreated)
            {
                var meth = new CompletedHandler(CheckNewThread_OnCompleted_UI);
                this.BeginInvoke(meth, new object[] { args });
            }
        }
        private void CheckNewThread_OnCompleted_UI(CompletedArgs args)
        {
            if (args != null)
            {
                if (args.IsSuccessd)
                {
                    llabDownUrl.Visible = true;
                    llabDownUrl.Text = CommonLib.GetLocalString("about_label_download");
                    llabDownUrl.Tag = args.download_url;
                    labLastVersion.Text = CommonLib.GetLocalString("about_label_last_version", args.version);
                    MessageBox.Show(args.description);
                }
                else
                {
                    labLastVersion.Text = CommonLib.GetLocalString("about_label_last_none");
                    MessageBox.Show(args.Message);
                }
            }
        }

        public void ChangeLanguage()
        {
            tabPageAbout.Text = CommonLib.GetLocalString("about_tab_aboutsoftware");
            tabPageCopyright.Text = CommonLib.GetLocalString("about_tab_copyright");

            labNowVersion.Text = CommonLib.GetLocalString("about_label_now_version", AssemblyVersion);
            labLastVersion.Text = CommonLib.GetLocalString("about_label_last_checking");
            last_version_str = CommonLib.GetLocalString("about_label_last_version");

            btnOK.Text = CommonLib.GetLocalString("alert_ok");
        }

        #region 程序集特性访问器

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion

        private void llabDownUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var obj = sender as LinkLabel;
            if (obj?.Tag == null)
            {
                Process.Start(obj.Tag.ToString());
            }
        }
    }
}
