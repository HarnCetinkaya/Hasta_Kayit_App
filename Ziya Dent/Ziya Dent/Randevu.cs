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

namespace Ziya_Dent
{
    public partial class Randevu : Form
    {
        public Randevu()
        {
            InitializeComponent();
        }
        ConnectionString MyConnection = new ConnectionString();
        private void fillHasta()
        {
            SqlConnection baglanti = MyConnection.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select HastaAd from Hasta ", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("HastaAd", typeof(string));
            dt.Load(rdr);
            RandevuAdCb.ValueMember = "HastaAd";
            RandevuAdCb.DataSource = dt;
            baglanti.Close();
        }
        private void fillTedavi()
        {
            SqlConnection baglanti = MyConnection.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select TedaviAd from Tedavi ", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TedaviAd", typeof(string));
            dt.Load(rdr);
            RandevuTedaviCb.ValueMember = "TedaviAd";
            RandevuTedaviCb.DataSource = dt;
            baglanti.Close();
        }
        private void Randevu_Load(object sender, EventArgs e)
        {
            fillHasta();
            fillTedavi();
            uyeler();
            reset();
        }
        void uyeler()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from Randevu";
            DataSet ds = Hs.ShowHasta(query);
            RandevuDGV.DataSource = ds.Tables[0];
        }
        void filter()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from Randevu where Hasta like '%" + AramaTb.Text + "%'";
            DataSet ds = Hs.ShowHasta(query);
            RandevuDGV.DataSource = ds.Tables[0];
        }
        void reset()
        {
            RandevuAdCb.SelectedValue = -1;
            RandevuTedaviCb.SelectedIndex = -1;
            RandevuTarih.Text = "";
            RandevuSaatCb.Text = "";

        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            string query = "insert into Randevu values('" + RandevuAdCb.SelectedValue.ToString() + "','" + RandevuTedaviCb.SelectedValue.ToString() + "','" + RandevuTarih.Value + "','" + RandevuSaatCb.Text + "')";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Randevu Başarıyla Eklediniz.");
                uyeler();
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silmek İstenilen Randevuyu Seçiniz.");
            }
            else
            {
                try
                {
                    string query = "Delete  from Randevu where RandevuId=" + key + "";
                    Hs.HastaSil(query);
                    MessageBox.Show("Randevu Silindi.");
                    uyeler();
                    reset();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Düzenlemek İstediğin Randevuyu Seçiniz.");
            }
            else
            {
                try
                {
                    string query = "Update Randevu set Hasta='" + RandevuAdCb.SelectedValue.ToString() + "', Tedavi='" + RandevuTedaviCb.SelectedValue.ToString() + "', RandevuTarih='" + RandevuTarih.Text + "', RandevuSaat='" + RandevuSaatCb.Text + "' where RandevuId=" + key + ";";
                    Hs.HastaSil(query);
                    MessageBox.Show("Randevu İşlemi Güncellendi.");
                    uyeler();
                    reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void RandevuDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                RandevuAdCb.SelectedValue = RandevuDGV.SelectedRows[0].Cells[1].Value.ToString();
                RandevuTedaviCb.SelectedValue = RandevuDGV.SelectedRows[0].Cells[2].Value.ToString();
                RandevuTarih.Text = RandevuDGV.SelectedRows[0].Cells[3].Value.ToString();
                RandevuSaatCb.Text = RandevuDGV.SelectedRows[0].Cells[4].Value.ToString();

                if (RandevuAdCb.SelectedIndex == -1)
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(RandevuDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
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

        private void RandevuAdCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
