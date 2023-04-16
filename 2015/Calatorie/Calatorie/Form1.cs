using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calatorie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "oti2015";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="agentie2015")
            {
                Form2 frm2 = new Form2(1);
                this.Hide();
                frm2.ShowDialog();
                this.Close();
            }
            if (textBox1.Text == "oti2015")
            {
                Form2 frm2 = new Form2(2);
                this.Hide();
                frm2.ShowDialog();
                this.Close();
            }
        }
    }
}
