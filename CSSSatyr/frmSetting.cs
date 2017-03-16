using CSSSatyr.Extends;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSSSatyr
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
            

            ChangeLanguage();
        }

        public void ChangeLanguage()
        {
            tabPageProject.Text = CommonLib.GetLocalString("setting_project");
            labProjectName.Text = CommonLib.GetLocalString("setting_project_name");
            labProjectAuthor.Text = CommonLib.GetLocalString("setting_project_author");
            labClassNamePrefix.Text = CommonLib.GetLocalString("setting_project_class_prefix");
            labCreateImageFormat.Text = CommonLib.GetLocalString("setting_project_image_create_format");
            labCreateTime.Text = CommonLib.GetLocalString("setting_project_created_time");
            labImageQuality.Text = CommonLib.GetLocalString("setting_project_image_quailty");

            btnOK.Text = CommonLib.GetLocalString("alert_ok");
            btnCancel.Text = CommonLib.GetLocalString("alert_cancel");
        }
    }
}
