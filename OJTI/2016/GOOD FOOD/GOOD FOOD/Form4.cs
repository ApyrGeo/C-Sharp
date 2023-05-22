using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GOOD_FOOD
{
    public partial class Form4 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\GOOD_FOOD.mdf;Integrated Security=True;Connect Timeout=30");

        public int ID; 
        public Form4(int id)
        {
            InitializeComponent();
            chart1.Series["Mancaruri"].Points.Clear();
            comanda.Clear();
            ID = id;
            dataGridView1.Rows.Clear();
            con.Open();
            SqlCommand select = new SqlCommand("SELECT * FROM Meniu", con);
            SqlDataReader read=select.ExecuteReader();
            while(read.Read())
            {
                dataGridView1.Rows.Add(read.GetInt32(0),read.GetString(1),read.GetString(2),read.GetInt32(3),read.GetInt32(4),read.GetInt32(5),1);

            }
            con.Close();
            textBox4.Text = "2000";
            textBox7.Text = "2000";
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int S=Convert.ToInt32(textBox1.Text)+ Convert.ToInt32(textBox2.Text)+Convert.ToInt32(textBox3.Text);
            if (S < 250) label5.Text = "1800";
            else if (S >= 250 && S <= 275) label5.Text = "2200";
            else if (S > 275) label5.Text = "2500";
            textBox4.Text = label5.Text;
            textBox7.Text = label5.Text;
            con.Open();
            SqlCommand zilnic = new SqlCommand("UPDATE Clienti SET kcal_zilnice=@1 WHERE id_client=@2", con);
            zilnic.Parameters.AddWithValue("1", label5.Text);
            zilnic.Parameters.AddWithValue("2", ID);
            zilnic.ExecuteNonQuery();
            con.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        List<(string, int, int, int)> comanda = new List<(string, int, int, int)>();
        (int, int) total ;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==7)
            {
                int j = 7;
                int i = e.RowIndex;

                if (Convert.ToInt32(dataGridView1[6,i].Value)>=0 && e.RowIndex<dataGridView1.Rows.Count-1)
                {
                    dataGridView1[6, i].Value = Convert.ToInt32(dataGridView1[6, i].Value) - 1;
                    if (textBox5.Text == "") textBox5.Text = "0";
                    if (textBox6.Text == "") textBox6.Text = "0";
                    textBox5.Text = (Convert.ToInt32(textBox5.Text) + Convert.ToInt32(dataGridView1[4, i].Value)).ToString();
                    textBox6.Text = (Convert.ToInt32(textBox6.Text) + Convert.ToInt32(dataGridView1[3, i].Value)).ToString();
                    if (Convert.ToInt32(dataGridView1[6, i].Value) == -1) MessageBox.Show("Cantitate negativa");
                    comanda.Add( (dataGridView1[1,i].Value.ToString(), Convert.ToInt32(dataGridView1[4, i].Value), Convert.ToInt32(dataGridView1[3, i].Value),1) );
                    total.Item1 = Convert.ToInt32(textBox5.Text);
                    total.Item2 = Convert.ToInt32(textBox6.Text);

                    con.Open();

                    SqlCommand kcal = new SqlCommand("SELECT kcal FROM Meniu WHERE id_produs=@1", con);
                    kcal.Parameters.AddWithValue("1", Convert.ToInt32(dataGridView1[0, i].Value));
                    int k = (int)kcal.ExecuteScalar();
                    con.Close();
                    chart1.Series["Mancaruri"].Points.AddXY(dataGridView1[1,i].Value.ToString(), k);
                    
                }
                else if (Convert.ToInt32(dataGridView1[6, i].Value) < 0) MessageBox.Show("Cantitate negativa");
                //2h 

                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comanda.Count>0)
            {
                Form5 frm5 = new Form5(comanda, total,ID);
                this.Hide();
                frm5.ShowDialog();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            con.Open();
            List<(int, int, string)> fel1 = new List<(int, int, string)>();
            List<(int, int, string)> fel2 = new List<(int, int, string)>();
            List<(int, int, string)> fel3 = new List<(int, int, string)>();
            SqlCommand select = new SqlCommand("SELECT kcal,pret,felul,denumire_produs FROM Meniu", con);
            SqlDataReader read = select.ExecuteReader();
            while(read.Read()) 
            { 
                if(read.GetInt32(2)==1)
                {
                    fel1.Add((read.GetInt32(0),read.GetInt32(1),read.GetString(3)));
                }
                if (read.GetInt32(2) == 2)
                {
                    fel2.Add((read.GetInt32(0), read.GetInt32(1), read.GetString(3)));
                }
                if (read.GetInt32(2) == 3)
                {
                    fel3.Add((read.GetInt32(0), read.GetInt32(1), read.GetString(3)));
                }
            }
            for(int i=0;i<fel1.Count;i++)
            {
                for(int j=0;j<fel2.Count;j++)
                {
                    for(int k=0;k<fel3.Count;k++)
                    {
                        int S1 = fel1[i].Item1 + fel2[j].Item1 + fel3[k].Item1;
                        int S2 = fel1[i].Item2 + fel2[j].Item2 + fel3[k].Item2;
                        if (S1<=Convert.ToInt32(textBox7.Text))
                        {
                            if(S2<= Convert.ToInt32(textBox8.Text))
                            {
                                dataGridView2.Rows.Add(fel1[i].Item3.ToString(), fel2[j].Item3.ToString(), fel3[k].Item3.ToString(), S1, S2);
                            }
                        }
                    }
                }
            }

            con.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==5)
            {
                int i = e.RowIndex;

                con.Open();
                SqlCommand comenzi = new SqlCommand("INSERT INTO Comenzi VALUES(@1,@2,@3)", con);
                Random r = new Random();
                string comanda = ID + r.Next(0, 1000).ToString();
                comenzi.Parameters.AddWithValue("1", comanda);
                comenzi.Parameters.AddWithValue("2", ID);
                comenzi.Parameters.AddWithValue("3", DateTime.Now);
                comenzi.ExecuteNonQuery();


                for(int j=0;j<3;j++)
                {
                    SqlCommand subcomenzi = new SqlCommand("INSERT INTO Subcomenzi VALUES(@1,@2,@3)", con);
                    subcomenzi.Parameters.AddWithValue("1", comanda);

                    SqlCommand idprodus = new SqlCommand("SELECT id_produs FROM Meniu WHERE denumire_produs=@1", con);
                    idprodus.Parameters.AddWithValue("1", dataGridView2[j,i].Value.ToString());
                    int id = (int)idprodus.ExecuteScalar();


                    subcomenzi.Parameters.AddWithValue("2", id);
                    subcomenzi.Parameters.AddWithValue("3", 1);
                    subcomenzi.ExecuteNonQuery();
                }
                con.Close();

                MessageBox.Show("Comanda trimisa!");
                Form1 frm1 = new Form1();
                this.Hide();
                frm1.ShowDialog();
                this.Close();
            }
        }
    }
}
