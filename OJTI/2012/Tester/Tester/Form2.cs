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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Tester
{
    public partial class Form2 : Form
    {
        private List<(string i, string r1, string r2, string r3, string r4, int c, int p, int t)> intrebare = new List<(string i, string r1, string r2, string r3, string r4, int c, int p, int t)>();
        private int punctaj;
        public Form2()
        {
            InitializeComponent();

            StreamReader read = new StreamReader("teste.txt");
            string line;
            int i = 1;
            string s1="", s2="", s3="", s4 = "", s5 = "";
            int i1=-1, i2=-1, i3=-1;
            while((line = read.ReadLine()) != null)
            {
                switch(i)
                {
                    case 1: { s1=line; break;}
                    case 2: { s2=line; break;}
                    case 3: { s3 = line; break; }
                    case 4: { s4 = line; break; }
                    case 5: { s5 = line; break; }
                    case 6: { i1 = Convert.ToInt32(line); break; }
                    case 7: { i2 = Convert.ToInt32(line); break; }
                    case 8: { i3 = Convert.ToInt32(line);  break; }
                }
                if(i==8)
                {
                    intrebare.Add((s1, s2, s3, s4, s5, i1, i2, i3));
                }
                i++;
                if (i == 9) i = 1;
            }


            textBox1.Text = intrebare[Intrebare].Item1;
            tip = intrebare[Intrebare].Item8;
            if (tip == 0)
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;

                radioButton1.Text = intrebare[Intrebare].Item2;
                radioButton2.Text = intrebare[Intrebare].Item3;
                radioButton3.Text = intrebare[Intrebare].Item4;
                radioButton4.Text = intrebare[Intrebare].Item5;
            }
            if (tip == 1)
            {
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;

                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;

                checkBox1.Text = intrebare[Intrebare].Item2;
                checkBox2.Text = intrebare[Intrebare].Item3;
                checkBox3.Text = intrebare[Intrebare].Item4;
                checkBox4.Text = intrebare[Intrebare].Item5;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private int Intrebare = 0, tip;
        private void button2_Click(object sender, EventArgs e)
        {
            if(Intrebare+1<intrebare.Count)
            {
                Intrebare++;
            }

            textBox1.Text = intrebare[Intrebare].Item1;
            tip = intrebare[Intrebare].Item8;
            if(tip==0)
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;

                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;

                radioButton1.Text = intrebare[Intrebare].Item2;
                radioButton2.Text = intrebare[Intrebare].Item3;
                radioButton3.Text = intrebare[Intrebare].Item4;
                radioButton4.Text = intrebare[Intrebare].Item5;
            }
            if (tip == 1)
            {
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;

                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;

                checkBox1.Text = intrebare[Intrebare].Item2;
                checkBox2.Text = intrebare[Intrebare].Item3;
                checkBox3.Text = intrebare[Intrebare].Item4;
                checkBox4.Text = intrebare[Intrebare].Item5;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           if( e_facut[Intrebare] != 1)
           {
                if (tip == 0)
                {
                    int raspuns = intrebare[Intrebare].c;

                    if (raspuns == 1 && radioButton1.Checked == true)
                    {
                        punctaj += intrebare[Intrebare].p;
                    }
                    if (raspuns == 2 && radioButton2.Checked == true)
                    {
                        punctaj += intrebare[Intrebare].p;
                    }
                    if (raspuns == 3 && radioButton3.Checked == true)
                    {
                        punctaj += intrebare[Intrebare].p;
                    }
                    if (raspuns == 4 && radioButton4.Checked == true)
                    {
                        punctaj += intrebare[Intrebare].p;
                    }
                }
                if (tip == 1)
                {
                    int raspuns = intrebare[Intrebare].c;
                    int p = 1;
                    int ales = 0;
                    if (checkBox1.Checked == true)
                    {
                        ales = ales * p + 1;
                        p *= 10;
                    }
                    if (checkBox2.Checked == true)
                    {
                        ales = ales * p + 1;
                        p *= 10;
                    }
                    if (checkBox3.Checked == true)
                    {
                        ales = ales * p + 1;
                        p *= 10;
                    }
                    if (checkBox4.Checked == true)
                    {
                        ales = ales * p + 1;
                        p *= 10;
                    }
                    if (ales == raspuns)
                        punctaj += intrebare[Intrebare].p;
                }
            }
            e_facut[Intrebare] = 1;
        }
        private int[] e_facut = new int[100];
        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "Ai acumulat " + punctaj.ToString() + " puncte";
            button1.Enabled = false;
            button2.Enabled = false;
            button5.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Intrebare - 1 >= 0)
            {
                Intrebare--;
            }
            textBox1.Text = intrebare[Intrebare].Item1;
            tip = intrebare[Intrebare].Item8;
            if (tip == 0)
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;

                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;

                radioButton1.Text = intrebare[Intrebare].Item2;
                radioButton2.Text = intrebare[Intrebare].Item3;
                radioButton3.Text = intrebare[Intrebare].Item4;
                radioButton4.Text = intrebare[Intrebare].Item5;
            }
            if (tip == 1)
            {
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;

                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;

                checkBox1.Text = intrebare[Intrebare].Item2;
                checkBox2.Text = intrebare[Intrebare].Item3;
                checkBox3.Text = intrebare[Intrebare].Item4;
                checkBox4.Text = intrebare[Intrebare].Item5;
            }
        }
    }
}
