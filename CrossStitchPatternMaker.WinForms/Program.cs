using System;
using System.Windows.Forms;

namespace CrossStitchPatternMaker.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var lMainForm = (args.Length == 0) ? new MainForm() : new MainForm(args[0]);
            Application.Run(lMainForm);
        }
    }
}
