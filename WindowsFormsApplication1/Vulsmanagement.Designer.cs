namespace VulScanner
{
    partial class Vulsmanagement
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
            this.VulGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.vulName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.vulEnvironment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.vulDescription = new System.Windows.Forms.TextBox();
            this.vulExample = new System.Windows.Forms.TextBox();
            this.vulDetermination = new System.Windows.Forms.TextBox();
            this.vulProtection = new System.Windows.Forms.TextBox();
            this.VulClearbtn = new System.Windows.Forms.Button();
            this.VulSaveBtn = new System.Windows.Forms.Button();
            this.VulDeleteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VulGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // VulGridView
            // 
            this.VulGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.VulGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VulGridView.Location = new System.Drawing.Point(0, 0);
            this.VulGridView.Name = "VulGridView";
            this.VulGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VulGridView.Size = new System.Drawing.Size(801, 217);
            this.VulGridView.TabIndex = 0;
            this.VulGridView.SelectionChanged += new System.EventHandler(this.VulGridView_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // vulName
            // 
            this.vulName.Location = new System.Drawing.Point(15, 247);
            this.vulName.Name = "vulName";
            this.vulName.Size = new System.Drawing.Size(376, 20);
            this.vulName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(418, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Environment";
            // 
            // vulEnvironment
            // 
            this.vulEnvironment.Location = new System.Drawing.Point(421, 248);
            this.vulEnvironment.Name = "vulEnvironment";
            this.vulEnvironment.Size = new System.Drawing.Size(368, 20);
            this.vulEnvironment.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(418, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Example";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 404);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Determination";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(418, 405);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Protection";
            // 
            // vulDescription
            // 
            this.vulDescription.Location = new System.Drawing.Point(15, 287);
            this.vulDescription.Multiline = true;
            this.vulDescription.Name = "vulDescription";
            this.vulDescription.Size = new System.Drawing.Size(376, 114);
            this.vulDescription.TabIndex = 9;
            // 
            // vulExample
            // 
            this.vulExample.Location = new System.Drawing.Point(421, 287);
            this.vulExample.Multiline = true;
            this.vulExample.Name = "vulExample";
            this.vulExample.Size = new System.Drawing.Size(368, 114);
            this.vulExample.TabIndex = 10;
            // 
            // vulDetermination
            // 
            this.vulDetermination.Location = new System.Drawing.Point(15, 420);
            this.vulDetermination.Multiline = true;
            this.vulDetermination.Name = "vulDetermination";
            this.vulDetermination.Size = new System.Drawing.Size(376, 114);
            this.vulDetermination.TabIndex = 11;
            // 
            // vulProtection
            // 
            this.vulProtection.Location = new System.Drawing.Point(421, 421);
            this.vulProtection.Multiline = true;
            this.vulProtection.Name = "vulProtection";
            this.vulProtection.Size = new System.Drawing.Size(368, 114);
            this.vulProtection.TabIndex = 12;
            // 
            // VulClearbtn
            // 
            this.VulClearbtn.Location = new System.Drawing.Point(714, 548);
            this.VulClearbtn.Name = "VulClearbtn";
            this.VulClearbtn.Size = new System.Drawing.Size(75, 23);
            this.VulClearbtn.TabIndex = 13;
            this.VulClearbtn.Text = "Clear";
            this.VulClearbtn.UseVisualStyleBackColor = true;
            // 
            // VulSaveBtn
            // 
            this.VulSaveBtn.Location = new System.Drawing.Point(633, 548);
            this.VulSaveBtn.Name = "VulSaveBtn";
            this.VulSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.VulSaveBtn.TabIndex = 14;
            this.VulSaveBtn.Text = "Save";
            this.VulSaveBtn.UseVisualStyleBackColor = true;
            this.VulSaveBtn.Click += new System.EventHandler(this.VulSaveBtn_Click);
            // 
            // VulDeleteBtn
            // 
            this.VulDeleteBtn.Location = new System.Drawing.Point(552, 548);
            this.VulDeleteBtn.Name = "VulDeleteBtn";
            this.VulDeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.VulDeleteBtn.TabIndex = 15;
            this.VulDeleteBtn.Text = "Delete";
            this.VulDeleteBtn.UseVisualStyleBackColor = true;
            this.VulDeleteBtn.Click += new System.EventHandler(this.VulDeleteBtn_Click);
            // 
            // Vulsmanagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 583);
            this.Controls.Add(this.VulDeleteBtn);
            this.Controls.Add(this.VulSaveBtn);
            this.Controls.Add(this.VulClearbtn);
            this.Controls.Add(this.vulProtection);
            this.Controls.Add(this.vulDetermination);
            this.Controls.Add(this.vulExample);
            this.Controls.Add(this.vulDescription);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vulEnvironment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vulName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VulGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Vulsmanagement";
            this.Text = "Vulnerabilities Manager";
            ((System.ComponentModel.ISupportInitialize)(this.VulGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView VulGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox vulName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox vulEnvironment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox vulDescription;
        private System.Windows.Forms.TextBox vulExample;
        private System.Windows.Forms.TextBox vulDetermination;
        private System.Windows.Forms.TextBox vulProtection;
        private System.Windows.Forms.Button VulClearbtn;
        private System.Windows.Forms.Button VulSaveBtn;
        private System.Windows.Forms.Button VulDeleteBtn;
    }
}