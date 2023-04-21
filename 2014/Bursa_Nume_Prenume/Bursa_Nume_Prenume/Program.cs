using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bursa_Nume_Prenume
{
    static class Globals
    {
        // momentan ,val_crestere, total_valoare_momentana, profit_momentan, profit tital
        public static List<(int, int, int, int, int)[]> bursa = new List<(int, int, int, int, int)[]>();
        public static List<int[,]> matrice = new List<int[,]>();
        //static int a=bursa[0][0].Item1;
        public static List<int> suma=new List<int>();
    }
    internal static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
