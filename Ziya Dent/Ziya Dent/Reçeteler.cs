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

namespace Ziya_Dent
{
    public partial class Reçeteler : Form
    {
        public Reçeteler()
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
            HastaAdCb.ValueMember = "HastaAd";
            HastaAdCb.DataSource = dt;
            baglanti.Close();
        }
        private void fillTedavi()
        {
            SqlConnection baglanti = MyConnection.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Randevu where Hasta ='"+ HastaAdCb.SelectedValue.ToString() + "'", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda=new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ReçeteTedaviTb.Text = dr["Tedavi"].ToString();
            }
            baglanti.Close();
        }
        private void fillTutar()
        {
            SqlConnection baglanti = MyConnection.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tedavi where TedaviAd ='" + ReçeteTedaviTb.Text + "'", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ReçetelerİlaçTb.Text = dr["TedaviÜcret"].ToString();
            }
            baglanti.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        Bitmap bitmap;
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            int height = ReçeteDGV.Height;
            ReçeteDGV.Height = ReçeteDGV.RowCount * ReçeteDGV.RowTemplate.Height * 2;
            bitmap = new Bitmap(ReçeteDGV.Width, ReçeteDGV.Height);
            ReçeteDGV.DrawToBitmap(bitmap, new Rectangle(0, 10, ReçeteDGV.Width, ReçeteDGV.Height));
            ReçeteDGV.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silmek İstenilen Reçeteyi Seçiniz.");
            }
            else
            {
                try
                {
                    string query = "Delete  from Recete where ReceteId=" + key + "";
                    Hs.HastaSil(query);
                    MessageBox.Show("Reçete Silindi.");
                    uyeler();
                    Reset();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Reçeteler_Load(object sender, EventArgs e)
        {
            fillHasta();
            uyeler();
            Reset();
        }

        private void HastaAdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fillTedavi();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Anasayfa ans = new Anasayfa();
            ans.Show();
            this.Hide();

        }

        private void ReçeteÜcretTb_TextChanged(object sender, EventArgs e)
        {
            fillTutar();
        }

        private void ReçeteTedaviTb_TextChanged(object sender, EventArgs e)
        {
            fillTutar();
        }
        void uyeler()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from Recete";
            DataSet ds = Hs.ShowHasta(query);
            ReçeteDGV.DataSource = ds.Tables[0];
        }
        void filter()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from Recete where HastaAd like '%" + AramaTb.Text + "%'";
            DataSet ds = Hs.ShowHasta(query);
            ReçeteDGV.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            HastaAdCb.SelectedItem = "";
            ReçeteTedaviTb.Text = "";
            ReçetelerİlaçTb.Text = "";
            ReçeteMiktarTb.Text = "";
            ReçetelerÜcretTb.Text = "";
            
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            string query = "insert into Recete values('" + HastaAdCb.SelectedValue.ToString() + "','" + ReçeteTedaviTb.Text + "','" + ReçetelerİlaçTb.Text + "','"+ ReçeteMiktarTb.Text+"','"+ ReçetelerÜcretTb.Text+"')";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Reçete Başarıyla Eklediniz.");
                uyeler();
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReçeteDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int key = 0;
        private void ReçeteDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HastaAdCb.Text = ReçeteDGV.SelectedRows[0].Cells[1].Value.ToString();
            ReçeteTedaviTb.Text = ReçeteDGV.SelectedRows[0].Cells[2].Value.ToString();
            ReçetelerÜcretTb.Text = ReçeteDGV.SelectedRows[0].Cells[3].Value.ToString();
            ReçetelerİlaçTb.Text = ReçeteDGV.SelectedRows[0].Cells[4].Value.ToString();
            ReçeteMiktarTb.Text = ReçeteDGV.SelectedRows[0].Cells[5].Value.ToString();
            
            if (ReçeteTedaviTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ReçeteDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void AramaTb_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void HastaAdCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
