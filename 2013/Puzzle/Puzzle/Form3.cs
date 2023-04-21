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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nr = folderBrowserDialog1.SelectedPath.Split('\\').Last();
            
            if(nr.Contains("image"))
            {
                int n = Convert.ToInt32(nr[nr.Length-1])-48;
                

                Form4 frm4 = new Form4(n, textBox2.Text);
                frm4.MdiParent = this.MdiParent;
                this.Hide();
                frm4.Show();
                this.Close();
            }
        }
    }
}
