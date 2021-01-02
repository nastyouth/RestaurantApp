using System;
using System.Windows.Forms;
using Final_project.Forms;

namespace Final_project
{
    internal static class Program
    {
        public static Database Db;
        
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}
