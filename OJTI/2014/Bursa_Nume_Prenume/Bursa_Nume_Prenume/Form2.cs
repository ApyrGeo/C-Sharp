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

namespace Bursa_Nume_Prenume
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBBursa.mdf;Integrated Security=True;Connect Timeout=30");
        private int dt;
        public Form2(int interval,bool ok)
        {
            InitializeComponent();
            dt = interval;
            con.Open();
            SqlCommand select = new SqlCommand("SELECT * FROM Actiuni",con);
            SqlDataReader read= select.ExecuteReader();
            while(read.Read())
            {
                dataGridView1.Rows.Add(
                    read.GetString(1),
                    read.GetInt32(2).ToString(),
                    read.GetInt32(3).ToString(),
                    read.GetInt32(3).ToString(),
                    "",
                    (read.GetInt32(2)*read.GetInt32(3)).ToString(),
                    "",
                    "",
                    ""
                    );
            }
            
            con.Close();
            if(ok==true)
            {

                
                timer1.Interval = dt;
                timer1.Start();
                timer1.Tick += (a, b) =>
                {
                    
                    
                    for(int i=0;i<dataGridView1.Rows.Count-1;i++)
                    {
                        Random x = new Random();
                        int xx = x.Next(-5, 6);

                        dataGridView1[4, i].Value = Globals.bursa.Last()[i].Item2.ToString() ;
                        dataGridView1[3, i].Value = Globals.bursa.Last()[i].Item1.ToString();
                        dataGridView1[6, i].Value = Globals.bursa.Last()[i].Item3.ToString();
                        dataGridView1[7, i].Value = Globals.bursa.Last()[i].Item4.ToString();
                        dataGridView1[8, i].Value = Globals.bursa.Last()[i].Item5.ToString();
                        
                        
                    }
                    textBox1.Text = Globals.suma.Last().ToString();
                    dataGridView1.Refresh();
                    
                };

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private Timer timer1 = new Timer();
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
