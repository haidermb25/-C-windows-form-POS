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

namespace POS.Model
{
    public partial class frmCategoryAdd : Form
    {
        public frmCategoryAdd()
        {
            InitializeComponent();
        }

        private void frmCategoryAdd_Load(object sender, EventArgs e)
        {

        }
        public int id = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = " ";
            if(id==0)
            {
                query = "insert into category values(@Name)";
            }
            else
            {
                query = "update category set cname=@Name where cid=@id";
            }
            Hashtable h= new Hashtable();
            h.Add("@id",id);
            h.Add("@Name", tadd.Text);
            if(mainclass.SQL(query,h)>0)
            {
                MessageBox.Show("Saved successfully..");
                id = 0;
                tadd.Text =" ";
                tadd.Focus();
            }
            else
            {
                MessageBox.Show("There is an error");

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
