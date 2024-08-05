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
    public partial class Tedavi : Form
    {
        public Tedavi()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            string query = "insert into Tedavi values('" + TedaviAdTb.Text + "','" + ÜcretTb.Text + "','" + AçıklamaTb.Text + "')";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Tedaviyi Başarıyla Eklediniz.");
                uyeler();
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int key = 0;

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Düzenlemek İstediğin Tedaviyi Seçiniz.");
            }
            else
            {
                try
                {
                    string query = "Update Tedavi set TedaviAd='" + TedaviAdTb.Text + "', TedaviÜcret='" + ÜcretTb.Text + "', TedaviAcıklama='" + AçıklamaTb.Text + "' where TedaviId=" + key + ";";
                    Hs.HastaSil(query);
                    MessageBox.Show("Tedavi İşlemi Güncellendi.");
                    uyeler();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silmek İstenilen Tedaviyi Seçiniz.");
            }
            else
            {
                try
                {
                    string query = "Delete  from Tedavi where TedaviId=" + key + "";
                    Hs.HastaSil(query);
                    MessageBox.Show("Tedavi Silindi.");
                    uyeler();
                    Reset();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        void uyeler()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from Tedavi";
            DataSet ds = Hs.ShowHasta(query);
            TedaviDGV.DataSource = ds.Tables[0];
        }
        void filter()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from Tedavi where TedaviAd like '%" + AramaTb.Text + "%'";
            DataSet ds = Hs.ShowHasta(query);
            TedaviDGV.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            TedaviAdTb.Text = "";
            ÜcretTb.Text = "";
            AçıklamaTb.Text = "";
        }

        private void Tedavi_Load(object sender, EventArgs e)
        {
            uyeler();
            Reset();
            
        }

        private void TedaviDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TedaviDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TedaviAdTb.Text = TedaviDGV.SelectedRows[0].Cells[1].Value.ToString();
            ÜcretTb.Text = TedaviDGV.SelectedRows[0].Cells[2].Value.ToString();
            AçıklamaTb.Text = TedaviDGV.SelectedRows[0].Cells[3].Value.ToString();
            
            if (TedaviAdTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TedaviDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Anasayfa ans = new Anasayfa();
            ans.Show();
            this.Hide();
        }

        private void AramaTb_TextChanged(object sender, EventArgs e)
        {
            filter();
        }
    }
}
