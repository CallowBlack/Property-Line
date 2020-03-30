using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Properties
{
    public partial class SelectProcessDialog : Form
    {
        public Process SelectedProcess { get; private set; }
        private Process[] processlist;

        public SelectProcessDialog()
        {
            InitializeComponent();
        }

        private void loadProcessList()
        {
            lbProcessList.Items.Clear();
            processlist = Process.GetProcesses();
            Array.Sort(processlist, compareProcess);
            foreach (Process process in processlist)
                lbProcessList.Items.Add(String.Format("0x{0:X08} - {1} - {2}", process.Id, process.ProcessName, "ad"));
        }

        private static int compareProcess(Process p1, Process p2)
        {
            return p1.Id - p2.Id;
        }

        private void SelectProcessDialog_Load(object sender, EventArgs e)
        {
            loadProcessList();
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadProcessList();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lbProcessList.SelectedIndex != -1)
            {
                SelectedProcess = processlist[lbProcessList.SelectedIndex];
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Please select element in the process list.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
