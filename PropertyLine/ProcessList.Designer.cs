namespace Properties
{
    partial class ProcessList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.procList = new System.Windows.Forms.DataGridView();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastInject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.btnAddProcess = new System.Windows.Forms.Button();
            this.ofdProcess = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.procList)).BeginInit();
            this.SuspendLayout();
            // 
            // procList
            // 
            this.procList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.procList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.procList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessName,
            this.LastInject});
            this.procList.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.procList.Location = new System.Drawing.Point(13, 15);
            this.procList.Margin = new System.Windows.Forms.Padding(4);
            this.procList.Name = "procList";
            this.procList.ReadOnly = true;
            this.procList.RowHeadersVisible = false;
            this.procList.RowHeadersWidth = 4;
            this.procList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.procList.Size = new System.Drawing.Size(408, 187);
            this.procList.TabIndex = 0;
            this.procList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.procList_CellContentClick);
            // 
            // ProcessName
            // 
            this.ProcessName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProcessName.HeaderText = "Process Name";
            this.ProcessName.MinimumWidth = 6;
            this.ProcessName.Name = "ProcessName";
            this.ProcessName.ReadOnly = true;
            // 
            // LastInject
            // 
            this.LastInject.HeaderText = "Last Inject";
            this.LastInject.MinimumWidth = 6;
            this.LastInject.Name = "LastInject";
            this.LastInject.ReadOnly = true;
            this.LastInject.Width = 125;
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(289, 245);
            this.btnAddFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(132, 28);
            this.btnAddFile.TabIndex = 1;
            this.btnAddFile.Text = "Add File";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(16, 209);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(100, 28);
            this.RemoveButton.TabIndex = 2;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(16, 245);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(100, 28);
            this.BackButton.TabIndex = 3;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // btnAddProcess
            // 
            this.btnAddProcess.Location = new System.Drawing.Point(289, 209);
            this.btnAddProcess.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddProcess.Name = "btnAddProcess";
            this.btnAddProcess.Size = new System.Drawing.Size(132, 28);
            this.btnAddProcess.TabIndex = 4;
            this.btnAddProcess.Text = "Add Proccess";
            this.btnAddProcess.UseVisualStyleBackColor = true;
            this.btnAddProcess.Click += new System.EventHandler(this.btnAddProcess_Click);
            // 
            // ofdProcess
            // 
            this.ofdProcess.FileName = "openFileDialog1";
            // 
            // ProcessList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 283);
            this.Controls.Add(this.btnAddProcess);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.procList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ProcessList";
            this.Text = "Hook Process List";
            this.Load += new System.EventHandler(this.ProcessList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.procList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView procList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastInject;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button btnAddProcess;
        private System.Windows.Forms.OpenFileDialog ofdProcess;
    }
}