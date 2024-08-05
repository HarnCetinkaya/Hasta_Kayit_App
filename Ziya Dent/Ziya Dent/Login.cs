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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (KullanıcıTb.Text == "" || ŞifreTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz.");
            }
            else if(KullanıcıTb.Text=="Admin"&& ŞifreTb.Text == "1905")
            {
                Anasayfa ans =new Anasayfa();
                ans.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı Yada Şifre.");
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
