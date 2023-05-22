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

namespace Turismul_de_pretutindeni
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();

            SqlCommand select = new SqlCommand("SELECT Email FROM Utilizatori WHERE TipCont=1", Program.Globals.con);
            SqlDataReader read=select.ExecuteReader();
            while(read.Read())
            {
                comboBox1.Items.Add(read.GetString(0));
            }
            read.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms["Form3"]!=null)
                Application.OpenForms["Form3"].Close();

            this.Hide();
            new Form2().ShowDialog();
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem.ToString() != null)
            {
                new SqlCommand($"UPDATE Utilizatori SET TipCont=0 WHERE Email='{comboBox1.SelectedItem.ToString()}'", Program.Globals.con).ExecuteNonQuery();

                MessageBox.Show("User transformat in admin!");
                this.Hide();
                this.Close();

            }
        }
    }
}
