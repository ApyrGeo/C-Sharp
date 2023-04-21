using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="jucator")
            {
                Form2 frm2 = new Form2(1);
                this.Hide();
                frm2.ShowDialog();
                this.Close();
            }
            if (textBox1.Text == "administrator")
            {
                Form2 frm2 = new Form2(2);
                this.Hide();
                frm2.ShowDialog();
                this.Close();
            }
        }
    }
}
