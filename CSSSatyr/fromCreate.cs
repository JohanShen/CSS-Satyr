using CSSSatyr.Extends;
using CSSSatyr.Models;
using CSSSatyr.MyControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CSSSatyr
{
    public partial class fromCreate : Form
    {
        private PicturePanel picPanel = null;
        public fromCreate(PicturePanel pp)
        {
            picPanel = pp;
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
            numImageQuality.Value = Global.CurrentProject.ImageQuality;
            txtExportPath.Text = AppDomain.CurrentDomain.BaseDirectory;

            ChangeLanguage();
        }

        public void ChangeLanguage()
        {
            tabPageExport.Text = CommonLib.GetLocalString("create_export_tab_title");
            labCreateImageFormat.Text = CommonLib.GetLocalString("setting_project_image_create_format");
            labExportPath.Text = CommonLib.GetLocalString("create_export_path");
            labImageQuality.Text = CommonLib.GetLocalString("setting_project_image_quailty");

            btnOK.Text = CommonLib.GetLocalString("alert_ok");
            btnCancel.Text = CommonLib.GetLocalString("alert_cancel");
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
            var exportPath = txtExportPath.Text;
            int quality = trackImageQuality.Value;
            if (quality >= 0 && quality <= 100)
                Global.CurrentProject.ImageQuality = (short)quality;

            var val = comboBoxExportFormat.SelectedItem as Models.ImageType;
            if (System.IO.Directory.Exists(exportPath) == false)
            {
                MessageBox.Show(CommonLib.GetLocalString("not_exists_export_path"), CommonLib.GetLocalString("alert_windows_title"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (val?.CodecInfo == null)
            {
                MessageBox.Show(CommonLib.GetLocalString("not_exists_image_format"), CommonLib.GetLocalString("alert_windows_title"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (picPanel == null)
            {
                MessageBox.Show(CommonLib.GetLocalString("not_exists_image_panel_object"), CommonLib.GetLocalString("alert_windows_title"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (picPanel.Controls.Count == 0)
            {
                MessageBox.Show(CommonLib.GetLocalString("not_exists_images"), CommonLib.GetLocalString("alert_windows_title"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newExportPath = $"{exportPath}\\{Global.CurrentProject.Name}\\";
            if (Directory.Exists(newExportPath) == false)
            {
                try
                {
                    Directory.CreateDirectory(newExportPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CommonLib.GetLocalString("alert_windows_title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Global.CurrentProject.ImageFormat = val.MimeType.ToLower();


            EncoderParameters encoderParams = new EncoderParameters(2);
            encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionLZW);
            ImageCodecInfo codecInfo = val.CodecInfo;
            var r = picPanel.Rectangle;

            StringBuilder cssBuilder = new StringBuilder();
            StringBuilder htmlBuilder = new StringBuilder();
            
            cssBuilder.AppendLine($".pic {{background-image: url(\"image{val.ExtName}\"); display: block;}}");
            cssBuilder.AppendLine($"/*{DateTime.Now}*/");
            htmlBuilder.AppendLine("<li class=\"classname\">ALL INO ONE:</li>")
                        .AppendLine($"<li><img src=\"image{val.ExtName}\" class=\"allinone\" alt=\"image\" /></li>")
                        .AppendLine("<li class=\"classname\">HOW TO USE:</li>");
            foreach (PictureBox button in picPanel.Controls)
            {
                Image btn_image = button.Image;
                ImageItem tag = button.Tag as ImageItem;
                if (btn_image == null || tag == null)
                    continue;
                string className = $"{Global.CurrentProject.DefaultCssName}{tag.ClassName}";

                cssBuilder.AppendLine($".{className} {{background-position: -{tag.X-r.X}px -{tag.Y-r.Y}px; width:{tag.Width}px; height:{tag.Height}px; }}");

                htmlBuilder.AppendLine("<li class=\"classname\">" + tag.ClassName + "</li>")
                    .AppendLine("<li><pre>&nbsp;&lt;span class=\"pic " + className + "\"&gt;&lt;/span&gt;</pre></li>")
                    .AppendLine("<li class=\"classmark\">" + tag.Mark + "</li>")
                    .AppendLine("<li class=\"pic " + className + "\"></li>");

                if (tag.Width < 20)
                {
                    //ICON
                    cssBuilder.AppendLine($".{className}_li {{background-position: -{tag.X - r.X}px -{tag.Y - r.Y}px;  background-repeat:no-repeat; padding-left: {tag.Width+3}px; height:{tag.Height}px; line-height:{tag.Height}px; }}");
                    htmlBuilder.AppendLine("<li class=\"classname\">" + tag.ClassName + " for list</li>")
                        .AppendLine("<li><pre>&nbsp;&lt;li class=\"pic " + className + "_li\"&gt; Some Texts &lt;/li&gt;</pre></li>")
                        .AppendLine("<li class=\"classmark\">" + tag.Mark + "</li>")
                        .AppendLine("<li><ul>")
                        .AppendLine($"<li class=\"pic {className}_li\">What is CSS-Sprites?</li>")
                        .AppendLine($"<li class=\"pic {className}_li\">Why CSS-Sprites?</li>")
                        .AppendLine("</ul></li>");
                }

            }
            htmlBuilder.Insert(0, "<ul>").AppendLine("</ul>");
            string html = CSSSatyr.Properties.Resources.create_template.Replace("{#project_name}", Global.CurrentProject.Name)
                .Replace("{#create_css}", cssBuilder.ToString())
                .Replace("{#soft_homepage}", Properties.Resources.URL_HomePage)
                .Replace("{#create_html}", htmlBuilder.ToString())
                .Replace("{#project_author}", Global.CurrentProject.Author?.Length>0 ? Global.CurrentProject.Author : Global.ProductName)
                .Replace("{#soft_name}", Global.ProductName)
                .Replace("{#project_createtime}", CommonLib.ToDateTime(Global.CurrentProject.CreateTime).ToString());

            picPanel.SavePanelToImage($"{newExportPath}image{val.ExtName}", codecInfo, encoderParams);
            //$"{exportPath}{Global.CurrentProject.Name}.{val.ExtName}"
            using (var writer = File.CreateText($"{newExportPath}page.htm"))
            {
                writer.Write(html);
                writer.Flush();
                writer.Close();
            }
            MessageBox.Show(CommonLib.GetLocalString("export_ok"), CommonLib.GetLocalString("alert_windows_title"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
