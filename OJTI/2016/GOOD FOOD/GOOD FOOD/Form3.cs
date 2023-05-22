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
    public partial class Form3 : Form
    {
        private SqlConnection con =new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\GOOD_FOOD.mdf;Integrated Security=True;Connect Timeout=30");
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cauta = new SqlCommand("SELECT id_client FROM Clienti WHERE email=@1 AND parola=@2", con);
            cauta.Parameters.AddWithValue("1", textBox1.Text);
            cauta.Parameters.AddWithValue("2", textBox2.Text);

            if (cauta.ExecuteScalar() == null)
            {
                MessageBox.Show("Eroare autentificare!");
                textBox1.Text = textBox2.Text = "";
                con.Close();
            }
            else
            {

                
                Form4 frm4 = new Form4((int)cauta.ExecuteScalar());
                con.Close();
                this.Hide();
                frm4.ShowDialog();
                this.Close();
            }
        }
    }
}
