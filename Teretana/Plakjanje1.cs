using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Teretana
{
    public partial class Plakjanje : Form
    {
        public Plakjanje()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-RV4OFEL\SQLEXPRESS;Initial Catalog=TeretanaDb;Integrated Security=True;Pooling=False");

        public static DataTable DataSource { get; private set; }

        private void PopolniIme()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CIme from ClenoviTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CIme", typeof(string));
            dt.Load(rdr);
            ImeCb.ValueMember = "CIme";
            ImeCb.DataSource = dt;
            Con.Close();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from PlakjanjeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PlakjanjeDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GlavnaForma glavnaforma = new GlavnaForma();
            glavnaforma.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // ImeTb.Text = "";
            IznosTb.Text = "";
        }

        private void Plakjanje_Load(object sender, EventArgs e)
        {
            PopolniIme();
            populate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(ImeCb.Text == "" || IznosTb.Text == "")
            {
                MessageBox.Show("Nedostiga Podatok");
            }
            else
            {
                string platenperiod = Periode.Value.Month.ToString() + Periode.Value.Year.ToString();
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PlakjanjeTbl where PClen'" + ImeCb.SelectedValue.ToString() + "'  and PMesec='" + platenperiod + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Plateno Za Ovaj Mesec");
                }
                else
                {
                    string query = "insert into PlakjanjeTbl values('" + platenperiod + "','" + ImeCb.SelectedValue.ToString() + "'," + IznosTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Plakjanjeto e Uspeshno ");
                }
                Con.Close();
                populate();
            }
        }

        private void IznesTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
