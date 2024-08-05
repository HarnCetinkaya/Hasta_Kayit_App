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
    public partial class Hasta : Form
    {
        public Hasta()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            string query = "insert into Hasta values('" + HastaAdSoyadTb.Text + "','" + HastaTelefonTb.Text + "','" + HastaAdresTb.Text + "','" + HastaDogumTarih.Text + "','" + HastaCinsiyetCb.SelectedItem.ToString() + "','" + HastaAlerjiTb.Text + "')";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Hastayı Başarıyla Eklediniz.");
                uyeler();
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void uyeler()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from Hasta";
            DataSet ds = Hs.ShowHasta(query);
            HastaDGV.DataSource = ds.Tables[0];
        }
        void filter()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from Hasta where HastaAd like '%"+AramaTb.Text+"%'";
            DataSet ds = Hs.ShowHasta(query);
            HastaDGV.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            HastaAdSoyadTb.Text = "";
            HastaTelefonTb.Text = "";
            HastaAdresTb.Text = "";
            HastaDogumTarih.Text = "";
            HastaCinsiyetCb.SelectedItem = "";
            HastaAlerjiTb.Text = "";
        }
        private void Hasta_Load(object sender, EventArgs e)
        {
            uyeler();
            Reset();
        }
        int key = 0;
        private void HastaDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HastaAdSoyadTb.Text = HastaDGV.SelectedRows[0].Cells[1].Value.ToString();
            HastaTelefonTb.Text = HastaDGV.SelectedRows[0].Cells[2].Value.ToString();
            HastaAdresTb.Text = HastaDGV.SelectedRows[0].Cells[3].Value.ToString();
            HastaDogumTarih.Text = HastaDGV.SelectedRows[0].Cells[4].Value.ToString();
            HastaCinsiyetCb.SelectedItem = HastaDGV.SelectedRows[0].Cells[5].Value.ToString();
            HastaAlerjiTb.Text = HastaDGV.SelectedRows[0].Cells[6].Value.ToString();
            if(HastaAdSoyadTb.Text =="")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32( HastaDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if(key==0)
            {
                MessageBox.Show("Silmek İstenilen Hastayı Seçiniz.");
            }
            else
            {
                try
                {
                    string query = "Delete  from Hasta where HastaId=" + key + "";
                    Hs.HastaSil(query);
                    MessageBox.Show("Hasta Silindi.");
                    uyeler();
                    Reset();
                    

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
           
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Düzenlemek İstediğin Hastayı Seçiniz.");
            }
            else
            {
                try
                {
                    string query = "Update Hasta set HastaAd='"+HastaAdSoyadTb.Text+"', HastaTelefon='"+HastaTelefonTb.Text+ "', HastaAdres='"+HastaAdresTb.Text+ "', HastaDoğumTarih='"+HastaDogumTarih.Text+ "', HastaCinsiyet='"+HastaCinsiyetCb.SelectedItem.ToString()+ "', HastaAlerji='"+HastaAlerjiTb.Text+"' where HastaId=" + key + ";";
                    Hs.HastaSil(query);
                    MessageBox.Show("Hasta Güncellendi.");
                    uyeler();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Anasayfa ans = new Anasayfa();
            ans.Show();
            this.Hide();
        }

        private void HastaDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AramaTb_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void HastaAdSoyadTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
