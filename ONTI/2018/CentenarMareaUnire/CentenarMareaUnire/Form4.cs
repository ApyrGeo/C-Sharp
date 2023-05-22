using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CentenarMareaUnire
{
    public partial class Form4 : Form
    {
        private List<string> oameni = new List<string>();
        private PictureBox[] pics;
        private string[] names=new string[6];
        int utilizator;
        public Form4(int id)
        {
            InitializeComponent();
            utilizator = id;
            StreamReader read = new StreamReader("oameni.txt");
            string line;
            while((line = read.ReadLine()) != null)
            {
                oameni.Add(line);
            }
            read.Dispose();
            gen_pics();
        }
        private void gen_pics()
        {
            pics = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6 };
            int[] used = new int[100];
            for (int i = 0; i < 6; i++)
            {
                int x = new Random().Next(1, 21);
                while (used[x] != 0)
                {
                    x = new Random().Next(1, 21);
                }
                used[x]++;
                pics[i].BackgroundImage = Image.FromFile(@"Captcha\" + x.ToString() + ".jpg");
                names[i] = x.ToString() + ".jpg";
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private int[] press = new int[6];
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            press[0]++;
            if (press[0] % 2 == 1)
            {
                pics[0].BorderStyle = BorderStyle.FixedSingle;
            }
            else if (press[0] % 2 == 0)
            {
                pics[0].BorderStyle = BorderStyle.None;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            press[1]++;
            if (press[1] % 2 == 1)
            {
                pics[1].BorderStyle = BorderStyle.FixedSingle;
            }
            else if (press[1] % 2 == 0)
            {
                pics[1].BorderStyle = BorderStyle.None;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            press[2]++;
            if (press[2] % 2 == 1)
            {
                pics[2].BorderStyle = BorderStyle.FixedSingle;
            }
            else if (press[2] % 2 == 0)
            {
                pics[2].BorderStyle = BorderStyle.None;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            press[3]++;
            if (press[3] % 2 == 1)
            {
                pics[3].BorderStyle = BorderStyle.FixedSingle;
            }
            else if (press[3] % 2 == 0)
            {
                pics[3].BorderStyle = BorderStyle.None;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            press[4]++;
            if (press[4] % 2 == 1)
            {
                pics[4].BorderStyle = BorderStyle.FixedSingle;
            }
            else if (press[4] % 2 == 0)
            {
                pics[4].BorderStyle = BorderStyle.None;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            press[5]++;
            if (press[5] % 2 == 1)
            {
                pics[5].BorderStyle = BorderStyle.FixedSingle;
            }
            else if (press[5] % 2 == 0)
            {
                pics[5].BorderStyle = BorderStyle.None;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ok = true;
            for (int i = 0; i < 6 && ok==true; i++)
            {
                if (oameni.IndexOf(names[i]) == -1)
                {
                    if(press[i] % 2 == 1)
                    {
                        ok = false;
                        MessageBox.Show("Eroare");
                    }
                }
                else
                {
                    if (press[i] % 2 == 0)
                    {
                        ok = false;
                        MessageBox.Show("Eroare");
                    }
                }
            }
            if(ok==true)
            {
                a_trecut_capthca = true;
            }
            else
            {
                a_trecut_capthca = false;
            }
        }
        private bool a_trecut_capthca = false;

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text && a_trecut_capthca==true)
            {
                new SqlCommand($"UPDATE TABLE Utilizatori SET Parola='{textBox1.Text}' WHERE IdUtilizator={utilizator}", Program.Globals.con).ExecuteNonQuery();
                MessageBox.Show("Parola schimbata cu succes!");
                this.Hide();
                new Form3().ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Eroare");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form3().ShowDialog();
            this.Close();
        }
    }
}
