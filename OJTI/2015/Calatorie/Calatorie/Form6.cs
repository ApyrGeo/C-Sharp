using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calatorie
{
    public partial class Form6 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBTimpSpatiu.mdf;Integrated Security=True;Connect Timeout=30");
        private string[] porturi = new string[] { "Constanta", "Varna", "Burgas", "Istanbul", "Kozlu", "Samsun", "Batumi", "Sokhumi", "Sochi", "Anapa", "Ialta", "Sevastopol", "Odessa" };
        private int selectie;
        public Form6(int selectie)
        {
            InitializeComponent();
            this.selectie = selectie;
            init();
           
        }
        private void init()
        {
            
        }
        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            

            Pen pen = new Pen(Color.Red, 2);

            con.Open();

            SqlCommand select = new SqlCommand($"SELECT Lista_Porturi FROM Croaziere WHERE Id_Croaziera={selectie}", con);
            string lista = (string)select.ExecuteScalar();
            select.Dispose();
            string[] list = lista.Split(' ');
            float precx = 0, precy = 0;
            for (int i = 0; i < list.Length; i++)
            {
                int curent = Convert.ToInt32((list[i]));
                SqlCommand select2 = new SqlCommand($"SELECT Pozitie_X,Pozitie_Y FROM Porturi WHERE IdPort={curent}", con);
                SqlDataReader read = select2.ExecuteReader();
                read.Read();
                float x = (float)read.GetInt32(0);
                float y = (float)read.GetInt32(1);
                if (i >= 1)
                {
                    e.Graphics.DrawLine(pen, precx, precy, x, y);
                }
                read.Dispose();
                precx = x;
                precy = y;

                e.Graphics.DrawRectangle(new Pen(Color.Black, 2), x, y, 10, 10);
            }
            con.Close();
        }
    }
}
