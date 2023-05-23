using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        Button[,] celule = new Button[100, 100];
        int[,] apasat = new int[100, 100];
        int width;
        public Form1()
        {
            InitializeComponent();
            N = (int)numericUpDown2.Value;

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    celule[i, j] = new Button();
                }
            }
        }
        private int[,] mat = new int[100, 100];
        private int[] OX = new int[] { 0, 1, 0, -1 };
        private int[] OY = new int[] { -1, 0, 1, 0 };
        private void desen_celula(object sender, PaintEventArgs e)
        {
            Button b = sender as Button;

            int w = Grid.Width / N;
            int i = b.Location.Y / w;
            int j = b.Location.X / w;

            if (apasat[i, j] != 0)
            {
                if (mat[i, j] == -1)
                {
                    e.Graphics.DrawEllipse(new Pen(Color.Black, width / 2), new Rectangle(width / 4, width / 4, width / 2, width / 2));
                }

                if (mat[i, j] > 0)
                {
                    e.Graphics.DrawString(mat[i, j].ToString(), new Font("Arial", width / 2), new SolidBrush(Color.Red), new Point(0, 0));
                }
                if (mat[i, j] < -1)
                {
                    e.Graphics.DrawString("F", new Font("Arial", width / 2), new SolidBrush(Color.Blue), new Point(0, 0));
                }
            }
        }
        private void populate_mat()
        {
            if (nr_bombe != 0)
            {
                for (int k = 1; k <= nr_bombe; k++)
                {
                    Random r = new Random();
                    int i = r.Next(0, N), j = r.Next(0, N);
                    while (mat[i, j] != 0)
                    {
                        i = r.Next(0, N);
                        j = r.Next(0, N);
                    }
                    mat[i, j] = -1;
                }

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (mat[i, j] == -1)
                        {
                            for (int a = i - 1; a <= i + 1; a++)
                            {
                                for (int b = j - 1; b <= j + 1; b++)
                                {
                                    if (a < N && b < N && a >= 0 && b >= 0)
                                    {
                                        if (mat[a, b] != -1)
                                        {
                                            mat[a, b]++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int nr_bombe;
        int N;
        private void button1_Click(object sender, EventArgs e)
        {
            gameover = false;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {

                    Grid.Controls.Remove(celule[i, j]);
                }
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    mat[i, j] = 0;
                    apasat[i, j] = 0;
                    celule[i, j].BackColor = Color.DarkGray;
                }
            }
            Grid.Refresh();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    width = Grid.Width / N;
                    celule[i, j].Location = new Point(width * j, width * i);
                    celule[i, j].Size = new Size(width, width);
                    celule[i, j].FlatStyle = FlatStyle.Flat;
                    celule[i, j].BackColor = Color.DarkGray;
                    celule[i, j].MouseDown += Grid_MouseDown;
                    celule[i, j].Paint += desen_celula;
                    Grid.Controls.Add(celule[i, j]);
                }
            }
            Grid.Refresh();
            nr_bombe = (int)numericUpDown1.Value;
            populate_mat();
        }
        int ii, ij;
        private void Fill(int i, int j)
        {
            if ((i >= 0 && j >= 0 && i < N && j < N) || (ii == i && ij == j))
            {
                if (mat[i, j] == 0 && apasat[i, j] == 0)
                {
                    celule[i, j].BackColor = Color.LightGray;
                    apasat[i, j] = 1;
                    for (int k = 0; k < 4; k++)
                    {
                        Fill(i + OX[k], j + OY[k]);
                    }
                }
                if (mat[i, j] > 0 && apasat[i, j] == 0)
                {
                    celule[i, j].BackColor = Color.LightGray;
                    apasat[i, j] = 1;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gameover = false;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    mat[i, j] = 0;
                    apasat[i, j] = 0;
                    celule[i, j].BackColor = Color.DarkGray;
                }
            }
            Grid.Refresh();
            populate_mat();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = (numericUpDown2.Value * numericUpDown2.Value) / 2;
            N = (int)numericUpDown2.Value;
            width = Grid.Width / N;
        }
        bool gameover = false;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        bool verif()
        {
            int k = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (apasat[i, j] == 1 && mat[i, j] + 15 == -1 || apasat[i, j] == 0)
                        k++;
                }
            }
            return k == nr_bombe;
        }

        private void Grid_MouseDown(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;

            int w = Grid.Width / N;
            int i = b.Location.Y / w;
            int j = b.Location.X / w;
            if (e.Button == MouseButtons.Left)
            {
                if (apasat[i, j] == 0 && !gameover)
                {
                    b.BackColor = Color.LightGray;
                    apasat[i, j] = 1;
                    //MessageBox.Show(i.ToString() + " " + j.ToString());
                    if (verif() == true)
                    {
                        gameover = true;
                        MessageBox.Show("You won!");
                    }
                    if (mat[i, j] == -1)
                    {
                        b.BackColor = Color.Red;
                        MessageBox.Show("Game over!");
                        gameover = true;
                    }
                    if (mat[i, j] == 0)
                    {
                        celule[i, j].BackColor = Color.LightGray;
                        apasat[i, j] = 1;
                        for (int k = 0; k < 4; k++)
                        {
                            Fill(i + OX[k], j + OY[k]);
                        }
                    }
                    else if (mat[i, j] > 0)
                    {
                        celule[i, j].BackColor = Color.LightGray;
                        apasat[i, j] = 1;
                    }

                }
            }
            else if (e.Button == MouseButtons.Right && apasat[i, j] == 0 || e.Button == MouseButtons.Right && apasat[i, j] == 1 && mat[i, j] <-1)
            {
                if (apasat[i, j] == 1)
                {
                    mat[i, j] += 15;
                    apasat[i, j] = 0;
                }
                else
                {
                    mat[i, j] -= 15;
                    apasat[i, j] = 1;
                }

                
            }
        }
        private void Grid_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
