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

namespace POS
{
    public partial class frmStaffAdd : Form
    {
        public frmStaffAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string query = " ";
            if (id == 0)
            {
                query = "insert into staff values(@Name,@phone,@role)";
            }
            else
            {
                query = "update staff set sName=@Name,sPhone=@phone,sRole=@role where staffID=@id";
            }
            Hashtable h = new Hashtable();
            h.Add("@id", id);
            h.Add("@Name", tadd.Text);
            h.Add("@phone", phone.Text);
            h.Add("@role",role.SelectedItem.ToString());
            if (mainclass.SQL(query, h) > 0)
            {
                MessageBox.Show("Saved successfully..");
                id = 0;
                tadd.Text = " ";
                phone.Text=" ";
                role.Text=" ";  
                tadd.Focus();
            }
            else
            {
                MessageBox.Show("There is an error");

            }

        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
