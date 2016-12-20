namespace CSSSatyr
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reOrderImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSorptionGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSiderTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.choiceLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.submitSuggestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyrightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BodyContainer = new System.Windows.Forms.SplitContainer();
            this.LeftSplitContainer = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.easyTrackBar1 = new CSSSatyr.MyControls.EasyTrackBar();
            this.MainPictureBox = new CSSSatyr.MyControls.PicturePanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbShowLeftTree = new System.Windows.Forms.ToolStripButton();
            this.tsbtnReOrder = new System.Windows.Forms.ToolStripButton();
            this.tsbtnColorChange = new System.Windows.Forms.ToolStripDropDownButton();
            this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnAutoSorption = new System.Windows.Forms.ToolStripButton();
            this.tsbtnShowGrid = new System.Windows.Forms.ToolStripButton();
            this.sslAutoSorption = new System.Windows.Forms.StatusStrip();
            this.tsStatusNewVersionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSpaceLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusAutoSorption = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslGridSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.BodyContainer.Panel1.SuspendLayout();
            this.BodyContainer.Panel2.SuspendLayout();
            this.BodyContainer.SuspendLayout();
            this.LeftSplitContainer.Panel1.SuspendLayout();
            this.LeftSplitContainer.Panel2.SuspendLayout();
            this.LeftSplitContainer.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.sslAutoSorption.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bmp24.png");
            this.imageList1.Images.SetKeyName(1, "jpg24.png");
            this.imageList1.Images.SetKeyName(2, "gif24.png");
            this.imageList1.Images.SetKeyName(3, "png24.png");
            this.imageList1.Images.SetKeyName(4, "ico24.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.MainSplitContainer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sslAutoSorption, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(845, 501);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MainSplitContainer.IsSplitterFixed = true;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            this.MainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.menuStrip1);
            this.MainSplitContainer.Panel1MinSize = 67;
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.BodyContainer);
            this.MainSplitContainer.Size = new System.Drawing.Size(845, 473);
            this.MainSplitContainer.SplitterDistance = 67;
            this.MainSplitContainer.SplitterWidth = 2;
            this.MainSplitContainer.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.createToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(845, 67);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.AutoSize = false;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addImagesToolStripMenuItem,
            this.exportImagesToolStripMenuItem,
            this.toolStripSeparator1,
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.folder_page_32;
            this.fileToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fileToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.fileToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.ShowShortcutKeys = false;
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(80, 63);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // addImagesToolStripMenuItem
            // 
            this.addImagesToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.picture_add_16;
            this.addImagesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addImagesToolStripMenuItem.Name = "addImagesToolStripMenuItem";
            this.addImagesToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.addImagesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addImagesToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.addImagesToolStripMenuItem.Text = "AddImages";
            // 
            // exportImagesToolStripMenuItem
            // 
            this.exportImagesToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.export_16;
            this.exportImagesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exportImagesToolStripMenuItem.Name = "exportImagesToolStripMenuItem";
            this.exportImagesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportImagesToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.exportImagesToolStripMenuItem.Text = "ExportImage";
            this.exportImagesToolStripMenuItem.Click += new System.EventHandler(this.exportImagesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(231, 6);
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.folder_add_16;
            this.newProjectToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.newProjectToolStripMenuItem.Text = "NewProject";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.folder_open_16;
            this.openProjectToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.openProjectToolStripMenuItem.Text = "OpenProject";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click_1);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.folder_save_16;
            this.saveProjectToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.saveProjectToolStripMenuItem.Text = "SaveProject";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(231, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.close_16_2;
            this.exitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.AutoSize = false;
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reOrderImagesToolStripMenuItem,
            this.toolStripSeparator3,
            this.showGridToolStripMenuItem,
            this.autoSorptionGridToolStripMenuItem,
            this.showSiderTreeToolStripMenuItem,
            this.toolStripSeparator4,
            this.choiceLanguageToolStripMenuItem});
            this.viewToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.view_choose_321;
            this.viewToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.viewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.viewToolStripMenuItem.ShowShortcutKeys = false;
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(80, 63);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // reOrderImagesToolStripMenuItem
            // 
            this.reOrderImagesToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.Order_16;
            this.reOrderImagesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reOrderImagesToolStripMenuItem.Name = "reOrderImagesToolStripMenuItem";
            this.reOrderImagesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.reOrderImagesToolStripMenuItem.Size = new System.Drawing.Size(314, 26);
            this.reOrderImagesToolStripMenuItem.Text = "ReOrderImages";
            this.reOrderImagesToolStripMenuItem.Click += new System.EventHandler(this.reOrderImagesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(311, 6);
            // 
            // showGridToolStripMenuItem
            // 
            this.showGridToolStripMenuItem.Checked = true;
            this.showGridToolStripMenuItem.CheckOnClick = true;
            this.showGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGridToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showGridToolStripMenuItem.Name = "showGridToolStripMenuItem";
            this.showGridToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.showGridToolStripMenuItem.Size = new System.Drawing.Size(314, 26);
            this.showGridToolStripMenuItem.Text = "ShowGrid";
            this.showGridToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.showGridToolStripMenuItem_CheckStateChanged);
            // 
            // autoSorptionGridToolStripMenuItem
            // 
            this.autoSorptionGridToolStripMenuItem.CheckOnClick = true;
            this.autoSorptionGridToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.autoSorptionGridToolStripMenuItem.Name = "autoSorptionGridToolStripMenuItem";
            this.autoSorptionGridToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.autoSorptionGridToolStripMenuItem.Size = new System.Drawing.Size(314, 26);
            this.autoSorptionGridToolStripMenuItem.Text = "AutoSorptionGrid";
            this.autoSorptionGridToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.autoSorptionGridToolStripMenuItem_CheckStateChanged);
            // 
            // showSiderTreeToolStripMenuItem
            // 
            this.showSiderTreeToolStripMenuItem.Checked = true;
            this.showSiderTreeToolStripMenuItem.CheckOnClick = true;
            this.showSiderTreeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showSiderTreeToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showSiderTreeToolStripMenuItem.Name = "showSiderTreeToolStripMenuItem";
            this.showSiderTreeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.showSiderTreeToolStripMenuItem.Size = new System.Drawing.Size(314, 26);
            this.showSiderTreeToolStripMenuItem.Text = "ShowSiderTree";
            this.showSiderTreeToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.showSiderTreeToolStripMenuItem_CheckStateChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(311, 6);
            // 
            // choiceLanguageToolStripMenuItem
            // 
            this.choiceLanguageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultLanguageToolStripMenuItem});
            this.choiceLanguageToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.china_16;
            this.choiceLanguageToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.choiceLanguageToolStripMenuItem.Name = "choiceLanguageToolStripMenuItem";
            this.choiceLanguageToolStripMenuItem.Size = new System.Drawing.Size(314, 26);
            this.choiceLanguageToolStripMenuItem.Text = "ChoiceLanguage";
            // 
            // defaultLanguageToolStripMenuItem
            // 
            this.defaultLanguageToolStripMenuItem.Checked = true;
            this.defaultLanguageToolStripMenuItem.CheckOnClick = true;
            this.defaultLanguageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.defaultLanguageToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.defaultLanguageToolStripMenuItem.Name = "defaultLanguageToolStripMenuItem";
            this.defaultLanguageToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.defaultLanguageToolStripMenuItem.Text = "DefaultLanguage";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.AutoSize = false;
            this.settingToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.cog_32;
            this.settingToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.settingToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.settingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(80, 63);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.AutoSize = false;
            this.createToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.application_side_expand_32;
            this.createToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(80, 63);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.AutoSize = false;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseToolStripMenuItem,
            this.checkVersionToolStripMenuItem,
            this.submitSuggestToolStripMenuItem,
            this.copyrightToolStripMenuItem,
            this.homepageToolStripMenuItem});
            this.helpToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.infomation_32;
            this.helpToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.helpToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(80, 63);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // howToUseToolStripMenuItem
            // 
            this.howToUseToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.help_16;
            this.howToUseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.howToUseToolStripMenuItem.Text = "HowToUse";
            // 
            // checkVersionToolStripMenuItem
            // 
            this.checkVersionToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.database_refresh_16;
            this.checkVersionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.checkVersionToolStripMenuItem.Name = "checkVersionToolStripMenuItem";
            this.checkVersionToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.checkVersionToolStripMenuItem.Text = "CheckVersion";
            // 
            // submitSuggestToolStripMenuItem
            // 
            this.submitSuggestToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.application_edit_16;
            this.submitSuggestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.submitSuggestToolStripMenuItem.Name = "submitSuggestToolStripMenuItem";
            this.submitSuggestToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.submitSuggestToolStripMenuItem.Text = "SubmitSuggest";
            // 
            // copyrightToolStripMenuItem
            // 
            this.copyrightToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.bullet_error_16;
            this.copyrightToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.copyrightToolStripMenuItem.Name = "copyrightToolStripMenuItem";
            this.copyrightToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.copyrightToolStripMenuItem.Text = "Copyright";
            // 
            // homepageToolStripMenuItem
            // 
            this.homepageToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.world_link_16;
            this.homepageToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.homepageToolStripMenuItem.Name = "homepageToolStripMenuItem";
            this.homepageToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.homepageToolStripMenuItem.Text = "Homepage";
            // 
            // BodyContainer
            // 
            this.BodyContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.BodyContainer.Location = new System.Drawing.Point(0, 0);
            this.BodyContainer.Margin = new System.Windows.Forms.Padding(0);
            this.BodyContainer.Name = "BodyContainer";
            // 
            // BodyContainer.Panel1
            // 
            this.BodyContainer.Panel1.Controls.Add(this.LeftSplitContainer);
            this.BodyContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BodyContainer.Panel1MinSize = 200;
            // 
            // BodyContainer.Panel2
            // 
            this.BodyContainer.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.BodyContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BodyContainer.Panel2MinSize = 100;
            this.BodyContainer.Size = new System.Drawing.Size(845, 404);
            this.BodyContainer.SplitterDistance = 250;
            this.BodyContainer.SplitterWidth = 3;
            this.BodyContainer.TabIndex = 0;
            // 
            // LeftSplitContainer
            // 
            this.LeftSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.LeftSplitContainer.IsSplitterFixed = true;
            this.LeftSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.LeftSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.LeftSplitContainer.Name = "LeftSplitContainer";
            this.LeftSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // LeftSplitContainer.Panel1
            // 
            this.LeftSplitContainer.Panel1.Controls.Add(this.listView1);
            this.LeftSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(4);
            this.LeftSplitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // LeftSplitContainer.Panel2
            // 
            this.LeftSplitContainer.Panel2.Controls.Add(this.propertyGrid1);
            this.LeftSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.LeftSplitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LeftSplitContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LeftSplitContainer.Size = new System.Drawing.Size(250, 404);
            this.LeftSplitContainer.SplitterDistance = 254;
            this.LeftSplitContainer.SplitterWidth = 2;
            this.LeftSplitContainer.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(4, 4);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(242, 246);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(4, 4);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(4);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGrid1.Size = new System.Drawing.Size(242, 140);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.ToolbarVisible = false;
            this.propertyGrid1.UseCompatibleTextRendering = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.Controls.Add(this.easyTrackBar1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.MainPictureBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(592, 404);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // easyTrackBar1
            // 
            this.easyTrackBar1.BackColor = System.Drawing.SystemColors.Control;
            this.easyTrackBar1.BarBorderColor = System.Drawing.SystemColors.HotTrack;
            this.easyTrackBar1.BarBorderWidth = false;
            this.easyTrackBar1.BarClickColor = System.Drawing.SystemColors.ControlDark;
            this.easyTrackBar1.BarColor = System.Drawing.SystemColors.HotTrack;
            this.easyTrackBar1.BarWidth = 8;
            this.easyTrackBar1.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.easyTrackBar1.BorderWidth = false;
            this.easyTrackBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.easyTrackBar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.easyTrackBar1.Location = new System.Drawing.Point(472, 0);
            this.easyTrackBar1.Margin = new System.Windows.Forms.Padding(0);
            this.easyTrackBar1.MaxValue = 50;
            this.easyTrackBar1.MinValue = 10;
            this.easyTrackBar1.Name = "easyTrackBar1";
            this.easyTrackBar1.ProgressBarBackColor = System.Drawing.SystemColors.ControlLight;
            this.easyTrackBar1.ProgressBarBorderColor = System.Drawing.SystemColors.ControlDark;
            this.easyTrackBar1.ProgressBarBorderWidth = true;
            this.easyTrackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.easyTrackBar1.ShowValue = false;
            this.easyTrackBar1.Size = new System.Drawing.Size(120, 22);
            this.easyTrackBar1.TabIndex = 0;
            this.easyTrackBar1.Text = "网格大小";
            this.easyTrackBar1.Value = 10;
            this.easyTrackBar1.ValueChanged += new CSSSatyr.MyControls.ValueChangeHandler<CSSSatyr.MyControls.EasyTrackBarValueChangedArgs>(this.easyTrackBar1_ValueChanged);
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.AllowDrop = true;
            this.MainPictureBox.AutoScroll = true;
            this.MainPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.MainPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel2.SetColumnSpan(this.MainPictureBox, 2);
            this.MainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPictureBox.Location = new System.Drawing.Point(4, 26);
            this.MainPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(584, 374);
            this.MainPictureBox.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 7F);
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbShowLeftTree,
            this.tsbtnReOrder,
            this.tsbtnColorChange,
            this.tsbtnAutoSorption,
            this.tsbtnShowGrid});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(467, 22);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbShowLeftTree
            // 
            this.tsbShowLeftTree.AutoSize = false;
            this.tsbShowLeftTree.Checked = true;
            this.tsbShowLeftTree.CheckOnClick = true;
            this.tsbShowLeftTree.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbShowLeftTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShowLeftTree.Image = global::CSSSatyr.Properties.Resources.Application_Side_Tree_16_1;
            this.tsbShowLeftTree.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbShowLeftTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowLeftTree.Margin = new System.Windows.Forms.Padding(4, 0, 5, 1);
            this.tsbShowLeftTree.Name = "tsbShowLeftTree";
            this.tsbShowLeftTree.Size = new System.Drawing.Size(23, 21);
            this.tsbShowLeftTree.Text = "ShowSiderTree";
            this.tsbShowLeftTree.Click += new System.EventHandler(this.toolStripButton1_CheckStateChanged);
            // 
            // tsbtnReOrder
            // 
            this.tsbtnReOrder.AutoSize = false;
            this.tsbtnReOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnReOrder.Image = global::CSSSatyr.Properties.Resources.Order_16;
            this.tsbtnReOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnReOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnReOrder.Margin = new System.Windows.Forms.Padding(0, 0, 5, 1);
            this.tsbtnReOrder.Name = "tsbtnReOrder";
            this.tsbtnReOrder.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsbtnReOrder.Size = new System.Drawing.Size(23, 21);
            this.tsbtnReOrder.Text = "ReOrder";
            this.tsbtnReOrder.Click += new System.EventHandler(this.tsbtnReOrder_Click);
            // 
            // tsbtnColorChange
            // 
            this.tsbtnColorChange.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnColorChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsbtnColorChange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whiteToolStripMenuItem,
            this.blackToolStripMenuItem,
            this.grayToolStripMenuItem});
            this.tsbtnColorChange.Image = global::CSSSatyr.Properties.Resources.color_swatches_16px;
            this.tsbtnColorChange.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnColorChange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnColorChange.Margin = new System.Windows.Forms.Padding(0, 0, 5, 1);
            this.tsbtnColorChange.Name = "tsbtnColorChange";
            this.tsbtnColorChange.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsbtnColorChange.Size = new System.Drawing.Size(90, 21);
            this.tsbtnColorChange.Text = "GridStyle";
            // 
            // whiteToolStripMenuItem
            // 
            this.whiteToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.whiteToolStripMenuItem.AutoToolTip = true;
            this.whiteToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.W_Letter_16px;
            this.whiteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            this.whiteToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.whiteToolStripMenuItem.Tag = "default";
            this.whiteToolStripMenuItem.Text = "White(Default)";
            this.whiteToolStripMenuItem.Click += new System.EventHandler(this.blackToolStripMenuItem_Click);
            // 
            // blackToolStripMenuItem
            // 
            this.blackToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.B_Letter_16px;
            this.blackToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.blackToolStripMenuItem.Name = "blackToolStripMenuItem";
            this.blackToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.blackToolStripMenuItem.Tag = "black";
            this.blackToolStripMenuItem.Text = "Black";
            this.blackToolStripMenuItem.Click += new System.EventHandler(this.blackToolStripMenuItem_Click);
            // 
            // grayToolStripMenuItem
            // 
            this.grayToolStripMenuItem.Image = global::CSSSatyr.Properties.Resources.G_Letter_16px;
            this.grayToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.grayToolStripMenuItem.Name = "grayToolStripMenuItem";
            this.grayToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.grayToolStripMenuItem.Tag = "gray";
            this.grayToolStripMenuItem.Text = "Gray";
            this.grayToolStripMenuItem.Click += new System.EventHandler(this.blackToolStripMenuItem_Click);
            // 
            // tsbtnAutoSorption
            // 
            this.tsbtnAutoSorption.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnAutoSorption.CheckOnClick = true;
            this.tsbtnAutoSorption.Image = global::CSSSatyr.Properties.Resources.magnet_16px;
            this.tsbtnAutoSorption.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnAutoSorption.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAutoSorption.Margin = new System.Windows.Forms.Padding(0, 0, 5, 1);
            this.tsbtnAutoSorption.Name = "tsbtnAutoSorption";
            this.tsbtnAutoSorption.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsbtnAutoSorption.Size = new System.Drawing.Size(105, 21);
            this.tsbtnAutoSorption.Text = "AutoSorption";
            this.tsbtnAutoSorption.Click += new System.EventHandler(this.tsbtnAutoSorption_CheckedChanged);
            // 
            // tsbtnShowGrid
            // 
            this.tsbtnShowGrid.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnShowGrid.Checked = true;
            this.tsbtnShowGrid.CheckOnClick = true;
            this.tsbtnShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbtnShowGrid.Image = global::CSSSatyr.Properties.Resources.Workspace_16px;
            this.tsbtnShowGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnShowGrid.Margin = new System.Windows.Forms.Padding(0, 0, 5, 1);
            this.tsbtnShowGrid.Name = "tsbtnShowGrid";
            this.tsbtnShowGrid.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsbtnShowGrid.Size = new System.Drawing.Size(84, 21);
            this.tsbtnShowGrid.Text = "ShowGrid";
            this.tsbtnShowGrid.Click += new System.EventHandler(this.tsbtnShowGrid_Click);
            // 
            // sslAutoSorption
            // 
            this.sslAutoSorption.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sslAutoSorption.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusNewVersionLabel,
            this.tsslSpaceLabel,
            this.tsStatusAutoSorption,
            this.tsslGridSize});
            this.sslAutoSorption.Location = new System.Drawing.Point(0, 476);
            this.sslAutoSorption.Name = "sslAutoSorption";
            this.sslAutoSorption.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.sslAutoSorption.Size = new System.Drawing.Size(845, 25);
            this.sslAutoSorption.TabIndex = 2;
            this.sslAutoSorption.Text = "statusStrip1";
            // 
            // tsStatusNewVersionLabel
            // 
            this.tsStatusNewVersionLabel.Image = global::CSSSatyr.Properties.Resources.information_16px;
            this.tsStatusNewVersionLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsStatusNewVersionLabel.Name = "tsStatusNewVersionLabel";
            this.tsStatusNewVersionLabel.Size = new System.Drawing.Size(114, 20);
            this.tsStatusNewVersionLabel.Text = "NowVersion";
            // 
            // tsslSpaceLabel
            // 
            this.tsslSpaceLabel.Name = "tsslSpaceLabel";
            this.tsslSpaceLabel.Size = new System.Drawing.Size(533, 20);
            this.tsslSpaceLabel.Spring = true;
            this.tsslSpaceLabel.Text = "toolStripStatusLabel1";
            // 
            // tsStatusAutoSorption
            // 
            this.tsStatusAutoSorption.Name = "tsStatusAutoSorption";
            this.tsStatusAutoSorption.Size = new System.Drawing.Size(109, 20);
            this.tsStatusAutoSorption.Text = "AutoSorption";
            // 
            // tsslGridSize
            // 
            this.tsslGridSize.Name = "tsslGridSize";
            this.tsslGridSize.Size = new System.Drawing.Size(69, 20);
            this.tsslGridSize.Text = "GridSize";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(845, 501);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "CSS Satyr v2.0 beta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel1.PerformLayout();
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            this.MainSplitContainer.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.BodyContainer.Panel1.ResumeLayout(false);
            this.BodyContainer.Panel2.ResumeLayout(false);
            this.BodyContainer.ResumeLayout(false);
            this.LeftSplitContainer.Panel1.ResumeLayout(false);
            this.LeftSplitContainer.Panel2.ResumeLayout(false);
            this.LeftSplitContainer.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.sslAutoSorption.ResumeLayout(false);
            this.sslAutoSorption.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reOrderImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem autoSorptionGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSiderTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem submitSuggestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyrightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homepageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.SplitContainer BodyContainer;
        private System.Windows.Forms.SplitContainer LeftSplitContainer;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private MyControls.PicturePanel MainPictureBox;
        private System.Windows.Forms.StatusStrip sslAutoSorption;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem choiceLanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusNewVersionLabel;
        private System.Windows.Forms.ToolStripMenuItem defaultLanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusAutoSorption;
        protected internal System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem showGridToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslGridSize;
        private System.Windows.Forms.ToolStripStatusLabel tsslSpaceLabel;
        private MyControls.EasyTrackBar easyTrackBar1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnShowGrid;
        private System.Windows.Forms.ToolStripButton tsbtnAutoSorption;
        private System.Windows.Forms.ToolStripButton tsbtnReOrder;
        private System.Windows.Forms.ToolStripDropDownButton tsbtnColorChange;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbShowLeftTree;
    }
}

