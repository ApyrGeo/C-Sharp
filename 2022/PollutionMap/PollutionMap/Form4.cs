using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollutionMap
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public double valoare_introdusa;
        private void button1_Click(object sender, EventArgs e)
        {
            valoare_introdusa = Convert.ToDouble(textBox1.Text);
            this.Close();
        }
    }
}
