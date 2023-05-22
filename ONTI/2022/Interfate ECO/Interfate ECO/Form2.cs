using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfate_ECO
{
    public partial class Form2 : Form
    {
        private PictureBox[,] matrice= new PictureBox[10,20];
       
        private int[,] ocupat = new int[10,20];
        public Form2(int id_poza)
        {
            InitializeComponent();

            pictureBox1.BackgroundImage = Image.FromFile(@"Background\Back" + id_poza.ToString() + ".jpg");

            paint(pictureBox3);
            
            int width= pictureBox1.Width/20;
            int height= pictureBox1.Height/10;
            for(int i=0;i<10;i++)
            {
                for(int j=0;j<20;j++)
                {
                    matrice[i, j] = new PictureBox();
                    matrice[i, j].Size = new Size(width,height);
                    matrice[i, j].Left = pictureBox1.Location.X + j * width;
                    matrice[i, j].Top = pictureBox1.Location.Y + i * height;
                    Controls.Add(matrice[i, j]);
                    matrice[i, j].Parent = pictureBox1;
                    matrice[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    matrice[i, j].Click += PictureBox_Click;
                    matrice[i, j].Paint += pictureBox_Paint;

                }
            }
            
        }
        private int rotire = 1;
        private void roteste()
        { 
            rotire++;
            paint(pictureBox3);

        }
        void paint(PictureBox a)
        {
            Graphics g = a.CreateGraphics();
            Pen pen = new Pen(Color.White, 1);
            if (rotire > 4) rotire = 1;

            if (a == pictureBox3)
            {
                g.Clear(Color.Transparent);
                a.Refresh();
                
            }
            
            if (rotire == 1)
            {
                Point[] points =
                {
                    new Point(0,0),
                    new Point(a.Width,a.Height),
                    new Point(0,a.Height),
                };
                g.DrawPolygon(pen, points);
                g.FillPolygon(new SolidBrush(Color.White), points);
            }
            else if (rotire == 2)
            {
                Point[] points =
                {
                    new Point(0,0),
                    new Point(a.Width,0),
                    new Point(0,a.Height),
                };
                g.DrawPolygon(pen, points);
                g.FillPolygon(new SolidBrush(Color.White), points);
            }
            else if (rotire == 3)
            {
                Point[] points =
                {
                    new Point(0,0),
                    new Point(a.Width,a.Height),
                    new Point(a.Width,0),
                };
                g.DrawPolygon(pen, points);
                g.FillPolygon(new SolidBrush(Color.White), points);
            }
            else if (rotire == 4)
            {
                Point[] points =
                {
                    new Point(a.Width,0),
                    new Point(a.Width,a.Height),
                    new Point(0,a.Height),
                };
                g.DrawPolygon(pen, points);
                g.FillPolygon(new SolidBrush(Color.White), points);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
           
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.White);
            var a = sender as PictureBox;
            var (i, j) = picture_box_to_index(a);
            if (ocupat[i,j] == 1)
            {
                Point[] points =
                {
                    new Point(0,0),
                    new Point(a.Width,a.Height),
                    new Point(0,a.Height),
                };
                g.DrawPolygon(pen, points);
                g.FillPolygon(new SolidBrush(Color.White), points);
            }
            else if (ocupat[i, j] == 2)
            {
                Point[] points =
                {
                    new Point(0,0),
                    new Point(a.Width,0),
                    new Point(0,a.Height),
                };
                g.DrawPolygon(pen, points);
                g.FillPolygon(new SolidBrush(Color.White), points);
            }
            else if (ocupat[i, j] == 3)
            {
                Point[] points =
                {
                    new Point(0,0),
                    new Point(a.Width,a.Height),
                    new Point(a.Width,0),
                };
                g.DrawPolygon(pen, points);
                g.FillPolygon(new SolidBrush(Color.White), points);
            }
            else if (ocupat[i, j] == 4)
            {
                Point[] points =
                {
                    new Point(a.Width,0),
                    new Point(a.Width,a.Height),
                    new Point(0,a.Height),
                };
                g.DrawPolygon(pen, points);
                g.FillPolygon(new SolidBrush(Color.White), points);
            }
            TH();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            roteste();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                foreach(PictureBox p in matrice)
                {
                    p.BorderStyle = BorderStyle.Fixed3D;
                }
            }
            if (checkBox1.Checked == false)
            {
                foreach (PictureBox p in matrice)
                {
                    p.BorderStyle = BorderStyle.None;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(PictureBox p in matrice)
                p.BackgroundImage= null;
            openFileDialog1.ShowDialog();


            StreamReader read=new StreamReader(openFileDialog1.FileName);

            string line;
            while((line=read.ReadLine())!=null)
            {

                if(line.Split()[0].Contains("Robot"))
                {
                    robot.BackgroundImage = Image.FromFile(@"Robot\Robot.png");
                    robot.Size = new Size(matrice[0, 0].Width, matrice[0, 0].Height);
                    robot.Parent = matrice[Convert.ToInt32(line.Split()[2]) - 1, Convert.ToInt32(line.Split()[1]) - 1];
                    robot.BackgroundImageLayout = ImageLayout.Stretch;
                    robot.Location = matrice[Convert.ToInt32(line.Split()[2]) - 1, Convert.ToInt32(line.Split()[1]) - 1].Location;
                    
                }
                if (line.Split()[0].Contains("Meduza"))
                {
                    matrice[Convert.ToInt32(line.Split()[2]) - 1, Convert.ToInt32(line.Split()[1]) - 1].BackgroundImage = Image.FromFile(@"Meduze\" + line.Split()[0] +".png");
                }
                if (line.Split()[0].Contains("Sticla"))
                {
                    matrice[Convert.ToInt32(line.Split()[2]) - 1, Convert.ToInt32(line.Split()[1]) - 1].BackgroundImage = Image.FromFile(@"MaterialeReciclabile\Sticla.png");
                }
                if (line.Split()[0].Contains("Hartie"))
                {
                    matrice[Convert.ToInt32(line.Split()[2]) - 1, Convert.ToInt32(line.Split()[1]) - 1].BackgroundImage = Image.FromFile(@"MaterialeReciclabile\Hartie.png");
                }
                if (line.Split()[0].Contains("Plastic"))
                {
                    matrice[Convert.ToInt32(line.Split()[2]) - 1, Convert.ToInt32(line.Split()[1]) - 1].BackgroundImage = Image.FromFile(@"MaterialeReciclabile\Plastic.png");
                }
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            var (i, j) = picture_box_to_index(sender as PictureBox);
            if ((sender as PictureBox).BackgroundImage==null )
            {
                if (ocupat[i,j]==0)
                {
                    ocupat[i, j] = rotire;
                    paint(pictureBox3);
                    (sender as PictureBox).Refresh();
                }
            }
            
            
        }
        private (int ,int ) picture_box_to_index(PictureBox a)
        {
            for(int i=0;i<10;i++)
            {
                for(int j=0;j<20;j++)
                {
                    if (matrice[i,j]==a)
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1);
        }
        private void Form2_ResizeBegin(object sender, EventArgs e)
        {

        }

        private void Form2_ResizeEnd(object sender, EventArgs e)
        {
            int width = pictureBox1.Width / 20;
            int height = pictureBox1.Height / 10;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    
                    matrice[i, j].Size = new Size(width, height);
                    matrice[i, j].Left = pictureBox1.Location.X + j * width;
                    matrice[i, j].Top = pictureBox1.Location.Y + i * height;
                    Controls.Add(matrice[i, j]);
                    matrice[i, j].Parent = pictureBox1;
                    matrice[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecteaza directia, dupa inchiderea acestui mesaj! (W pentru sus, A pentru stanga, D pentru dreapta, S pentru jos");
            ok = 1;
        }
        int ok = 0;
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(ok==1)
            {
                if (e.KeyChar == 's')
                {
                    
                }
                if (e.KeyChar == 'a')
                {
                   
                }
                if (e.KeyChar == 'd')
                {
                   
                }
                if (e.KeyChar == 'w')
                {
                    
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    ocupat[i, j] = 0;
                    matrice[i, j].Refresh();
                    matrice[i,j].BackgroundImage= null;
                }
            }
        }
        private void TH()
        {
            var g = pictureBox1.CreateGraphics();
            if (robot.BackgroundImage != null)
                g.DrawImage(robot.BackgroundImage, robot.Location.X, robot.Location.Y, robot.Width, robot.Height);

        }
    }
}
