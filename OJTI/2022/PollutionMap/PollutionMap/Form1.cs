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
using System.IO;

namespace PollutionMap
{
    public partial class Form1 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\Poluare.mdf"";Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
            con.Open();

            SqlCommand stergere= new SqlCommand("DELETE FROM Harti; DELETE FROM Masurare", con);
            stergere.ExecuteNonQuery();

            StreamReader citire = new StreamReader("harti.txt");
            string line;
            while ((line= citire.ReadLine()) != null) 
            {
                SqlCommand inserare = new SqlCommand("INSERT INTO Harti(NumeHarta,FisierHarta) VALUES(@nume,@adresa)", con);
                inserare.Parameters.AddWithValue("nume", line.Split('#')[0]);
                
                if(File.Exists(@"Harti\"+line.Split('#')[1]))
                    inserare.Parameters.AddWithValue("adresa", @"Harti\" + line.Split('#')[1]);
                else 
                    inserare.Parameters.AddWithValue("adresa", @"Harti\default_harta.png");
                inserare.ExecuteNonQuery();
            }
            citire.Dispose();
            citire = new StreamReader("masurari.txt");
            while((line=citire.ReadLine())!= null) 
            {
                SqlCommand inserare = new SqlCommand("INSERT INTO Masurare(Idharta, PozitieX, PozitieY, ValoareMasurare, DataMasurare) VALUES(@1,@2,@3,@4,@5)", con);
                SqlCommand id_nu = new SqlCommand("SELECT IdHarta FROM Harti WHERE NumeHarta=(@9)", con);
                id_nu.Parameters.AddWithValue("9", line.Split('#')[0]);
                int id = (int)(id_nu.ExecuteScalar());
                inserare.Parameters.AddWithValue("1", id);
                inserare.Parameters.AddWithValue("2", line.Split('#')[1]);
                inserare.Parameters.AddWithValue("3", line.Split('#')[2]);
                inserare.Parameters.AddWithValue("4", line.Split('#')[3]);
                inserare.Parameters.AddWithValue("5", DateTime.Parse(line.Split('#')[4]));
                inserare.ExecuteNonQuery();
            }

            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand verificare = new SqlCommand("SELECT IdUtilizator FROM Utilizatori WHERE NumeUtilizator=(@1) AND Parola=(@2)", con);
            verificare.Parameters.AddWithValue("1", textBox1.Text);
            verificare.Parameters.AddWithValue("2", textBox2.Text);
            if(verificare.ExecuteScalar()!=null)
            {
                //Logat cu succes
                

                SqlCommand current = new SqlCommand("UPDATE Utilizatori SET UltimaUtilizare=@1 WHERE NumeUtilizator=@2 AND Parola=@3", con);
                current.Parameters.AddWithValue("1", DateTime.Now);
                current.Parameters.AddWithValue("2", textBox1.Text);
                current.Parameters.AddWithValue("3", textBox2.Text);
                current.ExecuteNonQuery();
                con.Close();

                Form3 frm3=new Form3();
                this.Hide();
                frm3.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nume de utilizator si/sau parola invalida!");
                textBox1.Text = "";
                textBox2.Text = "";
                con.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
