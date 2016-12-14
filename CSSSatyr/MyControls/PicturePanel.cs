using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CSSSatyr.Models;
using System.Drawing.Imaging;
using CSSSatyr.Extends;
using System.Collections;

namespace CSSSatyr.MyControls
{
    public delegate void ImageChangeHandler<T>(object sender, T e) where T : ImageArgs;
    public class PicturePanel : Panel
    {
        private int _padding = 1;
        private List<ImageItem> _items = new List<ImageItem>();
        private Point _minPoint = new Point(0, 0);
        private Point _maxPoint = new Point(0, 0);
        private Point _nextLocation = new Point(0, 0);
        private Point _mouseOffset = new Point(0, 0);
        private Point _mouseLastPoint = new Point(0, 0);
        private PictureBox _activeBox = null;
        private GridStyle _gridStyle = CommonLib.GetGridStyle();

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
            //base.PreviewKeyDown += new PreviewKeyDownEventHandler(PicturePanel_PreviewKeyDown);
        }

        public void PKeyDown(Keys keyData)
        {
            this.PicturePanel_PreviewKeyDown(this, new PreviewKeyDownEventArgs(keyData));
        }

        private void PicturePanel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var button = _activeBox;
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
                        _activeBox = null;
                        return;
                    }
                default:
                    break;
            }
        }

        private void PicturePanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) || e.Data.GetDataPresent(DataFormats.FileDrop) )
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

        public void InsertImage(byte[] bytes, string clsName = null, int x = 0, int y = 0, string mark = null, long id = 0)
        {
            Image img = Image.FromStream(new MemoryStream(bytes));
            InsertImage(img, clsName, x, y, mark, id);
        }

        /// <summary>
        /// 完成配色修改
        /// </summary>
        public void ChangeColor(GridStyle gridStyle)
        {
            _gridStyle = gridStyle;
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
                foreach (PictureBox c in cItems)
                {
                    c.Focus();
                    c.BringToFront();
                    _activeBox = c;
                }
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            Controls.Clear();
        }

        public void InsertImage(Image image, string clsName =null, int x =0, int y = 0, string mark = null, long id = 0) {

            ImageItem ii = new ImageItem(image.Width, image.Height, _nextLocation.X, _nextLocation.Y, image.RawFormat, id)
            {
                ClassName = String.Format("c{0}", _items.Count + 1),
                Mark = mark
                //ShowHeight = image.Height,
                //ShowWidth = image.Width,
            };
            _items.Add(ii);
            PictureBox pic = new PictureBox();
            pic.Image = image;
            pic.SendToBack();
            pic.BackColor = Color.Transparent;
            pic.Tag = ii;
            pic.Name = String.Format("pic{0}", ii.Id);
            pic.Parent = this;
            //button.BackColor = Color.White;
            pic.ForeColor = Color.Transparent;
            pic.Size = new Size(image.Width, image.Height);
            pic.SizeMode = PictureBoxSizeMode.CenterImage;
            pic.Location = (x > 0 || y > 0) ? new Point(x, y) : _nextLocation;
            pic.Margin = new Padding(0);
            pic.Padding = new Padding(_padding);
            pic.Width = pic.Image.Width + pic.Padding.Left + pic.Padding.Right;
            pic.Height = pic.Image.Height + pic.Padding.Top + pic.Padding.Bottom;
            pic.MouseDown += new MouseEventHandler(this.pic_MouseDown);
            pic.MouseUp += new MouseEventHandler(this.pic_MouseUp);
            pic.MouseMove += new MouseEventHandler(this.pic_MouseMove);
            //button.PreviewKeyDown += new PreviewKeyDownEventHandler(this.pic_PreviewKeyDown);

            pic.LocationChanged += new EventHandler(this.pic_LocationChanged);

            pic.TabStop = false;
            pic.Cursor = Cursors.SizeAll;

            this.Controls.Add(pic);

            ImageChange(new ImageArgs(pic, OperationAction.Added, MouseClickType.MouseLeftUp));


            _nextLocation = new Point(_nextLocation.X + pic.Width, _nextLocation.Y);
            if (_nextLocation.X > this.Width)
            {
                _nextLocation = new Point(0, _nextLocation.Y + pic.Height);
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
                _mouseOffset = new Point(-e.X, -e.Y);
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
                _activeBox = button;
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
                Point mousePosition = MousePosition;
                mousePosition.Offset(_mouseOffset);
                Point point = this.PointToClient(mousePosition);
                //Point point = new Point(e.X, e.Y);


                int boxX = this.DisplayRectangle.X;
                int boxY = this.DisplayRectangle.Y;

                Console.WriteLine(String.Format("{0}, {1}", boxX, boxY));


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

                if (point.Equals(_mouseLastPoint))
                    return;

                ImageItem image = button.Tag as ImageItem;
                image?.SetLocation(new Point(point.X - boxX, point.Y - boxY));
                //button.SuspendLayout();
                button.Location = point;
                //button.ResumeLayout(false);
                _mouseLastPoint = point;
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
                    foreach(object o in al)
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
            //throw new NotImplementedException();
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
                        e.Graphics.FillRectangle(CommonLib.DrawRectangle(sNum, diffHeight, _gridStyle), new Rectangle(0, 0, boxW, diffHeight));
                    }
                }
                if (boxX < 0)
                {
                    int diffX = Math.Abs(boxX) % sNum;
                    if (diffX > 0)
                    {
                        diffWidth = sNum - diffX;
                        e.Graphics.FillRectangle(CommonLib.DrawRectangle(diffWidth, sNum, _gridStyle), new Rectangle(0, 0, diffWidth, boxH));
                    }
                }
                e.Graphics.FillRectangle(CommonLib.DrawRectangle(diffWidth, diffHeight, sNum, sNum, _gridStyle), r);
                
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
