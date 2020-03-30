using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Properties.Properties;
using NAudio.CoreAudioApi;
using Microsoft.Win32;
using NAudio.Wave;
using System.Diagnostics;
using System.Collections.Generic;

namespace Properties
{
    public partial class OptionForm : Form
    {
        #region DllImport
        [DllImport("user32.dll")]
        static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr window, int index, int value);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr window, int index);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;

            public MEMORYSTATUSEX()
            {
                this.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            }
        }

        #endregion

        #region Initial values
        private bool State = false;
        private bool isProcessElevated = false;
        private const string name = "Property Window v1.2";
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;
        private MMDevice ActiveDevice;
        private WaveInEvent WaveEvent;
        private DebugLine DebugLine;
        private LowLevelKeyHook LLkeyHook;
        private int totalMemory = 4096;
        #endregion

        #region Form processing

        #region Form Initializating
        
        public OptionForm()
        {
            isProcessElevated = UacHelper.IsProcessElevated;
            InitializeComponent();
        }

        private void onLoadForm(object sender, EventArgs e)
        {
            if (isProcessElevated)
                btnRunAs.Enabled = false;
            else
            {
                if (Settings.Default.AlwaysRunAsAdmin)
                {
                    runAs(true);
                }
            }

            if (Program.Auto)
            {
                HideFromAltTab();
            }

            DebugLine = new DebugLine();
            DebugLine.Show();

            WaveEvent = new WaveInEvent();
            WaveEvent.DataAvailable += WaveOnDataAvailable;
            WaveEvent.WaveFormat = new WaveFormat(8000, 1);

            MEMORYSTATUSEX ex = new MEMORYSTATUSEX();
            if (GlobalMemoryStatusEx(ex))
                totalMemory = (int)(ex.ullTotalPhys / 1024 / 1024);

            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            Program.n_arg = 0;
            Program.Vol = 0;

            LLkeyHook = new LowLevelKeyHook();
            LLkeyHook.keyPressedEvent = onKeyPressed;
            loadProperties();
        }

        private void loadProperties()
        {
            List<string[]> startCapabs = new List<string[]>();
            startCapabs.Add(new string[] { "Microphone: ", "On" });
            startCapabs.Add(new string[] { "Volume: ", "0%" });
            startCapabs.Add(new string[] { "CPU Load: ", "0%" });
            startCapabs.Add(new string[] { "Mem: ", "4096/4096MB" });
            startCapabs.Add(new string[] { "FPS: ", "0" });

            foreach (var elem in startCapabs)
            {
                DebugLine.setStatusLine(elem[0], elem[1], Color.White);
                DebugLine.setVisible(elem[0], false);
            }

            tbMainKey.Text = ((char)Settings.Default.SKey).ToString().ToUpper();
            cbSecondaryKey.Text = ComboKeyOut(Settings.Default.FKey);
            cbSecondaryKey.DropDownStyle = ComboBoxStyle.DropDownList;

            cbRelativeCorner.SelectedIndex = Settings.Default.RelativeCorner;
            cbRelativeCorner.DropDownStyle = ComboBoxStyle.DropDownList;

            SetMute(Settings.Default.Mute);

            MicEnabled_checkbox.Checked = Settings.Default.MicShow;
            volume_checkbox.Checked = Settings.Default.VolumeShow;
            CPULoad_check.Checked = Settings.Default.CPUVisible;
            MemLoad_check.Checked = Settings.Default.MemVisible;
            cbBlockKey.Checked = Settings.Default.BlockKey;
            cbAlwaysAsAdmin.Checked = Settings.Default.AlwaysRunAsAdmin;
            cbAutorun.Checked = Autorun;
            lPosition.Text = "Position: " + Settings.Default.WindowPosition.X.ToString() + ", " + Settings.Default.WindowPosition.Y.ToString();

            // Process overlay functionality
            // btnRunHookProcess.Enabled = cbEnableOverlay.Checked = Settings.Default.OverlayEnabled;
            // loadProccessList(); 
        }
        #endregion

        #region GUI element handlers
        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.FKey = ComboKey(cbSecondaryKey.Text);
            Settings.Default.SKey = ((int)tbMainKey.Tag);
            Settings.Default.Save();
        }

        private void checkBoxChanged(object sender, EventArgs e)
        {
            CheckBox ch = (CheckBox)sender;
            if (ch == MicEnabled_checkbox)
            {
                DebugLine.setVisible("Microphone: ", ch.Checked);
                Settings.Default.MicShow = ch.Checked;
            }
            else if (ch == volume_checkbox)
            {
                DebugLine.setVisible("Volume: ", ch.Checked);
                Settings.Default.VolumeShow = ch.Checked;
                if (ch.Checked)
                {
                    WaveEvent.StartRecording();
                    TimerIndex.Start();
                }
                else
                {
                    TimerIndex.Stop();
                    WaveEvent.StopRecording();
                }
            }
            else if (ch == CPULoad_check)
            {
                DebugLine.setVisible("CPU Load: ", ch.Checked);
                Settings.Default.CPUVisible = ch.Checked;
            }
            else if (ch == MemLoad_check)
            {
                DebugLine.setVisible("Mem: ", ch.Checked);
                Settings.Default.MemVisible = ch.Checked;
            }
            else if (ch == cbBlockKey)
            {
                Settings.Default.BlockKey = ch.Checked;
            }
            else if (ch == cbAlwaysAsAdmin)
            {
                Settings.Default.AlwaysRunAsAdmin = ch.Checked;
            }
            else if (ch == cbEnableOverlay)
            {
                Settings.Default.OverlayEnabled = btnRunHookProcess.Enabled = ch.Checked;
            }
            else if (ch == cbDragBoxMode)
            {
                DebugLine.DragMode = ch.Checked;
                if (!ch.Checked)
                {
                    lPosition.Text = "Position: " + Settings.Default.WindowPosition.X.ToString() + ", " + Settings.Default.WindowPosition.Y.ToString();
                }
            }
            else if (ch == cbAutorun)
            {
                Autorun = cbAutorun.Checked;
            }
            Settings.Default.Save();
        }

        private void OpenListProcessButton_Click(object sender, EventArgs e)
        {
            ProcessList pList = new ProcessList();
            pList.ShowDialog();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            IconTaskBar.Visible = false;
            this.ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine(e.CloseReason.ToString());
            if (e.CloseReason == CloseReason.UserClosing)
            {
                HideFromAltTab();
                e.Cancel = true;
            }
            else
            {
                closeProgramm();
            }
        }

        private void IconTaskBar_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MenuTaskBar.Show();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IconTaskBar.Visible = false;
            closeProgramm();
        }

        private void ReloadDebug_Click(object sender, EventArgs e)
        {
            DebugLine.reloadDebug();
        }

        private void btnRunAs_Click(object sender, EventArgs e)
        {
            runAs(true);
        }


        private void btnRunHookProcess_Click(object sender, EventArgs e)
        {
            ProcessList processList = new ProcessList();
            processList.ShowDialog();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            tbMainKey.Text = e.KeyCode.ToString().ToUpper();
            tbMainKey.Tag = e.KeyValue;
            e.Handled = true;
        }

        private void cbRelativeCorner_SelectedIndexChanged(object sender, EventArgs e)
        {
            Point glPosition = DebugLine.ConvertTo(Settings.Default.WindowPosition, (CornerRelativity)Settings.Default.RelativeCorner);
            Settings.Default.RelativeCorner = (byte)cbRelativeCorner.SelectedIndex;
            Settings.Default.WindowPosition = DebugLine.ConvertTo(glPosition, (CornerRelativity)Settings.Default.RelativeCorner);
            Settings.Default.Save();
        }
        #endregion

        #endregion

        #region Key Hook Handler
        void onKeyPressed(Object sender, LowLevelKeyHook.HookKeyDownArgs e)
        {
            short b;
            int keyCheck;
            
            if (e.KeyValue == Settings.Default.FKey)
            {
                keyCheck = Settings.Default.SKey;
            }
            else if(e.KeyValue == Settings.Default.SKey)
            {
                keyCheck = Settings.Default.FKey;
            }
            else
            {
                return;
            }
            b = GetKeyState(keyCheck);
            if (keyCheck == 0 || b <= -127)
            {
                if (!e.prevPress)
                {
                    State = !State;
                    SetMute(State);
                }
                if (cbBlockKey.Checked)
                    e.Cancel = true;
            }
        }

        #endregion

        #region Microphone record
        private void getActiveDevice()
        {
            MMDeviceEnumerator mMDeviceEnumerator = new MMDeviceEnumerator();
            MMDeviceCollection mMDeviceCollection = mMDeviceEnumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            for (int i = 0; i < mMDeviceCollection.Count; i++)
            {
                MMDevice mMDevice = mMDeviceCollection[i];
                bool flag = mMDevice.DataFlow == DataFlow.Capture && mMDevice.State == DeviceState.Active;
                if (flag)
                {
                    ActiveDevice = mMDevice;
                }
            }
        }

        private void SetMute(bool set)
        {
            MMDeviceEnumerator mMDeviceEnumerator = new MMDeviceEnumerator();
            MMDeviceCollection mMDeviceCollection = mMDeviceEnumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            for (int i = 0; i < mMDeviceCollection.Count; i++)
            {
                MMDevice mMDevice = mMDeviceCollection[i];
                bool flag = mMDevice.DataFlow == DataFlow.Capture && mMDevice.State == DeviceState.Active;
                if (flag)
                {
                    DebugLine.setStatusLine("Microphone: ", set ? "Off" : "On", set ? Color.Red : Color.Green);
                    Settings.Default.Mute = mMDevice.AudioEndpointVolume.Mute = set;
                    Settings.Default.Save();
                }
            }
        }

        private bool GetMute()
        {
            return ActiveDevice.AudioEndpointVolume.Mute;
        }

        private static void WaveOnDataAvailable(object sender, WaveInEventArgs e)
        {
            for (int i = 0; i < e.BytesRecorded; i += 2) // Циклично получаю значение сигнала с микрофона и пишу его в переменную Globals.Vol
            {
                //Конвертирую в байты
                short sample = (short)((e.Buffer[i + 1] << 8) | e.Buffer[i + 0]);
                //Нормализирую
                float amplitude = sample / 32768f;
                float level = Math.Abs(amplitude); // Цифровое значение от 0 до 1
                Program.Vol += Math.Round(level * 100); // Пишу в переменную значение от 0 до 100
                Program.n_arg++;
            }
        }
        #endregion

        int ticks = 0;
        private void TimerIndexOnTick(object sender, EventArgs e)
        {
            if (volume_checkbox.Checked)
            {
                Program.n_arg = Program.n_arg != 0 ? Program.n_arg : 1;
                int con = Convert.ToInt32(Program.Vol / Program.n_arg);
                if (con < 0)
                    Math.Abs(con);
                DebugLine.setStatusLine("Volume: ", con + "%", getColorOfPercent(con,100));
                Program.Vol = 0;
                Program.n_arg = 0;
            }
            if (ticks % 5 == 0)
            {
                if (CPULoad_check.Checked)
                {
                    int con = Convert.ToInt32(cpuCounter.NextValue());
                    DebugLine.setStatusLine("CPU Load: ", con + "%", getColorOfPercent(con, 100));
                }
                if (MemLoad_check.Checked)
                {
                    int con = Convert.ToInt32(ramCounter.NextValue());
                    DebugLine.setStatusLine("Mem: ", (totalMemory - con) + "/" + totalMemory + "MB", Color.Black);
                }
            }
            else if (ticks % 20 == 0 && Program.procListChanged)
                saveProcessList();
            ticks++;
        }
        
        private void MuteChecker_Tick(object sender, EventArgs e)
        {
            MMDevice TempDevice = ActiveDevice;
            getActiveDevice();
            if (TempDevice != ActiveDevice)
            {
                SetMute(GetMute());
            }
        }

        private void runAs(bool admin)
        {
            var exeName = Process.GetCurrentProcess().MainModule.FileName;
            if (admin)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas";
                if (Program.Auto)
                    startInfo.Arguments += "-auto";
                try
                {
                    Process.Start(startInfo);
                }catch (System.ComponentModel.Win32Exception){
                    if (Settings.Default.AlwaysRunAsAdmin || cbAlwaysAsAdmin.Checked)
                    {
                        Settings.Default.AlwaysRunAsAdmin = false;
                        cbAlwaysAsAdmin.Checked = false;
                        Settings.Default.Save();
                    }
                    return;
                }
               
            }
            else
                Process.Start("explorer", exeName);
            closeProgramm();
        }

        private void closeProgramm()
        {
            if (WaveEvent != null)
                WaveEvent.StopRecording();
            TimerIndex.Stop();
            MuteChecker.Stop();
            if (DebugLine != null)
                DebugLine.Close();
            FormClosing -= Form1_FormClosing;
            this.Close();
        }

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TOOLWINDOW = 0x00000080;
        
        public void HideFromAltTab()
        {
            WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            IconTaskBar.Visible = true;
            SetWindowLong(Handle, GWL_EXSTYLE, GetWindowLong(Handle,
                GWL_EXSTYLE) | WS_EX_TOOLWINDOW);
        }

        /* ----- Other methods ----- */

        private bool Autorun
        {
            get
            {
                RegistryKey reg;
                reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
                return reg.GetValue(name) != null;
            }
            set
            {
                RegistryKey reg;
                reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
                if (value)
                {
                    reg.SetValue(name, "\"" + Application.ExecutablePath + "\" -auto");
                }
                else
                {
                    reg.DeleteValue(name);
                }
            }
        }

        private void saveProcessList()
        {
            string saveValue = "";
            foreach (var arg in Program.procList)
                saveValue = arg.Key + "," + arg.Value + ";";
            Settings.Default.OverlayHookedProcess = saveValue;
            Settings.Default.Save();
        }

        private void loadProccessList()
        {
            Program.procList = new Dictionary<string, string>();
            String[] pairs = Settings.Default.OverlayHookedProcess.Split(';');
            foreach (String pair in pairs)
            {
                String[] p = pair.Split(',');
                if (p.Length != 2)
                {
                    Console.Error.WriteLine("Process list parsing false: " + pair);
                    continue;
                }
                Program.procList.Add(p[0], p[1]);
            }
        }

        private Color getColorOfPercent(int value,int MaxValue)
        {
            return Color.FromArgb(Convert.ToInt32(value * (255 / MaxValue)), 255 - Convert.ToInt32(value * (255 / MaxValue)), 0);
        }

        private int ComboKey(string text)
        {
            switch (text)
            {
                case "LShift": return 160;
                case "LCtrl": return 162;
                case "LAlt": return 164;
                case "Caps Lock": return 0x14;
                case "Tab": return 0x09;
                default:
                    return 0;
            }
        }

        private string ComboKeyOut(int i)
        {
            switch (i)
            {
                case 160: return "LShift";
                case 162: return "LCtrl";
                case 164: return "LAlt";
                case 0x14: return "Caps Lock";
                case 0x09: return "Tab";
                default:
                    return "No key";
            }
        }
    }
}
