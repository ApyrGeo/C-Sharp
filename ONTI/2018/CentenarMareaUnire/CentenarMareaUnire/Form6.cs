using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentenarMareaUnire
{
    public partial class Form6 : Form
    {
        private List<Point> romania=new List<Point>();
        private int user;
        public Form6(int user)
        {
            InitializeComponent();
            
            this.user= user;
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        private List<(Point a,string b)> solutii=new List<(Point,string)>();
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
            ColorBlend colorblend=new ColorBlend();
            colorblend.Positions =new float[]{ 0f,0.5f,1.0f};
            colorblend.Colors = new Color[] {Color.Red, Color.Yellow, Color.Blue };
            brush.InterpolationColors = colorblend;
           
            e.Graphics.FillPolygon(brush, romania.ToArray());


            for(int i=0;i<adrese.Length;i++)
            {
                read=new StreamReader(adrese[i]);
                List<Point> regiune = new List<Point>();
                int k = 0;
                while((line=read.ReadLine()) != null)
                {
                    if (k == 0) solutii.Add((new Point(Convert.ToInt32(line.Split('*')[0]), Convert.ToInt32(line.Split('*')[1])), line.Split('*')[2]));
                    else regiune.Add(new Point(Convert.ToInt32(line.Split('*')[0]), Convert.ToInt32(line.Split('*')[1])));
                    k++;
                }

                e.Graphics.DrawPolygon(new Pen(Color.White, 3), regiune.ToArray());
            }

        }
        private TextBox[] capitale=new TextBox[10];
        int punctaj;
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            for(int i=0;i<10;i++)
            {
                capitale[i] = new TextBox();
                capitale[i].Width = 100;
                pictureBox1.Controls.Add(capitale[i]);
                capitale[i].Location = solutii[i].a;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i=0;i<10;i++)
            {
                capitale[i].ReadOnly = true;
                if (capitale[i].Text == solutii[i].b)
                    punctaj++;
                else
                {
                    TextBox a = new TextBox();
                    a.Location = new Point (solutii[i].a.X, solutii[i].a.Y+30);
                    a.Width = 100;
                    a.ReadOnly= true;
                    pictureBox1.Controls.Add(a);
                    a.Text = solutii[i].b;
                }

            }
            textBox1.Text = punctaj.ToString();
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form7(user, Convert.ToInt32(textBox1.Text)).Show() ;
        }
    }
}
