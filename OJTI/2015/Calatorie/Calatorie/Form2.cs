using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calatorie
{
    public partial class Form2 : Form
    {
        private int I;
        public Form2(int i)
        {
            InitializeComponent();
            I = i;
            if(i==1)
            {
                menuStrip1.Items.Add("Administrare");
                menuStrip1.Items.Add("Iesire");
                
            }
            if(i==2)
            {
                menuStrip1.Items.Add("Turisti");
                menuStrip1.Items.Add("Iesire");
                
                
            }
        }
        public Form5 frm5 = new Form5();
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == menuStrip1.Items[1])
            {
                Application.Exit();
            }
            if (e.ClickedItem == menuStrip1.Items[0])
            {
                if (I == 1)
                {
                    Form3 frm3 = new Form3();
                    frm5.MdiParent = this;
                    frm3.MdiParent = this;
                    frm3.Show();
                }
                if(I==2)
                {
                    Form4 frm4 = new Form4();
                    frm4.MdiParent = this;
                    frm4.Show();
                }
            }
        }
        public void close()
        {
            this.Close();
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }
    }
}
