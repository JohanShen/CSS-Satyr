using CSSSatyr.Extends;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace CSSSatyr
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();

            comboBoxExportFormat.Items.Add(CommonLib.GetImageType(ImageFormat.Png));
            comboBoxExportFormat.Items.Add(CommonLib.GetImageType(ImageFormat.Jpeg));
            comboBoxExportFormat.Items.Add(CommonLib.GetImageType(ImageFormat.Gif));
            comboBoxExportFormat.DisplayMember = "MimeType";


            if (String.IsNullOrEmpty(Global.CurrentProject.ImageFormat) || Global.CurrentProject.ImageFormat.Equals("image/png", StringComparison.CurrentCultureIgnoreCase))
            {
                comboBoxExportFormat.SelectedIndex = 0;
            }
            else if (Global.CurrentProject.ImageFormat.Equals("image/jpeg", StringComparison.CurrentCultureIgnoreCase))
            {
                comboBoxExportFormat.SelectedIndex = 1;
            }
            else if (Global.CurrentProject.ImageFormat.Equals("image/gif", StringComparison.CurrentCultureIgnoreCase))
            {
                comboBoxExportFormat.SelectedIndex = 2;
            }
            trackImageQuality.Value = Global.CurrentProject.ImageQuality;
            labelProjectCreateTime.Text = CommonLib.ToDateTime(Global.CurrentProject.CreateTime).ToString();
            txtProjectAuthor.Text = Global.CurrentProject.Author;
            txtProjectClassNamePrefix.Text = Global.CurrentProject.DefaultCssName;
            txtProjectName.Text = Global.CurrentProject.Name;
            numImageQuality.Value = Global.CurrentProject.ImageQuality;

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

        private void comboBoxExportFormat_SelectionChangeCommitted(object sender, EventArgs e)
        {/*
            var obj = sender as ComboBox;
            if (obj != null)
            {
                var val = obj.SelectedItem as Models.ImageType;
                if (val != null)
                {
                    Global.CurrentProject.ImageFormat = val.MimeType.ToLower();
                }
            }
            */
        }

        private void trackImageQuality_ValueChanged(MyControls.EasyTrackBarValueChangedArgs e)
        {
            if (e.NewValue >= 0 && e.NewValue <= 100 && e.OldValue != e.NewValue)
                numImageQuality.Value = e.NewValue;

        }

        private void numImageQuality_ValueChanged(object sender, EventArgs e)
        {
            if (numImageQuality.Value > 100)
                numImageQuality.Value = 100;
            else if (numImageQuality.Value < 20)
                numImageQuality.Value = 20;
            if (numImageQuality.Value != trackImageQuality.Value)
            {
                trackImageQuality.Value = (int)numImageQuality.Value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int quality = trackImageQuality.Value;
            if (quality >= 0 && quality <= 100)
                Global.CurrentProject.ImageQuality = (short)quality;


            var val = comboBoxExportFormat.SelectedItem as Models.ImageType;
            if (val != null)
            {
                Global.CurrentProject.ImageFormat = val.MimeType.ToLower();
            }

            Global.CurrentProject.Author = txtProjectAuthor.Text;
            Global.CurrentProject.DefaultCssName = txtProjectClassNamePrefix.Text;
            Global.CurrentProject.Name = txtProjectName.Text;

            this.Close();
        }
    }
}
