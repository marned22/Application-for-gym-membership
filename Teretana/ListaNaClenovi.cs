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
    public partial class ListaNaClenovi : Form
    {
        public ListaNaClenovi()
        {
            InitializeComponent();
        }
        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
        private void ListaNaClenovi_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Najava naj = new Najava();
            naj.Show();
            this.Hide();
        }

        private void Clenovi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}
