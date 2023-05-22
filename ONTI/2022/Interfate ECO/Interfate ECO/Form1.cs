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

namespace Interfate_ECO
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

            new SqlCommand("TRUNCATE TABLE Useri", Program.Globals.con).ExecuteNonQuery();

            StreamReader read = new StreamReader("Useri.txt");
            string line;
            while((line=read.ReadLine())!=null)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Useri VALUES(@1,@2)", Program.Globals.con);
                cmd.Parameters.AddWithValue("1", line.Split()[0]);
                cmd.Parameters.AddWithValue("2", line.Split()[1]);
                cmd.ExecuteNonQuery();
                comboBox1.Items.Add(line.Split()[0]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Useri WHERE Nume=@1 AND Parola=@2", Program.Globals.con);
            cmd.Parameters.AddWithValue("1",comboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("2",textBox1.Text);

            if (cmd.ExecuteScalar() != null)
            {
                Form2 frm2 = new Form2(1);
                this.Hide();
                frm2.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Eroare!");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Useri WHERE Nume=@1 AND Parola=@2", Program.Globals.con);
            cmd.Parameters.AddWithValue("1", comboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("2", textBox1.Text);

            if (cmd.ExecuteScalar() != null)
            {
                Form2 frm2 = new Form2(2);
                this.Hide();
                frm2.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Eroare!");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Useri WHERE Nume=@1 AND Parola=@2", Program.Globals.con);
            cmd.Parameters.AddWithValue("1", comboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("2", textBox1.Text);

            if (cmd.ExecuteScalar() != null)
            {
                Form2 frm2 = new Form2(3);
                this.Hide();
                frm2.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Eroare!");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Useri WHERE Nume=@1 AND Parola=@2", Program.Globals.con);
            cmd.Parameters.AddWithValue("1", comboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("2", textBox1.Text);

            if (cmd.ExecuteScalar() != null)
            {
                Form2 frm2 = new Form2(4);
                this.Hide();
                frm2.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Eroare!");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Useri WHERE Nume=@1 AND Parola=@2", Program.Globals.con);
            cmd.Parameters.AddWithValue("1", comboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("2", textBox1.Text);

            if (cmd.ExecuteScalar() != null)
            {
                Form2 frm2 = new Form2(5);
                this.Hide();
                frm2.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Eroare!");
        }
    }
}
