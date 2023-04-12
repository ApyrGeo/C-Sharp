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

namespace FreeeBook
{
    public partial class Form2 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\Freebook.mdf; Integrated Security = True; Connect Timeout = 30");
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand email = new SqlCommand("SELECT email FROM utilizatori WHERE email=@1", con);
            email.Parameters.AddWithValue("1", textBox1.Text);
            string verif = (string)email.ExecuteScalar();
            con.Close();
            if (verif != null)
            {
                MessageBox.Show("Acest email este deja inregistrat!");

            }
            else
            {
                if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0)
                {
                    if (textBox4.Text == textBox5.Text)
                    {

                        con.Open();
                        SqlCommand inserare = new SqlCommand("INSERT INTO utilizatori VALUES(@1,@2,@3,@4)", con);
                        inserare.Parameters.AddWithValue("1", textBox1.Text);
                        inserare.Parameters.AddWithValue("2", textBox4.Text);
                        inserare.Parameters.AddWithValue("3", textBox2.Text);
                        inserare.Parameters.AddWithValue("4", textBox3.Text);
                        inserare.ExecuteNonQuery();
                        con.Close();

                        Form4 frm4=new Form4(textBox1.Text);
                        this.Hide();
                        frm4.ShowDialog();
                        this.Close();
                    }
                    else MessageBox.Show("Parolele nu se potrivesc!");
                }
                else MessageBox.Show("Va rugam completati toate casutele!");
            }
        }
    }
}
