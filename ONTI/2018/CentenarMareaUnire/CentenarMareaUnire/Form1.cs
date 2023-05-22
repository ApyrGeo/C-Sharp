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

namespace CentenarMareaUnire
{
    public partial class Form1 : Form
    {
        int user;
        public Form1(int i)
        {
            InitializeComponent();
            user = i;
            new SqlCommand("TRUNCATE TABLE Lectii;TRUNCATE TABLE Utilizatori", Program.Globals.con).ExecuteNonQuery();

            StreamReader read = new StreamReader("utilizatori.txt");
            string line;
            while ((line = read.ReadLine()) != null)
            {
                SqlCommand insert = new SqlCommand("INSERT INTO Utilizatori VALUES(@1,@2,@3)", Program.Globals.con);
                insert.Parameters.AddWithValue("1", line.Split('*')[0]);
                insert.Parameters.AddWithValue("2", line.Split('*')[1]);
                insert.Parameters.AddWithValue("3", line.Split('*')[2]);
                insert.ExecuteNonQuery();
            }
            read.Dispose();

            read = new StreamReader("lectii.txt");
            while ((line = read.ReadLine()) != null)
            {
                string[] val = line.Split('*');

                SqlCommand insert = new SqlCommand("INSERT INTO Lectii VALUES(@1,@2,@3,@4,@5)", Program.Globals.con);
                insert.Parameters.AddWithValue("1", Convert.ToInt32(val[0]));
                
                if (val.Length == 5)
                {
                    insert.Parameters.AddWithValue("2", val[1]);
                    insert.Parameters.AddWithValue("3", val[2]);
                    
                    insert.Parameters.AddWithValue("4", DateTime.ParseExact(val[4], "M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
                    insert.Parameters.AddWithValue("5", val[3]);
                }
                else if(val.Length == 4) 
                {
                    insert.Parameters.AddWithValue("2", DBNull.Value);
                    insert.Parameters.AddWithValue("3", val[1]);
                    insert.Parameters.AddWithValue("4", DateTime.ParseExact(val[3],"M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
                    insert.Parameters.AddWithValue("5", val[2]);
                }
                insert.ExecuteNonQuery();
            }

            if(i!=-1)
            {
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form3().ShowDialog();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form5(user).ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form6(user).ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form8(user).ShowDialog();
            this.Close();
        }
    }
}
