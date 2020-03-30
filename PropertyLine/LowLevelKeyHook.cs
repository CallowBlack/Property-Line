using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Properties
{
    public class LowLevelKeyHook
    {
        public delegate IntPtr HOOKPROC(int nCode, IntPtr wParam, IntPtr lParam);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;
        private const int HC_ACTION = 0;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HOOKPROC lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        static extern short GetKeyState(int nVirtKey);

        IntPtr _hook = IntPtr.Zero;
        public EventHandler<HookKeyDownArgs> keyPressedEvent;
        private HOOKPROC hookProcDelegate;
        public List<int> pressedKey;
        public LowLevelKeyHook()
        {
            pressedKey = new List<int>();
            hookProcDelegate = KeyboardHookCallback;
            setGlobalHook(true);
        }

        ~LowLevelKeyHook()
        {
            setGlobalHook(false);
        }

        void setGlobalHook(bool enable)
        {
            if (enable)
                using(var curProc = Process.GetCurrentProcess())
                    using(var curModule = curProc.MainModule)
                        _hook = SetWindowsHookEx(WH_KEYBOARD_LL, hookProcDelegate, GetModuleHandle(curModule.ModuleName), 0);
            else
                UnhookWindowsHookEx(_hook);
        }
 
        public IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode == HC_ACTION)
            {
                if (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    bool isPressed = pressedKey.IndexOf(vkCode) != -1;
                    HookKeyDownArgs args = new HookKeyDownArgs((Keys)vkCode, isPressed);
                    if(!isPressed)
                        pressedKey.Add(vkCode);
                    if (keyPressedEvent != null)
                    {
                        keyPressedEvent(this, args);
                        if (args.Cancel)
                        {
                            return (IntPtr)1;
                        }
                    }
                }
                else if (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYDOWN) {
                    int vkCode = Marshal.ReadInt32(lParam);
                    pressedKey.Remove(vkCode);
                }
            }
            return CallNextHookEx(_hook, nCode, wParam, lParam);
        }

        public class HookKeyDownArgs
        {
            public Keys KeyCode { get; private set; }
            public bool prevPress;
            public int KeyValue { get; private set; }
            public bool Cancel;
            public HookKeyDownArgs(Keys key, bool prevPress)
            {
                this.KeyCode = key;
                this.prevPress = prevPress;
                KeyValue = (int)KeyCode;
                Cancel = false;
            }
        }

    }
}
