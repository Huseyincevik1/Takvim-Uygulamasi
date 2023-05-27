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
    public partial class Anasayfa : Form
    {
        public Kisiler KullaniciBilgileri { get; set; }

        public Olaylar OlayBilgileri { get; set; }

        
        public Anasayfa()
        {
            InitializeComponent();
        }
        Veritabani veritabani = new Veritabani();

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            label1.Text = KullaniciBilgileri.kadi; 
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Emin misiniz?", "Çıkış Yap", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Giriş girisEkrani = new Giriş();
                this.Hide();
                girisEkrani.ShowDialog();
                this.Close();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string sifre = KullaniciBilgileri.sifre;
            string kad = KullaniciBilgileri.kadi;
            Kisiler kullanici = veritabani.KullaniciGetir(kad, sifre);
            Otanımla o = new Otanımla();
            o.KullaniciBilgileri = kullanici;
            o.Show(); 
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sifre = KullaniciBilgileri.sifre;
            string kad = KullaniciBilgileri.kadi;
            Kisiler kullanici = veritabani.KullaniciGetir(kad, sifre);
            Bilgilerim o = new Bilgilerim();
            o.KullaniciBilgileri = kullanici;
            o.Show(); 
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sifre = KullaniciBilgileri.sifre;
            string kad = KullaniciBilgileri.kadi;
            Kisiler kullanici = veritabani.KullaniciGetir(kad, sifre);
            Obilgilerim o = new Obilgilerim();
            o.KullaniciBilgileri = kullanici;
            o.Show();
            this.Close();
        }
    }
}
