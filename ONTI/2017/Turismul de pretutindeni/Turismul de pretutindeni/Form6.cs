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

namespace Turismul_de_pretutindeni
{
    public partial class Form6 : Form
    {
        int user;
        public Form6(int user)
        {
            InitializeComponent();
            this.user=user;

            dgv_refresh();   
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        private void dgv_refresh()
        {
            dataGridView1.Rows.Clear();
            SqlDataReader read = new SqlCommand($"SELECT IdRezervare,NumeVacanta,DataInceput,DataSfarsit,NrPersoane,PretTotal FROM Rezervari INNER JOIN Vacante ON Vacante.IdVacanta=Rezervari.IdVacanta WHERE IdUser={user}", Program.Globals.con).ExecuteReader();
            while (read.Read())
            {
                dataGridView1.Rows.Add(read.GetInt32(0), read.GetString(1), read.GetDateTime(2), read.GetDateTime(3), read.GetInt32(4), read.GetFloat(5));
            }
            read.Dispose();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==6 && e.RowIndex>=0 && e.RowIndex< dataGridView1.RowCount-1)
            {
                new SqlCommand($"UPDATE Vacante SET NrLocuri=NrLocuri+{Convert.ToInt32(dataGridView1[4,e.RowIndex].Value)} WHERE NumeVacanta='{dataGridView1[1,e.RowIndex].Value}'", Program.Globals.con).ExecuteNonQuery();
                new SqlCommand($"DELETE FROM Rezervari WHERE IdRezervare={Convert.ToInt32(dataGridView1[0, e.RowIndex].Value)}", Program.Globals.con).ExecuteNonQuery();
                dgv_refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
