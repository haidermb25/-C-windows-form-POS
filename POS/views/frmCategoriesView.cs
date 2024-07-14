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
    public partial class frmCategoriesView : SampleView
    {
        public frmCategoriesView()
        {
            InitializeComponent();
        }
        //from here we load data
        public void getdata()
        {
            string qry = "select *from category where cname like '%"+txtSearch.Text+"%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            mainclass.loadData(qry,guna2DataGridView1,lb);
        }
        public override void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            frmCategoryAdd fA = new frmCategoryAdd();
            fA.ShowDialog();
            getdata();
        }

        public override void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            getdata();
        }

        private void frmCategoriesView_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(guna2DataGridView1.CurrentCell.OwningColumn.Name=="dgvedit")
            {
                frmCategoryAdd a=new frmCategoryAdd();
                a.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                a.tadd.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                a.ShowDialog();
                getdata();
            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if(guna2MessageDialog1.Show("ARE YOU SURE YOU WANT TO DELETE--")==DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    string query = "delete from category where cid=" + id + "";
                    Hashtable ht = new Hashtable();
                    mainclass.SQL(query, ht);
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageBox.Show("Deleted succesfully");
                    getdata();
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
