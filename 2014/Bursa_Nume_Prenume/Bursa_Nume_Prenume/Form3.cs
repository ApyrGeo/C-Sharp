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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bursa_Nume_Prenume
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBBursa.mdf;Integrated Security=True;Connect Timeout=30");
        private int dt;
        public Form3(int interval, bool ok)
        {
            InitializeComponent();
            dt = interval;
            
            if (ok == true)
            {
                timer1.Interval = dt;
                int y = 0;
                foreach (int a in Globals.suma)
                {
                    chart1.Series["Series1"].Points.AddXY(y++, a);
                }

                timer1.Start();
                
                timer1.Tick += (a, b) =>
                {
                    chart1.Series["Series1"].Points.AddXY(y++, Globals.suma.Last());
                    dataGridView1.Refresh();
                };
            }
        }
        private Timer timer1 = new Timer();
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
