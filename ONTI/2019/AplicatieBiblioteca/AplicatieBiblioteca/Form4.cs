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

namespace AplicatieBiblioteca
{
    public partial class Form4 : Form
    {
        public Form4(int idcarte)
        {
            InitializeComponent();

            SqlCommand cmd=new SqlCommand($"SELECT Titlu,Autor,NrPag FROM Carti WHERE IdCarte={idcarte}",Program.Globals.con);
            SqlDataReader read=cmd.ExecuteReader();
            read.Read();

            textBox1.Text = read.GetString(0);
            textBox2.Text = read.GetString(1);
            textBox3.Text = read.GetInt32(2).ToString();

            pictureBox1.BackgroundImage = Image.FromFile(@"Imagini\carti\" + idcarte.ToString() + ".jpg");
            read.Dispose();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private void P_Mare_P_Mediu_P_Mic(int niv, RectangleF sursa, RectangleF destinatie, Graphics g)
        {
            if(niv<=3)
            {
                niv++;
                g.DrawImage(pictureBox1.BackgroundImage, destinatie, sursa, GraphicsUnit.Pixel);
                float x=destinatie.X, width=destinatie.Width, y=destinatie.Y;
                //x = x - 1 / 4f * width;
                //width = width / 2;
                float x1 = x - 1 / 4f * width, x2 = x+ 3/4f * width, x3 = x1, x4 = x2;
                float y1 = y - 1 / 4f * width, y2 = y1, y3 = y + 3 / 4f * width, y4 = y3;
                RectangleF[] patru = new RectangleF[]
                {
                    new RectangleF(x1,y1,width/2,width/2),
                    new RectangleF(x2,y2,width/2,width/2),
                    new RectangleF(x3,y3,width/2,width/2),
                    new RectangleF(x4,y4,width/2,width/2)
                };
                x = sursa.X;
                y = sursa.Y;
                width=sursa.Width;

                x1 = x;
                y1 = y;
                x2 = x + width / 2;
                y2 = y;
                x3 = x;
                y3 = y + width / 2;
                x4 = x + width / 2;
                y4 = y + width / 2;

                RectangleF[] patru2 = new RectangleF[]
                {
                    new RectangleF(x1,y1,width/2,width/2),
                    new RectangleF(x2,y2,width/2,width/2),
                    new RectangleF(x3,y3,width/2,width/2),
                    new RectangleF(x4,y4,width/2,width/2)
                };
                P_Mare_P_Mediu_P_Mic(niv, patru2[0], patru[0], g);
                P_Mare_P_Mediu_P_Mic(niv, patru2[1], patru[1], g);
                P_Mare_P_Mediu_P_Mic(niv, patru2[2], patru[2], g);
                P_Mare_P_Mediu_P_Mic(niv, patru2[3], patru[3], g);
            }
        }
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            
            float width = pictureBox1.Width * zoom.Value / 100f;
            float x = 1 / 4f * width + 1 / 16f * width;

            RectangleF patrat = new RectangleF(x, x, width, width);
            P_Mare_P_Mediu_P_Mic(1, new RectangleF(0, 0, pictureBox1.Width, pictureBox1.Width), patrat, e.Graphics);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
        }

        private void zoom_ValueChanged(object sender, EventArgs e)
        {
            pictureBox2.Refresh();
        }
    }
}
