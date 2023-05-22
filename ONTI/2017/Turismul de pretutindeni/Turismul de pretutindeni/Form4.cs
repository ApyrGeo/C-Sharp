using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Turismul_de_pretutindeni
{
    public partial class Form4 : Form
    {
        private int user, imag;
        public Form4(int user, int imag)
        {
            InitializeComponent();
            this.imag = imag;
            this.user = user;
            SqlCommand select = new SqlCommand($"SELECT * FROM Vacante WHERE IdVacanta={imag}", Program.Globals.con);
            SqlDataReader read = select.ExecuteReader();
            read.Read();

            label1.Text = read.GetString(1);
            label2.Text = read.GetDouble(4).ToString() + " lei";
            label3.Text = read.GetInt32(5).ToString() + " locuri";
            label4.Text = read.GetString(2);
            pictureBox1.BackgroundImage = Image.FromFile(read.GetString(3));
            read.Dispose();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private double PretTotal;

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {
                if (dateTimePicker1.Value < dateTimePicker2.Value)
                {
                    if ((int)(new SqlCommand($"SELECT NrLocuri FROM Vacante WHERE IdVacanta={imag}", Program.Globals.con).ExecuteScalar()) - (int)numericUpDown1.Value >= 0)
                    {
                        new SqlCommand($"UPDATE Vacante SET NrLocuri=NrLocuri-{(int)numericUpDown1.Value} WHERE IdVacanta={imag}", Program.Globals.con).ExecuteNonQuery();

                        SqlCommand cmd=new SqlCommand($"INSERT INTO Rezervari VALUES({imag},{user},@1,@2,{(int)numericUpDown1.Value},{(int)PretTotal})", Program.Globals.con);
                        cmd.Parameters.AddWithValue("1", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("2", dateTimePicker2.Value);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Rezervare finalizata!");

                        this.Hide();
                        this.Close();
                    }
                    else MessageBox.Show("Numar de locuri indisponibil!");
                }
                else MessageBox.Show("Alege date consecutive!");
            }
            else MessageBox.Show("Rezervarea trebuie sa contina cel putin o persoana!");

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            PretTotal =(double)(new SqlCommand($"SELECT Pret FROM Vacante WHERE IdVacanta={imag}", Program.Globals.con).ExecuteScalar());
            PretTotal *= (float)numericUpDown1.Value;
            label9.Text = PretTotal.ToString()+ " lei";

        }
    }
}
