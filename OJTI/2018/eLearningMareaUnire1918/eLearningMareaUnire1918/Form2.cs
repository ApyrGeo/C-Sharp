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

namespace eLearningMareaUnire1918
{
    public partial class Form2 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\geose\OneDrive\Desktop\Olimpiada C#\2018\eLearningMareaUnire1918\eLearningMareaUnire1918\bin\Debug\eLearning1918.mdf"";Integrated Security=True;Password=***********;Connect Timeout=30");

        int[] ales = new int[33];
        int IDelev;
        public Form2(int id)
        {
            InitializeComponent();
            for (int i = 1; i < 33; i++)
                ales[i] = 0;
            IDelev = id;
            graph();
            grid();
            con.Open();
            SqlCommand nume = new SqlCommand(@"SELECT NumePrenumeUtilizator FROM ""Tabela Utilizatori"" WHERE IdUtilizator=@1", con);
            nume.Parameters.AddWithValue("1", IDelev);
            label4.Text = "Carnetul de note al elevului " + nume.ExecuteScalar();
            con.Close();
        }
        private int caz = 0;
        private void caz1()
        {
            caz = 1;
            labelA.Visible = true;
            textboxA.Visible = true;

            raspunsaB.Visible = false;
            raspunsbB.Visible = false;
            raspunscB.Visible = false;
            raspunsdB.Visible = false;

            raspunsaC.Visible = false;
            raspunsbC.Visible = false;
            raspunscC.Visible = false;
            raspunsdC.Visible = false;

            raspunsaD.Visible = false;
            raspunsbD.Visible = false;
        }
        private void caz3()
        {
            caz = 3;
            labelA.Visible = false;
            textboxA.Visible = false;

            raspunsaB.Visible = true;
            raspunsbB.Visible = true;
            raspunscB.Visible = true;
            raspunsdB.Visible = true;

            raspunsaC.Visible = false;
            raspunsbC.Visible = false;
            raspunscC.Visible = false;
            raspunsdC.Visible = false;

            raspunsaD.Visible = false;
            raspunsbD.Visible = false;
        }
        private void caz2()
        {
            caz = 2;
            labelA.Visible = false;
            textboxA.Visible = false;

            raspunsaB.Visible = false;
            raspunsbB.Visible = false;
            raspunscB.Visible = false;
            raspunsdB.Visible = false;

            raspunsaC.Visible = true;
            raspunsbC.Visible = true;
            raspunscC.Visible = true;
            raspunsdC.Visible = true;

            raspunsaD.Visible = false;
            raspunsbD.Visible = false;
        }
        private void caz4()
        {
            caz = 4;
            labelA.Visible = false;
            textboxA.Visible = false;

            raspunsaB.Visible = false;
            raspunsbB.Visible = false;
            raspunscB.Visible = false;
            raspunsdB.Visible = false;

            raspunsaC.Visible = false;
            raspunsbC.Visible = false;
            raspunscC.Visible = false;
            raspunsdC.Visible = false;

            raspunsaD.Visible = true;
            raspunsbD.Visible = true;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void raspunsbD_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void raspunsaD_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void raspunsdC_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void raspunscC_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void raspunsbC_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void raspunsdB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void raspunscB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void raspunsbB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void raspunsaB_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void grid()
        {
            dataGridView1.Rows.Clear();

            con.Open();
            SqlCommand tabel = new SqlCommand($@"SELECT NotaEvaluare,DataEvaluare FROM ""Tabela Evaluari"" WHERE IdElev={IDelev}", con);
            SqlDataReader read = tabel.ExecuteReader();
            while (read.Read())
            {
                dataGridView1.Rows.Add(read.GetInt32(0),read.GetDateTime(1));
            }
            con.Close();
        }
        private void graph()
        {
            chart1.Series["evolutie"].Points.Clear();
            chart1.Series["medie"].Points.Clear();
            int p = 0;
            con.Open();
            SqlCommand select = new SqlCommand(@"SELECT NotaEvaluare FROM ""Tabela Evaluari"" WHERE IdElev=@1 ORDER BY DataEvaluare", con);
           
            select.Parameters.AddWithValue("1", IDelev);
            SqlDataReader read= select.ExecuteReader();
            while(read.Read())
            {
                
                ++p;
                chart1.Series["evolutie"].Points.AddXY(p, read.GetInt32(0));
            }
            read.Dispose();
            select = new SqlCommand(@"SELECT COUNT(NotaEvaluare),AVG(NotaEvaluare) FROM ""Tabela Evaluari""", con);
            read= select.ExecuteReader();
            read.Read();
            for(int i=1;i<=read.GetInt32(0);i++)
            {
                chart1.Series["medie"].Points.AddXY(i, read.GetInt32(1));
            }
            con.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        
        int k = 0, indice_curent = 0;
        private void generare(int k)
        {
            button3.Enabled = false;
            button2.Enabled = true;
            if (k <= 9)
            {
                {
                    textboxA.Text = "";
                    raspunsaB.Checked = false;
                    raspunsbB.Checked = false;
                    raspunscB.Checked = false;
                    raspunsdB.Checked = false;
                    raspunsaC.Checked = false;
                    raspunsbC.Checked = false;
                    raspunscC.Checked = false;
                    raspunsdC.Checked = false;
                    raspunsaD.Checked = false;
                    raspunsbD.Checked = false;
                }
                con.Open();
                label3.Text = "Item nr. " + Convert.ToString(k);
                int val = 0;
                do
                {
                    Random r = new Random();
                    val = r.Next(1, 33);
                } while (ales[val] == 1);
                ales[val] = 1;
                indice_curent = val;

                SqlCommand select = new SqlCommand(@"SELECT * FROM ""Tabela Itemi"" WHERE IdItem=@1", con);
                select.Parameters.AddWithValue("1", val);
                SqlDataReader read = select.ExecuteReader();
                read.Read();
                textBox1.Text = read.GetString(2);
                int alegere = (int)read.GetInt32(1);
                if (alegere == 1)
                {
                    caz1();
                }
                if (alegere == 3)
                {
                    caz3();
                    raspunsaB.Text = read.GetString(3);
                    raspunsbB.Text = read.GetString(4);
                    raspunscB.Text = read.GetString(5);
                    raspunsdB.Text = read.GetString(6);
                }
                if (alegere == 2)
                {
                    caz2();
                    raspunsaC.Text = read.GetString(3);
                    raspunsbC.Text = read.GetString(4);
                    raspunscC.Text = read.GetString(5);
                    raspunsdC.Text = read.GetString(6);
                }
                if (alegere == 4)
                {
                    caz4();
                }
                con.Close();
            }
            
            else
            {
                MessageBox.Show("Ai acumulat " + Convert.ToString(punctaj)+" puncte!");

                con.Open();
                SqlCommand insert = new SqlCommand(@"INSERT INTO ""Tabela Evaluari"" VALUES(@1,@2,@3)", con);
                insert.Parameters.AddWithValue("1", IDelev);
                insert.Parameters.AddWithValue("2", DateTime.Now);
                insert.Parameters.AddWithValue("3", punctaj);
                insert.ExecuteNonQuery(); 
                con.Close();

                Form2 f = new Form2(IDelev);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            punctaj = 1;
            generare(++k);
            
        }
        private int punctaj = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = true;
            con.Open();
            SqlCommand raspuns=new SqlCommand(@"SELECT RaspunsCorectItem FROM ""Tabela Itemi"" WHERE IdItem=@1",con);
            raspuns.Parameters.AddWithValue("1",indice_curent);
            string r=(string)raspuns.ExecuteScalar();
            con.Close();
            switch (caz)
            {
                case 1: 
                    { 
                         if(textboxA.Text==r || textboxA.Text.ToLower()==r.ToLower())
                         {
                            punctaj++;
                            label1.Text = "Punctaj: " + Convert.ToString(punctaj);
                         }
                        button2.Enabled = false;
                        button3.Enabled = true;
                        break; 
                    }
                case 2: 
                    {
                    string ans = "";
                        if (raspunsaC.Checked == true)
                            ans = "1";
                        if (raspunsbC.Checked == true)
                            ans = "2";
                        if (raspunscC.Checked == true)
                            ans = "3";
                        if (raspunsdC.Checked == true)
                            ans = "4";
                        if(ans==r)
                        {
                            punctaj++;
                            label1.Text = "Punctaj: " + Convert.ToString(punctaj);
                        }
                        button2.Enabled = false;
                        button3.Enabled = true;
                        break;
                    }
                case 3:
                    {
                        string ans = "";
                        if (raspunsaB.Checked == true)
                            ans += "1";
                        if (raspunsbB.Checked == true)
                            ans += "2";
                        if (raspunscB.Checked == true)
                            ans += "3";
                        if (raspunsdB.Checked == true)
                            ans += "4";
                        if (ans == r)
                        {
                            punctaj++;
                            label1.Text = "Punctaj: " + Convert.ToString(punctaj);
                        }
                        button2.Enabled = false;
                        button3.Enabled = true;
                        break;
                    }
                case 4:
                    {
                        string ans = "";
                        if (raspunsaD.Checked == true)
                            ans = "1";
                        if (raspunsbD.Checked == true)
                            ans = "0";
                        if (ans == r)
                        {
                            punctaj++;
                            label1.Text = "Punctaj: " + Convert.ToString(punctaj);
                        }
                        button2.Enabled = false;
                        button3.Enabled = true;
                        break;
                    }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            printPreviewControl1.Visible = true;
            
            printPreviewDialog1.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Doresti sa parasesti aplicatia?", "Iesire", MessageBoxButtons.YesNo);
            if(a==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button2.Enabled = true;
            generare(++k);
        }
    }
}
