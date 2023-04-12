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

namespace TurismulDurabil
{
    public partial class Form2 : Form
    {
        private SqlConnection con=new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Turism.mdf;Integrated Security=True;Connect Timeout=30");
        string adresa;
        public Form2(string a)
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            cb1();
            adresa = a;
            listBox1.Items.Clear();
        }
       
        private void cb1()
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "Selecteaza un oras";
            con.Open();
            SqlCommand loc = new SqlCommand("SELECT Nume FROM Localitati", con);
            SqlDataReader read=loc.ExecuteReader();
            while(read.Read())
            {
                comboBox1.Items.Add(read.GetString(0));
            }
            con.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string oras=comboBox1.SelectedItem.ToString();
            comboBox2.Items.Clear();
            comboBox2.Text = "Selecteaza o imagine";
            con.Open();
            SqlCommand adresa = new SqlCommand("SELECT CaleFisier FROM Imagini INNER JOIN Localitati ON Localitati.IdLocalitate=Imagini.IdLocalitate WHERE Nume=@1", con);
            adresa.Parameters.AddWithValue("1", oras);
            SqlDataReader read=adresa.ExecuteReader();
            while(read.Read())
            {
                string adr=read.GetString(0);
                string[] a = read.GetString(0).Split('\\');
                int len = a.Length;
                comboBox2.Items.Add(read.GetString(0).Split('\\')[len-1]);
            }
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile(adresa+@"\"+comboBox2.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(listBox1.Items.Count<10)
            {
                listBox1.Items.Add(comboBox2.SelectedItem);
            }
            else
            {
                MessageBox.Show("Ai ales prea multe imagini");
            }
        }
        private string imagine = "";
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(listBox1.Items.Count>0)
            {
                string imagine = listBox1.SelectedItem.ToString();

                pictureBox1.BackgroundImage = Image.FromFile(adresa + @"\" + listBox1.SelectedItem);
            }
            
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = textBox1.Text;
            saveFileDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.ShowDialog();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
