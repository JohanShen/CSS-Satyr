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
using CSSSatyr.Models;
using CSSSatyr.Extends;
using System.Diagnostics;

namespace CSSSatyr
{
    public partial class MainForm : Form
    {
        //private TextureBrush textureBrush;
        public MainForm()
        {
            InitializeComponent();
            this.MainPictureBox.ImageChanged += new MyControls.ImageChangeHandler<MyControls.ImageArgs>(MainPictureBox_ImageSelected);
            //this.MainPictureBox.MouseWheel += new MouseEventHandler( this.MainPictureBox_MouseWheel);
        }

        private void MainPictureBox_ImageSelected(object sender, MyControls.ImageArgs e)
        {
            switch (e.Action)
            {
                case MyControls.OperationAction.Selected:
                    {
                        if (e.Control != null && e.Control.Tag != null)
                            this.propertyGrid1.SelectedObject = e.Control.Tag;
                        break;
                    }
                case MyControls.OperationAction.Removed:
                    {
                        this.propertyGrid1.SelectedObject = null;
                        //删除左侧目录树显示
                        break;
                    }
                case MyControls.OperationAction.Added:
                    {
                        break;
                    }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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
                li.ImageIndex = i++% imageList1.Images.Count ;
                this.listView1.Items.Add(li);
            }

            /*
            //产生子控件
            Point pic_loca = new Point(0, 0);
            for (int i = 0; i < 300; i++)
            {
                Image image = imageList1.Images[i % 3];
                ImageItem ii = new ImageItem();
                ii.ClassName = String.Format("cls_{0}", i);
                PictureBox button = new PictureBox();
                button.Tag = ii;
                //button.Name = msg.ClassName;
                button.BackColor = Color.White;
                button.ForeColor = Color.Transparent;
                button.Size = new Size(image.Width, image.Height );
                button.SizeMode = PictureBoxSizeMode.CenterImage;
                button.Location = pic_loca;
                button.Margin = new Padding(0);
                button.Padding = new Padding(0);
                //button.Padding = new Padding(this.padding);
                //button.FlatStyle = FlatStyle.Flat;
                button.MouseDown += new MouseEventHandler(this.pic_MouseDown);
                button.MouseUp += new MouseEventHandler(this.pic_MouseUp);
                button.MouseMove += new MouseEventHandler(this.pic_MouseMove);
                button.PreviewKeyDown += new PreviewKeyDownEventHandler(this.pic_PreviewKeyDown);
                
                button.LocationChanged += new EventHandler(this.pic_LocationChanged);
                
                button.TabStop = false;
                button.Cursor = Cursors.SizeAll;

                button.Image = image;
                this.MainPictureBox.Controls.Add(button);
                pic_loca = new Point(0, pic_loca.Y + 32);

            }
            this.MainPictureBox.Refresh();
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
            }
        }

        private void autoSorptionGridToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            if (item != null)
            {
                Global.AlignMode = item.Checked ? AlignMode.AutoAlign : AlignMode.FreeAlign;
            }
        }
        /*
        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            var box = sender as Panel;
            if (box != null)
            {
                var r = box.ClientRectangle;
                int sNum = Global.GridSizeNum;
                int boxX = box.DisplayRectangle.X;
                int boxY = box.DisplayRectangle.Y;
                int boxW = box.Width;
                int boxH = box.Height;
                int diffWidth = 0, diffHeight = 0;

                if (boxY < 0)
                {
                    int diffY = Math.Abs(boxY) % sNum;
                    //Console.WriteLine("x={0} y={1} w={2} h={3} diff={4}", boxX, boxY, boxW, boxH, diffY);
                    if (diffY > 0)
                    {
                        diffHeight = sNum - diffY;
                        e.Graphics.FillRectangle(Global.CreateBrush(sNum, diffHeight), new Rectangle(0, 0, boxW, diffHeight));
                    }
                }
                if (boxX < 0)
                {
                    int diffX = Math.Abs(boxX) % sNum;
                    //Console.WriteLine("x={0} y={1} w={2} h={3} diff={4}", boxX, boxY, boxW, boxH, diffX);
                    if (diffX > 0)
                    {
                        diffWidth = sNum - diffX;
                        e.Graphics.FillRectangle(Global.CreateBrush(diffWidth, sNum), new Rectangle(0, 0, diffWidth, boxH));
                    }
                }
                e.Graphics.FillRectangle(Global.CreateBrush(diffWidth, diffHeight, sNum, sNum), r);
            }
        }
        */


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
        private void changeLanguage() {
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
    }
}
