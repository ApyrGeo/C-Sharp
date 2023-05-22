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
    public partial class Form2 : Form
    {
        private int tip;
        public Form2(int tip)
        {
            InitializeComponent();
            this.tip = tip;
            if (tip == 1)
            {
                menuStrip1.Items.Add("Joc nou");
                menuStrip1.Items.Add("Clasament");
                menuStrip1.Items.Add("Iesire");


            }
            if (tip == 2)
            {
                menuStrip1.Items.Add("Editare clasament");
                menuStrip1.Items.Add("Iesire");
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == menuStrip1.Items[0] && tip==1)
            {
                Form3 frm3 = new Form3();
                frm3.MdiParent = this;
                frm3.Show();
            }    
        }
    }
}
