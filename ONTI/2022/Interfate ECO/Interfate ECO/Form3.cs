using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Interfate_ECO
{
   
    public partial class Form3 : Form
    {

        private int width, height;
        public Form3(int id_poza)
        {

            InitializeComponent();
            pictureBox1.BackgroundImage = Image.FromFile(@"Background\Back" + id_poza.ToString() + ".jpg");

            width= pictureBox1.Width;
            height= pictureBox1.Height;


            pictureBox2.Size = new Size(width/20,height/10);
            pictureBox2.Parent = pictureBox1;


            p = pictureBox1.CreateGraphics();
            //Graphics a=pictureBox1.CreateGraphics();
            //a.DrawImage(pictureBox2.BackgroundImage, 200, 350);
            //pictureBox2.Parent = pictureBox1;
            //pictureBox2.Refresh();
        }
        private int rotire = 1;
        private void roteste()
        {
            rotire++;
            if (rotire > 4) rotire = 1;

            Graphics g = pictureBox3.CreateGraphics();
            Pen pen = new Pen(Color.White);

            g.Clear(Color.Transparent);
            pictureBox3.Refresh();
            if (rotire == 4)
            {
                g.FillPolygon(new SolidBrush(Color.White), new Point[] { new Point(100, 0), new Point(0, 0), new Point(0, 100) });
            }
            if (rotire == 3)
            {
                g.FillPolygon(new SolidBrush(Color.White), new Point[] { new Point(0, 0), new Point(0, 100), new Point(100, 100) });
            }
            if (rotire == 2)
            {
                g.FillPolygon(new SolidBrush(Color.White), new Point[] { new Point(0, 100), new Point(100, 100), new Point(100,0) });
            }
            if (rotire == 1)
            {
                g.FillPolygon(new SolidBrush(Color.White), new Point[] { new Point(100, 100), new Point(100, 0), new Point(0, 0) });
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            Pen pen = new Pen(Color.White, 2);
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i <= 10; i++)
                {
                    p.DrawLine(pen, 0, height / 10 * i, width, height / 10 * i);
                }
                for (int j = 0; j <= 20; j++)
                {
                    p.DrawLine(pen, width / 20 * j, 0, width / 20 * j, height);
                }
            }
            else
            {
                p.Clear(Color.Transparent);
                pictureBox1.Refresh();
            }
        }
        private Graphics p;
        private void button1_Click(object sender, EventArgs e)
        {
           
            openFileDialog1.ShowDialog();
            
            
            StreamReader read=new StreamReader(openFileDialog1.FileName);

            string line;
            
            
            while((line=read.ReadLine())!=null)
            {
                string obiect = line.Split()[0];
                int x = Convert.ToInt32(line.Split()[1]), y = Convert.ToInt32(line.Split()[2]);

                if(obiect.Contains("Meduza"))
                {
                    Image s = Image.FromFile(@"Meduze\" + obiect + ".png");
                    p.DrawImage(s, new Rectangle(new Point(width / 20 * x + 2, height / 10 * y + 2), new Size(width / 20-8, height / 10-8)));
                    ocupat[y+1, x+1] = -1;
                    p.Save();
                }
                else if(obiect.Contains("Sticla"))
                {
                    Image s = Image.FromFile(@"MaterialeReciclabile\Sticla.png");
                    p.DrawImage(s, new Rectangle(new Point(width / 20 * x + 2, height / 10 * y + 2), new Size(width / 20 - 8, height / 10 - 8)));
                    ocupat[y + 1, x + 1] = -2;
                    p.Save();
                }
                else if (obiect.Contains("Hartie"))
                { 
                    Image s = Image.FromFile(@"MaterialeReciclabile\Hartie.png");
                    p.DrawImage(s, new Rectangle(new Point(width / 20 * x + 2, height / 10 * y + 2), new Size(width / 20 - 8, height / 10 - 8)));
                    ocupat[y + 1, x + 1] = -3;
                    p.Save();
                }
                else if (obiect.Contains("Plastic"))
                {
                    Image s = Image.FromFile(@"MaterialeReciclabile\Plastic.png");
                    p.DrawImage(s, new Rectangle(new Point(width / 20 * x + 2, height / 10 * y + 2), new Size(width / 20 - 8, height / 10 - 8)));
                    ocupat[y + 1, x + 1] = -4;
                    p.Save();
                }
                else if (obiect.Contains("Robot"))
                {
                    pictureBox2.Visible = true;
                    pictureBox2.Location = new Point(width / 20 * (x-1) , height / 10 * (y-1));
                    ocupat[y , x] = -9;
                    pozitie.i = y;
                    pozitie.j = x;
                    p.Save();
                }

            }
        }
        
        int[,] ocupat = new int[11, 21];
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (int)(e.X / (width / 20) + 1);
            int y = (int)(e.Y / (height / 10) + 1);

            
            if(rotire == 1 && ocupat[y,x] == 0)
            {
                p.FillPolygon(new SolidBrush(Color.White), new Point[] { new Point(width / 20 * x, height / 10 * y), new Point(width / 20 * x , height / 10 * (y-1)), new Point(width/20*(x-1), height/10*(y-1)) });
                ocupat[y, x] = rotire;
            }
            if (rotire == 2 && ocupat[y, x] == 0)
            {
                p.FillPolygon(new SolidBrush(Color.White), new Point[] { new Point(width / 20 * (x-1), height / 10 * y), new Point(width / 20 * x, height / 10 * y), new Point(width / 20 * x, height / 10 * (y - 1)) });
                ocupat[y, x] = rotire;
            }
            if (rotire == 3 && ocupat[y, x] == 0)
            {
                p.FillPolygon(new SolidBrush(Color.White), new Point[] { new Point(width / 20 * (x - 1), height / 10 * (y - 1)), new Point(width / 20 * (x - 1), height / 10 * y), new Point(width / 20 * x, height / 10 * y) });
                ocupat[y, x] = rotire;
            }
            if (rotire == 4 && ocupat[y,x] == 0)
            {
                p.FillPolygon(new SolidBrush(Color.White), new Point[] { new Point(width / 20 * x, height / 10 * (y - 1)), new Point(width / 20 * (x - 1), height / 10 * (y - 1)), new Point(width / 20 * (x - 1), height / 10 * y) });
                ocupat[y, x] = rotire;
                
            }
        }
        bool oprit = false;
        private void button3_Click(object sender, EventArgs e)
        {
            p.Clear(Color.Transparent);
            pictureBox1.Refresh();
            pictureBox2.Visible = false;
            for (int i = 1; i <= 10; i++)
                for(int j = 1;j <= 20; j++)
                {
                    ocupat[i, j] = 0;
                }
            if(checkBox1.Checked==true)
            {
                
                Pen pen = new Pen(Color.White, 2);
                if (checkBox1.Checked == true)
                {
                    for (int i = 0; i <= 10; i++)
                    {
                        p.DrawLine(pen, 0, height / 10 * i, width, height / 10 * i);
                       
                    }
                    for (int j = 0; j <= 20; j++)
                    {
                        p.DrawLine(pen, width / 20 * j, 0, width / 20 * j, height);
                       
                    }
                }
            }
        }
        int ok = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecteaza directia de deplasare, dupa inchiderea acestui mesaj! (W,A,S sau D)");
            ok = 1;

            button4.Visible = false;
            button8.Visible = true;

            pictureBox2.BackColor= Color.Purple;
            timer_miscare.Start();

            pz[1] = new Bitmap(width, height);
            Rectangle rect = new Rectangle(this.PointToScreen(pictureBox1.Location).X, this.PointToScreen(pictureBox1.Location).Y, width, height);
            pz[1] = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(pz[1]);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, pz[1].Size, CopyPixelOperation.SourceCopy);



        }
        (int ox, int oy) miscare;
        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if(ok==1)
            {
                if(e.KeyCode==Keys.A)
                {
                    miscare.ox = -1;
                    miscare.oy = 0;
                }
                else if(e.KeyCode==Keys.W)
                {
                    miscare.ox = 0;
                    miscare.oy = -1;
                }
                else if (e.KeyCode == Keys.S)
                {
                    miscare.ox = 0;
                    miscare.oy = 1;
                }
                else if (e.KeyCode == Keys.D)
                {
                    miscare.ox = 1;
                    miscare.oy = 0;
                }
            }
        }
        int k = 0;
        private void timer_miscare_Tick(object sender, EventArgs e)
        {
            
            pictureBox2.Location = new Point(pictureBox2.Location.X+miscare.ox, pictureBox2.Location.Y + miscare.oy*((height/10)/(width/20)));

            
            if (!(pictureBox2.Left < pictureBox1.Left || pictureBox2.Right > pictureBox1.Right || pictureBox2.Top < pictureBox1.Top || pictureBox2.Bottom > pictureBox1.Bottom))
            {
                int i, j;
                bool cond = false;
                if(miscare==(0,-1) || miscare==(-1,0))
                {
                    
                    
                    j = pictureBox2.Left / (width / 20) + 1;
                    i = pictureBox2.Top / (height / 10) + 1;
                    
                    int x = pictureBox2.Location.X + miscare.ox;
                    int y = pictureBox2.Location.Y + miscare.oy * ((height / 10) / (width / 20));

                    int jj = x / (width / 20) + 1;
                    int ii = y / (height / 10) + 1;

                    cond = (ii != i || jj != j);
                }
                else
                {
                    

                    j = pictureBox2.Left / (width / 20) + 1;
                    i = pictureBox2.Top / (height / 10) + 1;

                    cond= (i!=pozitie.i||j!=pozitie.j);
                }
                

                
                if(cond)
                {
                   
                    
                    k++;
                    Brush b = new SolidBrush(Color.Orange);
                    if (k >= 2)
                    {
                        b=new SolidBrush(Color.Purple);
                    }
                    int nj = j - miscare.ox ;
                    int ni = i - miscare.oy ;
                    p.FillRectangle(b, (pozitie.j-1) * (width / 20)-2, (pozitie.i-1) * (height / 10)-2, width / 20+4, height / 10+4);
                    if (ocupat[i, j] == -2)
                    {
                        sticla++;
                        label1.Text = "Sticla " + sticla.ToString();
                    }
                    if (ocupat[i, j] == -3)
                    {
                        hartie++;
                        label1.Text = "Hartie " + hartie.ToString();
                    }
                    if (ocupat[i, j] == -4)
                    {
                        plastic++;
                        label1.Text = "Plastic " + plastic.ToString();
                    }
                    if (ocupat[i, j] == 1)
                    {
                        if (miscare == (1, 0))
                        {
                            miscare = (0, 1);
                        }
                        else if (miscare == (0, -1))
                        {
                            miscare = (-1, 0);
                        }
                        else {timer_miscare.Stop(); oprit = true;}
                    }
                    if (ocupat[i,j]==2)
                    {
                        if(miscare==(0,1))
                        {
                            miscare = (-1, 0);
                        }
                        else if(miscare==(1,0))
                        {
                            miscare = (0, -1);
                        }
                        else { timer_miscare.Stop(); oprit = true; }
                    }
                    if (ocupat[i, j] == 3)
                    {
                        if (miscare == (0, 1))
                        {
                            miscare = (1, 0);
                        }
                        else if (miscare == (-1, 0))
                        {
                            miscare = (0, -1);
                        }
                        else { timer_miscare.Stop(); oprit = true; }
                    }
                    if (ocupat[i, j] == 4)
                    {
                        if (miscare == (0, -1))
                        {
                            miscare = (1, 0);
                        }
                        else if (miscare == (-1, 0))
                        {
                            miscare = (0, 1);
                        }
                        else { timer_miscare.Stop(); oprit = true; }
                    }
                    pozitie = (i, j);
                }
            }
            else            
            {
                timer_miscare.Stop();
                oprit = true;
            }
        }

        private void Form3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ok == 1)
            {
                if (e.KeyChar == 'a')
                {
                    miscare.ox = -1;
                    miscare.oy = 0;
                    poze.Start();
                }
                else if (e.KeyChar == 'w')
                {
                    miscare.ox = 0;
                    miscare.oy = -1;
                    poze.Start();
                }
                else if (e.KeyChar == 's')
                {
                    miscare.ox = 0;
                    miscare.oy = 1;
                    poze.Start();
                }
                else if (e.KeyChar == 'd')
                {
                    miscare.ox = 1;
                    miscare.oy = 0;
                    poze.Start();
                }
                ok++;
            }
        }
        (int i, int j) pozitie;
        int sticla, hartie, plastic;

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
            button4.Visible = true;
            timer_miscare.Stop();
            oprit = true;
        }
        private int nr_poze = 1;
        private Bitmap[] pz = new Bitmap[6];
        private void poze_Tick(object sender, EventArgs e)
        {
            poze.Interval = new Random().Next(5000, 15000);
            nr_poze++;
            if (nr_poze <= 4)
            {
                pz[nr_poze] = new Bitmap(width, height);
                Rectangle rect = new Rectangle(this.PointToScreen(pictureBox1.Location).X, this.PointToScreen(pictureBox1.Location).Y, width, height);
                pz[nr_poze] = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(pz[nr_poze]);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, pz[nr_poze].Size, CopyPixelOperation.SourceCopy);
                
            }
        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            if (oprit == true)
            {
                pz[5] = new Bitmap(width, height);
                Rectangle rect = new Rectangle(this.PointToScreen(pictureBox1.Location).X, this.PointToScreen(pictureBox1.Location).Y, width, height);
                pz[5] = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(pz[5]);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, pz[5].Size, CopyPixelOperation.SourceCopy);



                saveFileDialog1.DefaultExt = ".png";
                saveFileDialog1.FileName = "1.png";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path=saveFileDialog1.FileName.Substring(0,saveFileDialog1.FileName.Length-5);
                    for (int i = 1; i <= 5 ; i++)
                    {
                        if (pz[i] != null)
                        {
                            pz[i].Save(path + i.ToString() + ".png");
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

            for(int i=1;i<=10;i++)
            {
                for (int j = 1; j <= 20; j++)
                {
                    int x = j, y = i;
                    switch (ocupat[i, j])
                    {
                        case 1:
                            {
                                p.FillPolygon(new SolidBrush(Color.White), new Point[] { new Point(width / 20 * x, height / 10 * y), new Point(width / 20 * x, height / 10 * (y - 1)), new Point(width / 20 * (x - 1), height / 10 * (y - 1)) });
                                break;
                            }
                        case 2:
                            {
                                p.FillPolygon(new SolidBrush(Color.White), new Point[] { new Point(width / 20 * (x - 1), height / 10 * y), new Point(width / 20 * x, height / 10 * y), new Point(width / 20 * x, height / 10 * (y - 1)) });
                                break;
                            }
                        case 3:
                            {
                                p.FillPolygon(new SolidBrush(Color.White), new Point[] { new Point(width / 20 * (x - 1), height / 10 * (y - 1)), new Point(width / 20 * (x - 1), height / 10 * y), new Point(width / 20 * x, height / 10 * y) });
                                break;
                            }
                        case 4:
                            {
                                p.FillPolygon(new SolidBrush(Color.White), new Point[] { new Point(width / 20 * x, height / 10 * (y - 1)), new Point(width / 20 * (x - 1), height / 10 * (y - 1)), new Point(width / 20 * (x - 1), height / 10 * y) });
                                break;
                            }
                    }
                }
            }

            if (openFileDialog1.FileName != null)
            {
                StreamReader read = new StreamReader(openFileDialog1.FileName);

                string line;

                while ((line = read.ReadLine()) != null)
                {
                    string obiect = line.Split()[0];
                    int x = Convert.ToInt32(line.Split()[1]), y = Convert.ToInt32(line.Split()[2]);

                    if (obiect.Contains("Meduza"))
                    {
                        Image s = Image.FromFile(@"Meduze\" + obiect + ".png");
                        p.DrawImage(s, new Rectangle(new Point(width / 20 * x + 2, height / 10 * y + 2), new Size(width / 20 - 8, height / 10 - 8)));
                        ocupat[y + 1, x + 1] = -1;
                    }
                    else if (obiect.Contains("Sticla"))
                    {
                        Image s = Image.FromFile(@"MaterialeReciclabile\Sticla.png");
                        p.DrawImage(s, new Rectangle(new Point(width / 20 * x + 2, height / 10 * y + 2), new Size(width / 20 - 8, height / 10 - 8)));
                        ocupat[y + 1, x + 1] = -2;
                    }
                    else if (obiect.Contains("Hartie"))
                    {
                        Image s = Image.FromFile(@"MaterialeReciclabile\Hartie.png");
                        p.DrawImage(s, new Rectangle(new Point(width / 20 * x + 2, height / 10 * y + 2), new Size(width / 20 - 8, height / 10 - 8)));
                        ocupat[y + 1, x + 1] = -3;
                    }
                    else if (obiect.Contains("Plastic"))
                    {
                        Image s = Image.FromFile(@"MaterialeReciclabile\Plastic.png");
                        p.DrawImage(s, new Rectangle(new Point(width / 20 * x + 2, height / 10 * y + 2), new Size(width / 20 - 8, height / 10 - 8)));
                        ocupat[y + 1, x + 1] = -4;
                    }
                    else if (obiect.Contains("Robot"))
                    {
                        pictureBox2.Visible = true;
                        pictureBox2.Location = new Point(width / 20 * (x - 1), height / 10 * (y - 1));
                        ocupat[y, x] = -9;
                        pozitie.i = y;
                        pozitie.j = x;
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            roteste();
        }
    }
}
