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
    public partial class Kaydol : Form
    {
        public Kaydol()
        {
            InitializeComponent();
        }

        Kisiler kisi = new Kisiler();
        Veritabani veri = new Veritabani();

        private void button1_Click(object sender, EventArgs e)
        {
            kisi.ad = textBox1.Text;
            kisi.soyad = textBox2.Text;
            kisi.kadi = textBox3.Text;
            kisi.sifre = textBox4.Text;
            kisi.tckn = textBox5.Text;
            kisi.telefon = textBox6.Text;
            kisi.email = textBox7.Text;
            kisi.adres = textBox8.Text;
            kisi.ktipi = Convert.ToInt32(textBox9.Text);
            veri.KullaniciEkle(kisi);

            MessageBox.Show("KAYIT BAŞARIYLA ALINMIŞTIR.");

            Giriş giris = new Giriş();
            giris.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
             Giriş giris = new Giriş();
             giris.Show();
             this.Hide();

            
        }
    }
}
