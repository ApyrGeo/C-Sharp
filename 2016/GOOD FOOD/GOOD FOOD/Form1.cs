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

namespace GOOD_FOOD
{
    public partial class Form1 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\GOOD_FOOD.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();

            con.Open();
            SqlCommand init = new SqlCommand("TRUNCATE TABLE Meniu", con);
            init.ExecuteNonQuery();

            
            StreamReader read = new StreamReader(@"Resurse_C#\meniu.txt");
            string line;
            int k = 1;
            line= read.ReadLine();
            while (line != null )
            {
                if(k>1)
                {
                    SqlCommand insert = new SqlCommand("INSERT INTO Meniu VALUES(@1,@2,@3,@4,@5,@6)", con);
                    insert.Parameters.AddWithValue("1", Convert.ToInt32(line.Split(';')[0]));
                    insert.Parameters.AddWithValue("2", line.Split(';')[1].ToString());
                    insert.Parameters.AddWithValue("3", line.Split(';')[2]);
                    insert.Parameters.AddWithValue("4", Convert.ToInt32(line.Split(';')[3]));
                    insert.Parameters.AddWithValue("5", Convert.ToInt32(line.Split(';')[4]));
                    insert.Parameters.AddWithValue("6", Convert.ToInt32(line.Split(';')[5]));
                    insert.ExecuteNonQuery();
                }
                k++;
                line = read.ReadLine();
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            this.Hide();
            frm2.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            this.Hide();
            frm3.ShowDialog();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
