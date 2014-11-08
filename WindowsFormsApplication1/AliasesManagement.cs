using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VulScanner
{
    public partial class AliasesManagement : Form
    {
        static string aliasPath = @"VulsDB\alias.ini";
        DataSet ds;
        Ini aliasDb = new Ini(aliasPath);

        public AliasesManagement()
        {
            InitializeComponent();

            aliasesGridView.Columns[0].Width = 300;
            DataGridViewColumn column = aliasesGridView.Columns[1];
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewRow row = new DataGridViewRow();

            string[] keys = aliasDb.GetKeys("");

            for (int i = 0; i < keys.Length; i += 1)
            {
                row = new DataGridViewRow();
                row.CreateCells(aliasesGridView);
                row.Cells[0].Value = keys[i];
                row.Cells[1].Value = aliasDb.GetValue(keys[i]);
                if (row.Cells[1].Value != "")
                {
                    aliasesGridView.Rows.Add(row);
                }
            }

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //clear all values
            System.IO.File.WriteAllText(aliasPath, string.Empty);
            aliasDb = new Ini(aliasPath);

            for (int i = 0; i < aliasesGridView.Rows.Count; i += 1)
            {
                try
                {
                    string key = aliasesGridView.Rows[i].Cells[0].Value.ToString();
                    string value = aliasesGridView.Rows[i].Cells[1].Value.ToString();
                    aliasDb.WriteValue(key, value);
                }
                catch
                {
                    //nothing
                }
            }
            aliasDb.Save();
            MessageBox.Show("All changes have been saved.");
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int rw = aliasesGridView.CurrentRow.Index;
            DialogResult dr = MessageBox.Show("Do you want to delete this record?", "Delete Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    aliasesGridView.Rows.RemoveAt(rw);
                    MessageBox.Show("A record has been deleted");
                }
                catch
                {
                    MessageBox.Show("No record exists. Please try again.");
                }
            }

        }
    }
}
