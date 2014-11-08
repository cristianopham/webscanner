namespace VulScanner
{
    partial class ConfigManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigManagement));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.formConfigName = new System.Windows.Forms.TextBox();
            this.formConfigVersion = new System.Windows.Forms.TextBox();
            this.formConfigValidType = new System.Windows.Forms.TextBox();
            this.formConfigExeCommand = new System.Windows.Forms.TextBox();
            this.formConfigDescription = new System.Windows.Forms.TextBox();
            this.formConfigAuthor = new System.Windows.Forms.TextBox();
            this.formConfigLicence = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.formConfigPath = new System.Windows.Forms.TextBox();
            this.configList = new System.Windows.Forms.TreeView();
            this.treeIcons = new System.Windows.Forms.ImageList(this.components);
            this.configSaveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "* Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Licence";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Author";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "* Exe Command";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Valid Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(182, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Version";
            // 
            // formConfigName
            // 
            this.formConfigName.Location = new System.Drawing.Point(240, 54);
            this.formConfigName.Name = "formConfigName";
            this.formConfigName.Size = new System.Drawing.Size(295, 20);
            this.formConfigName.TabIndex = 8;
            // 
            // formConfigVersion
            // 
            this.formConfigVersion.Location = new System.Drawing.Point(240, 87);
            this.formConfigVersion.Name = "formConfigVersion";
            this.formConfigVersion.Size = new System.Drawing.Size(295, 20);
            this.formConfigVersion.TabIndex = 9;
            // 
            // formConfigValidType
            // 
            this.formConfigValidType.Location = new System.Drawing.Point(240, 120);
            this.formConfigValidType.Name = "formConfigValidType";
            this.formConfigValidType.Size = new System.Drawing.Size(295, 20);
            this.formConfigValidType.TabIndex = 10;
            // 
            // formConfigExeCommand
            // 
            this.formConfigExeCommand.Location = new System.Drawing.Point(240, 153);
            this.formConfigExeCommand.Name = "formConfigExeCommand";
            this.formConfigExeCommand.Size = new System.Drawing.Size(295, 20);
            this.formConfigExeCommand.TabIndex = 11;
            // 
            // formConfigDescription
            // 
            this.formConfigDescription.Location = new System.Drawing.Point(240, 186);
            this.formConfigDescription.Name = "formConfigDescription";
            this.formConfigDescription.Size = new System.Drawing.Size(295, 20);
            this.formConfigDescription.TabIndex = 12;
            // 
            // formConfigAuthor
            // 
            this.formConfigAuthor.Location = new System.Drawing.Point(240, 219);
            this.formConfigAuthor.Name = "formConfigAuthor";
            this.formConfigAuthor.Size = new System.Drawing.Size(295, 20);
            this.formConfigAuthor.TabIndex = 13;
            // 
            // formConfigLicence
            // 
            this.formConfigLicence.Location = new System.Drawing.Point(240, 252);
            this.formConfigLicence.Name = "formConfigLicence";
            this.formConfigLicence.Size = new System.Drawing.Size(295, 20);
            this.formConfigLicence.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(195, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Path";
            // 
            // formConfigPath
            // 
            this.formConfigPath.Enabled = false;
            this.formConfigPath.Location = new System.Drawing.Point(240, 22);
            this.formConfigPath.Name = "formConfigPath";
            this.formConfigPath.Size = new System.Drawing.Size(295, 20);
            this.formConfigPath.TabIndex = 16;
            // 
            // configList
            // 
            this.configList.ImageIndex = 0;
            this.configList.ImageList = this.treeIcons;
            this.configList.Location = new System.Drawing.Point(-1, 3);
            this.configList.Name = "configList";
            this.configList.SelectedImageIndex = 0;
            this.configList.Size = new System.Drawing.Size(134, 318);
            this.configList.TabIndex = 17;
            this.configList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.configList_NodeMouseClick);
            // 
            // treeIcons
            // 
            this.treeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeIcons.ImageStream")));
            this.treeIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.treeIcons.Images.SetKeyName(0, "40705.png");
            this.treeIcons.Images.SetKeyName(1, "Check-icon.png");
            this.treeIcons.Images.SetKeyName(2, "notification_warning.png");
            // 
            // configSaveBtn
            // 
            this.configSaveBtn.Location = new System.Drawing.Point(459, 289);
            this.configSaveBtn.Name = "configSaveBtn";
            this.configSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.configSaveBtn.TabIndex = 18;
            this.configSaveBtn.Text = "Save";
            this.configSaveBtn.UseVisualStyleBackColor = true;
            this.configSaveBtn.Visible = false;
            this.configSaveBtn.Click += new System.EventHandler(this.configSaveBtn_Click);
            // 
            // ConfigManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(569, 324);
            this.Controls.Add(this.configSaveBtn);
            this.Controls.Add(this.formConfigPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.formConfigLicence);
            this.Controls.Add(this.formConfigAuthor);
            this.Controls.Add(this.formConfigDescription);
            this.Controls.Add(this.formConfigExeCommand);
            this.Controls.Add(this.formConfigValidType);
            this.Controls.Add(this.formConfigVersion);
            this.Controls.Add(this.formConfigName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.configList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigManagement";
            this.Text = "Manage Plugins";
            this.Load += new System.EventHandler(this.ConfigManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox formConfigName;
        private System.Windows.Forms.TextBox formConfigVersion;
        private System.Windows.Forms.TextBox formConfigValidType;
        private System.Windows.Forms.TextBox formConfigExeCommand;
        private System.Windows.Forms.TextBox formConfigDescription;
        private System.Windows.Forms.TextBox formConfigAuthor;
        private System.Windows.Forms.TextBox formConfigLicence;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox formConfigPath;
        private System.Windows.Forms.TreeView configList;
        private System.Windows.Forms.Button configSaveBtn;
        private System.Windows.Forms.ImageList treeIcons;
    }
}