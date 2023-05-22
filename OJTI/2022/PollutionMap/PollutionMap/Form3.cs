using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollutionMap
{
    public partial class Form3 : Form
    {
        
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\Poluare.mdf"";Integrated Security=True;Connect Timeout=30");
        public Form3()
        {
            
            InitializeComponent();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;//
            comboBox1.Items.Add("Selecteaza o harta");//
            comboBox1.SelectedIndex = 0;//

            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;//
            comboBox2.SelectedIndex = 0;//

            con.Open();
            SqlCommand comanda = new SqlCommand("SELECT NumeHarta FROM Harti", con);
            var read=comanda.ExecuteReader();
            while(read.Read())
            {
                comboBox1.Items.Add(read.GetString(0));
            }
            read.Dispose();
            con.Close();
            
            
        }
        
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
            if ((string)comboBox1.SelectedItem=="Selecteaza o harta"|| (string)comboBox1.SelectedItem == null)
            {
                pictureBox1.Image = Image.FromFile(@"Harti\default_harta.png");
            }
            else
            {
                con.Open();
                SqlCommand harta = new SqlCommand("SELECT FisierHarta FROM Harti WHERE NumeHarta=@1", con);
                harta.Parameters.AddWithValue("1", comboBox1.SelectedItem);

                string nume = (string)harta.ExecuteScalar();
                
                pictureBox1.Image = Image.FromFile(nume);
                pictureBox2.Image = Image.FromFile(nume);

                con.Close();
            }
            
            puncte();
            
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
            puncte();
        }
        
        private void puncte()
        {
            Graphics g = pictureBox1.CreateGraphics();
            Graphics gg= pictureBox2.CreateGraphics();
            g.Clear(Color.White);
            pictureBox1.Refresh();
            gg.Clear(Color.White);
            pictureBox2.Refresh();
            if (comboBox1.SelectedIndex!= 0)
            {

                con.Open();
                SqlCommand din_harti = new SqlCommand("SELECT IdHarta FROM Harti WHERE NumeHarta=@1", con);
                din_harti.Parameters.AddWithValue("1", comboBox1.SelectedItem);


                SqlCommand din_masurari = new SqlCommand("SELECT PozitieX,PozitieY,ValoareMasurare,DataMasurare FROM Masurare WHERE IdHarta=@1", con);
                din_masurari.Parameters.AddWithValue("1", (int)din_harti.ExecuteScalar());
                din_masurari.Parameters.AddWithValue("2", dateTimePicker1.Value);
                var read = din_masurari.ExecuteReader();
                while (read.Read())
                {
                    int x = read.GetInt32(0);
                    int y = read.GetInt32(1);
                    double val = read.GetDouble(2);
                    if(read.GetDateTime(3).Date==dateTimePicker1.Value.Date)
                    {
                        double X= (float)(pictureBox1.Width) / (float)(pictureBox1.BackgroundImage.Width) * (float)(x);
                        double Y= (float)(pictureBox1.Height) / (float)(pictureBox1.BackgroundImage.Height) * (float)(y);

                        
                        Pen pen= new Pen(Color.Black,1);
                        if(!e_filtrat)
                        {
                            if (val < 20)
                            {
                                pen = new Pen(Color.Green, 3);
                                g.DrawString(Convert.ToString(val), new Font("Arial", 12), new SolidBrush(Color.Green), (float)X, (float)Y);
                                gg.DrawString(Convert.ToString(val), new Font("Arial", 12), new SolidBrush(Color.Green), (float)X, (float)Y);

                            }

                            if (val > 40)
                            {
                                pen = new Pen(Color.Red, 3);
                                g.DrawString(Convert.ToString(val), new Font("Arial", 12), new SolidBrush(Color.Red), (float)X, (float)Y);
                                gg.DrawString(Convert.ToString(val), new Font("Arial", 12), new SolidBrush(Color.Red), (float)X, (float)Y);

                            }
                            if (val >= 20 && val <= 40)
                            {
                                pen = new Pen(Color.Yellow, 3);
                                g.DrawString(Convert.ToString(val), new Font("Arial", 12), new SolidBrush(Color.Yellow), (float)X, (float)Y);
                                gg.DrawString(Convert.ToString(val), new Font("Arial", 12), new SolidBrush(Color.Yellow), (float)X, (float)Y);

                            }
                            g.DrawEllipse(pen, (float)X, (float)Y, 20, 20);
                            gg.DrawEllipse(pen, (float)X, (float)Y, 20, 20);

                        }
                        else 
                        {
                            if(comboBox2.SelectedIndex==1 && val < 20)
                            {
                                pen = new Pen(Color.Green, 3);
                                g.DrawString(Convert.ToString(val), new Font("Arial", 12), new SolidBrush(Color.Green), (float)X, (float)Y);
                                g.DrawEllipse(pen, (float)X, (float)Y, 20, 20);
                            }
                            else if(comboBox2.SelectedIndex==2 && val >= 20 && val<=40)
                            {
                                pen = new Pen(Color.Yellow, 3);  
                                g.DrawString(Convert.ToString(val), new Font("Arial", 12), new SolidBrush(Color.Yellow), (float)X, (float)Y);
                                g.DrawEllipse(pen, (float)X, (float)Y, 20, 20);
                            }
                            else if(comboBox2.SelectedIndex==3 && val > 40)
                            {
                                pen = new Pen(Color.Red, 3);
                                g.DrawString(Convert.ToString(val), new Font("Arial", 12), new SolidBrush(Color.Red), (float)X, (float)Y);
                                g.DrawEllipse(pen, (float)X, (float)Y, 20, 20);
                            }
                            
                        }
                    }
                    
                }
                con.Close();
            }
            
        }
        private bool e_filtrat = false;
        private void button1_Click(object sender, EventArgs e)
        {
            e_filtrat = true;
            if (comboBox2.SelectedIndex == 0)
            {
                MessageBox.Show("Niciun filtru aplicat!"); 
                puncte(); 
            }
            else
            {
                button2.Visible = true;
                button2.Enabled = true;
                button1.Visible = false;
                button1.Enabled = false;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            e_filtrat = false;
            comboBox2.SelectedIndex = 0;
            button1.Visible = true;
            button1.Enabled = true;
            button2.Visible = false;
            button2.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            puncte();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(comboBox1.SelectedIndex!=0)
            {
                float x = e.X;
                float y = e.Y;
                x = (float)(pictureBox1.BackgroundImage.Width) / (float)(pictureBox1.Width) * (float)(x);
                y = (float)(pictureBox1.BackgroundImage.Height) / (float)(pictureBox1.Height) * (float)(y);
                con.Open();

                SqlCommand read = new SqlCommand("SELECT PozitieX,PozitieY FROM Masurare WHERE IdHarta=@1", con);
                SqlCommand adresa = new SqlCommand("SELECT IdHarta FROM Harti WHERE NumeHarta=@1", con);
                adresa.Parameters.AddWithValue("1", comboBox1.SelectedItem);
                int id = (int)adresa.ExecuteScalar();
                read.Parameters.AddWithValue("1", id);
                var citire = read.ExecuteReader();
                bool ok = true;
                while (citire.Read())
                {
                    int x_tabel = citire.GetInt32(0);
                    int y_tabel = citire.GetInt32(1);
                    
                    if (x >= x_tabel && x <= x_tabel + 20)
                    {
                        if (y >= y_tabel && y <= y_tabel + 20)
                        {
                            ok = false;
                        }
                    }
                }
                con.Close();
                if (ok)
                {
                    Form4 frm4 = new Form4();
                    frm4.ShowDialog();
                    con.Open();
                    SqlCommand inserare = new SqlCommand("INSERT INTO Masurare VALUES(@1,@2,@3,@4,@5)", con);
                    inserare.Parameters.AddWithValue("1", id);
                    inserare.Parameters.AddWithValue("2", x);
                    inserare.Parameters.AddWithValue("3", y);
                    inserare.Parameters.AddWithValue("4", frm4.valoare_introdusa);
                    inserare.Parameters.AddWithValue("5", dateTimePicker1.Value.Date + DateTime.Now.TimeOfDay);
                    inserare.ExecuteNonQuery();
                    con.Close();
                    puncte();
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult a=MessageBox.Show("Doresti sa parasesti aplicatia?","Parasire aplicatie", MessageBoxButtons.YesNo);
            if (a == DialogResult.Yes) Application.Exit();
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox2.Refresh();
            puncte();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }
        private (double,double) selectare(List<(float,float,double)> a)
        {
            double max1 = -1;
            double max2 = -1;

            foreach (var item in a) 
            {
                if (item.Item3 > max1)
                {
                    max2 = max1;
                    max1 = item.Item3;
                    
                }
                else if (item.Item3 > max2)
                {
                    max2 = item.Item3;
                }
            }
            return (max1,max2);
        }
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
                float x = e.X;
                float y = e.Y;
                x = (float)(pictureBox1.BackgroundImage.Width) / (float)(pictureBox1.Width) * (float)(x);
                y = (float)(pictureBox1.BackgroundImage.Height) / (float)(pictureBox1.Height) * (float)(y);
                con.Open();

                SqlCommand read = new SqlCommand("SELECT PozitieX,PozitieY,DataMasurare,ValoareMasurare FROM Masurare WHERE IdHarta=@1", con);
                SqlCommand adresa = new SqlCommand("SELECT IdHarta FROM Harti WHERE NumeHarta=@1", con);
                adresa.Parameters.AddWithValue("1", comboBox1.SelectedItem);
                int id = (int)adresa.ExecuteScalar();
                read.Parameters.AddWithValue("1", id);
                var citire = read.ExecuteReader();
                bool ok = true;
                int index = -1;
                List<(float, float, double)> v = new List<(float, float, double)>();
                while (citire.Read())
                {
                    int x_tabel = citire.GetInt32(0);
                    int y_tabel = citire.GetInt32(1);
                    if (citire.GetDateTime(2).Date == dateTimePicker1.Value.Date)
                    {
                        v.Add((x_tabel, y_tabel, citire.GetDouble(3)));
                        if ((x >= x_tabel && x <= x_tabel + 20))
                        {
                            if ((y >= y_tabel && y <= y_tabel + 20))
                            {
                                index = v.Count() - 1;
                            }
                        }
                    }
                }

                con.Close();
                if (index == -1 || index != -1 && (v[index].Item3 < 40))
                {
                    MessageBox.Show("Eroare!");
                    return;
                }
                var (mx1, mx2) = selectare(v);
                if (mx1 == -1 || mx2 == -1)
                {
                    MessageBox.Show("Eroare!"); 
                    return;
                }
                (int, int, int) traseu;
                traseu = (0, 0, 0);
                double lungime= double.MaxValue;

                for(int i=0;i<v.Count(); i++)
                {
                    for(int j=0;j<v.Count(); j++)
                    {
                        bool okay = false;
                        if (i == j) continue;
                        if (v[i].Item3 < v[j].Item3)
                        {
                            if (v[i].Item3==mx2 && v[j].Item3==mx1)
                            {
                                okay = true;
                            }
                        }
                        else
                        {
                            if (v[j].Item3 == mx2 && v[i].Item3 == mx1)
                            {
                                okay = true;
                            }
                        }
                        if (okay)
                        {
                            double lungime_curent = Math.Sqrt((v[i].Item1 - v[j].Item1) * (v[i].Item1 - v[j].Item1) + (v[i].Item2 - v[j].Item2) * (v[i].Item2 - v[j].Item2));
                            lungime_curent += Math.Sqrt((v[index].Item1 - v[i].Item1) * (v[index].Item1 - v[i].Item1) + (v[index].Item2 - v[i].Item2) * (v[index].Item2 - v[i].Item2));
                            if (lungime_curent < lungime)
                            {
                                lungime = lungime_curent;
                                traseu = (index, i, j);
                            }
                        }
                    }
                }

                Graphics a=pictureBox2.CreateGraphics();
                puncte();

                float r1 = (float)(pictureBox1.Width) / (float)(pictureBox1.BackgroundImage.Width) ;
                float r2 = (float)(pictureBox1.Height) / (float)(pictureBox1.BackgroundImage.Height) ;

                Pen pensula = new Pen(Color.Red,2);
                
                float x1 = r1 * v[traseu.Item1].Item1,x2=r1*v[traseu.Item2].Item1,y1=r2*v[traseu.Item1].Item2,y2=r2*v[traseu.Item2].Item2;
                a.DrawLine(pensula,x1,y1,x2,y2);    
                Timer timer = new Timer();
                timer.Interval = 1000;
                bool timer_oprit = false;
                timer.Tick += (s,b) => { timer_oprit = true; timer.Stop(); };
                timer.Start();
                while(!timer_oprit)
                {
                    Application.DoEvents();
                }
                float x3 = r1 * v[traseu.Item3].Item1, y3 = r2 * v[traseu.Item3].Item2;
                a.DrawLine(pensula, x2, y2, x3, y3);
            }
        }
    }
}
