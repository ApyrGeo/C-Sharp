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

namespace FreeeBook
{
    public partial class Form3 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\Freebook.mdf; Integrated Security = True; Connect Timeout = 30");

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand verif = new SqlCommand("SELECT email FROM utilizatori WHERE email=@1 AND parola=@2", con);
            verif.Parameters.AddWithValue("1", textBox1.Text);
            verif.Parameters.AddWithValue("2", textBox2.Text);
            if (verif.ExecuteScalar() == null)
            {
                MessageBox.Show("Eroare autentificare!");
                con.Close();
            }
            else
            {
                Form4 frm4 = new Form4(textBox1.Text);
                this.Hide();
                frm4.ShowDialog();
                this.Close();
                con.Close();
            }
        }
    }
}
