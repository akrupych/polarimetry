using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PolarimetryProject
{
    static class Program
    {
        public static Package Package { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
