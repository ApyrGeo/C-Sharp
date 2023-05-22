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

namespace CentenarMareaUnire
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1(-1).ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand find = new SqlCommand("SELECT IdUtilizator FROM Utilizatori WHERE Email=@1 AND Parola=@2", Program.Globals.con);
            find.Parameters.AddWithValue("1", textBox1.Text);
            find.Parameters.AddWithValue("2", textBox2.Text);
            if (find.ExecuteScalar() != null)
            {
                int id = (int)find.ExecuteScalar();
                this.Hide();
                new Form1(id).ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Eroare la autentificare!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                SqlCommand find = new SqlCommand("SELECT IdUtilizator FROM Utilizatori WHERE Email=@1", Program.Globals.con);
                find.Parameters.AddWithValue("1", textBox1.Text);
                if (find.ExecuteScalar() != null)
                {
                    this.Hide();
                    new Form4((int)find.ExecuteScalar()).ShowDialog();
                    this.Close();
                }
                else MessageBox.Show("Eroare la autentificare!");
            }
            else MessageBox.Show("Eroare la autentificare!");
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
