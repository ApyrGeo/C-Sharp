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

namespace TurismulDurabil
{
    public partial class Form1 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Turism.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
            init();
        }
        private void init()
        {
            con.Open();
            SqlCommand sterg=new SqlCommand("TRUNCATE TABLE Imagini; TRUNCATE TABLE Localitati; TRUNCATE TABLE Planificari",con);
            sterg.ExecuteNonQuery();
            StreamReader read = new StreamReader("planificari.txt");
            string line;
            int id_loc = 0;
            while((line=read.ReadLine()) != null) 
            {
                id_loc++;
                
                SqlCommand localitati = new SqlCommand("INSERT INTO Localitati VALUES(@1)", con);

                string localitate=line.Split('*')[0].Trim();
                localitati.Parameters.AddWithValue("1", localitate);
                localitati.ExecuteNonQuery();
                int index = 0;
                if (line.Split('*')[1].Trim() == "ocazional")
                {
                    SqlCommand plan = new SqlCommand("INSERT INTO Planificari(IdLocalitate, Frecventa, DataStart, DataStop) VALUES(@1,@2,@3,@4)" , con);
                    plan.Parameters.AddWithValue("1", id_loc);
                    plan.Parameters.AddWithValue("2", line.Split('*')[1].Trim());
                    plan.Parameters.AddWithValue("3", DateTime.ParseExact(line.Split('*')[2].Trim(), "d.M.yyyy", CultureInfo.InvariantCulture));
                    plan.Parameters.AddWithValue("4", DateTime.ParseExact(line.Split('*')[3].Trim(), "d.M.yyyy", CultureInfo.InvariantCulture));
                    plan.ExecuteNonQuery();
                    index = 4;
                }
                else 
                {
                    int zi = 0;
                    if (line.Split('*')[1].Trim() == "anual")
                    {
                        

                        zi = Convert.ToInt32(line.Split('*')[2].Trim());
                    }
                    if (line.Split('*')[1].Trim() == "lunar")
                    {
                        zi = Convert.ToInt32(line.Split('*')[2].Trim());
                    }
                    SqlCommand plan = new SqlCommand("INSERT INTO Planificari(IdLocalitate, Frecventa, Ziua) VALUES(@1,@2,@3)",con);
                    plan.Parameters.AddWithValue("1", id_loc);
                    plan.Parameters.AddWithValue("2", line.Split('*')[1].Trim());
                    
                    plan.Parameters.AddWithValue("3", zi);
                    plan.ExecuteNonQuery();
                    index = 3;
                }
                SqlCommand imagini = new SqlCommand("INSERT INTO Imagini VALUES(@1,@2)", con);
                imagini.Parameters.AddWithValue("1", id_loc);
                imagini.Parameters.AddWithValue("2", "");
                string[] a = line.Split('*');
                int L = a.Length;
                while (index<L)
                {
                   
                    imagini.Parameters["2"].Value = "";
                    imagini.Parameters["2"].Value=folderBrowserDialog1.SelectedPath+@"\"+line.Split('*')[index].Trim();
                    imagini.ExecuteNonQuery();
                    index++;
                } 
            }
            con.Close();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            init();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2=new Form2(folderBrowserDialog1.SelectedPath);
            this.Hide();
            frm2.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            this.Hide();
            frm3.ShowDialog();
            this.Close();
        }
    }
}
