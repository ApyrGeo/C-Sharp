using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeeBook
{
    public partial class Form1 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\Freebook.mdf; Integrated Security = True; Connect Timeout = 30");

        public Form1()
        {
            
            con.Open();
            SqlCommand stergere = new SqlCommand("TRUNCATE TABLE carti; TRUNCATE TABLE imprumut; TRUNCATE TABLE Utilizatori", con);
            stergere.ExecuteNonQuery();
            con.Close();
            StreamReader citire = new StreamReader(@"Resurse\carti.txt");
            string line;
            while ((line = citire.ReadLine()) != null)
            {
                con.Open();
                SqlCommand carti = new SqlCommand("INSERT INTO carti(titlu,autor,gen) VALUES(@1,@2,@3)", con);
                carti.Parameters.AddWithValue("1", line.Split('*')[0]);
                carti.Parameters.AddWithValue("2", line.Split('*')[1]);
                carti.Parameters.AddWithValue("3", line.Split('*')[2]);
                carti.ExecuteNonQuery();
                con.Close();
            }
            citire.Dispose();
            citire = new StreamReader(@"Resurse\imprumuturi.txt");
            while ((line = citire.ReadLine()) != null)
            {
                con.Open();
                SqlCommand imprumuturi = new SqlCommand("INSERT INTO imprumut(id_carte,email,data_imprumut) VALUES(@1,@2,@3)", con);

                SqlCommand id_carte = new SqlCommand("SELECT id_carte FROM carti WHERE titlu=@1", con);
                id_carte.Parameters.AddWithValue("1", line.Split('*')[0]);
                int id = (int)id_carte.ExecuteScalar();

                imprumuturi.Parameters.AddWithValue("1", id);
                imprumuturi.Parameters.AddWithValue("2", line.Split('*')[1]);

                imprumuturi.Parameters.AddWithValue("3", DateTime.ParseExact(line.Split('*')[2].Trim(), "M/d/yyyy", CultureInfo.InvariantCulture));

                imprumuturi.ExecuteNonQuery();
                con.Close();
            }
            citire.Dispose();
            citire = new StreamReader(@"Resurse\utilizatori.txt");
            while ((line = citire.ReadLine()) != null)
            {
                con.Open();
                SqlCommand utilizatori = new SqlCommand("INSERT INTO utilizatori VALUES(@1,@2,@3,@4)", con);
                utilizatori.Parameters.AddWithValue("1", line.Split('*')[0]);
                utilizatori.Parameters.AddWithValue("2", line.Split('*')[1]);
                utilizatori.Parameters.AddWithValue("3", line.Split('*')[2]);
                utilizatori.Parameters.AddWithValue("4", line.Split('*')[3]);
                utilizatori.ExecuteNonQuery();
                con.Close();
            }

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            this.Hide();
            frm2.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            this.Hide();
            frm3.ShowDialog();
            this.Close();
        }
    }
}
