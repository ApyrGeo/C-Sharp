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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PollutionMap
{
    public partial class Form2 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\Poluare.mdf"";Integrated Security=True;Connect Timeout=30");
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ok1 = false, ok2 = false, ok3 = false;
            
            //nume
            if (textBox1.Text.Length>4)
            {
                con.Open();
                SqlCommand cauta=new SqlCommand("SELECT IdUtilizator FROM Utilizatori WHERE NumeUtilizator=@1",con);
                cauta.Parameters.AddWithValue("1", textBox1.Text);
                if(cauta.ExecuteScalar()!=null)
                {
                    MessageBox.Show("Acest nume este folosit de alt utilizator. Va rugam sa introduceti un alt nume!");
                }
                else
                {
                    ok1 = true;
                    //parola
                    if (textBox4.Text.Length > 6)
                    {
                        if (textBox4.Text == textBox3.Text)
                        {
                            ok2 = true;
                            //email  
                            if (textBox2.Text.Contains('@') && textBox2.Text.Split('@')[1].Contains('.'))
                            {
                                ok3 = true;
                            }
                            else
                            {
                                MessageBox.Show("Va rugam sa introduceti o adresa de email valida!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Parolele nu coincid!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Va rugam sa introduceti o parola de cel putin 6 caractere!");
                    }
                    
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Va rugam sa introduceti un nume mai lung!");
            }
            
            if (ok1==ok2 &&ok2==ok3 &&ok3==true)
            {
                con.Open();
                SqlCommand inserare = new SqlCommand("INSERT INTO Utilizatori(NumeUtilizator,Parola,EmailUtilizator) VALUES(@1,@2,@3)",con);
                inserare.Parameters.AddWithValue("1", textBox1.Text);
                inserare.Parameters.AddWithValue("2", textBox4.Text);
                inserare.Parameters.AddWithValue("3", textBox2.Text);
                inserare.ExecuteNonQuery();

                this.Hide();
                Form1 frm1 = new Form1();
                frm1.ShowDialog();
                this.Close();
                con.Close();
            }
            
        }
    }
}
