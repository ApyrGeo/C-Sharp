using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class Form4 : Form
    {
        private int caz,I;
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\geose\OneDrive\Desktop\Olimpiada C#\2013\Puzzle\Puzzle\bin\Debug\a.mdf"";Integrated Security=True;Connect Timeout=30");
        private string nume;
        public Form4(int i,string nume)
        {
            InitializeComponent();
            this.nume = nume;
            I = i;
            if (i == 4 || i == 6)
            {
                caz = 3;
                caz3();
            }
            else caz = 9;

            mat3 = new PictureBox[] { t1, t2, t3, t4 };
        }
        
        private void t4_Click(object sender, EventArgs e)
        {
            
        }
        int selected=-1;
        int start = 0;
        private Stopwatch t = new Stopwatch();
        private bool valid3()
        {
            for(int i=0;i<4;i++)
            {
                int j = mat3[i].ImageLocation.Length - 1;
                while (mat3[i].ImageLocation[j] != '.') --j;
                --j;
                int img = (mat3[i].ImageLocation[j] - '0') + (mat3[i].ImageLocation[j - 2] - '0') * 2;

                if (img !=i)
                {
                    return false;
                }
            }
            return true;
        }
        private PictureBox[] mat3 ;
        private void PictureBox_Click(object sender, EventArgs e)
        {
            start ++;
            int now;
            now = Array.IndexOf(mat3, sender as PictureBox);

            if(selected==-1)
            {
                selected = now;
            }
            else
            {
                var loc = mat3[selected].Location;
                mat3[selected].Location=(sender as PictureBox).Location;
                (sender as PictureBox).Location = loc;

                PictureBox tmp = mat3[selected];
                mat3[selected] = mat3[now];
                mat3[now] = tmp;

                selected = -1;
                string result = "";
                foreach (PictureBox pb in mat3)
                {
                    int j = pb.ImageLocation.Length - 1;
                    while (pb.ImageLocation[j] != '.') --j;
                    --j;
                    int img = (pb.ImageLocation[j] - '0') + (pb.ImageLocation[j - 2] - '0') * 2;
                    result += img.ToString();
                }
                MessageBox.Show(result);
            }
            if(valid3()==true)
            {
                t.Stop();

                MessageBox.Show(nume+'\n'+t.Elapsed.ToString()+"\n3");
                con.Open();
                new SqlCommand($"INSERT INTO Clasament VALUES('{nume}',{t.Elapsed.Seconds}+':'+{t.Elapsed.Milliseconds},3)", con).ExecuteNonQuery();
                con.Close();

            }
            if(start==1)
            {
                t.Start();
            }
        }

        private void caz3()
        {
            int[] fol = new int[5];

            t1.Visible = true;
            t2.Visible = true;
            t3.Visible = true;
            t4.Visible = true;

            for (int i=0;i<=1;i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    Random x=new Random();
                    int v = x.Next(1, 5);
                    while (fol[v]!=0)
                    {
                        v = x.Next(1, 5);
                    }
                    fol[v]++;

                    if(v==1)
                    {
                        t1.ImageLocation =@"Img\image" + I.ToString() + @"\image" + I.ToString() + " [www.imagesplitter.net]-" + i.ToString() + "-" + j.ToString() + ".jpeg";
                        t1.Click += new EventHandler(PictureBox_Click);
                    }
                    if (v == 2)
                    {
                        t2.ImageLocation = @"Img\image" + I.ToString() + @"\image" + I.ToString() + " [www.imagesplitter.net]-" + i.ToString() + "-" + j.ToString() + ".jpeg";
                        t2.Click += new EventHandler(PictureBox_Click);
                    }
                    if (v == 3)
                    {
                        t3.ImageLocation = @"Img\image" + I.ToString() + @"\image" + I.ToString() + " [www.imagesplitter.net]-" + i.ToString() + "-" + j.ToString() + ".jpeg";
                        t3.Click += new EventHandler(PictureBox_Click);
                    }
                    if (v == 4)
                    {
                        t4.ImageLocation = @"Img\image" + I.ToString() + @"\image" + I.ToString() + " [www.imagesplitter.net]-" + i.ToString() + "-" + j.ToString() + ".jpeg";
                        t4.Click += new EventHandler(PictureBox_Click);
                    }
                }
            }
        }
    }
}
