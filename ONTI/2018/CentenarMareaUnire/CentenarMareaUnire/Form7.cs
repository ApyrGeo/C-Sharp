using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CentenarMareaUnire
{
    public partial class Form7 : Form
    {
        public Form7(int id, int rez)
        {
            InitializeComponent();

            string nume = (string)(new SqlCommand($"SELECT Nume FROM Utilizatori WHERE IdUtilizator={id}", Program.Globals.con).ExecuteScalar());
            string premiu="";
            if (rez == 10)
                premiu = " premiul I";
            if (rez == 9)
                premiu = " premiul II";
            if (rez == 8)
                premiu = " premiul III";
            if (rez <= 7 && rez >= 5)
                premiu = " mentiune";
            else
                premiu = " diploma de participare";
            label2.Text = "Se acorda elevului " + nume + premiu;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
