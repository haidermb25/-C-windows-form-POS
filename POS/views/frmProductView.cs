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
    public partial class frmProductView : Form
    {
        public frmProductView()
        {
            InitializeComponent();
        }

        private void frmProductView_Load(object sender, EventArgs e)
        {
            getdata();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductAdd fA = new frmProductAdd();
            fA.ShowDialog();
            getdata();

        }
        public void getdata()
        {
            string qry = "select p.pID,p.pName,p.pPrice,c.cid,c.cName from product p inner join category c on c.cid=p.categoryId where pName like '%"+txtSearch.Text+"%'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvprice);
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvcategory);

            mainclass.loadData(qry, guna2DataGridView1, lb);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            getdata();
        }
        private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                frmProductAdd a=new frmProductAdd();
                a.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
               // a.tadd.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
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
                    string query = "delete from product where pid=" + id + "";
                    Hashtable ht = new Hashtable();
                    mainclass.SQL(query, ht);
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageBox.Show("Deleted succesfully");
                    getdata();
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }
    }
}
