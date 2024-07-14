using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    internal class mainclass
    {

        public static readonly string conn_string = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        public static SqlConnection conn=new SqlConnection(conn_string);

        //method to check user validation
        public static bool IsValid(string user, string password)
        {
            bool valid = false;
            string query = "SELECT username FROM users WHERE username=@user AND upass=@password";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@password", password);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    valid = true;
                    if (reader.Read())
                    {
                        valid = true;
                        USER = reader.GetString(0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return valid;
        }

        //create property for user
        private static string user;
        public static string USER
        {
            get
            {
                return user;
            }
            private set
            {
                user = value;
            }
        }
        //Method for crud operation
        public static int SQL(string query,Hashtable hr)
        {
            int res = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                foreach(DictionaryEntry item in hr)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(),item.Value);
                }
                if(conn.State == ConnectionState.Closed) { conn.Open(); }
                res = cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open) { conn.Close(); }

            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        //for loading data from database 
        public static void loadData(string qry,DataGridView dv,ListBox lb)
        {
            //serial no in category
            dv.CellFormatting += new DataGridViewCellFormattingEventHandler(dv1);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt=new DataTable();
                sd.Fill(dt);
                for(int i=0; i<lb.Items.Count;i++)
                {
                    string colNam1 = ((DataGridViewColumn)lb.Items[i]).Name;
                    dv.Columns[colNam1].DataPropertyName = dt.Columns[i].ToString();
                }
                dv.DataSource = dt; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private static void dv1(Object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (sender is Guna.UI2.WinForms.Guna2DataGridView)
            {
                Guna.UI2.WinForms.Guna2DataGridView gv = (Guna.UI2.WinForms.Guna2DataGridView)sender;
                int count = 0;
                foreach (DataGridViewRow row in gv.Rows)
                {
                    count++;
                    row.Cells[0].Value = count;
                }
            }
        }
        //for combobox fill
        public void combobox(string query,ComboBox cb)
        {
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType=CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cb.DisplayMember = "name";
            cb.ValueMember = "id";
            cb.DataSource = dt;
            cb.SelectedItem = -1;
        }
    }
}
