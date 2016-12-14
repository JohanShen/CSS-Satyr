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

            this.MainPictureBox.ImageChanged += new MyControls.ImageChangeHandler<MyControls.ImageArgs>(MainPictureBox_ImageSelected);
        }

        private void MainPictureBox_ImageSelected(object sender, MyControls.ImageArgs e)
        {
            if (e == null || e.Control == null || e.Control.Tag == null)
                return;

            PictureBox picBox = e.Control as PictureBox;
            ImageItem imgItem = e.Control.Tag as ImageItem;
            if (imgItem == null)
                return;

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
            Image image = new Bitmap(this.MainPictureBox.DisplayRectangle.Width, this.MainPictureBox.DisplayRectangle.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.Transparent);
            foreach (PictureBox button in this.MainPictureBox.Controls)
            {
                Image btn_image = button.Image;
                ImageItem tag = button.Tag as ImageItem;
                if (btn_image == null || tag == null)
                    continue;

                graphics.DrawImage(btn_image, tag.X, tag.Y, tag.ShowWidth, tag.ShowHeight);
            }
            graphics.Save();
            graphics.Dispose();
            EncoderParameters encoderParams = new EncoderParameters(2);
            encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100);
            encoderParams.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionLZW);
            ImageCodecInfo codecInfo = CommonLib.GetCodecInfo("image/png");
            int width = image.Width;// this.imgSize.MaxX - this.imgSize.MinX;
            int height = image.Height;// this.imgSize.MaxY - this.imgSize.MinY;
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics2 = Graphics.FromImage(bitmap);
            graphics2.DrawImage(image, new Rectangle(0, 0, width, height), new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);
            graphics2.Dispose();
            //text = text + "." + selectedItem.Value;
            bitmap.Save("d:\\123.png", codecInfo, encoderParams);
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
                tsslGridSize.Text = String.Format("GridSize:{0}", e.NewValue);
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
            p.GridBgColor = CommonLib.ColorToInt( Global.GridStyle.BgColor);
            p.GridLineColor = CommonLib.ColorToInt(Global.GridStyle.LineColor);
            p.GridLineWidth = Global.GridStyle.LineWidth;

            p.ExtendInfos.Add(new ExtendInfo() { Name = "TestA", Value = "ValueA" });
            p.ExtendInfos.Add(new ExtendInfo() { Name = "测试B", Value = "值B" });

            ImagePanel ip = new ImagePanel();
            ip.Name = "Default Panel(1)";
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
                    Key = ii.Id,// BitConverter.ToInt64(Guid.NewGuid().ToByteArray(), 0),
                    Mark = ii.Mark,
                    ShowHeight = ii.ShowHeight,
                    ShowWidth = ii.ShowWidth,
                    Width = ii.Width,
                    X = ii.X,
                    Y = ii.Y,
                    Content = CommonLib.ImageToBytes(img)
                });
            }
            p.Panels.Add(ip);

            p.SaveToFile("d:\\test.cssp", true);
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
            byte[] buffer;
            using (FileStream fs = new FileStream("d:\\test.cssp", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
                fs.Close();
            }
            Project p = Project.ReadFromBytes(buffer);

            _defaultGroup = CommonLib.CreateNewProject(listView1, p.Name);


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
            MainPictureBox.ChangeColor(new GridStyle() { BgColor = CommonLib.IntToColor(p.GridBgColor), LineColor = CommonLib.IntToColor(p.GridLineColor), LineWidth = p.GridLineWidth, Name = p.GridStyleName, ShowGrid = p.ShowGrid });


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
    }
}
