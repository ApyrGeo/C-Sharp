using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Turismul_de_pretutindeni
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            
            refresh();
        }
        void refresh()
        {
            var files = new DirectoryInfo(@"Logare\").GetFiles();
            selected_captcha = files[new Random().Next(1, files.Count() + 1)].Name;
            pictureBox2.BackgroundImage = Image.FromFile(@"Logare\" +selected_captcha);

            selected_captcha = selected_captcha.Split('.')[0];
        }
        string selected_captcha = "";
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length>0&& textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0 && textBox6.Text.Length > 0 )
            {
                SqlCommand verify = new SqlCommand("SELECT IdUser FROM Utilizatori WHERE Email=@1", Program.Globals.con);
                verify.Parameters.AddWithValue("1", textBox3.Text);
                if(verify.ExecuteScalar()==null)
                {
                    if( textBox4.Text==textBox5.Text)
                    {
                        if(textBox6.Text==selected_captcha)
                        {
                            SqlCommand insert = new SqlCommand("INSERT INTO Utilizatori VALUES(@1,@2,@3,@4,1)", Program.Globals.con);
                            insert.Parameters.AddWithValue("1",textBox1.Text);
                            insert.Parameters.AddWithValue("2", textBox2.Text);
                            insert.Parameters.AddWithValue("3", textBox3.Text);
                            insert.Parameters.AddWithValue("4", textBox4.Text);
                            insert.ExecuteNonQuery();

                            this.Hide();
                            new Form3((int)(new SqlCommand("SELECT MAX(IdUser) FROM Utilizatori", Program.Globals.con).ExecuteScalar())).ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Capthca gresit!");
                            refresh();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Parolele nu se potrivesc!");
                    }
                }
                else
                {
                    MessageBox.Show("Acest eamil este deja folosit!");
                }
            }
            else
            {
                MessageBox.Show("Completeza toate celulele!");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
