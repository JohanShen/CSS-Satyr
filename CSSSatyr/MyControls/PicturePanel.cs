using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CSSSatyr.Models;
using System.Drawing.Imaging;
using CSSSatyr.Extends;

namespace CSSSatyr.MyControls
{
    public delegate void ImageChangeHandler<T>(object sender, T e) where T : ImageArgs;
    public class PicturePanel : Panel
    {
        private int padding = 1;
        private List<ImageItem> items = new List<ImageItem>();
        private Point minPoint = new Point(0, 0);
        private Point maxPoint = new Point(0, 0);
        private Point nextLocation = new Point(0, 0);
        private Point mouseOffset = new Point(0, 0);
        private Point mouseLastPoint = new Point(0, 0);
        private PictureBox activeBox = null;

        public PicturePanel()
        {
            this.AllowDrop = true;
            this.AutoScroll = true;
            //base.AllowDrop = true;
            base.DragDrop += new DragEventHandler(PicturePanel_DragDrop);
            base.DragEnter += new DragEventHandler(PicturePanel_DragEnter);
            base.Paint += new PaintEventHandler(PictureBoxGrid_Paint);
            //base.Scroll += new ScrollEventHandler(PicturePanel_Scroll);
            //base.MouseWheel += new MouseEventHandler(PicturePanel_MouseWheel);
            base.ControlAdded += new ControlEventHandler(PicturePanel_ControlAdded);
            base.ControlRemoved += new ControlEventHandler(PicturePanel_ControlRemoved);
            //base.PreviewKeyDown += new PreviewKeyDownEventHandler(PicturePanel_PreviewKeyDown);
        }

        public void PKeyDown(Keys keyData)
        {
            this.PicturePanel_PreviewKeyDown(this, new PreviewKeyDownEventArgs(keyData));
        }

        private void PicturePanel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var button = activeBox;
            int x = 0, y = 0;
            if (button == null || e.Alt || e.Shift)
                return;

            bool ctrl = e.Control;
            int space_num = Global.AutoAlignSpaceNum;
            Keys keyValue = e.KeyCode;
            x = button.Location.X;
            y = button.Location.Y;
            switch (keyValue)
            {
                case Keys.Left:
                    {
                        if (x >= 1)
                        {
                            if (ctrl)
                                x -= space_num;
                            else
                                x--;
                        }
                        else
                        {
                            x = 0;
                        }
                        button.Location = new Point(x, y);
                        return;
                    }
                case Keys.Up:
                    {
                        if (y >= 1)
                        {
                            if (ctrl)
                                y -= space_num;
                            else
                                y--;
                        }
                        else
                        {
                            y = 0;
                        }
                        button.Location = new Point(x, y);
                        return;
                    }
                case Keys.Right:
                    {
                        if (ctrl)
                            x += space_num;
                        else
                            x++;
                        button.Location = new Point(x, y);
                        return;
                    }
                case Keys.Down:
                    {
                        if (ctrl)
                            y += space_num;
                        else
                            y++;
                        button.Location = new Point(x, y);
                        return;
                    }
                case Keys.Delete:
                    {
                        //this.now_w -= button.Width;
                        //this.now_h -= button.Height;
                        //ClassMsg tag = (ClassMsg)button.Image.Tag;
                        this.Controls.Remove(button);
                        ImageChange(new ImageArgs(button, OperationAction.Removed, MouseClickType.None));
                        activeBox = null;
                        return;
                    }
                default:
                    break;
            }
        }

        private void PicturePanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) ||
               e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        public event ImageChangeHandler<ImageArgs> ImageChanged;
        private void ImageChange(ImageArgs s)
        {
            ImageChanged?.Invoke(this, s);
        }


        public void InsertImage(string path) {
            Image img = Image.FromFile(path);
            InsertImage(img);
        }

        public void InsertImage(byte[] bytes)
        {
            Image img = Image.FromStream(new MemoryStream(bytes));
            InsertImage(img);
        }

        public void InsertImage(Image image) {

            ImageItem ii = new ImageItem(image.Width, image.Height, nextLocation.X, nextLocation.Y, image.RawFormat)
            {
                ClassName = String.Format("c{0}", items.Count + 1),
                ShowHeight = image.Height,
                ShowWidth = image.Width,
            };
            items.Add(ii);
            PictureBox button = new PictureBox();
            button.Image = image;
            button.SendToBack();
            button.BackColor = Color.Transparent;
            button.Tag = ii;
            button.Name = ii.ClassName;
            button.Parent = this;
            //button.BackColor = Color.White;
            button.ForeColor = Color.Transparent;
            button.Size = new Size(image.Width, image.Height);
            button.SizeMode = PictureBoxSizeMode.CenterImage;
            button.Location = nextLocation;
            button.Margin = new Padding(0);
            button.Padding = new Padding(padding);
            button.Width = button.Image.Width + button.Padding.Left + button.Padding.Right;
            button.Height = button.Image.Height + button.Padding.Top + button.Padding.Bottom;
            button.MouseDown += new MouseEventHandler(this.pic_MouseDown);
            button.MouseUp += new MouseEventHandler(this.pic_MouseUp);
            button.MouseMove += new MouseEventHandler(this.pic_MouseMove);
            //button.PreviewKeyDown += new PreviewKeyDownEventHandler(this.pic_PreviewKeyDown);

            button.LocationChanged += new EventHandler(this.pic_LocationChanged);

            button.TabStop = false;
            button.Cursor = Cursors.SizeAll;

            this.Controls.Add(button);

            ImageChange(new ImageArgs(button, OperationAction.Added, MouseClickType.MouseLeftUp));


            nextLocation = new Point(nextLocation.X + button.Width, nextLocation.Y);
            if (nextLocation.X > this.Width)
            {
                nextLocation = new Point(0, nextLocation.Y + button.Height);
            }

        }


        private void pic_LocationChanged(object sender, EventArgs e)
        {
        }

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            var button = sender as PictureBox;
            if (button != null && MouseButtons.Left == e.Button)
            {
                mouseOffset = new Point(-e.X, -e.Y);
                button.BackColor = Color.Red;
                button.Focus();
                button.BringToFront();
                //button.Focus();
            }
        }
        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            var button = sender as PictureBox;
            if (button != null)
            {
                activeBox = button;
                //this.propertyGrid1.SelectedObject = button.Tag;
                ImageChange(new ImageArgs(button, OperationAction.Selected, MouseClickType.MouseLeftUp));
                button.BackColor = Color.Transparent;
                //MainSplitContainer.Focus();
                //button.Invalidate();
                //this.Focus();
                //base.Invalidate();
            }
        }

        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            var button = sender as PictureBox;
            if (button != null && MouseButtons.Left == e.Button)
            {
                Point mousePosition = Control.MousePosition;
                mousePosition.Offset(mouseOffset);
                Point point = this.PointToClient(mousePosition);

                if (Global.AlignMode == AlignMode.AutoAlign)
                {
                    point.X = CommonLib.GetSpaceNum(point.X);
                    point.Y = CommonLib.GetSpaceNum(point.Y);
                }
                if (point.X < 0)
                {
                    point.X = 0;
                }
                if (point.Y < 0)
                {
                    point.Y = 0;
                }

                if (point.Equals(mouseLastPoint))
                    return;

                ImageItem image = button.Tag as ImageItem;
                image?.SetLocation(point);
                //button.SuspendLayout();
                button.Location = point;
                //button.ResumeLayout(false);
                mouseLastPoint = point;
                //Console.WriteLine(String.Format("move({0},{1})", point.X, point.Y));
                //button.Invalidate();
            }
        }
        
        private void PicturePanel_DragDrop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Assign the file names to a string array, in 
                // case the user has selected multiple files.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                try
                {
                    this.SuspendLayout();
                    foreach (string path in files)
                    {
                        //string path = obj2.ToString();
                        if (Directory.Exists(path))
                        {
                            DirectoryInfo info = new DirectoryInfo(path);
                            foreach (FileInfo info2 in info.GetFiles())
                            {
                                string path1 = info2.FullName;
                                //检查文件类型
                                InsertImage(path1);
                            }
                        }
                        else if (File.Exists(path))
                        {
                            //检查文件类型
                            InsertImage(path);
                        }
                    }
                    this.ResumeLayout(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            // Handle Bitmap data.
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                try
                {
                    // Create an Image and assign it to the picture variable.
                    //this.picture = (Image)e.Data.GetData(DataFormats.Bitmap);
                    // Set the picture location equal to the drop point.
                    //this.pictureLocation = this.PointToClient(new Point(e.X, e.Y));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            /*
            //throw new NotImplementedException();
            Array data = (Array)e.Data.GetData(DataFormats.FileDrop);
            foreach (object obj2 in data)
            {
                string path = obj2.ToString();
                if (Directory.Exists(path))
                {
                    DirectoryInfo info = new DirectoryInfo(path);
                    foreach (FileInfo info2 in info.GetFiles())
                    {
                        path = info2.FullName;
                        //检查文件类型
                        InsertImage(path);
                    }
                }
                else if (File.Exists(path))
                {
                    //检查文件类型
                    InsertImage(path);
                }
            }*/
        }

        private void PicturePanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void PicturePanel_ControlAdded(object sender, ControlEventArgs e)
        {
            //throw new NotImplementedException();
            
        }

        private void PicturePanel_MouseWheel(object sender, MouseEventArgs e)
        {
            //this.Update();
        }

        private void PicturePanel_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.ThumbPosition)
            {
                //this.Update();
            }
        }

        private void PictureBoxGrid_Paint(object sender, PaintEventArgs e)
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
                    if (diffY > 0)
                    {
                        diffHeight = sNum - diffY;
                        e.Graphics.FillRectangle(CommonLib.DrawRectangle(sNum, diffHeight), new Rectangle(0, 0, boxW, diffHeight));
                    }
                }
                if (boxX < 0)
                {
                    int diffX = Math.Abs(boxX) % sNum;
                    if (diffX > 0)
                    {
                        diffWidth = sNum - diffX;
                        e.Graphics.FillRectangle(CommonLib.DrawRectangle(diffWidth, sNum), new Rectangle(0, 0, diffWidth, boxH));
                    }
                }
                e.Graphics.FillRectangle(CommonLib.DrawRectangle(diffWidth, diffHeight, sNum, sNum), r);
                
            }
        }
    }



    public class ImageArgs : EventArgs
    {
        public ImageArgs() { }
        public ImageArgs(Control control, OperationAction action, MouseClickType clickType)
        {
            Control = control;
            Action = action;
            MouseClickType = clickType;
        }
        public Control Control { get; set; }
        public OperationAction Action {get;set;}
        public MouseClickType MouseClickType { get; set; }
    }

    public enum OperationAction
    {
        None = 1,
        /// <summary>
        /// 新增
        /// </summary>
        Added = 1,
        /// <summary>
        /// 删除
        /// </summary>
        Removed = 2,
        /// <summary>
        /// 移动
        /// </summary>
        Moved = 3,
        /// <summary>
        /// 选中
        /// </summary>
        Selected = 4,
    }

    public enum MouseClickType
    {
        None = 0,
        MouseLeftDown = 11,
        MouseLeftUp = 12,
        MouseLeftMove = 13,
        MouseRightDown = 21,
        MouseRightUp = 22,
        MouseRightMove = 23,
        MouseMiddleDown = 31,
        MouseMiddleUp = 32,
        MouseMiddleMove = 33,
        MouseMiddleWheel = 35,
        MouseDoubleClickLeft = 91,
        MouseMiddleClickMiddle = 92,
        MouseDoubleClickRight = 93,
    }

}
