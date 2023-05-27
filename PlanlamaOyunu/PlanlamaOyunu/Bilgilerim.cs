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
    public partial class Bilgilerim : Form
    {
        public Kisiler KullaniciBilgileri { get; set; }
        public Olaylar OlayBilgileri { get; set; }
        public Bilgilerim()
        {
            InitializeComponent();
        }
        Veritabani veritabani = new Veritabani();
        Kisiler kisi = new Kisiler();

        private void Bilgilerim_Load(object sender, EventArgs e)
        {
            label1.Text = KullaniciBilgileri.kadi;
            textBox1.Text = KullaniciBilgileri.ad;
            textBox2.Text = KullaniciBilgileri.soyad;
            textBox3.Text = KullaniciBilgileri.kadi;
            textBox4.Text = KullaniciBilgileri.sifre;
            textBox5.Text = KullaniciBilgileri.tckn;
            textBox6.Text = KullaniciBilgileri.telefon;
            textBox7.Text = KullaniciBilgileri.email;
            textBox8.Text = KullaniciBilgileri.adres;
            textBox9.Text = KullaniciBilgileri.ktipi.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            kisi.kadi = textBox3.Text;
            kisi.sifre = textBox4.Text;
            kisi.telefon = textBox6.Text;
            kisi.email = textBox7.Text;
            kisi.adres = textBox8.Text;
            kisi.kisiId = KullaniciBilgileri.kisiId;

            veritabani.KisiGuncelle(kisi);
            MessageBox.Show("Bilgileriniz başarıyla güncellenmiştir.");
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sifre = KullaniciBilgileri.sifre;
            string kad = KullaniciBilgileri.kadi;
            Kisiler kullanici = veritabani.KullaniciGetir(kad, sifre);
            Anasayfa ana = new Anasayfa();
            ana.KullaniciBilgileri = kullanici;
            ana.Show(); 
            this.Close();
        }
    }
}
