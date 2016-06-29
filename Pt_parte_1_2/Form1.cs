using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net;
using Pt_parte_1_2.Properties;
using MySql;
using MySql.Data.MySqlClient;
using System.Reflection;
using IWshRuntimeLibrary;




namespace Pt_parte_1_2
{
       public partial class Form1 : Form
    {
        int possicaox = 27;
        int totaldeckcount = 100;
        int vez = 1;
        int i = 0;
        int sub_i = 0;
        int returni = 0;
        string prog;
      int picclick;
        PictureBox[] pbName = new PictureBox[1000];
        public Form1()
        {
            InitializeComponent();
        }
       
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Upload files";
            ofd.Filter = "All type for the programs | *.jpg; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox1.Image == null)
                {
                    pictureBox1.Enabled = false;
                    pictureBox1.BackgroundImage = new Bitmap(ofd.FileName);
                    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                    removeToolStripMenuItem.Enabled = true;
                    addToolStripMenuItem.Enabled = false;
                }
                else { MessageBox.Show("Errrrrrrooo!", "Erro 0");
                ofd.Dispose();
                }
            }
            else { MessageBox.Show("is not a fatal erro", "Erro -1"); }
            ofd.Dispose();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1 != null)
            {
                pictureBox1.Enabled = true;
                pictureBox1.BackgroundImage = null;
                removeToolStripMenuItem.Enabled = false;
                addToolStripMenuItem.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
          /*  DataTable dt = BusinessLogicLayer.BLL.pic.load();
            dataGridView1.DataSource = BusinessLogicLayer.BLL.pic.load();
            sub_i = dataGridView1.RowCount;*/

            DataTable dt = new DataTable();
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
                adap.Fill(dt);
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
              
                pb();

                PictureBox pic = new PictureBox { };
                pic.Click += this.PictureClick;
            
            removeToolStripMenuItem.Enabled = false;
            //File.Delete("CPUStress.exe");
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.BackgroundImage != null)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Edit directory";
                dlg.Filter = "Edit | *.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.BackgroundImage = new Bitmap(dlg.FileName);
                }
            }
            else
            {
                MessageBox.Show("Miss image", "Erroo 1", MessageBoxButtons.OK);
            }
        }

        private void backgroundImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Into image";
            ofd.Filter = " Image| *.jpg";
            ofd.FileName = "Image";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                BackgroundImage = new Bitmap(ofd.FileName);
                BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (BackgroundImage != null)
            {
                BackgroundImage = null;
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Edit image";
            ofd.FileName = "Upload image";
            ofd.Filter = "|*.png *.jpg";
            if (BackgroundImage != null)
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    BackgroundImage = null;
                    BackgroundImage = new Bitmap(ofd.FileName);
                    BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog(); 
            string[] files = Directory.GetFiles(fbd.SelectedPath);
            MessageBox.Show("Files Found " + files.Length.ToString(), "Message");
        }

        private void addTry2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {


            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void programsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {

            // add programa
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Upload a program";
            ofd.Filter = "Program |*.exe*";
            pb();
            if (vez == 1)
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Icon icon = Icon.ExtractAssociatedIcon(ofd.FileName);
                    pictureBox1.Image = icon.ToBitmap();
                    //end icon
                    prog = ofd.FileName;
                    BusinessLogicLayer.BLL.pic.insertPb(sub_i, prog);
                    vez = 2;
                }

                else { MessageBox.Show("Not a fatal error np my friend :P", "Errrrrrrrrrrrrooooo but no problem im here because you close me XD:( "); }

            }
            else
            {

                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    Icon icon = Icon.ExtractAssociatedIcon(ofd.FileName);
                    pbName[sub_i].Image = icon.ToBitmap();
                    pbName[sub_i].Tag = ofd.FileName;
                    sub_i =+ 1;
                    BusinessLogicLayer.BLL.pic.insertPb(sub_i, prog);
                }
                else { MessageBox.Show("Erro"); 
                    this.Controls.Remove(pbName[sub_i]);
                    possicaox -= 60;
                }
            }
        }

        private void PictureClick(object sender, EventArgs e)
        {    PictureBox click_pic = (PictureBox)sender;
           MessageBox.Show("Picturebox clicada" + click_pic.Name, " PB", MessageBoxButtons.OK);

           picclick = Int32.Parse(click_pic.Name);
           iniciar();
           
        }
        private void pb()
        {//create a pb auto
            DataTable dt = new DataTable();
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
                adap.Fill(dt);
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

                int colunas = dt.Rows.Count;
                tableLayoutPanel1.ColumnCount = colunas;
                tableLayoutPanel1.RowCount = 2;


                for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                {
                    tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));

                    for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                    {

                        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, (100 / tableLayoutPanel1.ColumnCount)));



                        Label lb = new Label { Text = (String)dt.Rows[j][0].ToString(), Size = new Size(150, 80), Visible = true, };
                        lb.Font = new Font(lb.Font.FontFamily, 15);
                             Icon icon = Icon.ExtractAssociatedIcon((String)dt.Rows[j][1]);
                        PictureBox pic = new PictureBox { Name = lb.Text, Size = new Size(32, 32), Visible = true, SizeMode = PictureBoxSizeMode.StretchImage, Location = new Point(30, 30), BorderStyle = (BorderStyle.FixedSingle), TabIndex = 0,Image = icon.ToBitmap(),TabStop = false };
                        pic.Click += this.PictureClick;


                        tableLayoutPanel1.Controls.Add(pic, j, i);


                        tableLayoutPanel1.Controls.Add(lb, j, i + 1);
                    }
                    i++;
                }


            }
        }


        private void removeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // remover Programa

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
                cmd.CommandText = "DELETE FROM `nb` WHERE `nb`.`NPB` = 1"; 
                cmd.ExecuteNonQuery();          
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
    

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            iniciar();
        }
        private void iniciar()
        {
            //comerçar o programa fora da form


            DataTable dt = new DataTable();
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
                adap.Fill(dt);
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
                
      
                    Process P = Process.Start(dt.Rows[picclick-1][1].ToString());
                    Thread.Sleep(2500);
                    //P.WaitForInputIdle();
                    SetParent(P.Handle, this.Handle);
            }
        }

        private void cPUStreesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient update_file = new WebClient();
                Uri update_url = new Uri(Properties.Glogalstring.Cpustress);
                update_file.DownloadFile(update_url, "CPUStress.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                var exe = new ProcessStartInfo();
                exe.FileName = "CPUStress";
                var process = new Process();
                process.StartInfo = exe;
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                string nome = getfilename(file);
                string dir = getdirectory(file);
                MessageBox.Show(nome);
                MessageBox.Show(dir);
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true) { e.Effect = DragDropEffects.All; }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
        private string getfilename(string name) {
            return Path.GetFileNameWithoutExtension(name);
        }

        private string getdirectory(string treeNode)
        { return Path.GetDirectoryName(treeNode); }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}