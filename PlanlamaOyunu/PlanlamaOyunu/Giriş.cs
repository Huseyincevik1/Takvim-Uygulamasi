using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanlamaOyunu
{

    public partial class Giriş : Form
    {
        public static class GirisYapanKullanici
        {
            public static Kisiler KullaniciBilgileri { get; set; }
        }
        public Giriş()
        {
            InitializeComponent();
        }
        Veritabani veritabani = new Veritabani();
       

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text;
            string sifre = textBox2.Text;

            // Kullanıcı adı ve şifresi doğruysa, kullanıcı bilgilerini alıp GirisYapanKullanici sınıfındaki KullaniciBilgileri property'sine atıyoruz.
            if (veritabani.KullaniciKontrol(kullaniciAdi, sifre))
            {
                Kisiler kullanici = veritabani.KullaniciGetir(kullaniciAdi, sifre);
                GirisYapanKullanici.KullaniciBilgileri = kullanici;

                // Başka bir form açılırken, bu sınıfta tutulan kullanıcı bilgilerine erişmek için bu örnekteki gibi kullanabilirsiniz:
                 Anasayfa ana = new Anasayfa();
                 ana.KullaniciBilgileri = kullanici;
                 ana.Show();

                // Formu kapatıyoruz.
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış.");
            }

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Kaydol k = new Kaydol();
            k.Show();
            this.Hide();
        }

        
    }
}
