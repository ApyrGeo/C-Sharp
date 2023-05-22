using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfate_ECO
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static class Globals
        {
            public static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\geose\OneDrive\Desktop\Olimpiada C#\ONTI\2022\Interfate ECO\Interfate ECO\bin\Debug\Useri.mdf"";Integrated Security=True;Connect Timeout=30");
            
        }

        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Globals.con.Open();
            Application.Run(new Form1());
        }
    }
}
