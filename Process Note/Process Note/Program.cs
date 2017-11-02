using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Process_Note
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form Form1 = new Form1();
            Application.Run(Form1);

            Process[] local = Process.GetProcesses();

            /*
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.ColumnCount = 2;
            panel.RowCount = local.Length;

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            panel.Controls.Add(new Label() {Text = "Process Name" }, 1, 0);
            panel.Controls.Add(new Label() { Text = "Process ID" }, 2, 0);
            foreach (Process proc in local)
            {
                panel.RowCount = panel.RowCount + 1;
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                panel.Controls.Add(new Label() { Text = proc.ProcessName }, 1, panel.RowCount - 1);
                panel.Controls.Add(new Label() { Text = "" + proc.Id }, 2, panel.RowCount - 1);
            }
            */


        }
    }
}
