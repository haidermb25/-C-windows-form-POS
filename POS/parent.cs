using POS.views;
using System;
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
    public partial class parent : Form
    {
        public parent()
        {
            InitializeComponent();
            update();
        }
        //here we add controls on the same page
        public void add_control(Form f)
        {
            controlPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            f.Height = 500;
            controlPanel.Controls.Add(f);
            f.Show();
        }


        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void update()
        {
            name.Text = mainclass.USER;

        }
        private void parent_Load(object sender, EventArgs e)
        {
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            add_control(new frmHome());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            add_control(new frmCategoriesView());
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            add_control(new frmTableview());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            add_control(new frmStaffview());
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            add_control(new frmProductView());
        }
    }
}
