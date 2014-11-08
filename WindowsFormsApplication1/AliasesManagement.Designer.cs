namespace VulScanner
{
    partial class AliasesManagement
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
            this.aliasesGridView = new System.Windows.Forms.DataGridView();
            this.col1Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2Alias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.aliasesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // aliasesGridView
            // 
            this.aliasesGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.aliasesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aliasesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col1Name,
            this.col2Alias});
            this.aliasesGridView.Location = new System.Drawing.Point(0, 1);
            this.aliasesGridView.Name = "aliasesGridView";
            this.aliasesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.aliasesGridView.Size = new System.Drawing.Size(702, 446);
            this.aliasesGridView.TabIndex = 0;
            // 
            // col1Name
            // 
            this.col1Name.HeaderText = "Name";
            this.col1Name.Name = "col1Name";
            // 
            // col2Alias
            // 
            this.col2Alias.HeaderText = "Alias";
            this.col2Alias.Name = "col2Alias";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(615, 456);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(534, 456);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 2;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // AliasesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 486);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.aliasesGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AliasesManagement";
            this.Text = "AliasesManagement";
            ((System.ComponentModel.ISupportInitialize)(this.aliasesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView aliasesGridView;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2Alias;
    }
}