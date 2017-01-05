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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageProject = new System.Windows.Forms.TabPage();
            this.tabPageApplication = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.comboBoxGridStyle = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtDefaultClassName = new System.Windows.Forms.TextBox();
            this.rdoSiderShow = new System.Windows.Forms.RadioButton();
            this.rdoSiderHidden = new System.Windows.Forms.RadioButton();
            this.rdoAlignFree = new System.Windows.Forms.RadioButton();
            this.rdoAlignAutoSorption = new System.Windows.Forms.RadioButton();
            this.rdoGridLineHidden = new System.Windows.Forms.RadioButton();
            this.rdoGridLineShow = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxProjectStyle = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdoProjectGridLineHidden = new System.Windows.Forms.RadioButton();
            this.rdoProjectGridLineShow = new System.Windows.Forms.RadioButton();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.labelProjectCreateTime = new System.Windows.Forms.Label();
            this.txtProjectAuthor = new System.Windows.Forms.TextBox();
            this.txtProjectClassName = new System.Windows.Forms.TextBox();
            this.easyTrackBar1 = new CSSSatyr.MyControls.EasyTrackBar();
            this.trackGridNum = new CSSSatyr.MyControls.EasyTrackBar();
            this.tabControl1.SuspendLayout();
            this.tabPageProject.SuspendLayout();
            this.tabPageApplication.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tabControl1, 2);
            this.tabControl1.Controls.Add(this.tabPageProject);
            this.tabControl1.Controls.Add(this.tabPageApplication);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(370, 251);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageProject
            // 
            this.tabPageProject.Controls.Add(this.tableLayoutPanel3);
            this.tabPageProject.Location = new System.Drawing.Point(4, 25);
            this.tabPageProject.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageProject.Name = "tabPageProject";
            this.tabPageProject.Padding = new System.Windows.Forms.Padding(5);
            this.tabPageProject.Size = new System.Drawing.Size(362, 222);
            this.tabPageProject.TabIndex = 0;
            this.tabPageProject.Text = "项目设置";
            this.tabPageProject.UseVisualStyleBackColor = true;
            // 
            // tabPageApplication
            // 
            this.tabPageApplication.Controls.Add(this.tableLayoutPanel2);
            this.tabPageApplication.Location = new System.Drawing.Point(4, 25);
            this.tabPageApplication.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageApplication.Name = "tabPageApplication";
            this.tabPageApplication.Padding = new System.Windows.Forms.Padding(5);
            this.tabPageApplication.Size = new System.Drawing.Size(362, 222);
            this.tabPageApplication.TabIndex = 1;
            this.tabPageApplication.Text = "程序设置";
            this.tabPageApplication.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(380, 311);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(100, 266);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(15, 10, 15, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(205, 266);
            this.btnOK.Margin = new System.Windows.Forms.Padding(15, 10, 15, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxLanguage, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxGridStyle, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtDefaultClassName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.trackGridNum, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(352, 212);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "class名：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "左边树：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "图片靠近：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "网格：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 30);
            this.label6.TabIndex = 5;
            this.label6.Text = "样式：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 30);
            this.label7.TabIndex = 6;
            this.label7.Text = "语言：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(108, 183);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(158, 23);
            this.comboBoxLanguage.TabIndex = 7;
            // 
            // comboBoxGridStyle
            // 
            this.comboBoxGridStyle.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxGridStyle.FormattingEnabled = true;
            this.comboBoxGridStyle.Location = new System.Drawing.Point(108, 153);
            this.comboBoxGridStyle.Name = "comboBoxGridStyle";
            this.comboBoxGridStyle.Size = new System.Drawing.Size(158, 23);
            this.comboBoxGridStyle.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoGridLineHidden);
            this.panel1.Controls.Add(this.rdoGridLineShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(105, 90);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 30);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdoAlignFree);
            this.panel2.Controls.Add(this.rdoAlignAutoSorption);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(105, 60);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(247, 30);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdoSiderHidden);
            this.panel3.Controls.Add(this.rdoSiderShow);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(105, 30);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(247, 30);
            this.panel3.TabIndex = 12;
            // 
            // txtDefaultClassName
            // 
            this.txtDefaultClassName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDefaultClassName.Location = new System.Drawing.Point(108, 3);
            this.txtDefaultClassName.Name = "txtDefaultClassName";
            this.txtDefaultClassName.Size = new System.Drawing.Size(158, 25);
            this.txtDefaultClassName.TabIndex = 13;
            // 
            // rdoSiderShow
            // 
            this.rdoSiderShow.AutoSize = true;
            this.rdoSiderShow.Checked = true;
            this.rdoSiderShow.Location = new System.Drawing.Point(3, 6);
            this.rdoSiderShow.Name = "rdoSiderShow";
            this.rdoSiderShow.Size = new System.Drawing.Size(58, 19);
            this.rdoSiderShow.TabIndex = 0;
            this.rdoSiderShow.TabStop = true;
            this.rdoSiderShow.Tag = "show";
            this.rdoSiderShow.Text = "显示";
            this.rdoSiderShow.UseVisualStyleBackColor = true;
            // 
            // rdoSiderHidden
            // 
            this.rdoSiderHidden.AutoSize = true;
            this.rdoSiderHidden.Location = new System.Drawing.Point(85, 6);
            this.rdoSiderHidden.Name = "rdoSiderHidden";
            this.rdoSiderHidden.Size = new System.Drawing.Size(58, 19);
            this.rdoSiderHidden.TabIndex = 1;
            this.rdoSiderHidden.Tag = "hidden";
            this.rdoSiderHidden.Text = "隐藏";
            this.rdoSiderHidden.UseVisualStyleBackColor = true;
            // 
            // rdoAlignFree
            // 
            this.rdoAlignFree.AutoSize = true;
            this.rdoAlignFree.Checked = true;
            this.rdoAlignFree.Location = new System.Drawing.Point(85, 6);
            this.rdoAlignFree.Name = "rdoAlignFree";
            this.rdoAlignFree.Size = new System.Drawing.Size(58, 19);
            this.rdoAlignFree.TabIndex = 3;
            this.rdoAlignFree.TabStop = true;
            this.rdoAlignFree.Text = "自由";
            this.rdoAlignFree.UseVisualStyleBackColor = true;
            // 
            // rdoAlignAutoSorption
            // 
            this.rdoAlignAutoSorption.AutoSize = true;
            this.rdoAlignAutoSorption.Location = new System.Drawing.Point(3, 6);
            this.rdoAlignAutoSorption.Name = "rdoAlignAutoSorption";
            this.rdoAlignAutoSorption.Size = new System.Drawing.Size(58, 19);
            this.rdoAlignAutoSorption.TabIndex = 2;
            this.rdoAlignAutoSorption.Text = "吸附";
            this.rdoAlignAutoSorption.UseVisualStyleBackColor = true;
            // 
            // rdoGridLineHidden
            // 
            this.rdoGridLineHidden.AutoSize = true;
            this.rdoGridLineHidden.Location = new System.Drawing.Point(85, 6);
            this.rdoGridLineHidden.Name = "rdoGridLineHidden";
            this.rdoGridLineHidden.Size = new System.Drawing.Size(58, 19);
            this.rdoGridLineHidden.TabIndex = 3;
            this.rdoGridLineHidden.Text = "隐藏";
            this.rdoGridLineHidden.UseVisualStyleBackColor = true;
            // 
            // rdoGridLineShow
            // 
            this.rdoGridLineShow.AutoSize = true;
            this.rdoGridLineShow.Checked = true;
            this.rdoGridLineShow.Location = new System.Drawing.Point(3, 6);
            this.rdoGridLineShow.Name = "rdoGridLineShow";
            this.rdoGridLineShow.Size = new System.Drawing.Size(58, 19);
            this.rdoGridLineShow.TabIndex = 2;
            this.rdoGridLineShow.TabStop = true;
            this.rdoGridLineShow.Text = "显示";
            this.rdoGridLineShow.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.Controls.Add(this.txtProjectClassName, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtProjectAuthor, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label11, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.label12, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxProjectStyle, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtProjectName, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.easyTrackBar1, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.labelProjectCreateTime, 1, 6);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(352, 212);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "名称：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 30);
            this.label8.TabIndex = 1;
            this.label8.Text = "作者：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 30);
            this.label9.TabIndex = 2;
            this.label9.Text = "class名：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 30);
            this.label10.TabIndex = 3;
            this.label10.Text = "网格：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 30);
            this.label11.TabIndex = 5;
            this.label11.Text = "样式：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 30);
            this.label12.TabIndex = 6;
            this.label12.Text = "创建时间：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxProjectStyle
            // 
            this.comboBoxProjectStyle.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxProjectStyle.FormattingEnabled = true;
            this.comboBoxProjectStyle.Location = new System.Drawing.Point(108, 153);
            this.comboBoxProjectStyle.Name = "comboBoxProjectStyle";
            this.comboBoxProjectStyle.Size = new System.Drawing.Size(158, 23);
            this.comboBoxProjectStyle.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rdoProjectGridLineHidden);
            this.panel4.Controls.Add(this.rdoProjectGridLineShow);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(105, 90);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(247, 30);
            this.panel4.TabIndex = 10;
            // 
            // rdoProjectGridLineHidden
            // 
            this.rdoProjectGridLineHidden.AutoSize = true;
            this.rdoProjectGridLineHidden.Location = new System.Drawing.Point(85, 6);
            this.rdoProjectGridLineHidden.Name = "rdoProjectGridLineHidden";
            this.rdoProjectGridLineHidden.Size = new System.Drawing.Size(58, 19);
            this.rdoProjectGridLineHidden.TabIndex = 3;
            this.rdoProjectGridLineHidden.Text = "隐藏";
            this.rdoProjectGridLineHidden.UseVisualStyleBackColor = true;
            // 
            // rdoProjectGridLineShow
            // 
            this.rdoProjectGridLineShow.AutoSize = true;
            this.rdoProjectGridLineShow.Checked = true;
            this.rdoProjectGridLineShow.Location = new System.Drawing.Point(3, 6);
            this.rdoProjectGridLineShow.Name = "rdoProjectGridLineShow";
            this.rdoProjectGridLineShow.Size = new System.Drawing.Size(58, 19);
            this.rdoProjectGridLineShow.TabIndex = 2;
            this.rdoProjectGridLineShow.TabStop = true;
            this.rdoProjectGridLineShow.Text = "显示";
            this.rdoProjectGridLineShow.UseVisualStyleBackColor = true;
            // 
            // txtProjectName
            // 
            this.txtProjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjectName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtProjectName.Location = new System.Drawing.Point(108, 3);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(158, 25);
            this.txtProjectName.TabIndex = 13;
            // 
            // labelProjectCreateTime
            // 
            this.labelProjectCreateTime.AutoSize = true;
            this.labelProjectCreateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProjectCreateTime.Location = new System.Drawing.Point(108, 180);
            this.labelProjectCreateTime.Name = "labelProjectCreateTime";
            this.labelProjectCreateTime.Size = new System.Drawing.Size(241, 30);
            this.labelProjectCreateTime.TabIndex = 15;
            this.labelProjectCreateTime.Text = "2016年10月14日 16:55:20";
            this.labelProjectCreateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProjectAuthor
            // 
            this.txtProjectAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjectAuthor.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtProjectAuthor.Location = new System.Drawing.Point(108, 33);
            this.txtProjectAuthor.Name = "txtProjectAuthor";
            this.txtProjectAuthor.Size = new System.Drawing.Size(158, 25);
            this.txtProjectAuthor.TabIndex = 16;
            // 
            // txtProjectClassName
            // 
            this.txtProjectClassName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjectClassName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtProjectClassName.Location = new System.Drawing.Point(108, 63);
            this.txtProjectClassName.Name = "txtProjectClassName";
            this.txtProjectClassName.Size = new System.Drawing.Size(158, 25);
            this.txtProjectClassName.TabIndex = 17;
            // 
            // easyTrackBar1
            // 
            this.easyTrackBar1.BarBorderColor = System.Drawing.SystemColors.HotTrack;
            this.easyTrackBar1.BarBorderWidth = false;
            this.easyTrackBar1.BarClickColor = System.Drawing.SystemColors.ControlDark;
            this.easyTrackBar1.BarColor = System.Drawing.SystemColors.HotTrack;
            this.easyTrackBar1.BarWidth = 7;
            this.easyTrackBar1.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.easyTrackBar1.BorderWidth = false;
            this.easyTrackBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.easyTrackBar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.easyTrackBar1.Location = new System.Drawing.Point(108, 123);
            this.easyTrackBar1.MaxValue = 50;
            this.easyTrackBar1.MinValue = 10;
            this.easyTrackBar1.Name = "easyTrackBar1";
            this.easyTrackBar1.ProgressBarBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.easyTrackBar1.ProgressBarBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.easyTrackBar1.ProgressBarBorderWidth = true;
            this.easyTrackBar1.ShowValue = true;
            this.easyTrackBar1.Size = new System.Drawing.Size(158, 24);
            this.easyTrackBar1.TabIndex = 14;
            this.easyTrackBar1.Text = "网格大小";
            this.easyTrackBar1.Value = 10;
            // 
            // trackGridNum
            // 
            this.trackGridNum.BarBorderColor = System.Drawing.SystemColors.HotTrack;
            this.trackGridNum.BarBorderWidth = false;
            this.trackGridNum.BarClickColor = System.Drawing.SystemColors.ControlDark;
            this.trackGridNum.BarColor = System.Drawing.SystemColors.HotTrack;
            this.trackGridNum.BarWidth = 7;
            this.trackGridNum.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.trackGridNum.BorderWidth = false;
            this.trackGridNum.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackGridNum.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.trackGridNum.Location = new System.Drawing.Point(108, 123);
            this.trackGridNum.MaxValue = 50;
            this.trackGridNum.MinValue = 10;
            this.trackGridNum.Name = "trackGridNum";
            this.trackGridNum.ProgressBarBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.trackGridNum.ProgressBarBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.trackGridNum.ProgressBarBorderWidth = true;
            this.trackGridNum.ShowValue = true;
            this.trackGridNum.Size = new System.Drawing.Size(158, 24);
            this.trackGridNum.TabIndex = 14;
            this.trackGridNum.Text = "网格大小";
            this.trackGridNum.Value = 10;
            // 
            // frmSetting
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(386, 332);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "frmSetting";
            this.Padding = new System.Windows.Forms.Padding(3, 18, 3, 3);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSetting";
            this.tabControl1.ResumeLayout(false);
            this.tabPageProject.ResumeLayout(false);
            this.tabPageApplication.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageProject;
        private System.Windows.Forms.TabPage tabPageApplication;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.ComboBox comboBoxGridStyle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoGridLineHidden;
        private System.Windows.Forms.RadioButton rdoGridLineShow;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdoAlignFree;
        private System.Windows.Forms.RadioButton rdoAlignAutoSorption;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdoSiderHidden;
        private System.Windows.Forms.RadioButton rdoSiderShow;
        private System.Windows.Forms.TextBox txtDefaultClassName;
        private MyControls.EasyTrackBar trackGridNum;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxProjectStyle;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdoProjectGridLineHidden;
        private System.Windows.Forms.RadioButton rdoProjectGridLineShow;
        private System.Windows.Forms.TextBox txtProjectName;
        private MyControls.EasyTrackBar easyTrackBar1;
        private System.Windows.Forms.TextBox txtProjectClassName;
        private System.Windows.Forms.TextBox txtProjectAuthor;
        private System.Windows.Forms.Label labelProjectCreateTime;
    }
}