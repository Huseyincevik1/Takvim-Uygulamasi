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
           
            if (veritabani.KullaniciKontrol(kullaniciAdi, sifre))
            {
                Kisiler kullanici = veritabani.KullaniciGetir(kullaniciAdi, sifre);
                GirisYapanKullanici.KullaniciBilgileri = kullanici;
                 Anasayfa ana = new Anasayfa();
                 ana.KullaniciBilgileri = kullanici;
                 ana.Show();
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
