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

namespace eLearningMareaUnire1918
{
    public partial class eLearning1918_start : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\eLearning1918.mdf;Integrated Security=True;Password=***********;Connect Timeout=30");
        public eLearning1918_start()
        {
            InitializeComponent();
            pictureBox1.BackgroundImage = Image.FromFile(@"imaginislideshow\1.jpg");
            progressBar1.Maximum = 5;
            Auto();
            con.Open();

            SqlCommand sterge = new SqlCommand(@"TRUNCATE TABLE ""Tabela Evaluari"";TRUNCATE TABLE ""Tabela Itemi"";TRUNCATE TABLE ""Tabela Utilizatori"";", con);
            sterge.ExecuteNonQuery();

            StreamReader citire = new StreamReader("date.txt");
            string line;
            int curent = 0;
            while ((line = citire.ReadLine()) != null)
            {
                if (line.Contains(';'))
                {
                    if (curent == 1)
                    {
                        SqlCommand inserare = new SqlCommand(@"INSERT INTO ""Tabela Utilizatori"" VALUES(@1,@2,@3,@4)", con);
                        inserare.Parameters.AddWithValue("1", line.Split(';')[0]);
                        inserare.Parameters.AddWithValue("2", line.Split(';')[1]);
                        inserare.Parameters.AddWithValue("3", line.Split(';')[2]);
                        inserare.Parameters.AddWithValue("4", line.Split(';')[3]);
                        inserare.ExecuteNonQuery();
                    }
                    if (curent == 2)
                    {
                        SqlCommand inserare = new SqlCommand(@"INSERT INTO ""Tabela Itemi"" VALUES(@1,@2,@3,@4,@5,@6,@7)", con);
                        inserare.Parameters.AddWithValue("1", Convert.ToInt32(line.Split(';')[0]));
                        inserare.Parameters.AddWithValue("2", line.Split(';')[1]);
                        inserare.Parameters.AddWithValue("3", line.Split(';')[2]);
                        inserare.Parameters.AddWithValue("4", line.Split(';')[3]);
                        inserare.Parameters.AddWithValue("5", line.Split(';')[4]);
                        inserare.Parameters.AddWithValue("6", line.Split(';')[5]);
                        inserare.Parameters.AddWithValue("7", line.Split(';')[6]);
                        inserare.ExecuteNonQuery();
                    }
                    if (curent == 3)
                    {
                        SqlCommand inserare = new SqlCommand(@"INSERT INTO ""Tabela Evaluari""(IdElev,DataEvaluare,NotaEvaluare) VALUES(@1,@2,@3)", con);
                        inserare.Parameters.AddWithValue("1", line.Split(';')[0]);
                        inserare.Parameters.AddWithValue("2", DateTime.ParseExact(line.Split(';')[1], "M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture));
                        inserare.Parameters.AddWithValue("3", line.Split(';')[2]);
                        inserare.ExecuteNonQuery();
                    }
                }
                if (line.Contains(':'))
                {
                    if (line == "Utilizatori:")
                    { curent = 1; }
                    if (line == "Itemi:")
                    { curent = 2; }
                    if (line == "Evaluari:")
                    { curent = 3; }
                }
            }
            con.Close();
        }
        private Timer timer = new Timer();
        private int i = 1;
        private void Manual()
        {
            timer.Stop();
        }
        private void Auto()
        {
            
            timer.Interval = 2000;
            
            timer.Tick += (a, b) =>
            {
                i++;
                if (i > 5) i = 1;
                pictureBox1.BackgroundImage = Image.FromFile(@"imaginislideshow\"+Convert.ToString(i)+".jpg");
                
            };
            timer.Start();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Auto();
            button4.Visible = false;
            button4.Enabled = false;
            button1.Visible = true;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manual();
            button1.Visible = false;
            button1.Enabled = false;
            button4.Visible = true;
            button4.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i++;
            if (i > 5) i = 1;
            pictureBox1.BackgroundImage = Image.FromFile(@"imaginislideshow\" + Convert.ToString(i) + ".jpg");
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i--;
            if (i < 1) i = 5;
            pictureBox1.BackgroundImage = Image.FromFile(@"imaginislideshow\" + Convert.ToString(i) + ".jpg");

        }

        private void pictureBox1_BackgroundImageChanged(object sender, EventArgs e)
        {
            progressBar1.Value = i;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand verif = new SqlCommand(@"SELECT IdUtilizator FROM ""Tabela Utilizatori"" WHERE EmailUtilizator=@1 AND ParolaUtilizator=@2", con);
            verif.Parameters.AddWithValue("1", textBox1.Text);
            verif.Parameters.AddWithValue("2", textBox2.Text);
            if (verif.ExecuteScalar() != null)
            {
                int id = (int)verif.ExecuteScalar();
                Form2 frm2=new Form2(id);
                this.Hide();
                frm2.ShowDialog();
                this.Close();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("Eroare de autentificare!");
            }
            con.Close();
        }
    }
}
