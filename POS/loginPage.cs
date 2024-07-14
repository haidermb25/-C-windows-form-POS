using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace POS
{
    public partial class loginPage : Form
    {
        public loginPage()
        {
            InitializeComponent();
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtpass.Clear();
            txtuser.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (mainclass.IsValid(txtuser.Text, txtpass.Text) == true)
            {
                this.Hide();
                parent P = new parent();
                P.Show();
            }
            else
            {

                guna2MessageDialog1.Show("invalid username or password");
            }
        }
    }
}
