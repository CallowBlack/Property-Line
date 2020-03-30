

namespace Properties
{
    partial class OptionForm
    {


        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionForm));
            this.button1 = new System.Windows.Forms.Button();
            this.tbMainKey = new System.Windows.Forms.TextBox();
            this.cbSecondaryKey = new System.Windows.Forms.ComboBox();
            this.IconTaskBar = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuTaskBar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MicEnabled_checkbox = new System.Windows.Forms.CheckBox();
            this.volume_checkbox = new System.Windows.Forms.CheckBox();
            this.MuteChecker = new System.Windows.Forms.Timer(this.components);
            this.Tag_1 = new System.Windows.Forms.Label();
            this.Tag_2 = new System.Windows.Forms.Label();
            this.CPULoad_check = new System.Windows.Forms.CheckBox();
            this.MemLoad_check = new System.Windows.Forms.CheckBox();
            this.TimerIndex = new System.Windows.Forms.Timer(this.components);
            this.cbBlockKey = new System.Windows.Forms.CheckBox();
            this.btnMakeDebugLineTop = new System.Windows.Forms.Button();
            this.btnRunAs = new System.Windows.Forms.Button();
            this.cbAlwaysAsAdmin = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRunHookProcess = new System.Windows.Forms.Button();
            this.cbEnableOverlay = new System.Windows.Forms.CheckBox();
            this.cbDragBoxMode = new System.Windows.Forms.CheckBox();
            this.cbAutorun = new System.Windows.Forms.CheckBox();
            this.cbRelativeCorner = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lPosition = new System.Windows.Forms.Label();
            this.MenuTaskBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 29);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbMainKey
            // 
            this.tbMainKey.Location = new System.Drawing.Point(160, 30);
            this.tbMainKey.Margin = new System.Windows.Forms.Padding(2);
            this.tbMainKey.Name = "tbMainKey";
            this.tbMainKey.Size = new System.Drawing.Size(26, 20);
            this.tbMainKey.TabIndex = 1;
            this.tbMainKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // cbSecondaryKey
            // 
            this.cbSecondaryKey.Items.AddRange(new object[] {
            "LShift",
            "LCtrl",
            "LAlt",
            "Caps Lock",
            "Tab",
            "No key"});
            this.cbSecondaryKey.Location = new System.Drawing.Point(48, 29);
            this.cbSecondaryKey.Margin = new System.Windows.Forms.Padding(2);
            this.cbSecondaryKey.Name = "cbSecondaryKey";
            this.cbSecondaryKey.Size = new System.Drawing.Size(92, 21);
            this.cbSecondaryKey.TabIndex = 2;
            // 
            // IconTaskBar
            // 
            this.IconTaskBar.ContextMenuStrip = this.MenuTaskBar;
            this.IconTaskBar.Icon = ((System.Drawing.Icon)(resources.GetObject("IconTaskBar.Icon")));
            this.IconTaskBar.Text = "Property Line";
            this.IconTaskBar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // MenuTaskBar
            // 
            this.MenuTaskBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuTaskBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.MenuTaskBar.Name = "MenuTaskBar";
            this.MenuTaskBar.Size = new System.Drawing.Size(110, 26);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "+";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Key:";
            // 
            // MicEnabled_checkbox
            // 
            this.MicEnabled_checkbox.AutoSize = true;
            this.MicEnabled_checkbox.Location = new System.Drawing.Point(17, 93);
            this.MicEnabled_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.MicEnabled_checkbox.Name = "MicEnabled_checkbox";
            this.MicEnabled_checkbox.Size = new System.Drawing.Size(109, 17);
            this.MicEnabled_checkbox.TabIndex = 6;
            this.MicEnabled_checkbox.Text = "Microphone Stats";
            this.MicEnabled_checkbox.UseVisualStyleBackColor = true;
            this.MicEnabled_checkbox.CheckedChanged += new System.EventHandler(this.checkBoxChanged);
            // 
            // volume_checkbox
            // 
            this.volume_checkbox.AutoSize = true;
            this.volume_checkbox.Location = new System.Drawing.Point(17, 114);
            this.volume_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.volume_checkbox.Name = "volume_checkbox";
            this.volume_checkbox.Size = new System.Drawing.Size(61, 17);
            this.volume_checkbox.TabIndex = 4;
            this.volume_checkbox.Text = "Volume";
            this.volume_checkbox.UseVisualStyleBackColor = true;
            this.volume_checkbox.CheckedChanged += new System.EventHandler(this.checkBoxChanged);
            // 
            // MuteChecker
            // 
            this.MuteChecker.Enabled = true;
            this.MuteChecker.Interval = 2000;
            this.MuteChecker.Tick += new System.EventHandler(this.MuteChecker_Tick);
            // 
            // Tag_1
            // 
            this.Tag_1.AutoSize = true;
            this.Tag_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Tag_1.Location = new System.Drawing.Point(8, 9);
            this.Tag_1.Name = "Tag_1";
            this.Tag_1.Size = new System.Drawing.Size(107, 18);
            this.Tag_1.TabIndex = 7;
            this.Tag_1.Text = "Bind properties";
            // 
            // Tag_2
            // 
            this.Tag_2.AutoSize = true;
            this.Tag_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Tag_2.Location = new System.Drawing.Point(8, 74);
            this.Tag_2.Name = "Tag_2";
            this.Tag_2.Size = new System.Drawing.Size(42, 18);
            this.Tag_2.TabIndex = 8;
            this.Tag_2.Text = "Index";
            // 
            // CPULoad_check
            // 
            this.CPULoad_check.AutoSize = true;
            this.CPULoad_check.Location = new System.Drawing.Point(133, 93);
            this.CPULoad_check.Margin = new System.Windows.Forms.Padding(2);
            this.CPULoad_check.Name = "CPULoad_check";
            this.CPULoad_check.Size = new System.Drawing.Size(71, 17);
            this.CPULoad_check.TabIndex = 9;
            this.CPULoad_check.Text = "CPU load";
            this.CPULoad_check.UseVisualStyleBackColor = true;
            this.CPULoad_check.CheckedChanged += new System.EventHandler(this.checkBoxChanged);
            // 
            // MemLoad_check
            // 
            this.MemLoad_check.AutoSize = true;
            this.MemLoad_check.Location = new System.Drawing.Point(133, 114);
            this.MemLoad_check.Margin = new System.Windows.Forms.Padding(2);
            this.MemLoad_check.Name = "MemLoad_check";
            this.MemLoad_check.Size = new System.Drawing.Size(86, 17);
            this.MemLoad_check.TabIndex = 10;
            this.MemLoad_check.Text = "Memory load";
            this.MemLoad_check.UseVisualStyleBackColor = true;
            this.MemLoad_check.CheckedChanged += new System.EventHandler(this.checkBoxChanged);
            // 
            // TimerIndex
            // 
            this.TimerIndex.Enabled = true;
            this.TimerIndex.Tick += new System.EventHandler(this.TimerIndexOnTick);
            // 
            // cbBlockKey
            // 
            this.cbBlockKey.AutoSize = true;
            this.cbBlockKey.Location = new System.Drawing.Point(16, 55);
            this.cbBlockKey.Margin = new System.Windows.Forms.Padding(2);
            this.cbBlockKey.Name = "cbBlockKey";
            this.cbBlockKey.Size = new System.Drawing.Size(103, 17);
            this.cbBlockKey.TabIndex = 17;
            this.cbBlockKey.Text = "Block key signal";
            this.cbBlockKey.UseVisualStyleBackColor = true;
            this.cbBlockKey.CheckedChanged += new System.EventHandler(this.checkBoxChanged);
            // 
            // btnMakeDebugLineTop
            // 
            this.btnMakeDebugLineTop.Location = new System.Drawing.Point(147, 206);
            this.btnMakeDebugLineTop.Margin = new System.Windows.Forms.Padding(2);
            this.btnMakeDebugLineTop.Name = "btnMakeDebugLineTop";
            this.btnMakeDebugLineTop.Size = new System.Drawing.Size(86, 23);
            this.btnMakeDebugLineTop.TabIndex = 18;
            this.btnMakeDebugLineTop.Text = "Make top";
            this.btnMakeDebugLineTop.UseVisualStyleBackColor = true;
            this.btnMakeDebugLineTop.Click += new System.EventHandler(this.ReloadDebug_Click);
            // 
            // btnRunAs
            // 
            this.btnRunAs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunAs.Location = new System.Drawing.Point(11, 206);
            this.btnRunAs.Margin = new System.Windows.Forms.Padding(2);
            this.btnRunAs.Name = "btnRunAs";
            this.btnRunAs.Size = new System.Drawing.Size(90, 23);
            this.btnRunAs.TabIndex = 19;
            this.btnRunAs.Text = "Run as admin";
            this.btnRunAs.UseVisualStyleBackColor = true;
            this.btnRunAs.Click += new System.EventHandler(this.btnRunAs_Click);
            // 
            // cbAlwaysAsAdmin
            // 
            this.cbAlwaysAsAdmin.AutoSize = true;
            this.cbAlwaysAsAdmin.Location = new System.Drawing.Point(11, 232);
            this.cbAlwaysAsAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.cbAlwaysAsAdmin.Name = "cbAlwaysAsAdmin";
            this.cbAlwaysAsAdmin.Size = new System.Drawing.Size(123, 17);
            this.cbAlwaysAsAdmin.TabIndex = 20;
            this.cbAlwaysAsAdmin.Text = "Always run as Admin";
            this.cbAlwaysAsAdmin.UseVisualStyleBackColor = true;
            this.cbAlwaysAsAdmin.CheckedChanged += new System.EventHandler(this.checkBoxChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 436);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "D3DOverlay (Don\'t work)";
            this.label3.Visible = false;
            // 
            // btnRunHookProcess
            // 
            this.btnRunHookProcess.Enabled = false;
            this.btnRunHookProcess.Location = new System.Drawing.Point(16, 481);
            this.btnRunHookProcess.Margin = new System.Windows.Forms.Padding(2);
            this.btnRunHookProcess.Name = "btnRunHookProcess";
            this.btnRunHookProcess.Size = new System.Drawing.Size(85, 23);
            this.btnRunHookProcess.TabIndex = 22;
            this.btnRunHookProcess.Text = "Hook Process";
            this.btnRunHookProcess.UseVisualStyleBackColor = true;
            this.btnRunHookProcess.Visible = false;
            this.btnRunHookProcess.Click += new System.EventHandler(this.btnRunHookProcess_Click);
            // 
            // cbEnableOverlay
            // 
            this.cbEnableOverlay.AutoSize = true;
            this.cbEnableOverlay.Enabled = false;
            this.cbEnableOverlay.Location = new System.Drawing.Point(17, 459);
            this.cbEnableOverlay.Margin = new System.Windows.Forms.Padding(2);
            this.cbEnableOverlay.Name = "cbEnableOverlay";
            this.cbEnableOverlay.Size = new System.Drawing.Size(96, 17);
            this.cbEnableOverlay.TabIndex = 23;
            this.cbEnableOverlay.Text = "Enable overlay";
            this.cbEnableOverlay.UseVisualStyleBackColor = true;
            this.cbEnableOverlay.Visible = false;
            this.cbEnableOverlay.CheckedChanged += new System.EventHandler(this.checkBoxChanged);
            // 
            // cbDragBoxMode
            // 
            this.cbDragBoxMode.AutoSize = true;
            this.cbDragBoxMode.Location = new System.Drawing.Point(16, 185);
            this.cbDragBoxMode.Margin = new System.Windows.Forms.Padding(2);
            this.cbDragBoxMode.Name = "cbDragBoxMode";
            this.cbDragBoxMode.Size = new System.Drawing.Size(76, 17);
            this.cbDragBoxMode.TabIndex = 24;
            this.cbDragBoxMode.Text = "DragMode";
            this.cbDragBoxMode.UseVisualStyleBackColor = true;
            this.cbDragBoxMode.CheckedChanged += new System.EventHandler(this.checkBoxChanged);
            // 
            // cbAutorun
            // 
            this.cbAutorun.AutoSize = true;
            this.cbAutorun.Location = new System.Drawing.Point(11, 253);
            this.cbAutorun.Margin = new System.Windows.Forms.Padding(2);
            this.cbAutorun.Name = "cbAutorun";
            this.cbAutorun.Size = new System.Drawing.Size(132, 17);
            this.cbAutorun.TabIndex = 25;
            this.cbAutorun.Text = "Autorun with Windows";
            this.cbAutorun.UseVisualStyleBackColor = true;
            this.cbAutorun.CheckedChanged += new System.EventHandler(this.checkBoxChanged);
            // 
            // cbRelativeCorner
            // 
            this.cbRelativeCorner.Items.AddRange(new object[] {
            "top left",
            "top right",
            "bottom left",
            "bottom right"});
            this.cbRelativeCorner.Location = new System.Drawing.Point(82, 160);
            this.cbRelativeCorner.Margin = new System.Windows.Forms.Padding(2);
            this.cbRelativeCorner.Name = "cbRelativeCorner";
            this.cbRelativeCorner.Size = new System.Drawing.Size(129, 21);
            this.cbRelativeCorner.TabIndex = 26;
            this.cbRelativeCorner.SelectedIndexChanged += new System.EventHandler(this.cbRelativeCorner_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 27;
            this.label4.Text = "Position";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(13, 161);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 28;
            this.label5.Text = "Relative to";
            // 
            // lPosition
            // 
            this.lPosition.AutoSize = true;
            this.lPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPosition.Location = new System.Drawing.Point(120, 185);
            this.lPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lPosition.Name = "lPosition";
            this.lPosition.Size = new System.Drawing.Size(84, 15);
            this.lPosition.TabIndex = 29;
            this.lPosition.Text = "Position: 5, 10";
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 273);
            this.Controls.Add(this.lPosition);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbRelativeCorner);
            this.Controls.Add(this.cbAutorun);
            this.Controls.Add(this.cbDragBoxMode);
            this.Controls.Add(this.cbAlwaysAsAdmin);
            this.Controls.Add(this.btnRunAs);
            this.Controls.Add(this.btnMakeDebugLineTop);
            this.Controls.Add(this.cbBlockKey);
            this.Controls.Add(this.MemLoad_check);
            this.Controls.Add(this.CPULoad_check);
            this.Controls.Add(this.Tag_2);
            this.Controls.Add(this.Tag_1);
            this.Controls.Add(this.MicEnabled_checkbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.volume_checkbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSecondaryKey);
            this.Controls.Add(this.tbMainKey);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbEnableOverlay);
            this.Controls.Add(this.btnRunHookProcess);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "OptionForm";
            this.Text = "Properties Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.onLoadForm);
            this.MenuTaskBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbMainKey;
        private System.Windows.Forms.ComboBox cbSecondaryKey;
        private System.Windows.Forms.NotifyIcon IconTaskBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox MicEnabled_checkbox;
        private System.Windows.Forms.CheckBox volume_checkbox;
        private System.Windows.Forms.Timer MuteChecker;
        private System.Windows.Forms.Label Tag_1;
        private System.Windows.Forms.Label Tag_2;
        private System.Windows.Forms.CheckBox CPULoad_check;
        private System.Windows.Forms.CheckBox MemLoad_check;
        private System.Windows.Forms.Timer TimerIndex;
        private System.Windows.Forms.ContextMenuStrip MenuTaskBar;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbBlockKey;
        private System.Windows.Forms.Button btnMakeDebugLineTop;
        private System.Windows.Forms.Button btnRunAs;
        private System.Windows.Forms.CheckBox cbAlwaysAsAdmin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRunHookProcess;
        private System.Windows.Forms.CheckBox cbEnableOverlay;
        private System.Windows.Forms.CheckBox cbDragBoxMode;
        private System.Windows.Forms.CheckBox cbAutorun;
        private System.Windows.Forms.ComboBox cbRelativeCorner;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lPosition;
    }
}

