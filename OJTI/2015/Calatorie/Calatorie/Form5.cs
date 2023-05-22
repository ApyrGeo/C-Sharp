using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calatorie
{
    public partial class Form5 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBTimpSpatiu.mdf;Integrated Security=True;Connect Timeout=30");

        public Form5()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;


        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.MdiParent.Hide();
            this.MdiParent.Close();
            Form frm1 = new Form1();
            frm1.ShowDialog();
            this.Close();
            
        }
        private string[] porturi = new string[] { "Constanta", "Varna", "Burgas", "Istanbul", "Kozlu", "Samsun", "Batumi", "Sokhumi", "Sochi", "Anapa", "Ialta", "Sevastopol", "Odessa" };

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            int tip = 3;
            dataGridView1.Rows.Clear();
            if (i == 0)
            {
                tip = 3;
            }
            if (i == 1)
            {
                tip = 5;
            }
            if (i == 2)
            {
                tip = 8;
            }

            con.Open();
                SqlCommand select = new SqlCommand($"SELECT * FROM Croaziere WHERE Tip_Croaziera={tip}",con);
                SqlDataReader read = select.ExecuteReader();
                while(read.Read())
                {
                    string[] traseu = read.GetString(2).Split(' ');
                    string final="";
                    for (int j = 0; j < traseu.Length; j++)
                    {
                       final += porturi[Convert.ToInt32(traseu[j])-1] + ", ";
                    }
                    dataGridView1.Rows.Add(
                        read.GetInt32(1),
                        final,
                        read.IsDBNull(3) ? null : read.GetDateTime(3).ToString(),
                        read.IsDBNull(4) ? null : read.GetDateTime(4).ToString(),
                        read.GetInt32(5),
                        read.IsDBNull(6) ? null : read.GetInt32(4).ToString());
                    
                    
                }
                con.Close();
            
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Close();
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Close();
        }
    }
}
