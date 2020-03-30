using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Properties
{
    public partial class ProcessList : Form
    {
        public ProcessList()
        {
            InitializeComponent();
        }

        private void procList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            string key;
            DialogResult result = ofdProcess.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {
                string fname = ofdProcess.FileName;
                if (!Program.procList.TryGetValue(fname, out key))
                {
                    procList.Rows.Add(fname, "Never");
                    Program.procList.Add(fname, "Never");
                    Program.procListChanged = true;
                }
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow elem in procList.SelectedRows)
            {
                procList.Rows.Remove(elem);
                Program.procList.Remove(elem.Cells[0].Value.ToString());
                Program.procListChanged = true;
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProcessList_Load(object sender, EventArgs e)
        {
            foreach(var elem in Program.procList)
            {
                procList.Rows.Add(elem.Key,elem.Value);
            }
        }

        private void btnAddProcess_Click(object sender, EventArgs e)
        {
            var selectProcessDialog = new SelectProcessDialog();
            selectProcessDialog.ShowDialog();
            if (selectProcessDialog.DialogResult == DialogResult.OK)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("CANCEL");
            }
        }
    }
}
