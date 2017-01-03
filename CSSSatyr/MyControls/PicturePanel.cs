using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CSSSatyr.Models;
using System.Drawing.Imaging;
using CSSSatyr.Extends;
using System.Collections;
using System.Drawing.Drawing2D;

namespace CSSSatyr.MyControls
{
    /// <summary>
    /// 控件委托
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ChangedEventHandler<T>(object sender, T e) where T : EventArgs;
    /// <summary>
    /// PicturePanel 控件
    /// </summary>
    public class PicturePanel : Panel
    {
        private int padding = 1;
        private List<ImageItem> imageCollection = new List<ImageItem>();
        private Point minPoint = new Point(0, 0);
        private Point maxPoint = new Point(0, 0);
        private Point nextLocation = new Point(0, 0);
        private Point mouseOffset = new Point(0, 0);
        private Point mouseLastPoint = new Point(0, 0);
        private PictureBox activeBox = null;
        private GridStyle gridStyle = CommonLib.GetGridStyle();

        public PicturePanel()
        {
            this.AllowDrop = true;
            base.AutoScroll = true;
            //base.AllowDrop = true;
            base.DragDrop += new DragEventHandler(PicturePanel_DragDrop);
            base.DragEnter += new DragEventHandler(PicturePanel_DragEnter);
            base.Paint += new PaintEventHandler(PictureBoxGrid_Paint);
            base.Scroll += new ScrollEventHandler(PicturePanel_Scroll);
            base.MouseWheel += new MouseEventHandler(PicturePanel_MouseWheel);
            base.ControlAdded += new ControlEventHandler(PicturePanel_ControlAdded);
            base.ControlRemoved += new ControlEventHandler(PicturePanel_ControlRemoved);
            base.MouseDown += new MouseEventHandler(PicturePanel_MouseDown);
            //base.MouseUp += new MouseEventHandler(PicturePanel_MouseDown);
            //base.PreviewKeyDown += new PreviewKeyDownEventHandler(PicturePanel_PreviewKeyDown);
        }

        /// <summary>
        /// 图片显示区域
        /// </summary>
        public Rectangle Rectangle
        {
            get
            {
                ArrayList xList = new ArrayList(), yList = new ArrayList();
                foreach (ImageItem item in imageCollection)
                {
                    xList.Add(item.X);
                    xList.Add(item.X + item.Width);
                    yList.Add(item.Y);
                    yList.Add(item.Y + item.Height);
                }
                xList.Sort();
                yList.Sort();

                int x = (int)xList[0], y = (int)yList[0];
                int width = (int)xList[xList.Count - 1] - x, height = (int)yList[yList.Count - 1] - y;
                return new Rectangle(x, y, width, height);
            }
        }

        /// <summary>
        /// 选中控件
        /// </summary>
        public PictureBox ActiveControl
        {
            get { return activeBox; }
        }

        /// <summary>
        /// 选中控件的 ImageItem 对象
        /// </summary>
        public ImageItem ActiveControlTag
        {
            get
            {
                return activeBox?.Tag as ImageItem;
            }
        }

        #region - 相应事件 -
        public void PKeyDown(Keys keyData)
        {
            this.PicturePanel_PreviewKeyDown(this, new PreviewKeyDownEventArgs(keyData));
        }

        /// <summary>
        /// 键盘调整图片位置和删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        Controls.Remove(button);
                        ImageChange(new ImageArgs(button, OperationAction.Removed, MouseClickType.None));
                        activeBox = null;
                        return;
                    }
                default:
                    break;
            }
        }



        private void PicturePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (activeBox != null)
            {
                if (MouseButtons.Right == e.Button)
                    activeBox.BackColor = Color.Red;
            }
        }


        /// <summary>
        /// 拖入图片和文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicturePanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) || e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
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

                if (activeBox != null)
                    activeBox.BackColor = Color.Transparent;
                //button.Focus();
            }
            else if (activeBox != null && MouseButtons.Right == e.Button)
            {
                activeBox.BackColor = Color.Red;
            }
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            var button = sender as PictureBox;
            if (button != null && MouseButtons.Left == e.Button)
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

        /// <summary>
        /// 拖动图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            var button = sender as PictureBox;
            if (button != null && MouseButtons.Left == e.Button)
            {
                Point mousePosition = MousePosition;
                mousePosition.Offset(mouseOffset);
                Point point = this.PointToClient(mousePosition);


                int boxX = this.DisplayRectangle.X;
                int boxY = this.DisplayRectangle.Y;
                int sNum = Global.GridSizeNum;


                if (Global.AlignMode == AlignMode.AutoAlign)
                {

                    int diffX = 0, diffY = 0;

                    if (boxY < 0)
                    {
                        diffY = Math.Abs(boxY) % sNum;
                    }
                    if (boxX < 0)
                    {
                        diffX = Math.Abs(boxX) % sNum;
                    }
                    point.X = CommonLib.GetSpaceNum(point.X) - diffX;
                    point.Y = CommonLib.GetSpaceNum(point.Y) - diffY;
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
                image?.SetLocation(new Point(point.X - boxX, point.Y - boxY));
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
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                try
                {
                    ArrayList al = new ArrayList();
                    foreach (string path in files)
                    {
                        al.AddRange(CommonLib.GetAllAllowFiles(path));
                    }
                    this.SuspendLayout();
                    foreach (object o in al)
                    {
                        InsertImage(o.ToString());
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
                    InsertImage((Image)e.Data.GetData(DataFormats.Bitmap));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void PicturePanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            ImageItem ii = e.Control.Tag as ImageItem;
            if (ii != null && imageCollection.Count > 0)
            {
                if (ii.IsBindEvent())
                {
                    ii.ValueChanged -= Ii_ValueChanged;
                }
                imageCollection.Remove(ii);
                if (e.Control.Equals(activeBox))
                    activeBox = null;

                //TODO: 重新计算最新值的坐标 _nextPoint
            }
        }

        private void PicturePanel_ControlAdded(object sender, ControlEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void PicturePanel_MouseWheel(object sender, MouseEventArgs e)
        {
            //Console.WriteLine(String.Format("{2},{3}  {0}, {1}", e.X, e.Y, e.Location.X, e.Location.Y));
            this.Refresh();
        }

        private void PicturePanel_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.ThumbPosition)
            {
                // Console.WriteLine(String.Format("{2}  {0}, {1}", e.NewValue, e.OldValue, e.ScrollOrientation));
                this.Refresh();
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
                        e.Graphics.FillRectangle(CommonLib.DrawRectangle(sNum, diffHeight, gridStyle), new Rectangle(0, 0, boxW, diffHeight));
                    }
                }
                if (boxX < 0)
                {
                    int diffX = Math.Abs(boxX) % sNum;
                    if (diffX > 0)
                    {
                        diffWidth = sNum - diffX;
                        e.Graphics.FillRectangle(CommonLib.DrawRectangle(diffWidth, sNum, gridStyle), new Rectangle(0, 0, diffWidth, boxH));
                    }
                }
                e.Graphics.FillRectangle(CommonLib.DrawRectangle(diffWidth, diffHeight, sNum, sNum, gridStyle), r);

            }
        }

        #endregion

        #region - 输出事件 -

        public event ChangedEventHandler<ImageArgs> ImageChanged;
        /// <summary>
        /// 图片发生变化
        /// </summary>
        /// <param name="s"></param>
        private void ImageChange(ImageArgs s)
        {
            ImageChanged?.Invoke(this, s);
        }

        #endregion

        #region - 插入图片 -

        public void InsertImage(string path)
        {
            Image img = Image.FromFile(path);
            InsertImage(img);
        }

        public void InsertImage(byte[] bytes, string clsName = null, int x = 0, int y = 0, string mark = null, long id = 0)
        {
            Image img = Image.FromStream(new MemoryStream(bytes));
            InsertImage(img, clsName, x, y, mark, id);
        }


        public void InsertImage(Image image, string clsName = null, int x = 0, int y = 0, string mark = null, long id = 0)
        {
            nextLocation = (x > 0 || y > 0) ? new Point(x, y) : nextLocation;
            ImageItem ii = new ImageItem(image.Width, image.Height, nextLocation.X, nextLocation.Y, image.RawFormat, id)
            {
                ClassName = clsName == null ? String.Format("c{0}", imageCollection.Count + 1) : clsName,
                Mark = mark
            };
            ii.ValueChanged += new ChangedEventHandler<ValueChangedArgs>(Ii_ValueChanged);
            ii.SetParentCollection(imageCollection);
            imageCollection.Add(ii);
            PictureBox pic = new PictureBox();
            pic.Image = image;
            pic.SendToBack();
            pic.BackColor = Color.Transparent;
            pic.Tag = ii;
            pic.Name = String.Format("pic{0}", ii.Id);
            pic.Parent = this;
            //pic.BackColor = Color.White;
            pic.ForeColor = Color.Transparent;
            pic.Size = new Size(image.Width, image.Height);
            pic.SizeMode = PictureBoxSizeMode.CenterImage;
            pic.Location = nextLocation;
            pic.Margin = new Padding(0);
            pic.Padding = new Padding(padding);
            pic.Width = pic.Image.Width + pic.Padding.Left + pic.Padding.Right;
            pic.Height = pic.Image.Height + pic.Padding.Top + pic.Padding.Bottom;
            pic.MouseDown += new MouseEventHandler(this.pic_MouseDown);
            pic.MouseUp += new MouseEventHandler(this.pic_MouseUp);
            pic.MouseMove += new MouseEventHandler(this.pic_MouseMove);
            //pic.PreviewKeyDown += new PreviewKeyDownEventHandler(this.pic_PreviewKeyDown);

            pic.LocationChanged += new EventHandler(this.pic_LocationChanged);

            pic.TabStop = false;
            pic.Cursor = Cursors.SizeAll;

            this.Controls.Add(pic);

            ImageChange(new ImageArgs(pic, OperationAction.Added, MouseClickType.MouseLeftUp));


            nextLocation = new Point(nextLocation.X + pic.Width, nextLocation.Y);
            if (nextLocation.X > this.Width)
            {
                nextLocation = new Point(0, nextLocation.Y + pic.Height);
            }

        }

        private void Ii_ValueChanged(object sender, ValueChangedArgs e)
        {
            ImageItem ii = sender as ImageItem;
            if (ii != null)
            {
                //触发了值被修改的事件
                ImageChange(new ImageArgs()
                {
                    Action = OperationAction.EditTag,
                    Control = activeBox,
                    MouseClickType = MouseClickType.None
                });
            }
        }

        #endregion

        #region - 其他方法 -
        /// <summary>
        /// 完成配色修改
        /// </summary>
        public void ChangeColor(GridStyle gridStyle)
        {
            this.gridStyle = gridStyle;
            Invalidate();
        }

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="id"></param>
        public void RemoveImage(long id)
        {
            Controls.RemoveByKey(String.Format("pic{0}", id));
        }

        public void SelectItem(long id)
        {
            Control[] cItems = Controls.Find(String.Format("pic{0}", id), false);
            if (cItems != null)
            {
                if (activeBox != null)
                    activeBox.BackColor = Color.Transparent;
                foreach (PictureBox c in cItems)
                {
                    c.Focus();
                    c.BringToFront();
                    activeBox = c;
                }
                if (activeBox != null)
                    activeBox.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            imageCollection.Clear();
            Controls.Clear();
        }

        #endregion

        #region - 保存图片 -
        public void SaveSingleImage(string path, long id = 0)
        {
            PictureBox pb = activeBox;
            if (id != 0)
            {
                Control[] cItems = Controls.Find(String.Format("pic{0}", id), false);
                if (cItems.Length > 0)
                    pb = cItems[0] as PictureBox;
            }

            if (pb == null)
                throw new NullReferenceException(CommonLib.GetLocalString("no_object"));

            Image btn_image = pb.Image;
            ImageItem tag = pb.Tag as ImageItem;

            btn_image.Save(path);
        }


        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="path"></param>
        /// <param name="imgCodec"></param>
        /// <param name="encoderParames"></param>
        public void SavePanelToImage(string path, ImageCodecInfo imgCodec, EncoderParameters encoderParames)
        {
            Image image = new Bitmap(DisplayRectangle.Width, DisplayRectangle.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.Transparent);
            foreach (PictureBox button in this.Controls)
            {
                Image btn_image = button.Image;
                ImageItem tag = button.Tag as ImageItem;
                if (btn_image == null || tag == null)
                    continue;

                graphics.DrawImage(btn_image, tag.X, tag.Y, tag.Width, tag.Height);
            }
            graphics.Save();
            graphics.Dispose();

            Rectangle r = Rectangle;
            int width = r.Width;
            int height = r.Height;
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics2 = Graphics.FromImage(bitmap);
            graphics2.DrawImage(image, new Rectangle(0, 0, width, height), new Rectangle(r.X, r.Y, width, height), GraphicsUnit.Pixel);
            graphics2.Dispose();

            bitmap.Save(path, imgCodec, encoderParames);
        }

        #endregion
    }


    /// <summary>
    /// 事件传递参数
    /// </summary>
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

    /// <summary>
    /// 操作动作
    /// </summary>
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
        /// <summary>
        /// 修改
        /// </summary>
        EditTag = 5,
    }

    /// <summary>
    /// 鼠标点击类型
    /// </summary>
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
