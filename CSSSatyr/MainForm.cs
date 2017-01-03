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
            InitializeComponent();
            tsslSpaceLabel.Text = "";
            easyTrackBar1.Value = Global.GridSizeNum;
            _defaultGroup = CommonLib.CreateNewProject(listView1);
            tsStatusNewVersionLabel.Text = String.Format("当前版本:{0}", Global.ProductVersion);
            Global.ProjectSaved = true;
            ReWriteTitle();

            this.MainPictureBox.ImageChanged += new ImageChangeHandler<ImageArgs>(MainPictureBox_ImageSelected);
        }

        private void ReWriteTitle()
        {
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
                tsStatusAutoSorption.Text = String.Format("对齐模式：{0}", item.Checked ? "吸附模式" : "自由模式");
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
            EncoderParameters encoderParams = new EncoderParameters(2);
            encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100);
            encoderParams.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionLZW);
            ImageCodecInfo codecInfo = CommonLib.GetCodecInfo("image/png");

            MainPictureBox.SavePanelToImage(String.Format("d:\\{0}.png", Guid.NewGuid().ToString()), codecInfo, encoderParams);
        }



        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.Lang = Global.Lang == "zh-CN" ? "en-US" : "zh-CN";
            changeLanguage();
        }
        private void changeLanguage()
        {
            fileToolStripMenuItem.Text = CommonLib.GetLocalString("file");
            addImagesToolStripMenuItem.Text = CommonLib.GetLocalString("add_images");
            viewToolStripMenuItem.Text = CommonLib.GetLocalString("view");
            exitToolStripMenuItem.Text = CommonLib.GetLocalString("exit");
            helpToolStripMenuItem.Text = CommonLib.GetLocalString("help");
            createToolStripMenuItem.Text = CommonLib.GetLocalString("create");
            settingToolStripMenuItem.Text = CommonLib.GetLocalString("setting");

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
                tsslGridSize.Text = String.Format("网格大小:{0}", e.NewValue);
                MainPictureBox.Invalidate();
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
                && MessageBox.Show("项目为空，确定要保存工程吗？", "空项目", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.SupportMultiDottedExtensions = false;
            saveFileDialog.Filter = "CSS-Satry Project File(2016)|*.cssp";
            if (String.IsNullOrEmpty(Global.SavedPath) && saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Global.SavedPath = saveFileDialog.FileName;
            }
            if (String.IsNullOrEmpty(Global.SavedPath) == false)
            {
                Project p = new Project();
                p.Author = "沈秋寒";
                p.AutoSorption = true;
                p.CompressType = 1;
                p.CreateTime = CommonLib.ToUnixTime(DateTime.Now);
                p.DefaultCssName = "csss_";
                p.GridSizeNum = Global.GridSizeNum;
                p.Language = "zh-cn";
                p.LastTime = CommonLib.ToUnixTime(DateTime.Now);
                p.Name = _defaultGroup.Header;
                p.ShowGrid = true;
                p.ShowSider = true;
                p.SorptionNum = Global.AutoAlignSpaceNum;
                p.GridStyleName = Global.GridStyle.Name;
                p.GridBgColor = CommonLib.ColorToInt(Global.GridStyle.BgColor);
                p.GridLineColor = CommonLib.ColorToInt(Global.GridStyle.LineColor);
                p.GridLineWidth = Global.GridStyle.LineWidth;

                p.ExtendInfos.Add(new ExtendInfo() { Name = "TestA", Value = "ValueA" });
                p.ExtendInfos.Add(new ExtendInfo() { Name = "测试B", Value = "值B" });

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
            openfileDialog.Filter = "CSS-Satry Project File(2016)|*.cssp";

            if (openfileDialog.ShowDialog() == DialogResult.OK)
            {
                //TODO: 添加打开错误异常
                byte[] buffer;
                using (FileStream fs = new FileStream(openfileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                    fs.Close();
                }
                Project p = Project.ReadFromBytes(buffer);

                _defaultGroup = CommonLib.CreateNewProject(listView1, p.Name);

                MainPictureBox.Clear();
                easyTrackBar1.Value = Global.GridSizeNum = p.GridSizeNum;
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
            Thread t = new Thread(new ParameterizedThreadStart(run));
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
            //saveFileDialog.Filter = "CSS-Satry Project File(2016)|*.*";
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
        
    }
}
