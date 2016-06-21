using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using MySql.Web;

namespace Pt_parte_1_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
            private void button1_Click(object sender, EventArgs e)
        {
           string n1 = textBox1.Text;
            string n2 = textBox2.Text;
     
MySqlConnection conn;
string myConnectionString;

myConnectionString = "server=localhost;uid=root;" +
    "database=ezedesktop;";
conn = new MySqlConnection(myConnectionString);
    conn.ConnectionString = myConnectionString;
    conn.Open();
            MySqlCommand cmd;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "Insert into nb (Directory) values(@Directory)";
                cmd.Parameters.AddWithValue("@Directory", n2);
                cmd.ExecuteNonQuery();
                loaddata();
            }
            catch (Exception) { throw; }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Clone();
                }
            }

        }
        private void loaddata()
        {
            MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=127.0.0.1;uid=root;" +
                "database=ezedesktop;";
            conn = new MySqlConnection(myConnectionString);
            conn.ConnectionString = myConnectionString;
            conn.Open();
            MySqlCommand cmd;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM nb";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Clone();
                }

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}