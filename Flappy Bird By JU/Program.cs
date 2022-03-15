using System;
using System.Windows.Forms;

namespace Flappy_Bird_By_JU
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Selection());
        }

        internal static void Error(object sender, EventArgs e, Exception ex)
        {
            return;
        }
    }
}
