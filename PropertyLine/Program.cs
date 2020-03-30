using Properties.Properties;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Properties
{
    public enum CornerRelativity { TopLeft, TopRight, BottomLeft, BottomRight };
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 

        #region Shared variables
        public static bool Auto { get; set; }
        public static double Vol { get; set; }
        public static int n_arg { get; set; }
        public static bool procListChanged { get; set; }
        public static Dictionary<string,string> procList { get; set; }
        #endregion

        

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                var d = Settings.Default.MemVisible;
            }
            catch (ConfigurationErrorsException ex)
            {
                string filename = ((ConfigurationErrorsException)ex.InnerException).Filename;
                MessageBox.Show(filename);
                File.Delete(filename);
                Settings.Default.Reload();
            }
            if (args.Length > 0 && args[0] == "-auto")
                Auto = true;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OptionForm());

        }
        
    }
}
