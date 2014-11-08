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
    public partial class Vulsmanagement : Form
    {
        DataSet ds; int rno = 0; DataRow drow;
        string vulPath = @"VulsDB\vulsdb.xml";

        public Vulsmanagement()
        {
            InitializeComponent();

            VulGridView.DataSource = null;

            ds = new DataSet();
            ds.ReadXml(vulPath);

            VulGridView.DataSource = ds.Tables[0];

            DataGridViewColumn column = VulGridView.Columns[1];
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables[0].Columns[0];
            //keys[1] = ds.Tables[0].Columns[1];

            ds.Tables[0].PrimaryKey = keys;

            showData();

        }

        void showData()
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                vulName.Text = ds.Tables[0].Rows[rno][0].ToString();
                vulDescription.Text = ds.Tables[0].Rows[rno][1].ToString();
                vulEnvironment.Text = ds.Tables[0].Rows[rno][2].ToString();
                vulExample.Text = ds.Tables[0].Rows[rno][3].ToString();
                vulDetermination.Text = ds.Tables[0].Rows[rno][4].ToString();
                vulProtection.Text = ds.Tables[0].Rows[rno][5].ToString();
            }
            else
                MessageBox.Show("No records");
        }

        private void VulSaveBtn_Click(object sender, EventArgs e)
        {

            DataRow drow = ds.Tables[0].Rows.Find(VulGridView.SelectedRows[0].Cells[0].Value);
            if (drow != null)
            {
                rno = ds.Tables[0].Rows.IndexOf(drow);

                ds.Tables[0].Rows[rno][0] = vulName.Text;
                ds.Tables[0].Rows[rno][1] = vulDescription.Text;
                ds.Tables[0].Rows[rno][2] = vulEnvironment.Text;
                ds.Tables[0].Rows[rno][3] = vulExample.Text;
                ds.Tables[0].Rows[rno][4] = vulDetermination.Text;
                ds.Tables[0].Rows[rno][5] = vulProtection.Text;

                ds.WriteXml(vulPath);
                MessageBox.Show("Record has been updated");
            }
            else
                MessageBox.Show("No record exists. Please try again.");
        }

        private void VulDeleteBtn_Click(object sender, EventArgs e)
        {
            DataRow drow = ds.Tables[0].Rows.Find(vulName.Text);
            int rw = VulGridView.CurrentRow.Index;

            drow = ((VulGridView.DataSource) as DataTable).Rows[rw];

            if (drow != null)
            {
                ds.Tables[0].Rows.Remove(drow);
                ds.WriteXml(vulPath);
                MessageBox.Show("A record has been deleted");
                showData();
            }
            else
                MessageBox.Show("No record exists. Please try again.");
        }

        private void VulGridView_SelectionChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("dsads");
            if (VulGridView.SelectedRows.Count > 0)
            {
                //MessageBox.Show(VulGridView.SelectedRows[0].Cells[0].Value.ToString());
                PopulateFormData();
            }
        }

        private void PopulateFormData()
        {
            try
            {
                vulName.Text = VulGridView.SelectedRows[0].Cells[0].Value.ToString();
                vulDescription.Text = VulGridView.SelectedRows[0].Cells[1].Value.ToString();
                vulEnvironment.Text = VulGridView.SelectedRows[0].Cells[2].Value.ToString();
                vulExample.Text = VulGridView.SelectedRows[0].Cells[3].Value.ToString();
                vulDetermination.Text = VulGridView.SelectedRows[0].Cells[4].Value.ToString();
                vulProtection.Text = VulGridView.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch
            {

            }
        }



    }
}
