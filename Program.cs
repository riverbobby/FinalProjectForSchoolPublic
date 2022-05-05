using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace JustinTownleyCapstone
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //starting mySQL connection
            Globals.conn = new MySqlConnection(Globals.connStg);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
