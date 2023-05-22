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
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace Bursa_Nume_Prenume
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBBursa.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
            con.Open();

            new SqlCommand("TRUNCATE TABLE Actiuni;INSERT INTO Actiuni VALUES ('Azomed',5,25);\r\nINSERT INTO Actiuni VALUES ('Tepra',15,12);\r\nINSERT INTO Actiuni VALUES ('Raddin',0,4);\r\nINSERT INTO Actiuni VALUES ('Nelacom',200,8);\r\nINSERT INTO Actiuni VALUES ('Daleprod',0,7);", con).ExecuteNonQuery();
            con.Close();


           
            con.Open();
            SqlCommand select = new SqlCommand("SELECT * FROM Actiuni", con);
            SqlDataReader read = select.ExecuteReader();
            while (read.Read())
            {
                dataGridView1.Rows.Add(
                    read.GetString(1),
                    read.GetInt32(2).ToString(),
                    read.GetInt32(3).ToString(),
                    read.GetInt32(3).ToString(),
                    "",
                    (read.GetInt32(2) * read.GetInt32(3)).ToString(),
                    "",
                    "",
                    ""
                    );
            }

            con.Close();
            if (on==true)
            {
                
            }
        }
        private void actiunileMeleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form2 frm2 = new Form2(timer1.Interval,on);
            frm2.Show();
        }
        private bool on = false;
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = false;
            on = true;
            

            timer1.Start();
            int y = 0;
            timer1.Tick += (a, b) =>
            {
                y++;
                int s = 0;
                Globals.bursa.Add(new(int, int, int, int, int)[5]);
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    Random x = new Random();
                    int xx = x.Next(-5, 6);


                    

                    dataGridView1[4, i].Value = xx.ToString();
                    dataGridView1[3, i].Value = (Convert.ToInt32(dataGridView1[3, i].Value) + xx).ToString();
                    dataGridView1[6, i].Value = (Convert.ToInt32(dataGridView1[1, i].Value) * Convert.ToInt32(dataGridView1[3, i].Value)).ToString();
                    dataGridView1[7, i].Value = (Convert.ToInt32(dataGridView1[1, i].Value) * Convert.ToInt32(dataGridView1[4, i].Value)).ToString();
                    dataGridView1[8, i].Value = (Convert.ToInt32(dataGridView1[6, i].Value) - Convert.ToInt32(dataGridView1[5, i].Value)).ToString();
                    s += Convert.ToInt32(dataGridView1[8, i].Value);
                    Globals.bursa.Last()[i] = (
                    Convert.ToInt32(dataGridView1[3, i].Value) + xx,
                    xx,
                    Convert.ToInt32(dataGridView1[1, i].Value) * Convert.ToInt32(dataGridView1[3, i].Value),
                    Convert.ToInt32(dataGridView1[1, i].Value) * Convert.ToInt32(dataGridView1[4, i].Value),
                    Convert.ToInt32(dataGridView1[6, i].Value) - Convert.ToInt32(dataGridView1[5, i].Value)
                    );
                }
                Globals.suma.Add(s);
                textBox1.Text = s.ToString();

                dataGridView1.Refresh();

            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            while (Application.OpenForms["Form3"] != null)
            {
                Application.OpenForms["Form3"].Close();
            }
            while (Application.OpenForms["Form2"] != null)
            {
                Application.OpenForms["Form2"].Close();
            }
            on = false;
            timer1.Stop();
            StreamWriter write = new StreamWriter(@"rezultate.txt");
            write.Write(Globals.suma.Last());
            write.Close();
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDown1.Value;
        }

        private void graficProfitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(timer1.Interval, on);
            frm3.Show();
        }
    }
}
