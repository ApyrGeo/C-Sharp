using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentenarMareaUnire
{
    public partial class Form5 : Form
    {
        int user;
        public Form5(int id)
        {
            InitializeComponent();

            user = id;
            this.tableLayoutPanel1.RowStyles.Clear();
            this.tableLayoutPanel1.ColumnStyles.Clear();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowCount++;
            for (int i = 1; i <= this.tableLayoutPanel1.RowCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
            }
            for (int j=0;j<tableLayoutPanel1.ColumnCount;j++)
            {
                tableLayoutPanel1.Controls.Add(new Control());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.RowCount - 1 > 0) tableLayoutPanel1.RowCount--;
            for (int i = 1; i <= this.tableLayoutPanel1.RowCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnCount++;
            for (int i = 1; i <= this.tableLayoutPanel1.ColumnCount; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
            }
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                tableLayoutPanel1.Controls.Add(new Control());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.ColumnCount - 1 > 0) tableLayoutPanel1.ColumnCount--;
            for (int i = 1; i <= this.tableLayoutPanel1.ColumnCount; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Bitmap map = new Bitmap(tableLayoutPanel1.Width, tableLayoutPanel1.Height, PixelFormat.Format32bppArgb);
            tableLayoutPanel1.DrawToBitmap(map, new Rectangle(0,0, tableLayoutPanel1.Size.Width, tableLayoutPanel1.Size.Height));
            map.Save(@"ContinutLectii\" + textBox1.Text+".bmp");
        }
        (int i, int j) celula_selectata;
        private void button10_Click(object sender, EventArgs e)
        {
            TextBox a=new TextBox();
            a.Multiline = true;
            a.Dock= DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(a, celula_selectata.j, celula_selectata.i);
        }

        private void celula_click(object sender, MouseEventArgs e)
        {
            MessageBox.Show("idk");
            celula_selectata.i = tableLayoutPanel1.GetRow(sender as Control);
            celula_selectata.j = tableLayoutPanel1.GetColumn(sender as Control);
        }

        private void tableLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            MessageBox.Show("idk");
            (sender as Control).MouseClick += celula_click;
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
