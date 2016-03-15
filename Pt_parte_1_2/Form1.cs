using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pt_parte_1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Upload files";
            ofd.Filter = "All type for the programs | *.*";
           
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox1.Image == null)
                {
            pictureBox1.Image = new Bitmap(dlg.FileName);
                    removeToolStripMenuItem.Enabled = true;
                    addToolStripMenuItem.Enabled = false;

                }
                else { MessageBox.Show("Errrrrrrooo!"); }
                }
            //dlg.Dispose();
            }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1 != null)
            {
                pictureBox1.Image = null;
                removeToolStripMenuItem.Enabled = false;
                addToolStripMenuItem.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            removeToolStripMenuItem.Enabled = false;

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
              if (pictureBox1.Image != null)
            {
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.Title = "Edit directory";
                dlg.Filter = "Edit | *.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    
                    pictureBox1.Image = new Bitmap(dlg.FileName);


                }
            }
            else { MessageBox.Show("Miss image","Erroo", MessageBoxButtons.OK);
            }
        }
        }
        }
    

