namespace VulScanner
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vulnerabilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aliasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lexerParserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dirsTreeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.urlInput = new System.Windows.Forms.TextBox();
            this.url_label = new System.Windows.Forms.Label();
            this.source_label = new System.Windows.Forms.Label();
            this.sourceInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.showOpt = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.blackRadio = new System.Windows.Forms.RadioButton();
            this.whiteRadio = new System.Windows.Forms.RadioButton();
            this.bothRadio = new System.Windows.Forms.RadioButton();
            this.listWhiteboxPlugins = new System.Windows.Forms.CheckedListBox();
            this.blackPluginsLabel = new System.Windows.Forms.Label();
            this.whitePluginsLabel = new System.Windows.Forms.Label();
            this.ScanBtn = new System.Windows.Forms.Button();
            this.listBlackboxPlugins = new System.Windows.Forms.CheckedListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.plgLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileNameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.inputGroupBox1 = new System.Windows.Forms.GroupBox();
            this.StopBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.inputGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.vulnerabilitiesToolStripMenuItem,
            this.pluginsToolStripMenuItem,
            this.lexerParserToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // vulnerabilitiesToolStripMenuItem
            // 
            this.vulnerabilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageToolStripMenuItem,
            this.aliasToolStripMenuItem});
            this.vulnerabilitiesToolStripMenuItem.Name = "vulnerabilitiesToolStripMenuItem";
            this.vulnerabilitiesToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.vulnerabilitiesToolStripMenuItem.Text = "Vulnerabilities";
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.manageToolStripMenuItem.Text = "Manage";
            this.manageToolStripMenuItem.Click += new System.EventHandler(this.manageToolStripMenuItem_Click);
            // 
            // aliasToolStripMenuItem
            // 
            this.aliasToolStripMenuItem.Name = "aliasToolStripMenuItem";
            this.aliasToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.aliasToolStripMenuItem.Text = "Aliases";
            this.aliasToolStripMenuItem.Click += new System.EventHandler(this.aliasToolStripMenuItem_Click);
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageToolStripMenuItem1});
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.pluginsToolStripMenuItem.Text = "Plugins";
            // 
            // manageToolStripMenuItem1
            // 
            this.manageToolStripMenuItem1.Name = "manageToolStripMenuItem1";
            this.manageToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.manageToolStripMenuItem1.Text = "Manage";
            this.manageToolStripMenuItem1.Click += new System.EventHandler(this.manageToolStripMenuItem1_Click);
            // 
            // lexerParserToolStripMenuItem
            // 
            this.lexerParserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageToolStripMenuItem2});
            this.lexerParserToolStripMenuItem.Name = "lexerParserToolStripMenuItem";
            this.lexerParserToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.lexerParserToolStripMenuItem.Text = "Lexer/Parser";
            // 
            // manageToolStripMenuItem2
            // 
            this.manageToolStripMenuItem2.Name = "manageToolStripMenuItem2";
            this.manageToolStripMenuItem2.Size = new System.Drawing.Size(117, 22);
            this.manageToolStripMenuItem2.Text = "Manage";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // dirsTreeView
            // 
            this.dirsTreeView.ImageIndex = 0;
            this.dirsTreeView.ImageList = this.imageList1;
            this.dirsTreeView.Location = new System.Drawing.Point(7, 44);
            this.dirsTreeView.Name = "dirsTreeView";
            this.dirsTreeView.SelectedImageIndex = 0;
            this.dirsTreeView.Size = new System.Drawing.Size(184, 463);
            this.dirsTreeView.TabIndex = 1;
            this.dirsTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.dirsTreeView_BeforeExpand);
            this.dirsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.dirsTreeView_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "0.bmp");
            this.imageList1.Images.SetKeyName(1, "1.bmp");
            this.imageList1.Images.SetKeyName(2, "2.bmp");
            this.imageList1.Images.SetKeyName(3, "3.bmp");
            this.imageList1.Images.SetKeyName(4, "4.bmp");
            this.imageList1.Images.SetKeyName(5, "5.bmp");
            this.imageList1.Images.SetKeyName(6, "6.bmp");
            this.imageList1.Images.SetKeyName(7, "7.bmp");
            this.imageList1.Images.SetKeyName(8, "8.bmp");
            this.imageList1.Images.SetKeyName(9, "9.bmp");
            this.imageList1.Images.SetKeyName(10, "10.bmp");
            this.imageList1.Images.SetKeyName(11, "11.bmp");
            this.imageList1.Images.SetKeyName(12, "12.bmp");
            // 
            // urlInput
            // 
            this.urlInput.Location = new System.Drawing.Point(68, 31);
            this.urlInput.Name = "urlInput";
            this.urlInput.Size = new System.Drawing.Size(324, 22);
            this.urlInput.TabIndex = 2;
            this.urlInput.Text = "http://";
            this.urlInput.TextChanged += new System.EventHandler(this.urlInput_TextChanged);
            // 
            // url_label
            // 
            this.url_label.AutoSize = true;
            this.url_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.url_label.Location = new System.Drawing.Point(15, 34);
            this.url_label.Name = "url_label";
            this.url_label.Size = new System.Drawing.Size(32, 13);
            this.url_label.TabIndex = 3;
            this.url_label.Text = "URL";
            // 
            // source_label
            // 
            this.source_label.AutoSize = true;
            this.source_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.source_label.Location = new System.Drawing.Point(15, 60);
            this.source_label.Name = "source_label";
            this.source_label.Size = new System.Drawing.Size(47, 13);
            this.source_label.TabIndex = 4;
            this.source_label.Text = "Source";
            // 
            // sourceInput
            // 
            this.sourceInput.Location = new System.Drawing.Point(68, 57);
            this.sourceInput.Name = "sourceInput";
            this.sourceInput.ReadOnly = true;
            this.sourceInput.Size = new System.Drawing.Size(324, 22);
            this.sourceInput.TabIndex = 5;
            this.sourceInput.TextChanged += new System.EventHandler(this.sourceInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(209, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Options";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(447, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Type";
            // 
            // showOpt
            // 
            this.showOpt.AutoSize = true;
            this.showOpt.Location = new System.Drawing.Point(212, 189);
            this.showOpt.Name = "showOpt";
            this.showOpt.Size = new System.Drawing.Size(151, 17);
            this.showOpt.TabIndex = 8;
            this.showOpt.Text = "Show result after scanning";
            this.showOpt.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(212, 212);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(66, 17);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "Option 1";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(212, 235);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(66, 17);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.Text = "Option 1";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // blackRadio
            // 
            this.blackRadio.AutoSize = true;
            this.blackRadio.Location = new System.Drawing.Point(450, 189);
            this.blackRadio.Name = "blackRadio";
            this.blackRadio.Size = new System.Drawing.Size(73, 17);
            this.blackRadio.TabIndex = 11;
            this.blackRadio.Text = "Black Box";
            this.blackRadio.UseVisualStyleBackColor = true;
            this.blackRadio.CheckedChanged += new System.EventHandler(this.blackRadio_CheckedChanged);
            // 
            // whiteRadio
            // 
            this.whiteRadio.AutoSize = true;
            this.whiteRadio.Location = new System.Drawing.Point(450, 212);
            this.whiteRadio.Name = "whiteRadio";
            this.whiteRadio.Size = new System.Drawing.Size(74, 17);
            this.whiteRadio.TabIndex = 12;
            this.whiteRadio.Text = "White Box";
            this.whiteRadio.UseVisualStyleBackColor = true;
            this.whiteRadio.CheckedChanged += new System.EventHandler(this.whiteRadio_CheckedChanged);
            // 
            // bothRadio
            // 
            this.bothRadio.AutoSize = true;
            this.bothRadio.Checked = true;
            this.bothRadio.Location = new System.Drawing.Point(450, 235);
            this.bothRadio.Name = "bothRadio";
            this.bothRadio.Size = new System.Drawing.Size(47, 17);
            this.bothRadio.TabIndex = 13;
            this.bothRadio.TabStop = true;
            this.bothRadio.Text = "Both";
            this.bothRadio.UseVisualStyleBackColor = true;
            this.bothRadio.CheckedChanged += new System.EventHandler(this.bothRadio_CheckedChanged);
            // 
            // listWhiteboxPlugins
            // 
            this.listWhiteboxPlugins.BackColor = System.Drawing.SystemColors.Control;
            this.listWhiteboxPlugins.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listWhiteboxPlugins.CheckOnClick = true;
            this.listWhiteboxPlugins.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listWhiteboxPlugins.FormattingEnabled = true;
            this.listWhiteboxPlugins.Location = new System.Drawing.Point(622, 315);
            this.listWhiteboxPlugins.Name = "listWhiteboxPlugins";
            this.listWhiteboxPlugins.Size = new System.Drawing.Size(150, 190);
            this.listWhiteboxPlugins.TabIndex = 15;
            this.listWhiteboxPlugins.SelectedIndexChanged += new System.EventHandler(this.listWhiteboxPlugins_SelectedIndexChanged);
            // 
            // blackPluginsLabel
            // 
            this.blackPluginsLabel.AutoSize = true;
            this.blackPluginsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blackPluginsLabel.Location = new System.Drawing.Point(619, 55);
            this.blackPluginsLabel.Name = "blackPluginsLabel";
            this.blackPluginsLabel.Size = new System.Drawing.Size(130, 17);
            this.blackPluginsLabel.TabIndex = 16;
            this.blackPluginsLabel.Text = "Blackbox Plugins";
            // 
            // whitePluginsLabel
            // 
            this.whitePluginsLabel.AutoSize = true;
            this.whitePluginsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whitePluginsLabel.Location = new System.Drawing.Point(619, 286);
            this.whitePluginsLabel.Name = "whitePluginsLabel";
            this.whitePluginsLabel.Size = new System.Drawing.Size(132, 17);
            this.whitePluginsLabel.TabIndex = 17;
            this.whitePluginsLabel.Text = "Whitebox Plugins";
            // 
            // ScanBtn
            // 
            this.ScanBtn.Location = new System.Drawing.Point(212, 286);
            this.ScanBtn.Name = "ScanBtn";
            this.ScanBtn.Size = new System.Drawing.Size(75, 23);
            this.ScanBtn.TabIndex = 18;
            this.ScanBtn.Text = "Scan Now";
            this.ScanBtn.UseVisualStyleBackColor = true;
            this.ScanBtn.Click += new System.EventHandler(this.ScanBtn_Click);
            // 
            // listBlackboxPlugins
            // 
            this.listBlackboxPlugins.BackColor = System.Drawing.SystemColors.Control;
            this.listBlackboxPlugins.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBlackboxPlugins.CheckOnClick = true;
            this.listBlackboxPlugins.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBlackboxPlugins.FormattingEnabled = true;
            this.listBlackboxPlugins.Location = new System.Drawing.Point(622, 75);
            this.listBlackboxPlugins.Name = "listBlackboxPlugins";
            this.listBlackboxPlugins.Size = new System.Drawing.Size(150, 190);
            this.listBlackboxPlugins.TabIndex = 19;
            this.listBlackboxPlugins.SelectedIndexChanged += new System.EventHandler(this.listBlackboxPlugins_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.stsLabel,
            this.toolStripStatusLabel2,
            this.plgLabel,
            this.toolStripStatusLabel3,
            this.fileNameLabel,
            this.timeLabel,
            this.timeValue});
            this.statusStrip1.Location = new System.Drawing.Point(0, 537);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 19);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // stsLabel
            // 
            this.stsLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.stsLabel.Name = "stsLabel";
            this.stsLabel.Size = new System.Drawing.Size(62, 19);
            this.stsLabel.Text = "Unstarted";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(44, 19);
            this.toolStripStatusLabel2.Text = "Plugin:";
            // 
            // plgLabel
            // 
            this.plgLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.plgLabel.Name = "plgLabel";
            this.plgLabel.Size = new System.Drawing.Size(20, 19);
            this.plgLabel.Text = "   ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(60, 19);
            this.toolStripStatusLabel3.Text = "FileName:";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(16, 19);
            this.fileNameLabel.Text = "   ";
            this.fileNameLabel.TextChanged += new System.EventHandler(this.fileNameLabel_TextChanged);
            // 
            // timeLabel
            // 
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(491, 19);
            this.timeLabel.Spring = true;
            this.timeLabel.Text = "Time Elapsed:";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeValue
            // 
            this.timeValue.Name = "timeValue";
            this.timeValue.Size = new System.Drawing.Size(34, 19);
            this.timeValue.Text = "00:00";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(7, 511);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(770, 23);
            this.progressBar1.TabIndex = 27;
            // 
            // inputGroupBox1
            // 
            this.inputGroupBox1.Controls.Add(this.url_label);
            this.inputGroupBox1.Controls.Add(this.urlInput);
            this.inputGroupBox1.Controls.Add(this.source_label);
            this.inputGroupBox1.Controls.Add(this.sourceInput);
            this.inputGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputGroupBox1.Location = new System.Drawing.Point(197, 44);
            this.inputGroupBox1.Name = "inputGroupBox1";
            this.inputGroupBox1.Size = new System.Drawing.Size(410, 100);
            this.inputGroupBox1.TabIndex = 28;
            this.inputGroupBox1.TabStop = false;
            this.inputGroupBox1.Text = "Input";
            // 
            // StopBtn
            // 
            this.StopBtn.Enabled = false;
            this.StopBtn.Location = new System.Drawing.Point(293, 286);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(75, 23);
            this.StopBtn.TabIndex = 29;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.inputGroupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBlackboxPlugins);
            this.Controls.Add(this.ScanBtn);
            this.Controls.Add(this.whitePluginsLabel);
            this.Controls.Add(this.blackPluginsLabel);
            this.Controls.Add(this.listWhiteboxPlugins);
            this.Controls.Add(this.bothRadio);
            this.Controls.Add(this.whiteRadio);
            this.Controls.Add(this.blackRadio);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.showOpt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dirsTreeView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.inputGroupBox1.ResumeLayout(false);
            this.inputGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vulnerabilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lexerParserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TreeView dirsTreeView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox urlInput;
        private System.Windows.Forms.Label url_label;
        private System.Windows.Forms.Label source_label;
        private System.Windows.Forms.TextBox sourceInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox showOpt;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.RadioButton blackRadio;
        private System.Windows.Forms.RadioButton whiteRadio;
        private System.Windows.Forms.RadioButton bothRadio;
        private System.Windows.Forms.CheckedListBox listWhiteboxPlugins;
        private System.Windows.Forms.Label blackPluginsLabel;
        private System.Windows.Forms.Label whitePluginsLabel;
        private System.Windows.Forms.Button ScanBtn;
        private System.Windows.Forms.CheckedListBox listBlackboxPlugins;
        private System.Windows.Forms.ToolStripMenuItem aliasToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stsLabel;
        private System.Windows.Forms.ToolStripStatusLabel plgLabel;
        private System.Windows.Forms.ToolStripStatusLabel fileNameLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripStatusLabel timeLabel;
        private System.Windows.Forms.ToolStripStatusLabel timeValue;
        private System.Windows.Forms.GroupBox inputGroupBox1;
        private System.Windows.Forms.Button StopBtn;
    }
}

