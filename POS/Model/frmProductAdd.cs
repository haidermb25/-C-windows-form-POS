using System;
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
    public partial class frmProductAdd : Form
    {
        public frmProductAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        private void frmProductAdd_Load(object sender, EventArgs e)
        {

        }

        private void phone_TextChanged(object sender, EventArgs e)
        {

        }
        string filepath;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "images(.jpg, .png)!* .png; *.jpg";
            if(ofd.ShowDialog() == DialogResult.OK )
            {
                filepath=ofd.FileName;
            }
        }

        private void role_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var query=
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
