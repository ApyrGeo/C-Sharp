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

namespace GOOD_FOOD
{
    public partial class Form5 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\GOOD_FOOD.mdf;Integrated Security=True;Connect Timeout=30");
        private int ID;
        public Form5(List<(string,int,int,int)>a,(int,int)b,int ID)
        {
            InitializeComponent();
            dataGridView1.Rows.Clear();
            textBox5.Text = b.Item1.ToString();
            textBox6.Text = b.Item2.ToString();
            this.ID = ID;
            for(int i=0;i<a.Count();i++)
            {
                dataGridView1.Rows.Add(a[i].Item1.ToString(), a[i].Item2.ToString(), a[i].Item3.ToString(), a[i].Item4.ToString());
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int i = e.RowIndex;
                textBox5.Text = (Convert.ToInt32(textBox5.Text) - Convert.ToInt32(dataGridView1[1, i].Value)).ToString();
                textBox6.Text = (Convert.ToInt32(textBox6.Text) - Convert.ToInt32(dataGridView1[2, i].Value)).ToString();
                if(dataGridView1.Rows.Count>0)dataGridView1.Rows.RemoveAt(i);
                dataGridView1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //if(dataGridView1.Rows.Count>0)
            {
                MessageBox.Show("Comanda trimisa!");
                con.Open();
                SqlCommand comenzi = new SqlCommand("INSERT INTO Comenzi VALUES(@1,@2,@3)", con);
                Random r = new Random();
                string comanda = ID + r.Next(0, 1000).ToString();
                comenzi.Parameters.AddWithValue("1", comanda);
                comenzi.Parameters.AddWithValue("2", ID);
                comenzi.Parameters.AddWithValue("3", DateTime.Now);
                comenzi.ExecuteNonQuery();

                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    SqlCommand subcomenzi = new SqlCommand("INSERT INTO Subcomenzi VALUES(@1,@2,@3)", con);
                    subcomenzi.Parameters.AddWithValue("1", comanda);

                    SqlCommand idprodus = new SqlCommand("SELECT id_produs FROM Meniu WHERE denumire_produs=@1", con);
                    idprodus.Parameters.AddWithValue("1", dataGridView1[0, i].Value.ToString());
                    int id = (int)idprodus.ExecuteScalar();

                    
                    subcomenzi.Parameters.AddWithValue("2", id);
                    subcomenzi.Parameters.AddWithValue("3", 1);
                    subcomenzi.ExecuteNonQuery();
                }
                Form1 frm1=new Form1();
                this.Hide();
                
                frm1.ShowDialog();
                this.Close();
                con.Close();
            }
        }
    }
}
