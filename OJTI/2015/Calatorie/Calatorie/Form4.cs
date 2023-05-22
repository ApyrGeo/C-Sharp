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

namespace Calatorie
{
    public partial class Form4 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBTimpSpatiu.mdf;Integrated Security=True;Connect Timeout=30");
        private string[] porturi = new string[] { "Constanta", "Varna", "Burgas", "Istanbul", "Kozlu", "Samsun", "Batumi", "Sokhumi", "Sochi", "Anapa", "Ialta", "Sevastopol", "Odessa" };

        public Form4()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            int tip = 3;
            dataGridView1.Rows.Clear();
            if (i == 0)
            {
                tip = 3;
            }
            if (i == 1)
            {
                tip = 5;
            }
            if (i == 2)
            {
                tip = 8;
            }

            con.Open();
            SqlCommand select = new SqlCommand($"SELECT * FROM Croaziere WHERE Tip_Croaziera={tip}", con);
            SqlDataReader read = select.ExecuteReader();
            while (read.Read())
            {
                string[] traseu = read.GetString(2).Split(' ');
                string final = "";
                for (int j = 0; j < traseu.Length; j++)
                {
                    final += porturi[Convert.ToInt32(traseu[j]) - 1] + ", ";
                }
                dataGridView1.Rows.Add(
                    read.GetInt32(1),
                    read.GetInt32(0),
                    final,
                    read.IsDBNull(3) ? null : read.GetDateTime(3).ToString(),
                    read.IsDBNull(4) ? null : read.GetDateTime(4).ToString(),
                    read.GetInt32(5),
                    read.IsDBNull(6) ? null : read.GetInt32(4).ToString());


            }
            con.Close();
        }
        private int selectie=-1;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(selectie!=-1)
            {
                Form6 frm6=new Form6(selectie);
                this.Hide();
                frm6.MdiParent = this.MdiParent;
                frm6.Show();
                this.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            selectie = (int)dataGridView1[1, i].Value;
        }
    }
}
