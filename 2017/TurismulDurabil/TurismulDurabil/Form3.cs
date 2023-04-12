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

namespace TurismulDurabil
{
    public partial class Form3 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Turism.mdf;Integrated Security=True;Connect Timeout=30");

        public Form3()
        {
            InitializeComponent();
            dtgrid1();
            
        }
        private void dtgrid1()
        {
            con.Open();
            dataGridView1.Rows.Clear();
            SqlCommand select = new SqlCommand("SELECT Nume,DataStart,DataStop,Frecventa,Ziua FROM Planificari INNER JOIN Localitati ON Localitati.IdLocalitate=Planificari.IdLocalitate",con);
            SqlDataReader read = select.ExecuteReader();
            while(read.Read())
            {
                string a = read.GetString(0), b, c, d = read.GetString(3), e;
                e=read.IsDBNull(4)? null:read.GetInt32(4).ToString();
                b = read.IsDBNull(1) ? null : read.GetDateTime(1).ToString("dd/MM/yyyy");
                c = read.IsDBNull(2) ? null : read.GetDateTime(2).ToString("dd/MM/yyyy");
                dataGridView1.Rows.Add(a,b,c,d,e);
            }
            con.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void dtgrid2()
        {
            
            con.Open();
            dataGridView2.Rows.Clear();
            DateTime inceput = dateTimePicker1.Value.Date;
            DateTime final = dateTimePicker2.Value.Date;
            SqlCommand select = new SqlCommand("SELECT Nume,DataStart,DataStop,Frecventa,Ziua FROM Planificari INNER JOIN Localitati ON Localitati.IdLocalitate=Planificari.IdLocalitate", con);
            
            SqlDataReader read = select.ExecuteReader();
            while (read.Read())
            {
                if (read.GetString(3)=="ocazional")
                {
                    if(read.GetDateTime(1)>=inceput&& read.GetDateTime(2)<=final)
                        dataGridView2.Rows.Add(read.GetString(0), read.GetDateTime(1).ToString("dd/MM/yyyy"), read.GetDateTime(2).ToString("dd/MM/yyyy"), read.GetString(3));
                    else if(read.GetDateTime(1) < inceput && read.GetDateTime(2) >= inceput && read.GetDateTime(2) <= final)
                        dataGridView2.Rows.Add(read.GetString(0), inceput.ToString("dd/MM/yyyy"), read.GetDateTime(2).ToString("dd/MM/yyyy"), read.GetString(3));

                }
                else if (read.GetString(3) == "anual")
                {
                    DateTime data;
                    
                    DateTime an_nou = Convert.ToDateTime("1.01.2017");
                    
                    data = an_nou.AddDays(read.GetInt32(4) - 1);
                    if (data >= inceput)
                        dataGridView2.Rows.Add(read.GetString(0), data.ToString("dd/MM/yyyy"), data.ToString("dd/MM/yyyy"), read.GetString(3));
                    

                }
                else if (read.GetString(3) == "lunar")
                {
                    DateTime data;
                    for(int i=1;i<=12;i++)
                    {
                        try
                        {
                            data = Convert.ToDateTime(Convert.ToString(read.GetInt32(4)) + "." + Convert.ToString(i) + ".2017");
                        }
                        catch 
                        { 
                            continue; 
                        }
                        if(data>inceput &&data<final)
                        {
                            dataGridView2.Rows.Add(read.GetString(0), data.ToString("dd/MM/yyyy"), data.ToString("dd/MM/yyyy"), read.GetString(3));
                        }
                    }
                }
            }
            con.Close();
            
        }
        private void dtgrid3()
        {
            dataGridView3.Rows.Clear();

            DateTime inceput = dateTimePicker1.Value;
            DateTime final = dateTimePicker2.Value;
            DateTime zi=inceput; 
            
            while(zi<=final)
            {
                int max = dataGridView2.Rows.Count;
                for(int i=0;i<max;i++)
                {
                    if (Convert.ToDateTime(dataGridView2[1, i].Value) <= zi && zi <=Convert.ToDateTime(dataGridView2[2, i].Value))
                    {
                        dataGridView3.Rows.Add(dataGridView2[0,i].Value, zi.ToString("dd/MM/yyyy"));
                    }
                }
                zi=zi.AddDays(1);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            timer.Stop();
            init_cnt();
            dtgrid2();
            dtgrid3();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        private int[] cnt=new int[100];
        private void init_cnt()
        {
            
            progressBar1.Maximum = (int)dataGridView3.Rows.Count;
            progressBar1.Minimum = 1;
        }
        private Timer timer = new Timer();
        private void button2_Click(object sender, EventArgs e)
        {
            init_cnt();
            button2.Visible = false; 
            button3.Visible = true;
            timer.Interval = 1;
            int i = 0;
            timer.Start();
            
            timer.Tick += (s, d) =>
            {
                if(progressBar1.Value<progressBar1.Maximum)
                {
                    progressBar1.Value += 1;
                    label3.Text = dataGridView3[0, i].Value.ToString();
                    label4.Text = dataGridView3[1, i].Value.ToString();


                    con.Open();
                    SqlCommand img = new SqlCommand("SELECT Nume,CaleFisier,IdImagine FROM Imagini INNER JOIN Localitati ON Localitati.IdLocalitate=Imagini.IdLocalitate WHERE Nume=@1", con);
                    //
                    img.Parameters.AddWithValue("1", dataGridView3[0, i].Value.ToString());
                    SqlDataReader read = img.ExecuteReader();
                    bool ok = false;
                    while (read.Read())
                    {
                        if (cnt[read.GetInt32(2)] == 0)
                        {
                            cnt[read.GetInt32(2)] = 1;
                            pictureBox1.BackgroundImage = Image.FromFile(read.GetString(1));
                            ok = true;
                            break;
                        }
                    }
                    read.Close();
                    if (!ok)
                    {
                        SqlCommand img2 = new SqlCommand("SELECT Nume,CaleFisier,IdImagine FROM Imagini INNER JOIN Localitati ON Localitati.IdLocalitate=Imagini.IdLocalitate WHERE Nume=@1", con);
                        img2.Parameters.AddWithValue("1", dataGridView3[0, i].Value.ToString());
                        SqlDataReader read2 = img2.ExecuteReader();
                        while (read2.Read())
                        {
                            cnt[read2.GetInt32(2)] = 0;
                        }
                        read2.Close();
                    }
                    i++;
                    con.Close();
                    timer.Interval = 2000;
                }
                else
                {
                    progressBar1.Value = 1;
                    i = 0;
                }
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button2.Visible = true;
            timer.Stop();

        }
    }
}
