using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentenarMareaUnire
{
    public partial class Form8 : Form
    {
        private List<(Point a, string b)> solutii = new List<(Point, string)>();
        private List<Point> romania = new List<Point>();
        private string[] adrese = new string[]
        {
            @"Harti\Banat.txt", 
            @"Harti\Basarabia.txt",
            @"Harti\Bucovina.txt",
            @"Harti\Crisana.txt",
            @"Harti\Dobrogea.txt",
            @"Harti\Maramures.txt",
            @"Harti\Moldova.txt",
            @"Harti\Muntenia.txt",
            @"Harti\Oltenia.txt",
            @"Harti\Transilvania.txt"
        };
        private int[] ordine = new int[] {6,1,2,5,3,9,0,8,7,4,6};
        int user;
        public Form8(int user)
        {
            InitializeComponent();
            this.user = user;

        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            StreamReader read = new StreamReader(@"Harti\RomaniaMare.txt");
            string line;

            while ((line = read.ReadLine()) != null)
            {
                romania.Add(new Point(Convert.ToInt32(line.Split('*')[0]), Convert.ToInt32(line.Split('*')[1])));
            }
            read.Dispose();

            e.Graphics.DrawPolygon(new Pen(Color.Green, 10), romania.ToArray());

            PathGradientBrush brush = new PathGradientBrush(
                romania.ToArray(),
                WrapMode.Clamp
                );
            ColorBlend colorblend = new ColorBlend();
            colorblend.Positions = new float[] { 0f, 0.5f, 1.0f };
            colorblend.Colors = new Color[] { Color.Red, Color.Yellow, Color.Blue };
            brush.InterpolationColors = colorblend;

            e.Graphics.FillPolygon(brush, romania.ToArray());


            for (int i = 0; i < adrese.Length; i++)
            {
                read = new StreamReader(adrese[i]);
                List<Point> regiune = new List<Point>();
                int k = 0;
                

                while ((line = read.ReadLine()) != null)
                {
                    if (k == 0) solutii.Add((new Point(Convert.ToInt32(line.Split('*')[0]), Convert.ToInt32(line.Split('*')[1])), line.Split('*')[2]));
                    else regiune.Add(new Point(Convert.ToInt32(line.Split('*')[0]), Convert.ToInt32(line.Split('*')[1])));
                    k++;
                }

                e.Graphics.DrawPolygon(new Pen(Color.White, 3), regiune.ToArray());

                e.Graphics.DrawEllipse(new Pen(Color.Black,3),new Rectangle(solutii[i].a.X, solutii[i].a.Y,10,10));

                e.Graphics.DrawString(solutii[i].b, new Font("Arial", 10), new SolidBrush(Color.Black), solutii[i].a.X + 10, solutii[i].a.Y);
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Graphics g = pictureBox1.CreateGraphics();
            
            
            timer1.Start();
            int k = 0;
            timer1.Interval = 15;
            timer1.Tick += (a, b) =>
            {
                
                k++;
                if(k<=10)
                {
                    g.DrawLine(new Pen(Color.Green, 5), solutii[ordine[k - 1]].a, solutii[ordine[k]].a);
                }
                timer1.Interval = 2000;
                if(k==11) button1.Enabled = true;
            };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1(user).ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
