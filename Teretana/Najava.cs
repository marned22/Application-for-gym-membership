using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teretana
{
    public partial class Najava : Form
    {
        public Najava()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(UIdTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Imate Greshka");
            }
            else if(UIdTb.Text == "Admin" && PassTb.Text == "Admin")
            {
                GlavnaForma glavnaforma = new GlavnaForma();
                glavnaforma.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UIdTb.Text = "";
            PassTb.Text = "";
        }
    }
}
