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

namespace GOOD_FOOD
{
    public partial class Form2 : Form
    {
        private SqlConnection con=new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\GOOD_FOOD.mdf;Integrated Security=True;Connect Timeout=30");
        public Form2()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand verif = new SqlCommand("SELECT id_client FROM Clienti WHERE email=@1", con);
            verif.Parameters.AddWithValue("1", textBox6.Text);
            int id;
            if (textBox1.Text.Length == 0) MessageBox.Show("Introduceti numele!");
            else if(textBox2.Text.Length == 0) MessageBox.Show("Introduceti prenumele!");
            else if(textBox3.Text.Length == 0) MessageBox.Show("Introduceti o adresa!");
            else if(textBox4.Text.Length == 0) MessageBox.Show("Introduceti o parola!");
            else if(textBox4.Text!=textBox5.Text) MessageBox.Show("Parolele nu se potrivesc");
            else if(textBox6.Text.Length == 0 || !textBox6.Text.Contains('@')) MessageBox.Show("Introduceti un email valid!");

            
            else if(verif.ExecuteScalar()!=null)
            {
                MessageBox.Show("Acest email este deja utilizat");
                con.Close();
                textBox6.Text = "";
            }
            else
            {
                MessageBox.Show("Cont creat!");
                SqlCommand insert = new SqlCommand("INSERT INTO Clienti VALUES(@1,@2,@3,@4,@5,2000)", con);
                insert.Parameters.AddWithValue("1", textBox4.Text);
                insert.Parameters.AddWithValue("2", textBox1.Text);
                insert.Parameters.AddWithValue("3", textBox2.Text);
                insert.Parameters.AddWithValue("4", textBox3.Text);
                insert.Parameters.AddWithValue("5", textBox6.Text);
                insert.ExecuteNonQuery();
                con.Close();

                this.Close();
            }
            con.Close();
        }
    }
}
