using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void inchidereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lansareTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            
            textBox1.Visible = true;
            textBox2.Visible = true;

            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="candidat" && textBox2.Text=="cia2012")
            {
                Form2 frm2=new Form2();
                this.Hide();
                frm2.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nume utilizator sau parolă gresită!! Vă rugăm reluati!");
            }
        }
    }
}
