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
using System.Globalization;
using System.Security.Cryptography;
using System.Drawing.Imaging;

namespace AplicatieBiblioteca
{
    public partial class Form3 : Form
    {
        private string nume_utilizator;
        private int utilizator;
        public Form3(int utilizator)
        {
            InitializeComponent();
            this.utilizator = utilizator;
            SqlCommand cauta = new SqlCommand($"SELECT NumePrenume FROM Utilizatori WHERE IdUtilizator={utilizator}", Program.Globals.con);
            nume_utilizator = cauta.ExecuteScalar().ToString();
            label1.Text="Bibliotecar= "+ nume_utilizator;
            timer1.Start();


            pictureBox1.BackgroundImage = Image.FromFile(@"Imagini\utilizatori\"+utilizator.ToString() + ".jpg");

            populate_cititori();
        }
        private void populate_cititori()
        {
            dataGridView1.Rows.Clear();
            SqlCommand cititori = new SqlCommand($"SELECT * FROM Utilizatori WHERE TipUtilizator=2 AND (NumePrenume LIKE '{de_cautat}%' OR NumePrenume LIKE '%{de_cautat}%' OR NumePrenume LIKE '%{de_cautat}')", Program.Globals.con);
            SqlDataReader read = cititori.ExecuteReader();
            while (read.Read())
            {
                dataGridView1.Rows.Add(read.GetInt32(0), read.GetString(2), read.GetString(3));
            }
            read.Dispose();
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Refresh();
            label2.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
        }
        private void reset()
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            pictureBox2.BackgroundImage = null;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if(openFileDialog1.FileName!=null)
                pictureBox2.BackgroundImage=Image.FromFile(openFileDialog1.FileName);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && (radioButton1.Checked || radioButton2.Checked) && pictureBox2.BackgroundImage!=null &&(textBox3.Text==textBox4.Text))
            {
                SqlCommand get_email = new SqlCommand($"SELECT Email FROM Utilizatori WHERE Email='{textBox2.Text}'", Program.Globals.con);
                if(get_email.ExecuteScalar()==null)
                {
                    SqlCommand insert = new SqlCommand("INSERT INTO Utilizatori VALUES(@1,@2,@3,@4)", Program.Globals.con);
                    
                    if( radioButton1.Checked )
                    {
                        insert.Parameters.AddWithValue("1", 1);
                        insert.Parameters.AddWithValue("4", Program.Globals.criptare(textBox3.Text));
                    }
                    else if(radioButton2.Checked )
                    {
                        insert.Parameters.AddWithValue("1", 2);
                        insert.Parameters.AddWithValue("4", DBNull.Value);
                    }
                    insert.Parameters.AddWithValue("2", textBox1.Text);
                    insert.Parameters.AddWithValue("3", textBox2.Text);

                    insert.ExecuteNonQuery();

                    SqlCommand get_id = new SqlCommand("SELECT MAX(IdUtilizator) FROM Utilizatori", Program.Globals.con);

                    int id=(int) get_id.ExecuteScalar();
                    pictureBox2.Name =  id.ToString()+ ".jpg";
                    pictureBox2.BackgroundImage.Save(@"Imagini\utilizatori\"+pictureBox2.Name);

                    MessageBox.Show("Cont creat!");
                    reset();
                    populate_cititori();
                }
                else MessageBox.Show("Eroare");
            }
            else MessageBox.Show("Eroare");
        }
        private string de_cautat = "";
        private void button2_Click(object sender, EventArgs e)
        {
            de_cautat = textBox5.Text;
            populate_cititori();
        }
        private int id_ales;
        private void populate_cititor()
        {
            dataGridView2.Rows.Clear();
            pictureBox3.BackgroundImage = Image.FromFile(@"Imagini\utilizatori\"+id_ales.ToString()+".jpg");
            
            label9.Text="Cititor: IdCititor= "+id_ales.ToString()+", Nume si prenume= "
                + new SqlCommand($"SELECT NumePrenume FROM Utilizatori WHERE IdUtilizator={id_ales}",Program.Globals.con).ExecuteScalar();

            SqlCommand get_imprumut = new SqlCommand($"SELECT IdImprumut,Imprumuturi.IdCarte,Titlu,Autor,DataImprumut,DataRestituire,IdCititor FROM Imprumuturi INNER JOIN Carti ON Imprumuturi.IdCarte=Carti.IdCarte WHERE IdCititor={id_ales}", Program.Globals.con);
            SqlDataReader read=get_imprumut.ExecuteReader();
            while(read.Read())
            {

                dataGridView2.Rows.Add(
                    read.GetInt32(0),
                    read.GetInt32(1),
                    read.GetString(2),
                    read.GetString(3),
                    read.GetDateTime(4),
                    DBNull.Value
                    ) ;
                if (read.IsDBNull(5))
                {
                    
                    if (read.GetInt32(6) == id_ales) imp++;
                }
                else
                    dataGridView2[5, dataGridView2.Rows.Count-2].Value = read.GetDateTime(5).ToString();

            }
            label10.Text = "Rezervari ramase: " + (3 - rez).ToString();
            label11.Text = "Imprumuturi ramase: " + (3 - imp).ToString();
            read.Dispose();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==3 && e.RowIndex>=0 &&e.RowIndex<dataGridView1.Rows.Count-1)
            {
                id_ales = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
                tabControl1.SelectedIndex = 2;
                populate_cititor();
                populate_rezervari();
                populate_carti();
            }
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex>=0 &&e.RowIndex < dataGridView2.Rows.Count - 1)
            {
                new SqlCommand($"DELETE FROM Imprumuturi WHERE IdImprumut={Convert.ToInt32(dataGridView2[0, e.RowIndex].Value)}", Program.Globals.con).ExecuteNonQuery();
                imp = 0;
                rez = 0;
                populate_cititor();
            }
        }
        private int rez = 0, imp = 0;
        private void populate_rezervari()
        {
            dataGridView4.Rows.Clear();

            SqlCommand get_rezervari = new SqlCommand("SELECT IdRezervare,Carti.IdCarte,Titlu,Autor,DataRezervare,IdCititor FROM Rezervari " +
                $"INNER JOIN Carti ON Carti.IdCarte=Rezervari.IdCarte WHERE StatusRezervare=1 AND IdCititor={id_ales}", Program.Globals.con);
            SqlDataReader read=get_rezervari.ExecuteReader();
            while(read.Read())
            {
                dataGridView4.Rows.Add(read.GetInt32(0),
                    read.GetInt32(1),
                    read.GetString(2),
                    read.GetString(3),
                    read.GetDateTime(4),
                    read.GetDateTime(4).AddDays(1));
                if (read.GetInt32(5) == id_ales)
                    rez++;
            }
            read.Dispose();
            label10.Text = "Rezervari ramase: " + (3 - rez).ToString();
            label11.Text = "Imprumuturi ramase: " + (3-imp).ToString();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==6 && e.RowIndex>=0 && e.RowIndex< dataGridView4.Rows.Count-1)
            {
                new SqlCommand($"UPDATE Rezervari SET StatusRezervare=0 WHERE IdRezervare={Convert.ToInt32(dataGridView4[0, e.RowIndex].Value)}", Program.Globals.con).ExecuteNonQuery();
                rez=0;
                populate_rezervari();
            }

            if (e.ColumnIndex == 7 && e.RowIndex >= 0 && e.RowIndex < dataGridView4.Rows.Count - 1)
            {
                if(3-imp>0)
                {
                    imp = 0;
                    SqlCommand cmd=new SqlCommand($"INSERT INTO Imprumuturi VALUES(@1,@2,@3,@4)", Program.Globals.con);
                    cmd.Parameters.AddWithValue("1", id_ales);
                    cmd.Parameters.AddWithValue("2", Convert.ToInt32(dataGridView4[1, e.RowIndex].Value));
                    cmd.Parameters.AddWithValue("3", DateTime.Now);
                    cmd.Parameters.AddWithValue("4", DBNull.Value);
                    cmd.ExecuteNonQuery();
                    rez = 0;
                    new SqlCommand($"UPDATE Rezervari SET StatusRezervare=0 WHERE IdRezervare={Convert.ToInt32(dataGridView4[0, e.RowIndex].Value)}", Program.Globals.con).ExecuteNonQuery();
                    populate_rezervari();
                    populate_cititor();
                }
                else
                    MessageBox.Show("Nu poti imprumuta mai mult de 3 carti");
                
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        private void populate_carti(string a, string b)
        {
            dataGridView5.Rows.Clear();

            SqlCommand get = new SqlCommand($"SELECT IdCarte,Titlu,Autor,NrPag FROM Carti WHERE Titlu LIKE '{a}%' AND Autor LIKE '{b}%' ", Program.Globals.con);
            SqlDataReader read = get.ExecuteReader();
            while (read.Read())
            {
                dataGridView5.Rows.Add(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetInt32(3));
            }
            read.Dispose();
        }
        private void populate_carti()
        {
            dataGridView5.Rows.Clear();

            SqlCommand get = new SqlCommand($"SELECT IdCarte,Titlu,Autor,NrPag FROM Carti", Program.Globals.con);
            SqlDataReader read=get.ExecuteReader();
            while(read.Read())
            {
                dataGridView5.Rows.Add(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetInt32(3));
            }
            read.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a,b ;
            if (textBox6.Text == null)
                a = "";
            else
                a = textBox6.Text;
            if (textBox7.Text == null)
                b = "";
            else
                b = textBox7.Text;
            populate_carti(a, b);

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==4 && e.RowIndex>=0&& e.RowIndex<dataGridView5.Rows.Count-1)
            {
                if (3 - rez > 0)
                {
                    SqlCommand insert=new SqlCommand($"INSERT INTO Rezervari VALUES(@1,@2,@3,@4)", Program.Globals.con);
                    insert.Parameters.AddWithValue("1", id_ales);
                    insert.Parameters.AddWithValue("2", Convert.ToInt32(dataGridView5[0,e.RowIndex].Value));
                    insert.Parameters.AddWithValue("3", DateTime.Now);
                    insert.Parameters.AddWithValue("4", 1);
                    insert.ExecuteNonQuery();
                    rez = 0;
                    
                    populate_rezervari();
                }
                else MessageBox.Show("Poti rezerva maxim 3 carti!");
            }
            if (e.ColumnIndex == 5 && e.RowIndex >= 0 && e.RowIndex < dataGridView5.Rows.Count - 1)
            {
                if (3 - imp > 0)
                {
                    SqlCommand insert = new SqlCommand($"INSERT INTO Imprumuturi VALUES(@1,@2,@3,@4)", Program.Globals.con);
                    insert.Parameters.AddWithValue("1", id_ales);
                    insert.Parameters.AddWithValue("2", Convert.ToInt32(dataGridView5[0, e.RowIndex].Value));
                    insert.Parameters.AddWithValue("3", DateTime.Now);
                    insert.Parameters.AddWithValue("4", DBNull.Value);
                    imp = 0;

                    insert.ExecuteNonQuery();
                    populate_cititor();
                }
                else MessageBox.Show("Poti imprumuta maxim 3 carti!");
            }
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0&&e.RowIndex<dataGridView5.Rows.Count-1)
            {
                int idcarte = Convert.ToInt32(dataGridView5[0,e.RowIndex].Value);
                new Form4(idcarte).Show();
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox8.Text.Length > 0)
                    label15.Text = "x 7=" + (Convert.ToInt32(textBox8.Text) * 7).ToString();
                else
                    label15.Text = "";
            }
            catch
            {

            }
        }
        int maxpag;
        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView6.Rows.Clear();
            if (textBox8.Text.Length == 0) return;
            maxpag = 7 * Convert.ToInt32(textBox8.Text);
            List<(int id, string titlu, string autor, int pag)> lista = new List<(int id, string titlu, string autor, int pag)>();
            SqlCommand select = new SqlCommand("SELECT DISTINCT Carti.IdCarte,Titlu,Autor,NrPag FROM Carti " +
                "LEFT JOIN Imprumuturi ON Imprumuturi.IdCarte=Carti.IdCarte " +
                "LEFT JOIN Rezervari ON Rezervari.IdCarte=Carti.IdCarte " +
                $"WHERE ((Imprumuturi.IdCititor != {id_ales} AND Imprumuturi.DataRestituire IS NOT NULL) OR (Imprumuturi.IdCititor ={id_ales}) " +
                $"AND ((Rezervari.IdCititor != {id_ales} AND Rezervari.StatusRezervare=0) OR Rezervari.IdCititor={id_ales})) " +
                $"ORDER BY Carti.IdCarte", Program.Globals.con);

            SqlDataReader read = select.ExecuteReader();
            while(read.Read())
            {
                lista.Add((read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetInt32(3)));
            }
            read.Dispose();

            bool ok1 = false, ok2 = false;
            for(int i = 0; i < lista.Count; i++)
            {
                ok1 = false;
                for (int j = i+1; j < lista.Count; j++)
                {
                    ok2 = false;
                    for (int k = j+1; k < lista.Count; k++)
                    {
                        if (lista[i].pag + lista[j].pag + lista[k].pag<=maxpag)
                        {
                            ok2 = true;
                            ok1 = true;
                            dataGridView6.Rows.Add
                                (
                                    lista[i].id,
                                    lista[i].titlu,
                                    lista[i].autor,
                                    lista[i].pag,
                                    lista[j].id,
                                    lista[j].titlu,
                                    lista[j].autor,
                                    lista[j].pag,
                                    lista[k].id,
                                    lista[k].titlu,
                                    lista[k].autor,
                                    lista[k].pag,
                                    lista[i].pag + lista[j].pag + lista[k].pag
                                );

                        }
                    }
                    if(!ok2)
                    {
                        if(lista[i].pag + lista[j].pag<=maxpag)
                        {
                            ok1 = true;
                            dataGridView6.Rows.Add
                                (
                                    lista[i].id,
                                    lista[i].titlu,
                                    lista[i].autor,
                                    lista[i].pag,
                                    lista[j].id,
                                    lista[j].titlu,
                                    lista[j].autor,
                                    lista[j].pag,
                                    '-',
                                    '-',
                                    '-',
                                    '-',
                                    lista[i].pag + lista[j].pag
                                );
                        }
                    }
                }
                if(!ok1)
                {
                    if (lista[i].pag <= maxpag)
                    {
                        dataGridView6.Rows.Add
                                (
                                    lista[i].id,
                                    lista[i].titlu,
                                    lista[i].autor,
                                    lista[i].pag,
                                    '-',
                                    '-',
                                    '-',
                                    '-',
                                    '-',
                                    '-',
                                    '-',
                                    '-',
                                    lista[i].pag
                                );
                    }  
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            SqlCommand get = new SqlCommand("SELECT NumePrenume, Titlu, Autor, DataImprumut, DataRestituire FROM Imprumuturi " +
                "INNER JOIN Utilizatori ON Utilizatori.IdUtilizator=Imprumuturi.IdCititor " +
                $"INNER JOIN Carti ON Carti.IdCarte=Imprumuturi.IdCarte WHERE Utilizatori.IdUtilizator={id_ales}", Program.Globals.con);

            SqlDataReader read = get.ExecuteReader();
            while (read.Read())
            {

                dataGridView3.Rows.Add(read.GetString(0),
                    read.GetString(1),
                    read.GetString(2),
                    read.GetDateTime(3),
                    DBNull.Value
                    );
                if(!read.IsDBNull(4))
                {
                    dataGridView3[4,dataGridView3.Rows.Count-2].Value=read.GetDateTime(4);
                }
            }

            
        }
    }
}
