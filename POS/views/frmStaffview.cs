using Guna.UI2.WinForms;
using POS.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.views
{
    public partial class frmStaffview : Form
    {
        public frmStaffview()
        {
            InitializeComponent();
        }

        private void frmStaffview_Load(object sender, EventArgs e)
        {
            getdata();
        }
        public void getdata()
        {
            string qry = "select *from staff where sName like '%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvRole);
            mainclass.loadData(qry, guna2DataGridView1, lb);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmStaffAdd fA = new frmStaffAdd();
            fA.ShowDialog();
            getdata();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            getdata();
        }

        private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                frmStaffAdd a = new frmStaffAdd();
                a.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                a.tadd.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                a.phone.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPhone"].Value);
                a.ShowDialog();
                getdata();
            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if (guna2MessageDialog1.Show("ARE YOU SURE YOU WANT TO DELETE--") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    string query = "delete from staff where staffID=" + id + "";
                    Hashtable ht = new Hashtable();
                    mainclass.SQL(query, ht);
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageBox.Show("Deleted succesfully");
                    getdata();
                }
            }
        }
    }
}

