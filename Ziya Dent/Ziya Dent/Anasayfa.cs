using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ziya_Dent
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Tedavi tdv = new Tedavi();
            tdv.Show();
            this.Hide();
            
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Randevu rnd = new Randevu();
            rnd.Show();
            this.Hide();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Hasta ht = new Hasta();
            ht.Show();
            this.Hide();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            Reçeteler rçt = new Reçeteler();
            rçt.Show();
            this.Hide();
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {

        }
    }
}
