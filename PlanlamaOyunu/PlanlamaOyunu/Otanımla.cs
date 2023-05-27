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
    public partial class Otanımla : Form
    {
        public Kisiler KullaniciBilgileri { get; set; }
        public Olaylar OlayBilgileri { get; set; }
        public Otanımla()
        {
            InitializeComponent();
        }

        private void Otanımla_Load(object sender, EventArgs e)
        {
            dateTimePicker1.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
            label1.Text = KullaniciBilgileri.kadi; // kullanıcının adını Label kontrolüne yazdırıyoruz
            //label2.Text = KullaniciBilgileri.kisiId.ToString();
            //OlayBilgileri.kisiId = KullaniciBilgileri.kisiId;
        }
        Veritabani veritabani = new Veritabani();
        Olaylar olaylar = new Olaylar();

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                olaylar.islemzamani = DateTime.Parse(textBox1.Text);
                olaylar.baslangicsaat = TimeSpan.Parse(textBox2.Text);
                olaylar.bitissaat = TimeSpan.Parse(textBox3.Text);
                olaylar.olaytipi = textBox4.Text;
                olaylar.olayaciklama = textBox5.Text;
                olaylar.uyaribildirimi = Convert.ToInt32(textBox6.Text);
                olaylar.kisiId = KullaniciBilgileri.kisiId;
                veritabani.OlayEkle(olaylar);

                MessageBox.Show("Kayıt başarıyla alınmıştır");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt işlemi sırasında bir hata oluştu: " + ex.Message);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sifre = KullaniciBilgileri.sifre;
            string kad = KullaniciBilgileri.kadi;
            Kisiler kullanici = veritabani.KullaniciGetir(kad, sifre);
            // Kisiler kullanici = new Kisiler();
            Anasayfa ana = new Anasayfa();
            ana.KullaniciBilgileri = kullanici;
            ana.Show(); // burda kaldın otanımla kısmına kiml,k bilgisi getirmen, eçilen tarihi textboxlara yazdırman butona basınca kaydetmenlazım kayıt işlemlerini hallettin.
            this.Close();
        }
    }
}
