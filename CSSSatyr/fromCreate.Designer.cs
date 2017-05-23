namespace CSSSatyr
{
    partial class fromCreate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageExport = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtExportPath = new System.Windows.Forms.TextBox();
            this.labExportPath = new System.Windows.Forms.Label();
            this.trackImageQuality = new CSSSatyr.MyControls.EasyTrackBar();
            this.comboBoxExportFormat = new System.Windows.Forms.ComboBox();
            this.labCreateImageFormat = new System.Windows.Forms.Label();
            this.labImageQuality = new System.Windows.Forms.Label();
            this.numImageQuality = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageExport.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(555, 279);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(292, 237);
            this.btnOK.Margin = new System.Windows.Forms.Padding(15, 13, 15, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 37);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tabControl1, 2);
            this.tabControl1.Controls.Add(this.tabPageExport);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(130, 45);
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(545, 219);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageExport
            // 
            this.tabPageExport.BackColor = System.Drawing.Color.White;
            this.tabPageExport.Controls.Add(this.tableLayoutPanel3);
            this.tabPageExport.Location = new System.Drawing.Point(4, 49);
            this.tabPageExport.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageExport.Name = "tabPageExport";
            this.tabPageExport.Size = new System.Drawing.Size(537, 166);
            this.tabPageExport.TabIndex = 1;
            this.tabPageExport.Text = "Export Options";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.Controls.Add(this.txtExportPath, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labExportPath, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.trackImageQuality, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxExportFormat, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.labCreateImageFormat, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.labImageQuality, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.numImageQuality, 2, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(537, 166);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // txtExportPath
            // 
            this.txtExportPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExportPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtExportPath.Location = new System.Drawing.Point(163, 4);
            this.txtExportPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtExportPath.Name = "txtExportPath";
            this.txtExportPath.ReadOnly = true;
            this.txtExportPath.Size = new System.Drawing.Size(277, 27);
            this.txtExportPath.TabIndex = 17;
            // 
            // labExportPath
            // 
            this.labExportPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labExportPath.AutoSize = true;
            this.labExportPath.Location = new System.Drawing.Point(3, 0);
            this.labExportPath.Name = "labExportPath";
            this.labExportPath.Size = new System.Drawing.Size(154, 40);
            this.labExportPath.TabIndex = 2;
            this.labExportPath.Text = "Export Path";
            this.labExportPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackImageQuality
            // 
            this.trackImageQuality.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.trackImageQuality.BarBorderColor = System.Drawing.SystemColors.HotTrack;
            this.trackImageQuality.BarBorderWidth = false;
            this.trackImageQuality.BarClickColor = System.Drawing.SystemColors.ControlDarkDark;
            this.trackImageQuality.BarColor = System.Drawing.SystemColors.HotTrack;
            this.trackImageQuality.BarWidth = 7;
            this.trackImageQuality.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.trackImageQuality.BorderWidth = false;
            this.trackImageQuality.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackImageQuality.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.trackImageQuality.Location = new System.Drawing.Point(163, 84);
            this.trackImageQuality.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackImageQuality.MaxValue = 100;
            this.trackImageQuality.MinValue = 20;
            this.trackImageQuality.Name = "trackImageQuality";
            this.trackImageQuality.ProgressBarBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.trackImageQuality.ProgressBarBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.trackImageQuality.ProgressBarBorderWidth = true;
            this.trackImageQuality.ShowValue = true;
            this.trackImageQuality.Size = new System.Drawing.Size(192, 32);
            this.trackImageQuality.TabIndex = 19;
            this.trackImageQuality.Text = null;
            this.trackImageQuality.Value = 100;
            this.trackImageQuality.ValueChanged += new CSSSatyr.MyControls.ValueChangeHandler<CSSSatyr.MyControls.EasyTrackBarValueChangedArgs>(this.trackImageQuality_ValueChanged);
            // 
            // comboBoxExportFormat
            // 
            this.comboBoxExportFormat.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxExportFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExportFormat.FormattingEnabled = true;
            this.comboBoxExportFormat.Location = new System.Drawing.Point(163, 44);
            this.comboBoxExportFormat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxExportFormat.Name = "comboBoxExportFormat";
            this.comboBoxExportFormat.Size = new System.Drawing.Size(192, 28);
            this.comboBoxExportFormat.TabIndex = 20;
            // 
            // labCreateImageFormat
            // 
            this.labCreateImageFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labCreateImageFormat.Location = new System.Drawing.Point(3, 40);
            this.labCreateImageFormat.Name = "labCreateImageFormat";
            this.labCreateImageFormat.Size = new System.Drawing.Size(154, 40);
            this.labCreateImageFormat.TabIndex = 18;
            this.labCreateImageFormat.Text = "Create Image Format";
            this.labCreateImageFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labImageQuality
            // 
            this.labImageQuality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labImageQuality.Location = new System.Drawing.Point(3, 80);
            this.labImageQuality.Name = "labImageQuality";
            this.labImageQuality.Size = new System.Drawing.Size(154, 40);
            this.labImageQuality.TabIndex = 21;
            this.labImageQuality.Text = "ImageQuality";
            this.labImageQuality.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numImageQuality
            // 
            this.numImageQuality.Location = new System.Drawing.Point(460, 87);
            this.numImageQuality.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.numImageQuality.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numImageQuality.Name = "numImageQuality";
            this.numImageQuality.Size = new System.Drawing.Size(70, 27);
            this.numImageQuality.TabIndex = 22;
            this.numImageQuality.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numImageQuality.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numImageQuality.ValueChanged += new System.EventHandler(this.numImageQuality_ValueChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(187, 237);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(15, 13, 15, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 37);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // fromCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(561, 307);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fromCreate";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fromCreate";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageExport.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageQuality)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageExport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtExportPath;
        private System.Windows.Forms.Label labExportPath;
        private MyControls.EasyTrackBar trackImageQuality;
        private System.Windows.Forms.ComboBox comboBoxExportFormat;
        private System.Windows.Forms.Label labCreateImageFormat;
        private System.Windows.Forms.Label labImageQuality;
        private System.Windows.Forms.NumericUpDown numImageQuality;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}