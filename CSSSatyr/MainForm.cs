using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using CSSSatyr.Models;
using CSSSatyr.Extends;
using CSSSatyr.MyControls;
using CSSSatyr.Filemeta.v1;
using System.Threading;

namespace CSSSatyr
{
    public partial class MainForm : Form
    {
        private static ListViewGroup _defaultGroup = null;

        public MainForm()
        {
            Global.Lang = Global.Config.Language ?? System.Globalization.CultureInfo.CurrentCulture.Name;
            InitializeComponent();

            tsslSpaceLabel.Text = "";
            etbGridSize.Value = Global.GridSizeNum;
            _defaultGroup = CommonLib.CreateNewProject(listView1, CommonLib.GetLocalString("main_default_project_name"));
            tsStatusNewVersionLabel.Text = String.Format(CommonLib.GetLocalString("status_now_version"), Global.ProductVersion);
            Global.ProjectSaved = true;

            //defaultLanguageToolStripMenuItem;

            foreach (var item in CommonLib.LangList)
            {
                var tsmi = new ToolStripMenuItem();
                tsmi.AutoSize = true;
                //tsmi.Size = new Size(200, 26);
                tsmi.TextAlign = ContentAlignment.MiddleCenter;
                tsmi.Text = item.Value;
                tsmi.Tag = item.Key;
                tsmi.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular);
                tsmi.Click += new EventHandler(Tsmi_Click);
                tsmi.Checked = item.Key.Equals(Global.Lang, StringComparison.CurrentCultureIgnoreCase);

                choiceLanguageToolStripMenuItem.DropDownItems.Add(tsmi);
            }
            this.MainPictureBox.ImageChanged += new ChangedEventHandler<ImageArgs>(MainPictureBox_ImageSelected);
        }

        private void Tsmi_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(sender);
            var c = sender as ToolStripMenuItem;
            if (c != null && c.Tag != null)
            {
                foreach (ToolStripMenuItem item in choiceLanguageToolStripMenuItem.DropDownItems)
                {
                    item.Checked = false;
                }
                c.Checked = true;
                Global.Config.Language = Global.Lang = c.Tag.ToString();
                Global.Config.Save();
                //Console.WriteLine(Global.Lang);
                changeLanguage();
            }
        }

        private void ReWriteTitle()
        {
            _defaultGroup.Header = Global.CurrentProject?.Name;
            this.Text = String.Format("{3}{0} {4} - {1} v2.0 beta", _defaultGroup.Header, Global.ProductName, Global.ProductVersion, Global.ProjectSaved ? "" : "*", Global.SavedPath);
        }

        private void MainPictureBox_ImageSelected(object sender, MyControls.ImageArgs e)
        {
            if (e == null || e.Control == null || e.Control.Tag == null)
                return;

            PictureBox picBox = e.Control as PictureBox;
            ImageItem imgItem = e.Control.Tag as ImageItem;
            if (imgItem == null)
                return;

            Global.ProjectSaved = false;
            ReWriteTitle();

            switch (e.Action)
            {
                case OperationAction.Selected:
                    {
                        if (e.Control != null && e.Control.Tag != null)
                        {
                            this.propertyGrid1.SelectedObject = e.Control.Tag;
                            //int index = listView1.Items.IndexOfKey(imgItem.Id.ToString());
                            //listView1.Items[index].Selected = true;
                        }
                        break;
                    }
                case OperationAction.Removed:
                    {
                        this.propertyGrid1.SelectedObject = null;
                        listView1.Items.RemoveByKey(imgItem.Id.ToString());
                        break;
                    }
                case OperationAction.EditTag:
                    {
                        ListViewItem[] lvis = listView1.Items.Find(imgItem.Id.ToString(), true);
                        if (lvis.Length > 0)
                        {
                            foreach(ListViewItem lvi in lvis)
                            {
                                lvi.Text = imgItem.ClassName;
                            }
                        }
                        break;
                    }
                case OperationAction.Added:
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Group = _defaultGroup;
                        lvi.ToolTipText = imgItem.ClassName;
                        lvi.Text = imgItem.ClassName;
                        lvi.Name = imgItem.Id.ToString();
                        lvi.ImageIndex = imgItem.ImageType.ImageIndex;
                        lvi.Tag = imgItem;
                        listView1.Items.Add(lvi);
                        break;
                    }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            /*
            int i = 0;
            ListViewGroup lvg = new ListViewGroup();
            lvg.Header = "New project(1)";
            lvg.HeaderAlignment = HorizontalAlignment.Center;
            listView1.Groups.Add(lvg);
            foreach (Process pro in Process.GetProcesses())
            {
                ListViewItem li = new ListViewItem();
                li.Group = lvg;
                li.ToolTipText = pro.MainWindowTitle;
                li.Text = pro.ProcessName.ToString();
                li.ImageIndex = i++ % imageList1.Images.Count;
                this.listView1.Items.Add(li);
            }
            */

        }


        private void pic_LocationChanged(object sender, EventArgs e)
        {
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void showSiderTreeToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            if (item != null)
            {
                BodyContainer.Panel1Collapsed = !item.Checked;
                tsbShowLeftTree.Checked = item.Checked;
            }
        }

        private void autoSorptionGridToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            if (item != null)
            {
                Global.AlignMode = item.Checked ? AlignMode.AutoAlign : AlignMode.FreeAlign;
                tsbtnAutoSorption.Checked = item.Checked;
                tsStatusAutoSorption.Text = CommonLib.GetLocalString("status_sorption_model", item.Checked ? CommonLib.GetLocalString("status_sorption_model_auto") : CommonLib.GetLocalString("status_sorption_model_free"));
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.propertyGrid1.SelectedObject != null)
            {
                //Console.WriteLine(keyData == (Keys.Left | Keys.Control));
                if (keyData == Keys.Left
                    || keyData == Keys.Right
                    || keyData == Keys.Up
                    || keyData == Keys.Down
                    ||
                    keyData == (Keys.Control | Keys.Left)
                    || keyData == (Keys.Control | Keys.Right)
                    || keyData == (Keys.Control | Keys.Up)
                    || keyData == (Keys.Control | Keys.Down)
                    || keyData == Keys.Delete
                    )
                {
                    MainPictureBox.PKeyDown(keyData);
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            //TODO: 导出图片判断
            EncoderParameters encoderParams = new EncoderParameters(2);
            encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100);
            encoderParams.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionLZW);
            ImageCodecInfo codecInfo = CommonLib.GetCodecInfo("image/png");

            MainPictureBox.SavePanelToImage(String.Format("d:\\{0}.png", Guid.NewGuid().ToString()), codecInfo, encoderParams);
            */
            new fromCreate(MainPictureBox).ShowDialog();
        }



        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSetting setting = new frmSetting();
            setting.ShowDialog(this);
        }
        private void changeLanguage()
        {
            fileToolStripMenuItem.Text = CommonLib.GetLocalString("menu_file");
            addImagesToolStripMenuItem.Text = CommonLib.GetLocalString("menu_file_add_images");
            exportImagesToolStripMenuItem.Text = CommonLib.GetLocalString("menu_file_export_image");
            newProjectToolStripMenuItem.Text = CommonLib.GetLocalString("menu_file_new_project");
            openProjectToolStripMenuItem.Text = CommonLib.GetLocalString("menu_file_open_project");
            saveProjectToolStripMenuItem.Text = CommonLib.GetLocalString("menu_file_save_project");
            exitToolStripMenuItem.Text = CommonLib.GetLocalString("menu_file_exit");

            viewToolStripMenuItem.Text = CommonLib.GetLocalString("menu_view");
            reOrderImagesToolStripMenuItem.Text = CommonLib.GetLocalString("menu_view_reorder");
            showGridToolStripMenuItem.Text = CommonLib.GetLocalString("menu_view_show_grid");
            autoSorptionGridToolStripMenuItem.Text = CommonLib.GetLocalString("menu_view_auto_sorption");
            showSiderTreeToolStripMenuItem.Text = CommonLib.GetLocalString("menu_view_sider_tree");
            choiceLanguageToolStripMenuItem.Text = CommonLib.GetLocalString("menu_view_choice_language");

            settingToolStripMenuItem.Text = CommonLib.GetLocalString("menu_setting");

            createToolStripMenuItem.Text = CommonLib.GetLocalString("menu_create");

            helpToolStripMenuItem.Text = CommonLib.GetLocalString("menu_help");
            howToUseToolStripMenuItem.Text = CommonLib.GetLocalString("menu_help_howto");
            //checkVersionToolStripMenuItem.Text = CommonLib.GetLocalString("menu_help_check_version");
            submitSuggestToolStripMenuItem.Text = CommonLib.GetLocalString("menu_help_suggest");
            copyrightToolStripMenuItem.Text = CommonLib.GetLocalString("menu_help_copyright");
            homepageToolStripMenuItem.Text = CommonLib.GetLocalString("menu_help_homepage");


            etbGridSize.Text = CommonLib.GetLocalString("main_bar_grid_size");
            tsbtnAutoSorption.Text = CommonLib.GetLocalString("main_btn_auto_sorption");
            tsbtnColorChange.Text = CommonLib.GetLocalString("main_btn_grid_style");
            tsbtnReOrder.Text = CommonLib.GetLocalString("main_btn_reorder");
            tsbtnShowGrid.Text = CommonLib.GetLocalString("main_btn_show_grid");
            tsbShowLeftTree.Text = CommonLib.GetLocalString("main_btn_show_sidertree");
            tsbtnExportImage.Text = CommonLib.GetLocalString("main_btn_show_export_image");

            tsStatusNewVersionLabel.Text = CommonLib.GetLocalString("status_now_version", Global.ProductVersion);
            tsStatusAutoSorption.Text = CommonLib.GetLocalString("status_sorption_model", autoSorptionGridToolStripMenuItem.Checked ? CommonLib.GetLocalString("status_sorption_model_auto") : CommonLib.GetLocalString("status_sorption_model_free"));
            tsslStatusGridSize.Text =CommonLib.GetLocalString("status_grid_size", Global.GridSizeNum.ToString());

            propertyGrid1.Refresh();
        }

        private void reOrderImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;

            MainPictureBox.SuspendLayout();
            MainPictureBox.AutoScrollPosition = new Point(0, 0);
            foreach (PictureBox button in this.MainPictureBox.Controls)
            {
                //TODO: 优化算法，合理排列，防止图片重叠
                if (x < 0)
                {
                    x = 0;
                }
                if (y < 0)
                {
                    y = 0;
                }
                Point point = new Point(x, y);

                button.Location = point;
                ImageItem tag = button.Tag as ImageItem;
                tag.SetLocation(point);
                x += button.Width;
                if ((x + button.Width) > this.MainPictureBox.Width)
                {
                    x = 0;
                    y += button.Height;
                }
            }
            MainPictureBox.ResumeLayout();
        }

        private void easyTrackBar1_ValueChanged(EasyTrackBarValueChangedArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                Global.GridSizeNum = e.NewValue;
                tsslStatusGridSize.Text = CommonLib.GetLocalString("status_grid_size", e.NewValue.ToString());
                if (Global.GridStyle.ShowGrid)
                {
                    MainPictureBox.Invalidate();
                }
            }
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainPictureBox.Controls.Count == 0
                && MessageBox.Show(CommonLib.GetLocalString("save_empty_project"), CommonLib.GetLocalString("alert_windows_title"), MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.SupportMultiDottedExtensions = false;
            saveFileDialog.Filter = String.Format( "{0}(2017)|*.cssp", CommonLib.GetLocalString("project_file_format_2017"));
            if (String.IsNullOrEmpty(Global.SavedPath) && saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Global.SavedPath = saveFileDialog.FileName;
            }
            if (String.IsNullOrEmpty(Global.SavedPath) == false)
            {
                Project p = Global.CurrentProject;

                p.GridSizeNum = Global.GridSizeNum;
                p.Language = Global.Lang.ToLower();
                p.LastTime = CommonLib.ToUnixTime(DateTime.Now);
                p.AutoSorption = tsbtnAutoSorption.Checked;
                p.CompressType = 1;
                p.ShowGrid = tsbtnShowGrid.Checked;
                p.ShowSider = tsbShowLeftTree.Checked;
                p.SorptionNum = Global.AutoAlignSpaceNum;
                p.GridStyleName = Global.GridStyle.Name;
                p.GridBgColor = CommonLib.ColorToInt(Global.GridStyle.BgColor);
                p.GridLineColor = CommonLib.ColorToInt(Global.GridStyle.LineColor);
                p.GridLineWidth = Global.GridStyle.LineWidth;

                //p.ExtendInfos.Add(new ExtendInfo() { Name = "TestA", Value = "ValueA" });
                //p.ExtendInfos.Add(new ExtendInfo() { Name = "测试B", Value = "值B" });
                p.Panels.Clear();
                ImagePanel ip = new ImagePanel();
                ip.Name = "Default Panel";
                foreach (PictureBox c in MainPictureBox.Controls)
                {
                    ImageItem ii = c.Tag as ImageItem;
                    Image img = c.Image;
                    if (ii == null || img == null)
                        continue;
                    ip.Images.Add(new ImageObj()
                    {
                        CreateTime = CommonLib.ToUnixTime(DateTime.Now),
                        CssName = ii.ClassName,
                        Height = ii.Height,
                        ImageType = CommonLib.GetImageMimeTypeIndex(ii.ImageType.MimeType),
                        Key = ii.Id,
                        Mark = ii.Mark,
                        ShowHeight = ii.Height,
                        ShowWidth = ii.Width,
                        Width = ii.Width,
                        X = ii.X,
                        Y = ii.Y,
                        Content = CommonLib.ImageToBytes(img)
                    });
                }
                p.Panels.Add(ip);

                p.SaveToFile(Global.SavedPath, true);

                Global.ProjectSaved = true;
                ReWriteTitle();
            }
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            if (tsmi != null && tsmi.Tag != null)
            {
                GridStyle gridStyle = CommonLib.GetGridStyle(tsmi.Tag.ToString());
                if (gridStyle != null)
                {
                    gridStyle.ShowGrid = showGridToolStripMenuItem.Checked;
                    Global.GridStyle = gridStyle;
                    MainPictureBox.ChangeColor(gridStyle);
                }
            }
        }

        private void openProjectToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            if (Global.ProjectSaved == false && MessageBox.Show(CommonLib.GetLocalString("project_no_saved"), CommonLib.GetLocalString("confirm_windows_title"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                return;
            }


            OpenFileDialog openfileDialog = new OpenFileDialog();
            openfileDialog.AddExtension = true;
            openfileDialog.CheckFileExists = true;
            openfileDialog.Multiselect = false;
            openfileDialog.Filter = String.Format("{0}(2017)|*.cssp", CommonLib.GetLocalString("project_file_format_2017"));

            if (openfileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] buffer = null;
                try
                {
                    using (FileStream fs = new FileStream(openfileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, (int)fs.Length);
                        fs.Close();
                    }
                }
                catch(Exception ex)
                {
                    //将文件读取到流出错
                    MessageBox.Show(CommonLib.GetLocalString("open_project_file_error_exception", ex.Message), 
                        CommonLib.GetLocalString("alert_windows_title"), 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    return;
                }
                if (buffer == null)
                {
                    //加载的流文件为空
                    MessageBox.Show(CommonLib.GetLocalString("open_project_file_error_buffer_null"), 
                        CommonLib.GetLocalString("alert_windows_title"), 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }


                Project p = null;
                try
                {
                    p = Project.ReadFromBytes(buffer);
                }
                catch (Exception ex)
                {
                    //从流读取项目信息出错
                    MessageBox.Show(CommonLib.GetLocalString("open_project_format_error", ex.Message),
                        CommonLib.GetLocalString("alert_windows_title"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                _defaultGroup = CommonLib.CreateNewProject(listView1, p.Name);

                MainPictureBox.Clear();
                etbGridSize.Value = Global.GridSizeNum = p.GridSizeNum;

                //TODO: InsertImage 判断出错
                foreach (ImagePanel panel in p.Panels)
                    foreach (ImageObj io in panel.Images)
                        MainPictureBox.InsertImage(io.Content, io.CssName, io.X, io.Y, io.Mark, io.Key);

                if (tsbtnShowGrid.Checked != p.ShowGrid)
                {
                    tsbtnShowGrid.Checked = p.ShowGrid;
                    tsbtnShowGrid_Click(tsbtnShowGrid, e);
                }
                if (tsbtnAutoSorption.Checked != p.AutoSorption)
                {
                    tsbtnAutoSorption.Checked = p.AutoSorption;
                    tsbtnAutoSorption_CheckedChanged(tsbtnAutoSorption, e);
                }
                if (tsbShowLeftTree.Checked != p.ShowSider)
                {
                    tsbShowLeftTree.Checked = p.ShowSider;
                    toolStripButton1_CheckStateChanged(tsbShowLeftTree, e);
                }
                GridStyle gs = new GridStyle() { BgColor = CommonLib.IntToColor(p.GridBgColor), LineColor = CommonLib.IntToColor(p.GridLineColor), LineWidth = p.GridLineWidth, Name = p.GridStyleName, ShowGrid = p.ShowGrid };
                MainPictureBox.ChangeColor(gs);
                Global.GridStyle = gs;

                Global.SavedPath = openfileDialog.FileName;
                Global.ProjectSaved = true;
                Global.SetCurrentProject(p);
                ReWriteTitle();
            }

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lvis = listView1.SelectedItems;
            if (lvis != null && lvis.Count == 1)
            {
                ListViewItem lvi = lvis[0];
                ImageItem ii = lvi.Tag as ImageItem;
                if (ii != null)
                {
                    MainPictureBox.SelectItem(ii.Id);
                    MainPictureBox.Focus();
                    propertyGrid1.SelectedObject = ii;
                }
            }
        }

        private void tsbtnAutoSorption_CheckedChanged(object sender, EventArgs e)
        {
            var item = sender as ToolStripButton;
            if (item != null)
                autoSorptionGridToolStripMenuItem.Checked = item.Checked;
        }

        private void showGridToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            if (item != null)
            {
                Global.GridStyle.ShowGrid = item.Checked;
                tsbtnShowGrid.Checked = item.Checked;
                MainPictureBox.ChangeColor(Global.GridStyle);
            }
        }

        private void toolStripButton1_CheckStateChanged(object sender, EventArgs e)
        {
            var item = sender as ToolStripButton;
            if (item != null)
                showSiderTreeToolStripMenuItem.Checked = item.Checked;
        }

        private void tsbtnShowGrid_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripButton;
            if (item != null)
                showGridToolStripMenuItem.Checked = item.Checked;
        }

        private void tsbtnReOrder_Click(object sender, EventArgs e)
        {
            reOrderImagesToolStripMenuItem_Click(reOrderImagesToolStripMenuItem, e);
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //重新启动一个实例
            var t = new System.Threading. Thread(new ParameterizedThreadStart(run));
            object appName = Application.ExecutablePath;
            t.Start(appName);
        }


        private void run(Object obj)
        {
            Process ps = new Process();
            ps.StartInfo.FileName = obj.ToString();
            ps.Start();
        }

        private void exportImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainPictureBox.ActiveControlTag == null)
            {
                MessageBox.Show(CommonLib.GetLocalString("no_object"), CommonLib.GetLocalString("alert_windows_title"), MessageBoxButtons.OK);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.SupportMultiDottedExtensions = false;
            saveFileDialog.Filter = String.Format("Image File|{0}", MainPictureBox.ActiveControlTag.ImageType.ExtName);
            saveFileDialog.FileName = String.Format( "{0}{1}", MainPictureBox.ActiveControlTag.ClassName, MainPictureBox.ActiveControlTag.ImageType.ExtName );
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                MainPictureBox.SaveSingleImage(saveFileDialog.FileName);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.ProjectSaved == false)
            {
                if (MessageBox.Show(CommonLib.GetLocalString("project_no_saved"), CommonLib.GetLocalString("confirm_windows_title"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void copyrightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog(this);
            Global.ProjectSaved = false;
            ReWriteTitle();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            changeLanguage();
            ReWriteTitle();
        }

        private void homepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Resources.URL_HomePage);
        }

        private void submitSuggestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Resources.URL_Suggest);
            
        }

        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Process.Start(Properties.Resources.URL_HowToUse);
        }

        private void checkVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnExportImage_Click(object sender, EventArgs e)
        {
            exportImagesToolStripMenuItem_Click(sender, e);
        }
    }
}
