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
    public partial class DodajClen : Form
    {
        public DodajClen()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-RV4OFEL\SQLEXPRESS;Initial Catalog=TeretanaDb;Integrated Security=True;Pooling=False");
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void DodajClen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ImeTb.Text == "" || TelefonTb.Text == "" || IznosTb.Text == "" || VozrastTb.Text == "")
            {
                MessageBox.Show("Nedostasuva podatok");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into ClenoviTbl values('" + ImeTb.Text + "','" + TelefonTb.Text + "','" + PolCb.SelectedItem.ToString() + "','" + VozrastTb.Text + "','" + IznosTb.Text + "','" + PeriodCb.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Clenot e uspeshno dodaden");
                    Con.Close();
                    IznosTb.Text = "";
                    VozrastTb.Text = "";
                    ImeTb.Text = "";
                    TelefonTb.Text = "";
                    PolCb.Text = "";
                    PeriodCb.Text = "";
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IznosTb.Text = "";
            VozrastTb.Text = "";
            ImeTb.Text = "";
            TelefonTb.Text = "";
            PolCb.Text = "";
            PeriodCb.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GlavnaForma glavnaforma = new GlavnaForma();
            glavnaforma.Show();
            this.Hide();
        }
    }
}
