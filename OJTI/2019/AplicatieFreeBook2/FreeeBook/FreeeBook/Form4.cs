using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FreeeBook
{
    public partial class Form4 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\Freebook.mdf; Integrated Security = True; Connect Timeout = 30");
        private string ID="";
        public Form4(string email)
        {
            InitializeComponent();
            ID = email;
            label1.Text = "Email utilizator: " + email;
            comboBox1.Text = "2023";
            update_graph1();
        }
        private void update_graph1()
        {
            con.Open();
            SqlCommand select = new SqlCommand("SELECT titlu,autor,gen FROM carti", con);
            dataGridView1.Rows.Clear();
            var read = select.ExecuteReader();
            while (read.Read())
            {
                dataGridView1.Rows.Add(read.GetString(0), read.GetString(1), read.GetString(2));
            }
            select.Dispose();
            dataGridView2.Rows.Clear();
            select = new SqlCommand("SELECT titlu,autor,data_imprumut FROM imprumut INNER JOIN carti ON imprumut.id_carte=carti.id_carte WHERE email=@1", con);
            select.Parameters.AddWithValue("1", ID);
            read.Close();
            int k = 0;

            read = select.ExecuteReader();
            while (read.Read())
            {
                DateTime a = read.GetDateTime(2), b = read.GetDateTime(2) + TimeSpan.FromDays(30);
                dataGridView2.Rows.Add(++k, read.GetString(0), read.GetString(1), a, b);
                if (DateTime.Now - a > TimeSpan.FromDays(30))
                {
                    dataGridView2.Rows[k - 1].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    dataGridView2.Rows[k - 1].DefaultCellStyle.BackColor = Color.Green;
                }
            }
            read.Close();
            con.Close();
        }

        private void chart1_update()
        {
            con.Open();
            SqlCommand verifica = new SqlCommand("SELECT COUNT(*) FROM imprumut WHERE data_imprumut>@1 AND email=@2", con);
            verifica.Parameters.AddWithValue("1", DateTime.Now - TimeSpan.FromDays(30));
            verifica.Parameters.AddWithValue("2", ID);
            int x = (int)verifica.ExecuteScalar();
            label2.Text = "Disponibilitate imprumuturi " + Convert.ToString(x) + "/3";
            progressBar1.Value = x;
            progressBar1.Maximum = 3;

            chart1.Series["Luna"].Points.Clear();
            if (comboBox1.SelectedItem != null)
            {
                int an = Convert.ToInt32(comboBox1.SelectedItem);
                SqlCommand l = new SqlCommand("SELECT COUNT(DISTINCT email) FROM imprumut  WHERE YEAR(data_imprumut)=@1 AND MONTH(data_imprumut)=@2", con);
                l.Parameters.AddWithValue("1", an);
                l.Parameters.AddWithValue("2", 1);


                chart1.Series["Luna"].Points.AddXY("Ian", (int)l.ExecuteScalar());
                l.Parameters["2"].Value = 2;
                chart1.Series["Luna"].Points.AddXY("Feb", (int)l.ExecuteScalar());
                l.Parameters["2"].Value = 3;
                chart1.Series["Luna"].Points.AddXY("Mar", (int)l.ExecuteScalar());
                l.Parameters["2"].Value = 4;
                chart1.Series["Luna"].Points.AddXY("Apr", (int)l.ExecuteScalar());
                l.Parameters["2"].Value = 5;
                chart1.Series["Luna"].Points.AddXY("Mai", (int)l.ExecuteScalar());
                l.Parameters["2"].Value = 6;
                chart1.Series["Luna"].Points.AddXY("Iun", (int)l.ExecuteScalar());
                l.Parameters["2"].Value = 7;
                chart1.Series["Luna"].Points.AddXY("Iul", (int)l.ExecuteScalar());
                l.Parameters["2"].Value = 8;
                chart1.Series["Luna"].Points.AddXY("Aug", (int)l.ExecuteScalar());
                l.Parameters["2"].Value = 9;
                chart1.Series["Luna"].Points.AddXY("Sep", (int)l.ExecuteScalar());
                l.Parameters["2"].Value = 10;
                chart1.Series["Luna"].Points.AddXY("Oct", (int)l.ExecuteScalar());
                l.Parameters["2"].Value = 11;
                chart1.Series["Luna"].Points.AddXY("Nov", (int)l.ExecuteScalar());
                l.Parameters["2"].Value = 12;
                chart1.Series["Luna"].Points.AddXY("Dec", (int)l.ExecuteScalar());
                chart1.ChartAreas[0].AxisY.Title = "Numarul de utilizatori in anul curent - " + Convert.ToString(an);
            }
            con.Close();
        }
        private void chart2_update()
        {
            con.Open();
            (int, int, int, int) maxi = (0, 0, 0, 0);
            (int, int, int, int) id = (0, 0, 0, 0);
            SqlCommand maxime = new SqlCommand("SELECT COUNT(id_carte) FROM imprumut WHERE id_carte=@1", con);

            SqlDataReader read;
            int i = 0;
            maxime.Parameters.AddWithValue("1", ++i);
            while((read=maxime.ExecuteReader()).Read() && read.GetInt32(0)!=0)
            {
                int val = read.GetInt32(0);
                
                if (val > maxi.Item1)
                {
                    maxi.Item4 = maxi.Item3;
                    maxi.Item3 = maxi.Item2;
                    maxi.Item2 = maxi.Item1;
                    maxi.Item1 = val;
                    id.Item4 = id.Item3;
                    id.Item3 = id.Item2;
                    id.Item2 = id.Item1;
                    id.Item1 = i;
                }
                else if (val > maxi.Item2)
                {
                    maxi.Item4 = maxi.Item3;
                    maxi.Item3 = maxi.Item2;
                    maxi.Item2 = val;
                    id.Item4 = id.Item3;
                    id.Item3 = id.Item2;
                    id.Item2 = i;
                }
                else if (val > maxi.Item3)
                {
                    maxi.Item4 = maxi.Item3;
                    maxi.Item3 = val;
                    id.Item4 = id.Item3;
                    id.Item3 = i; 
                }
                else if (val > maxi.Item4)
                {
                    maxi.Item4 = val;
                    id.Item4 = i;
                }
                maxime.Parameters["1"].Value = ++i;
                read.Close();
            }
            read.Close();
            double sum = maxi.Item1+maxi.Item2+maxi.Item3+maxi.Item4;
            
            SqlCommand carte = new SqlCommand("SELECT titlu FROM carti WHERE id_carte=@1", con);
            chart2.Series["Series1"].Points.Clear();

            carte.Parameters.AddWithValue("1",id.Item1);
            chart2.Series["Series1"].Points.AddXY(maxi.Item1.ToString(), (double)(maxi.Item1 * 100 / sum));
            chart2.Series["Series1"].Points[0].LegendText = Convert.ToString(carte.ExecuteScalar());

            carte.Parameters["1"].Value = id.Item2;
            chart2.Series["Series1"].Points.AddXY(maxi.Item2.ToString(), (double)(maxi.Item2 * 100 / sum));
            chart2.Series["Series1"].Points[1].LegendText = Convert.ToString(carte.ExecuteScalar());

            carte.Parameters["1"].Value = id.Item3;
            chart2.Series["Series1"].Points.AddXY(maxi.Item3.ToString(), (double)(maxi.Item3 * 100 / sum));
            chart2.Series["Series1"].Points[2].LegendText = Convert.ToString(carte.ExecuteScalar());

            carte.Parameters["1"].Value = id.Item4;
            chart2.Series["Series1"].Points.AddXY(maxi.Item4.ToString(), (double)(maxi.Item4 * 100 / sum));
            chart2.Series["Series1"].Points[3].LegendText = Convert.ToString(carte.ExecuteScalar());

            con.Close();
            
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id=(int)e.RowIndex;
            if(e.ColumnIndex==3)
            {
                con.Open();
                SqlCommand verifica = new SqlCommand("SELECT COUNT(*) FROM imprumut WHERE data_imprumut>@1 AND email=@2", con);
                verifica.Parameters.AddWithValue("1", DateTime.Now - TimeSpan.FromDays(30));
                verifica.Parameters.AddWithValue("2", ID);
                int i = (int)verifica.ExecuteScalar();
                con.Close();
                if (i < 3)
                {
                    con.Open();
                    SqlCommand insert = new SqlCommand("INSERT INTO imprumut VALUES(@1,@2,@3)", con);

                    SqlCommand cauta_id = new SqlCommand("SELECT id_carte FROM carti WHERE titlu=@1", con);
                    cauta_id.Parameters.AddWithValue("1", (string)dataGridView1[0, id].Value);
                    insert.Parameters.AddWithValue("1", (int)cauta_id.ExecuteScalar());
                    insert.Parameters.AddWithValue("2", ID);
                    insert.Parameters.AddWithValue("3", DateTime.Now);
                    insert.ExecuteNonQuery();
                    con.Close();

                }
                else MessageBox.Show("Ai imprumutat prea multe carti!");
            }
            update_graph1();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!(e.RowIndex == -1)) 
            {
                con.Open();
                string titlu =(string)dataGridView2[1,e.RowIndex].Value;
                SqlCommand id = new SqlCommand("SELECT id_carte FROM carti WHERE titlu=@1", con);
                id.Parameters.AddWithValue("1", titlu);
                
                int i = (int)id.ExecuteScalar();
                con.Close();
                Form5 frm5=new Form5(i);
                frm5.ShowDialog();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1_update();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            chart1_update();
        }

        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            if(label4.BackColor == SystemColors.ActiveBorder)
            {
                DialogResult a = MessageBox.Show("Doresti sa parasesti aplicatia?", "Iesire din aplicatie", MessageBoxButtons.YesNo);
                if (a == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.BackColor = SystemColors.ActiveBorder;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = SystemColors.Control;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex==2)
            {
                chart2_update();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                chart1_update();
            }
        }
    }
}
