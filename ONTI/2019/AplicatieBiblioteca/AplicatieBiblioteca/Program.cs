using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AplicatieBiblioteca
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static class Globals
        {
            public static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Biblioteca.mdf;Integrated Security=True;Connect Timeout=30");

            static Globals()
            {
                con.Open();
            }
            public static string criptare(string a)
            {
                char[] rez = new char[a.Length];

                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] >= 'a' && a[i] <= 'z')
                    {
                        if (a[i] == 'z') rez[i] = 'a';
                        else rez[i] = (char)(a[i] + 1);
                    }
                    else if (a[i] >= 'A' && a[i] <= 'Z')
                    {
                        if (a[i] == 'A') rez[i] = 'Z';
                        else rez[i] = (char)(a[i] - 1);
                    }
                    else if (a[i] >= '0' && a[i] <= '9')
                    {
                        rez[i] = (char)('0' + '9' - a[i]);
                    }
                    else rez[i] = a[i];
                }
                return new string(rez);
            }
            public static string decriptare(string a)
            {
                char[] rez = new char[a.Length];

                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] >= 'a' && a[i] <= 'z')
                    {
                        if (a[i] == 'a') rez[i] = 'z';
                        else rez[i] = (char)(a[i] - 1);
                    }
                    else if (a[i] >= 'A' && a[i] <= 'Z')
                    {
                        if (a[i] == 'Z') rez[i] = 'A';
                        else rez[i] = (char)(a[i] + 1);
                    }
                    else if (a[i] >= '0' && a[i] <= '9')
                    {
                        rez[i] = (char)('0' + '9' - a[i]);
                    }
                    else rez[i] = a[i];
                }
                return new string(rez);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
