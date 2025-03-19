using System;
using System.Windows.Forms;
using CleanCode_ExampleMVP.Presenters;

namespace CleanCode_ExampleMVP
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView(new PresenterFactory()));
        }
    }
}
