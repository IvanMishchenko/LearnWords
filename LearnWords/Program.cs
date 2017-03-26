using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using LearnWords.Forms;

namespace LearnWords
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string name = Assembly.GetExecutingAssembly().GetName().Name;
            Process[] localByName = Process.GetProcesses();

            int counter = localByName.Count(a => a.ProcessName == name);

            if (counter > 1) { Process.GetCurrentProcess().Kill(); }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormWordsManagement());
        }
    }
}
