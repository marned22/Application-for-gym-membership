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

namespace Teretana
{
    public partial class AzurirajIzbrisi : Form
    {
        public AzurirajIzbrisi()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-RV4OFEL\SQLEXPRESS;Initial Catalog=TeretanaDb;Integrated Security=True;Pooling=False");
        private void populate()
        {
            Con.Open();
            string query = "select * from ClenoviTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            Clenovi.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void AzurirajIzbrisi_Load(object sender, EventArgs e)
        {
            populate();
        }

        int key=0;
        private void Clenovi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(Clenovi.SelectedRows[0].Cells[0].Value.ToString());
            ImeTb.Text = Clenovi.SelectedRows[0].Cells[1].Value.ToString();
            TelefonTb.Text = Clenovi.SelectedRows[0].Cells[2].Value.ToString();
            PolCb.Text = Clenovi.SelectedRows[0].Cells[3].Value.ToString();
            VozrastTb.Text = Clenovi.SelectedRows[0].Cells[4].Value.ToString();
            IznosTb.Text = Clenovi.SelectedRows[0].Cells[5].Value.ToString();
            PeriodCb.Text = Clenovi.SelectedRows[0].Cells[6].Value.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ImeTb.Text = "";
            VozrastTb.Text = "";
            TelefonTb.Text = "";
            PeriodCb.Text = "";
            IznosTb.Text = "";
            PolCb.Text = "";
           
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            GlavnaForma glavnaforma= new GlavnaForma();
            glavnaforma.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(key == 0)
            {
                MessageBox.Show("Odberi Chlen Shto Sakash Da Bidi Izbrishan");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from ClenoviTbl where CId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Clenot e Izbrishan");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0 || ImeTb.Text == "" || TelefonTb.Text == "" || VozrastTb.Text == "" || IznosTb.Text == "" || PolCb.Text == "" || PeriodCb.Text == "")
            {
                MessageBox.Show("Odberi Chlen Shto Sakash Da Bidi Izbrishan");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update ClenoviTbl set CIme='"+ImeTb.Text+"', CTelefon='"+TelefonTb.Text+"', CPol='"+PolCb.Text+"', CVozrast='"+VozrastTb.Text+"',CPeriod='"+PeriodCb.Text+"' where CId="+key+";";
                     
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Clenot e Azhuriran");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
