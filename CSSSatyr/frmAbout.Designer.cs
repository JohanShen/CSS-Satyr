namespace CSSSatyr
{
    partial class frmAbout
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.llabDownUrl = new System.Windows.Forms.LinkLabel();
            this.labLastVersion = new System.Windows.Forms.Label();
            this.labNowVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtAbout = new System.Windows.Forms.TextBox();
            this.tabPageCopyright = new System.Windows.Forms.TabPage();
            this.txtCopyright = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPageCopyright.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(594, 422);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tabControl1, 2);
            this.tabControl1.Controls.Add(this.tabPageAbout);
            this.tabControl1.Controls.Add(this.tabPageCopyright);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(130, 45);
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 362);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.BackColor = System.Drawing.Color.White;
            this.tabPageAbout.Controls.Add(this.llabDownUrl);
            this.tabPageAbout.Controls.Add(this.labLastVersion);
            this.tabPageAbout.Controls.Add(this.labNowVersion);
            this.tabPageAbout.Controls.Add(this.pictureBox1);
            this.tabPageAbout.Controls.Add(this.txtAbout);
            this.tabPageAbout.Location = new System.Drawing.Point(4, 49);
            this.tabPageAbout.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Size = new System.Drawing.Size(576, 309);
            this.tabPageAbout.TabIndex = 1;
            this.tabPageAbout.Text = "About software";
            // 
            // llabDownUrl
            // 
            this.llabDownUrl.AutoSize = true;
            this.llabDownUrl.Location = new System.Drawing.Point(69, 280);
            this.llabDownUrl.Name = "llabDownUrl";
            this.llabDownUrl.Size = new System.Drawing.Size(82, 15);
            this.llabDownUrl.TabIndex = 4;
            this.llabDownUrl.TabStop = true;
            this.llabDownUrl.Text = "下载最新版";
            this.llabDownUrl.Visible = false;
            this.llabDownUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llabDownUrl_LinkClicked);
            // 
            // labLastVersion
            // 
            this.labLastVersion.AutoSize = true;
            this.labLastVersion.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labLastVersion.Location = new System.Drawing.Point(68, 253);
            this.labLastVersion.Name = "labLastVersion";
            this.labLastVersion.Size = new System.Drawing.Size(94, 20);
            this.labLastVersion.TabIndex = 3;
            this.labLastVersion.Text = "Check last...";
            // 
            // labNowVersion
            // 
            this.labNowVersion.AutoSize = true;
            this.labNowVersion.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labNowVersion.Location = new System.Drawing.Point(68, 231);
            this.labNowVersion.Name = "labNowVersion";
            this.labNowVersion.Size = new System.Drawing.Size(130, 20);
            this.labNowVersion.TabIndex = 2;
            this.labNowVersion.Text = "Now version: 2.0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CSSSatyr.Properties.Resources.Refresh_48px_522650_easyicon_net;
            this.pictureBox1.InitialImage = global::CSSSatyr.Properties.Resources.Refresh_48px_522650_easyicon_net;
            this.pictureBox1.Location = new System.Drawing.Point(12, 231);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // txtAbout
            // 
            this.txtAbout.BackColor = System.Drawing.Color.White;
            this.txtAbout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAbout.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtAbout.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAbout.Location = new System.Drawing.Point(0, 0);
            this.txtAbout.Multiline = true;
            this.txtAbout.Name = "txtAbout";
            this.txtAbout.ReadOnly = true;
            this.txtAbout.Size = new System.Drawing.Size(576, 225);
            this.txtAbout.TabIndex = 0;
            this.txtAbout.Text = resources.GetString("txtAbout.Text");
            // 
            // tabPageCopyright
            // 
            this.tabPageCopyright.Controls.Add(this.txtCopyright);
            this.tabPageCopyright.Location = new System.Drawing.Point(4, 49);
            this.tabPageCopyright.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageCopyright.Name = "tabPageCopyright";
            this.tabPageCopyright.Size = new System.Drawing.Size(576, 309);
            this.tabPageCopyright.TabIndex = 0;
            this.tabPageCopyright.Text = "Copyright";
            this.tabPageCopyright.UseVisualStyleBackColor = true;
            // 
            // txtCopyright
            // 
            this.txtCopyright.BackColor = System.Drawing.Color.White;
            this.txtCopyright.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCopyright.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCopyright.Location = new System.Drawing.Point(0, 0);
            this.txtCopyright.Multiline = true;
            this.txtCopyright.Name = "txtCopyright";
            this.txtCopyright.ReadOnly = true;
            this.txtCopyright.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCopyright.Size = new System.Drawing.Size(576, 309);
            this.txtCopyright.TabIndex = 0;
            this.txtCopyright.Text = resources.GetString("txtCopyright.Text");
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel1.SetColumnSpan(this.btnOK, 2);
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(259, 377);
            this.btnOK.Margin = new System.Windows.Forms.Padding(15, 10, 15, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 4);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutBox";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageAbout.ResumeLayout(false);
            this.tabPageAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPageCopyright.ResumeLayout(false);
            this.tabPageCopyright.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCopyright;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtCopyright;
        private System.Windows.Forms.TextBox txtAbout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labLastVersion;
        private System.Windows.Forms.Label labNowVersion;
        private System.Windows.Forms.LinkLabel llabDownUrl;
    }
}
