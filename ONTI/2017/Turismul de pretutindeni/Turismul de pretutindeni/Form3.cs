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
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;

namespace Turismul_de_pretutindeni
{
    public partial class Form3 : Form
    {
        int imag = 1, max;
        int user;
        public Form3(int user)
        {
            InitializeComponent();

            this.user = user;
            emailToolStripMenuItem.Text = (string)(new SqlCommand($"SELECT Email FROM Utilizatori WHERE IdUser={user}", Program.Globals.con).ExecuteScalar());
            if((int)(new SqlCommand($"SELECT TipCont FROM Utilizatori WHERE IdUser={user}",Program.Globals.con).ExecuteScalar())==0)
            {
                fileToolStripMenuItem.Visible = true;
            }
            timer1.Start();
            max=(int)new SqlCommand("SELECT COUNT(*) FROM Vacante",Program.Globals.con).ExecuteScalar();

            pictureBox1.Controls.Add(label1);
            pictureBox1.Controls.Add(label2);
            pictureBox1.Controls.Add(label3);
            pictureBox1.Controls.Add(label4);


        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deconectareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            next_image();
        }
        private void change_image()
        {
            SqlCommand select = new SqlCommand($"SELECT * FROM Vacante WHERE IdVacanta={imag}", Program.Globals.con);
            SqlDataReader read = select.ExecuteReader();
            read.Read();

            label1.Text = read.GetString(1);
            label2.Text = read.GetDouble(4).ToString()+ " lei";
            label3.Text = read.GetInt32(5).ToString() + " locuri";
            label4.Text = read.GetString(2);
            pictureBox1.BackgroundImage = Image.FromFile(read.GetString(3));
            read.Dispose();
        }
        private void next_image()
        {
            imag++;
            if (imag > max) imag = 1;
            change_image();
        }
        private void prev_image()
        {
            imag--;
            if (imag < 1) imag = max;
            change_image();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prev_image();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            next_image();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form4(user, imag).ShowDialog();
        }

        private void adaugaAdminNouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form5().ShowDialog();
        }

        private void adaugaVacanteNoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var p=Process.Start("Vacante.txt");
            p.WaitForExit();

            MessageBox.Show("Date modificate!");
            var files = new DirectoryInfo(@"Imagini\").GetFiles();

            new SqlCommand("TRUNCATE TABLE Vacante;", Program.Globals.con).ExecuteNonQuery();

            StreamReader read = new StreamReader("Vacante.txt");
            string line;
            while ((line = read.ReadLine()) != null)
            {
                SqlCommand insert = new SqlCommand("INSERT INTO Vacante VALUES(@1,@2,@3,@4,@5)", Program.Globals.con);
                insert.Parameters.AddWithValue("1", line.Split('|')[0]);
                insert.Parameters.AddWithValue("2", line.Split('|')[1]);
                insert.Parameters.AddWithValue("4", Convert.ToDouble(line.Split('|')[2]));
                insert.Parameters.AddWithValue("5", Convert.ToInt32(line.Split('|')[3]));
                bool ok = false;
                foreach (var file in files)
                {
                    if (file.Name.Contains(line.Split('|')[0]))
                    {
                        ok = true;
                        insert.Parameters.AddWithValue("3", @"Imagini\" + file.Name);
                    }
                }
                if (!ok)
                {
                    insert.Parameters.AddWithValue("3", @"Imagini\implicit.jpg");
                }

                insert.ExecuteNonQuery();
            }
        }

        private void vacanteleMeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form6(user).ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap mp = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            pictureBox1.DrawToBitmap(mp,new Rectangle(0,0,pictureBox1.Width,pictureBox1.Height));
            SaveFileDialog sv=new SaveFileDialog();
            sv.FileName = "Poster";
            sv.Filter = "|*.png";
            sv.ShowDialog();
            if (sv.FileName!=null)
            {
                mp.Save(sv.FileName,ImageFormat.Png);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                timer1.Start();
                button1.Enabled = button2.Enabled = false;
            }
            else
            {
                timer1.Stop();
                button1.Enabled = button2.Enabled = true;
            }
        }
    }
}
