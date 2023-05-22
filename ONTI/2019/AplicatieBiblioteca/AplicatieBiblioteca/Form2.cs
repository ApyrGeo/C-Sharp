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

namespace AplicatieBiblioteca
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                SqlCommand cmd = new SqlCommand("SELECT IdUtilizator FROM Utilizatori WHERE Email=@1 AND Parola=@2", Program.Globals.con);
                cmd.Parameters.AddWithValue("1", textBox1.Text);
                cmd.Parameters.AddWithValue("2", Program.Globals.criptare(textBox2.Text));
                int id;
                if (cmd.ExecuteScalar() != null)
                {
                    id = (int)cmd.ExecuteScalar();
                    this.Hide();
                    new Form3(id).ShowDialog();
                    this.Close();
                }
                else MessageBox.Show("“Email si/ sau parola invalida!");
            }
            else MessageBox.Show("“Email si/ sau parola invalida!");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
