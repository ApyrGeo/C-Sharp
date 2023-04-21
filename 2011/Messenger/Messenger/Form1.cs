using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Messenger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;

            richTextBox1.SelectionColor = Color.Blue;
            richTextBox1.Text += "Ionel: " + richTextBox2.Text+"\n";

            richTextBox2.ForeColor = Color.Red;
            richTextBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.ForeColor = Color.Blue;
            button2.Enabled = false;
            button1.Enabled = true;
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.Text += "Maria: " + richTextBox2.Text+"\n";
            richTextBox2.ForeColor = Color.Blue;
            richTextBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            StreamWriter write = new StreamWriter(Path.GetFullPath(saveFileDialog1.FileName));
            write.Write(richTextBox1.Text);
            write.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            richTextBox1.Text = "";
            StreamReader read=new StreamReader(Path.GetFullPath(openFileDialog1.FileName));
            string line;
            while((line=read.ReadLine()) != null)
            {
                richTextBox1.Text += line + "\n";
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
             
        }
    }
}
