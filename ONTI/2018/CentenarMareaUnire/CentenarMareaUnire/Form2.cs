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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            SqlCommand lectii = new SqlCommand("SELECT NumeImagine FROM Lectii", Program.Globals.con);
            SqlDataReader reader = lectii.ExecuteReader();
            while(reader.Read())
            {
                listBox1.Items.Add(reader.GetString(0));
            }
            reader.Dispose();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile(@"ContinutLectii\" + listBox1.SelectedItem + ".bmp");

            SqlCommand find = new SqlCommand("SELECT Nume,Email,Regiune,DataCreare " +
                "FROM Lectii INNER JOIN Utilizatori ON Utilizatori.IdUtilizator=Lectii.IdUtilizator " +
                $"WHERE NumeImagine='{listBox1.SelectedItem}'", Program.Globals.con);
            SqlDataReader read = find.ExecuteReader();
            read.Read();
            textBox2.Text = read.GetString(0) + "\r\n" + read.GetString(1) + "\r\n" + read.GetString(2) + "\r\n" + read.GetDateTime(3).ToString();
            read.Dispose();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
