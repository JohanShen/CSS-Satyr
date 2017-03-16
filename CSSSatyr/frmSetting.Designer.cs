namespace CSSSatyr
{
    partial class frmSetting
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageProject = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtProjectClassNamePrefix = new System.Windows.Forms.TextBox();
            this.txtProjectAuthor = new System.Windows.Forms.TextBox();
            this.labProjectName = new System.Windows.Forms.Label();
            this.labProjectAuthor = new System.Windows.Forms.Label();
            this.labClassNamePrefix = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.comboBoxExportFormat = new System.Windows.Forms.ComboBox();
            this.labCreateTime = new System.Windows.Forms.Label();
            this.labelProjectCreateTime = new System.Windows.Forms.Label();
            this.labCreateImageFormat = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.labImageQuality = new System.Windows.Forms.Label();
            this.trackImageQuality = new CSSSatyr.MyControls.EasyTrackBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageProject.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(594, 422);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(207, 361);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(15, 13, 15, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 37);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tabControl1, 2);
            this.tabControl1.Controls.Add(this.tabPageProject);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(5, 7);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 341);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageProject
            // 
            this.tabPageProject.Controls.Add(this.tableLayoutPanel3);
            this.tabPageProject.Location = new System.Drawing.Point(4, 29);
            this.tabPageProject.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageProject.Name = "tabPageProject";
            this.tabPageProject.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tabPageProject.Size = new System.Drawing.Size(576, 308);
            this.tabPageProject.TabIndex = 0;
            this.tabPageProject.Text = "Project Setting";
            this.tabPageProject.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.Controls.Add(this.txtProjectClassNamePrefix, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtProjectAuthor, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.labProjectName, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.labProjectAuthor, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.labClassNamePrefix, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtProjectName, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.trackImageQuality, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxExportFormat, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.labCreateTime, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.labelProjectCreateTime, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.labCreateImageFormat, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.labImageQuality, 0, 5);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 7);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(566, 372);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // txtProjectClassNamePrefix
            // 
            this.txtProjectClassNamePrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjectClassNamePrefix.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtProjectClassNamePrefix.Location = new System.Drawing.Point(172, 114);
            this.txtProjectClassNamePrefix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProjectClassNamePrefix.Name = "txtProjectClassNamePrefix";
            this.txtProjectClassNamePrefix.Size = new System.Drawing.Size(201, 27);
            this.txtProjectClassNamePrefix.TabIndex = 17;
            // 
            // txtProjectAuthor
            // 
            this.txtProjectAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjectAuthor.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtProjectAuthor.Location = new System.Drawing.Point(172, 74);
            this.txtProjectAuthor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProjectAuthor.Name = "txtProjectAuthor";
            this.txtProjectAuthor.Size = new System.Drawing.Size(201, 27);
            this.txtProjectAuthor.TabIndex = 16;
            // 
            // labProjectName
            // 
            this.labProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labProjectName.AutoSize = true;
            this.labProjectName.Location = new System.Drawing.Point(3, 30);
            this.labProjectName.Name = "labProjectName";
            this.labProjectName.Size = new System.Drawing.Size(163, 40);
            this.labProjectName.TabIndex = 0;
            this.labProjectName.Text = "Project Name";
            this.labProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labProjectAuthor
            // 
            this.labProjectAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labProjectAuthor.AutoSize = true;
            this.labProjectAuthor.Location = new System.Drawing.Point(3, 70);
            this.labProjectAuthor.Name = "labProjectAuthor";
            this.labProjectAuthor.Size = new System.Drawing.Size(163, 40);
            this.labProjectAuthor.TabIndex = 1;
            this.labProjectAuthor.Text = "Author";
            this.labProjectAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labClassNamePrefix
            // 
            this.labClassNamePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labClassNamePrefix.AutoSize = true;
            this.labClassNamePrefix.Location = new System.Drawing.Point(3, 110);
            this.labClassNamePrefix.Name = "labClassNamePrefix";
            this.labClassNamePrefix.Size = new System.Drawing.Size(163, 40);
            this.labClassNamePrefix.TabIndex = 2;
            this.labClassNamePrefix.Text = "Class Name Prefix";
            this.labClassNamePrefix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProjectName
            // 
            this.txtProjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjectName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtProjectName.Location = new System.Drawing.Point(172, 34);
            this.txtProjectName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(320, 27);
            this.txtProjectName.TabIndex = 13;
            // 
            // comboBoxExportFormat
            // 
            this.comboBoxExportFormat.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxExportFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExportFormat.FormattingEnabled = true;
            this.comboBoxExportFormat.Location = new System.Drawing.Point(172, 154);
            this.comboBoxExportFormat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxExportFormat.Name = "comboBoxExportFormat";
            this.comboBoxExportFormat.Size = new System.Drawing.Size(201, 28);
            this.comboBoxExportFormat.TabIndex = 20;
            // 
            // labCreateTime
            // 
            this.labCreateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labCreateTime.Location = new System.Drawing.Point(3, 230);
            this.labCreateTime.Name = "labCreateTime";
            this.labCreateTime.Size = new System.Drawing.Size(163, 40);
            this.labCreateTime.TabIndex = 6;
            this.labCreateTime.Text = "Created Time";
            this.labCreateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelProjectCreateTime
            // 
            this.labelProjectCreateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProjectCreateTime.Location = new System.Drawing.Point(172, 230);
            this.labelProjectCreateTime.Name = "labelProjectCreateTime";
            this.labelProjectCreateTime.Size = new System.Drawing.Size(391, 40);
            this.labelProjectCreateTime.TabIndex = 15;
            this.labelProjectCreateTime.Text = "2016年10月14日 16:55:20";
            this.labelProjectCreateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labCreateImageFormat
            // 
            this.labCreateImageFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labCreateImageFormat.Location = new System.Drawing.Point(3, 150);
            this.labCreateImageFormat.Name = "labCreateImageFormat";
            this.labCreateImageFormat.Size = new System.Drawing.Size(163, 40);
            this.labCreateImageFormat.TabIndex = 18;
            this.labCreateImageFormat.Text = "Create Image Format";
            this.labCreateImageFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(312, 361);
            this.btnOK.Margin = new System.Windows.Forms.Padding(15, 13, 15, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 37);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // labImageQuality
            // 
            this.labImageQuality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labImageQuality.Location = new System.Drawing.Point(3, 190);
            this.labImageQuality.Name = "labImageQuality";
            this.labImageQuality.Size = new System.Drawing.Size(163, 40);
            this.labImageQuality.TabIndex = 21;
            this.labImageQuality.Text = "ImageQuality";
            this.labImageQuality.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.trackImageQuality.Location = new System.Drawing.Point(172, 194);
            this.trackImageQuality.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackImageQuality.MaxValue = 100;
            this.trackImageQuality.MinValue = 50;
            this.trackImageQuality.Name = "trackImageQuality";
            this.trackImageQuality.ProgressBarBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.trackImageQuality.ProgressBarBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.trackImageQuality.ProgressBarBorderWidth = true;
            this.trackImageQuality.ShowValue = true;
            this.trackImageQuality.Size = new System.Drawing.Size(201, 32);
            this.trackImageQuality.TabIndex = 19;
            this.trackImageQuality.Text = null;
            this.trackImageQuality.Value = 76;
            // 
            // frmSetting
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "frmSetting";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 4);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSetting";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageProject.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageProject;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtProjectClassNamePrefix;
        private System.Windows.Forms.TextBox txtProjectAuthor;
        private System.Windows.Forms.Label labProjectName;
        private System.Windows.Forms.Label labProjectAuthor;
        private System.Windows.Forms.Label labClassNamePrefix;
        private System.Windows.Forms.TextBox txtProjectName;
        private MyControls.EasyTrackBar trackImageQuality;
        private System.Windows.Forms.ComboBox comboBoxExportFormat;
        private System.Windows.Forms.Label labCreateTime;
        private System.Windows.Forms.Label labelProjectCreateTime;
        private System.Windows.Forms.Label labCreateImageFormat;
        private System.Windows.Forms.Label labImageQuality;
    }
}