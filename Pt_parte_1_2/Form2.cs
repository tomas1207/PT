using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pt_parte_1_2
{
    public partial class Form2 : Form
    {
        Thread[] cpuLoadThread;

        public Form2()
        {
            InitializeComponent();
            cpuLoadThread = new Thread[Environment.ProcessorCount];
        }
        public static void CPUKill(object cpuUsage)
        {
            Parallel.For(0, 1, new Action<int>((int i) =>
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                while (true)
                {
                    if (watch.ElapsedMilliseconds > (int)cpuUsage)
                    {
                        Thread.Sleep(100 - (int)cpuUsage);
                        watch.Reset();
                        watch.Start();
                    }
                }
            })
            );

        }


        private void test()
        {
            
            int cpuUsageIncreaseby = 100;
            while (true)
            {
                for (int i = 0; i < Environment.ProcessorCount; i++)
                {
                    int cpuUsage = cpuUsageIncreaseby;
                    int time = 6000;
                    List<Thread> threads = new List<Thread>();
                    for (int j = 0; j < Environment.ProcessorCount; j++)
                    {
                        Thread t = new Thread(new ParameterizedThreadStart(CPUKill));
                        t.Start(cpuUsage);
                        threads.Add(t);
                    }
                    Thread.Sleep(time);
                    foreach (var t in threads)
                    {
                        t.Abort();
                        
                    }
                    Application.Restart();
                    Thread.Sleep(20);

                   
                }
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
          backgroundWorker1.RunWorkerAsync();
          
        }

        private void Form2_Load(object sender, EventArgs e)
        {
         

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.backgroundWorker1.CancellationPending)
            {  
                
                e.Cancel = true;
            return;
            }
            else
            {
                test();

             //  backgroundWorker1.WorkerSupportsCancellation = true;
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                escreve("CPU Stress has been cancel");
            }
            else {
                escreve("CPU Stress haas been end");
            }
        }
        private void escreve(string text) {
            MessageBox.Show(text);
        }
        private void button2_Click(object sender, EventArgs e)
        {
      
                backgroundWorker1.CancelAsync();
               backgroundWorker1.Dispose();
            backgroundWorker1 = null;
           
          
        }
    }
}
