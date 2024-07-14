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
    public partial class tableADD : Form
    {
        public tableADD()
        {
            InitializeComponent();
        }

        private void tableADD_Load(object sender, EventArgs e)
        {

        }
        public int id = 0;
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string query = " ";
            if (id == 0)
            {
                query = "insert into POS_table values(@Name)";
            }
            else
            {
                query = "update POS_table set tname=@Name where tid=@id";
            }
            Hashtable h = new Hashtable();
            h.Add("@id", id);
            h.Add("@Name", tadd.Text);
            if (mainclass.SQL(query, h) > 0)
            {
                MessageBox.Show("Saved successfully..");
                id = 0;
                tadd.Text = " ";
                tadd.Focus();
            }
            else
            {
                MessageBox.Show("There is an error..");
            }
        }
    }
}
