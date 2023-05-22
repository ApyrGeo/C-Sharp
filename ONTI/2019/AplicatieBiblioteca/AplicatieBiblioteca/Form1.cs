using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics.Eventing.Reader;

namespace AplicatieBiblioteca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            new SqlCommand("TRUNCATE TABLE Carti; TRUNCATE TABLE Utilizatori; TRUNCATE TABLE Imprumuturi; TRUNCATE TABLE Rezervari", Program.Globals.con).ExecuteNonQuery();

            StreamReader read = new StreamReader("carti.txt");
            string line;


            while ((line = read.ReadLine()) != null)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Carti VALUES(@1,@2,@3)", Program.Globals.con);
                cmd.Parameters.AddWithValue("1", line.Split(';')[0]);
                cmd.Parameters.AddWithValue("2", line.Split(';')[1]);
                cmd.Parameters.AddWithValue("3", Convert.ToInt32(line.Split(';')[2]));
                cmd.ExecuteNonQuery();
            }

            read.Dispose();
            read = new StreamReader("imprumuturi.txt");
            while ((line = read.ReadLine()) != null)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Imprumuturi VALUES(@1,@2,@3,@4)", Program.Globals.con);
                cmd.Parameters.AddWithValue("1", Convert.ToInt32(line.Split(';')[0]));
                cmd.Parameters.AddWithValue("2", Convert.ToInt32(line.Split(';')[1]));
                cmd.Parameters.AddWithValue("3", DateTime.ParseExact(line.Split(';')[2], "MM/dd/yyyy hh/mm/ss tt", CultureInfo.InvariantCulture));
                if (line.Split(';')[3] == "NULL")
                    cmd.Parameters.AddWithValue("4", DBNull.Value); 
                else
                    cmd.Parameters.AddWithValue("4", DateTime.ParseExact(line.Split(';')[3],"MM/dd/yyyy hh/mm/ss tt", CultureInfo.InvariantCulture));
                
                cmd.ExecuteNonQuery();
            }

            read.Dispose();
            read = new StreamReader("rezervari.txt");
            while ((line = read.ReadLine()) != null)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Rezervari VALUES(@1,@2,@3,@4)", Program.Globals.con);
                cmd.Parameters.AddWithValue("1", Convert.ToInt32(line.Split(';')[0]));
                cmd.Parameters.AddWithValue("2", Convert.ToInt32(line.Split(';')[1]));
                cmd.Parameters.AddWithValue("3", DateTime.ParseExact(line.Split(';')[2], "MM/dd/yyyy hh/mm/ss tt", CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("4", Convert.ToInt32(line.Split(';')[3]));
                cmd.ExecuteNonQuery();
            }


            read.Dispose();
            read = new StreamReader("utilizatori.txt");
            while ((line = read.ReadLine()) != null)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Utilizatori VALUES(@1,@2,@3,@4)", Program.Globals.con);
                cmd.Parameters.AddWithValue("1", Convert.ToInt32(line.Split(';')[0]));
                cmd.Parameters.AddWithValue("2", line.Split(';')[1]);
                cmd.Parameters.AddWithValue("3", line.Split(';')[2]);

                if (line.Split(';')[3] == "")
                    cmd.Parameters.AddWithValue("4", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("4", Program.Globals.criptare(line.Split(';')[3]));
                cmd.ExecuteNonQuery();
            }

            read.Dispose();
            read = new StreamReader("descriere.txt");
            textBox1.Text = read.ReadToEnd();

        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().ShowDialog();
            this.Close();
        }
    }
}
