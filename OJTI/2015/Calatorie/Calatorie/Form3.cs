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

namespace Calatorie
{
    public partial class Form3 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBTimpSpatiu.mdf;Integrated Security=True;Connect Timeout=30");
        public Form3()
        {
            InitializeComponent();
        }
        private int pasi = 13, curent = 0;
        bool ok = false;
        private void button1_Click(object sender, EventArgs e)
        {
            ok = true;
            button1.Enabled = false;
            
        }
        private string[] porturi = new string[]{"Constanta","Varna","Burgas", "Istanbul", "Kozlu", "Samsun", "Batumi", "Sokhumi", "Sochi", "Anapa", "Ialta", "Sevastopol", "Odessa" };
        private List<(int, int)> coord = new List<(int, int)>();

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            
            //SqlCommand del = new SqlCommand("TRUNCATE TABLE Porturi", con);
            new SqlCommand("TRUNCATE TABLE Porturi", con).ExecuteNonQuery();
           
            for (int i=0;i<porturi.Length;i++)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Porturi VALUES(@1,@2,@3)", con);
                cmd.Parameters.AddWithValue("1", porturi[i]);
                cmd.Parameters.AddWithValue("2", coord[i].Item1);
                cmd.Parameters.AddWithValue("3", coord[i].Item2);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();

            new SqlCommand("TRUNCATE TABLE Distante",con).ExecuteNonQuery();

            StreamReader read = new StreamReader(@"Harta_Distantelor.txt");
            string line;
            int i = 0;
            while((line=read.ReadLine())!=null)
            {
                for(int j=0;j<13;j++)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Distante VALUES(@1,@2,@3,@4)", con);
                    cmd.Parameters.AddWithValue("1", i+1);
                    cmd.Parameters.AddWithValue("2", j+1);
                    cmd.Parameters.AddWithValue("3", porturi[j]);
                    cmd.Parameters.AddWithValue("4", line.Split(' ')[j]);
                    cmd.ExecuteNonQuery();
                }
                i++;
            }

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //3 zile 1-2-3-4 min 800 max 1100

            int id = 0;
            con.Open();
            new SqlCommand("TRUNCATE TABLE Croaziere", con).ExecuteNonQuery();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = i + 1; j <= 11; j++)
                {
                    for (int k = j + 1; k <= 12; k++)
                    {
                        for (int l = k + 1; l <= 13; l++)
                        {
                            int d1 = (int)new SqlCommand($"SELECT Distanta FROM Distante WHERE Id_Port={i} AND Id_Port_Destinatie={j}", con).ExecuteScalar();
                            int d2 = (int)new SqlCommand($"SELECT Distanta FROM Distante WHERE Id_Port={j} AND Id_Port_Destinatie={k}", con).ExecuteScalar();
                            int d3 = (int)new SqlCommand($"SELECT Distanta FROM Distante WHERE Id_Port={k} AND Id_Port_Destinatie={l}", con).ExecuteScalar();
                            if (d1 + d2 + d3 >= 800 && d1 + d2 + d3 <= 1100)
                            {
                                SqlCommand insert = new SqlCommand("INSERT INTO Croaziere(Id_Croaziera,Tip_Croaziera,Lista_Porturi,Pret) VALUES(@1,@2,@3,@4)", con);
                                insert.Parameters.AddWithValue("1", ++id);
                                insert.Parameters.AddWithValue("2", 3);
                                insert.Parameters.AddWithValue("3", i.ToString() + " " + j.ToString() + " " + k.ToString() + " " + l.ToString() + " " + i.ToString()); ;
                                insert.Parameters.AddWithValue("4", (d1 + d2 + d3) * 2);
                                insert.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            // 5 min 800 max 1600
            for (int i = 1; i <= 8; i++)
            {
                for (int j = i + 1; j <= 9; j++)
                {
                    for (int k = j + 1; k <= 10; k++)
                    {
                        for (int l = k + 1; l <= 11; l++)
                        {
                            for (int m = l + 1; m <= 12; m++)
                            {
                                for (int n = m + 1; n <= 13; n++)
                                {
                                    int d1 = (int)new SqlCommand($"SELECT Distanta FROM Distante WHERE Id_Port={i} AND Id_Port_Destinatie={j}", con).ExecuteScalar();
                                    int d2 = (int)new SqlCommand($"SELECT Distanta FROM Distante WHERE Id_Port={j} AND Id_Port_Destinatie={k}", con).ExecuteScalar();
                                    int d3 = (int)new SqlCommand($"SELECT Distanta FROM Distante WHERE Id_Port={k} AND Id_Port_Destinatie={l}", con).ExecuteScalar();
                                    int d4 = (int)new SqlCommand($"SELECT Distanta FROM Distante WHERE Id_Port={l} AND Id_Port_Destinatie={m}", con).ExecuteScalar();
                                    int d5 = (int)new SqlCommand($"SELECT Distanta FROM Distante WHERE Id_Port={m} AND Id_Port_Destinatie={n}", con).ExecuteScalar();
                                    int s = d1 + d2 + d3 + d4 + d5;
                                    if (s >= 800 && s <= 1600)
                                    {
                                        SqlCommand insert = new SqlCommand("INSERT INTO Croaziere(Id_Croaziera,Tip_Croaziera,Lista_Porturi,Pret) VALUES(@1,@2,@3,@4)", con);
                                        insert.Parameters.AddWithValue("1", ++id);
                                        insert.Parameters.AddWithValue("2", 5);
                                        insert.Parameters.AddWithValue("3", i.ToString() + " " + j.ToString() + " " + k.ToString() + " " + l.ToString() + " " + m.ToString() + " " + n.ToString() + " " + i.ToString()); ;
                                        insert.Parameters.AddWithValue("4", (s) * 2);
                                        insert.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
            }
                for (int i = 1; i <= 5; i++)
                {
                    for (int j = i + 1; j <= 6; j++)
                    {
                        for (int k = j + 1; k <=7; k++)
                        {
                            for (int l = k + 1; l <= 8; l++)
                            {
                                for (int m = l + 1; m <= 9; m++)
                                {
                                    for (int n = m + 1; n <= 10; n++)
                                    {
                                        for(int o=n+1;o<=11;o++)
                                        {
                                            for(int p=o+1;p<=12;p++)
                                            {
                                                for(int q=1;q<=13;q++)
                                                {
                                                int d1 = (int)new SqlCommand($"SELECT Distanta FROM Distante WHERE Id_Port={i} AND Id_Port_Destinatie={j}", con).ExecuteScalar();
                                                int d2 = (int)new SqlCommand($"SELECT Distanta FROM Distante WHERE Id_Port={j} AND Id_Port_Destinatie={k}", con).ExecuteScalar();
                                                int d3 = (int)new SqlCommand($"SELECT Distanta FROM Distante WHERE Id_Port={k} AND Id_Port_Destinatie={l}", con).ExecuteScalar();
                                                int d4 = (int)new SqlCommand($"SELECT Distanta FROM Distante WHERE Id_Port={l} AND Id_Port_Destinatie={m}", con).ExecuteScalar();
                                                int d5 = (int)new SqlCommand($"SELECT Distanta FROM Distante WHERE Id_Port={m} AND Id_Port_Destinatie={n}", con).ExecuteScalar();
                                                int d6 = (int)new SqlCommand($"SELECT Distanta FROM Distante WHERE Id_Port={n} AND Id_Port_Destinatie={o}", con).ExecuteScalar();
                                                int d7 = (int)new SqlCommand($"SELECT Distanta FROM Distante WHERE Id_Port={o} AND Id_Port_Destinatie={p}", con).ExecuteScalar();
                                                int d8 = (int)new SqlCommand($"SELECT Distanta FROM Distante WHERE Id_Port={p} AND Id_Port_Destinatie={q}", con).ExecuteScalar();

                                                int s = d1 + d2 + d3 + d4 + d5+d6+d7+d8;
                                                if (s >= 800 && s <= 1900)
                                                {
                                                    SqlCommand insert = new SqlCommand("INSERT INTO Croaziere(Id_Croaziera,Tip_Croaziera,Lista_Porturi,Pret) VALUES(@1,@2,@3,@4)", con);
                                                    insert.Parameters.AddWithValue("1", ++id);
                                                    insert.Parameters.AddWithValue("2", 8);
                                                    insert.Parameters.AddWithValue("3", i.ToString() + " " + j.ToString() + " " + k.ToString() + " " + l.ToString() + " " + m.ToString() + " " + n.ToString() + " " + o.ToString() + " " + p.ToString() + " " + q.ToString() + " " + i.ToString()); ;
                                                    insert.Parameters.AddWithValue("4", (s) * 2);
                                                    insert.ExecuteNonQuery();
                                                }
                                            }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 frm5 = new Form5();
            frm5.MdiParent = this.MdiParent;
            //frm5.Owner = this.MdiParent;
            frm5.Show();
            this.Close();
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if(ok==true)
            {
                if (curent <= 13)
                {
                    coord.Add(((int)e.X, (int)e.Y));
                    curent++;
                }
                if (curent == 13)
                {
                    MessageBox.Show("Coordonate memorate!");
                    ok = false;
                    button1.Enabled = true;
                }
            }
            
        }
    }
}
