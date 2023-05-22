using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turismul_de_pretutindeni
{
    public partial class Form1 : Form
    {
        public static string email_retinut = "admin@oti.ro";
        public Form1()
        {
            InitializeComponent();

            var files = new DirectoryInfo(@"Imagini\").GetFiles();

            new SqlCommand("TRUNCATE TABLE Vacante;", Program.Globals.con).ExecuteNonQuery();

            StreamReader read = new StreamReader("Vacante.txt");
            string line;
            while((line = read.ReadLine()) != null)
            {
                SqlCommand insert = new SqlCommand("INSERT INTO Vacante VALUES(@1,@2,@3,@4,@5)", Program.Globals.con);
                insert.Parameters.AddWithValue("1", line.Split('|')[0]);
                insert.Parameters.AddWithValue("2", line.Split('|')[1]);
                insert.Parameters.AddWithValue("4", Convert.ToDouble(line.Split('|')[2]));
                insert.Parameters.AddWithValue("5", Convert.ToInt32(line.Split('|')[3]));
                bool ok = false;
                foreach(var file in files)
                {
                    if(file.Name.Contains(line.Split('|')[0]))
                    {
                        ok = true;
                        insert.Parameters.AddWithValue("3", @"Imagini\"+file.Name);
                    }
                }
                if(!ok)
                {
                    insert.Parameters.AddWithValue("3", @"Imagini\implicit.jpg");
                }
                
                insert.ExecuteNonQuery();
                
            }
            if(new SqlCommand("SELECT IdUser FROM Utilizatori WHERE Email='admin@oti.ro'",Program.Globals.con).ExecuteScalar()==null)
                new SqlCommand("INSERT INTO Utilizatori VALUES('admin','admin','admin@oti.ro','oti2017',0)", Program.Globals.con).ExecuteNonQuery();

            textBox1.Text = email_retinut;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT IdUser FROM Utilizatori WHERE Email=@1 AND Parola=@2", Program.Globals.con);
            cmd.Parameters.AddWithValue("1", textBox1.Text);
            cmd.Parameters.AddWithValue("2", textBox2.Text);
            if(cmd.ExecuteScalar()!=null)
            {
                email_retinut = textBox1.Text;
                //
                this.Hide();
                new Form3((int)(cmd.ExecuteScalar())).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Eroare de autentificare!");
                textBox1.Text = textBox2.Text ="";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().ShowDialog();
            this.Close();
        }
    }
}
