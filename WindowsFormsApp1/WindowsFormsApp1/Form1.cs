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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DataGridView GetDataGridView1 = new DataGridView();

        public Form1()
        {
            InitializeComponent();            
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            Process[] localProcesses = Process.GetProcesses();

            foreach (Process proc in localProcesses)
            {
                string[] actualRow = { proc.ProcessName, "" + proc.Id };
                dataGridView1.Rows.Add(proc.ProcessName, proc.Id);
            }
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                tableLayoutPanel1.Controls.Clear();

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                int selectedProcessId = (int)row.Cells["Column2"].Value;

                Process selectedProcess = Process.GetProcessById(selectedProcessId);

                tableLayoutPanel1.Controls.Add(new Label() { Text = "CPU Usage" }, 0, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Memory Usage" }, 0, 1);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Running Time" }, 0, 2);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Start Time" }, 0, 3);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Threads" }, 0, 4);

                
                PerformanceCounter CPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                float Value1 = CPUCounter.NextValue();
                Thread.Sleep(250);
                float Value2 = CPUCounter.NextValue();
                tableLayoutPanel1.Controls.Add(new Label() { Text = Value2.ToString() }, 1, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = selectedProcess.WorkingSet64.ToString() }, 1, 1);


                string TimeElapsed = "Unknown";
                try
                {
                    TimeElapsed = (DateTime.Now - selectedProcess.StartTime).ToString();
                }
                catch (System.ComponentModel.Win32Exception) { }
                tableLayoutPanel1.Controls.Add(new Label() { Text = TimeElapsed }, 1, 2);

                string StartTime = "Unknown";
                try
                {
                    StartTime = selectedProcess.StartTime.ToString();
                }
                catch (Win32Exception){ }
                tableLayoutPanel1.Controls.Add(new Label() { Text = StartTime }, 1, 3);

                ProcessThreadCollection threads = selectedProcess.Threads;
                int numberOfThreads = 0;
                foreach (var thread in threads)
                {
                    numberOfThreads++;
                }

                tableLayoutPanel1.Controls.Add(new Label() { Text = numberOfThreads.ToString() }, 1, 4);
            }
        }
    }
}
