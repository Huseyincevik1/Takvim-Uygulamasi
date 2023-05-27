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
    public partial class Obilgilerim : Form
    {
        public Kisiler KullaniciBilgileri { get; set; }
        public Olaylar OlayBilgileri { get; set; }

        Veritabani veritabani = new Veritabani();
        Olaylar olaylar = new Olaylar();
        public Obilgilerim()
        {
            InitializeComponent();
            
        }

        private void Obilgilerim_Load(object sender, EventArgs e)
        {
            label1.Text = KullaniciBilgileri.kadi;
            int seciliKisi = KullaniciBilgileri.kisiId; 
            DataTable dt = veritabani.OlayGoruntule(seciliKisi);
            dataGridView1.DataSource = dt;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DateTime islemZamani = Convert.ToDateTime(row.Cells["IslemZamani"].Value);
                TimeSpan kalanSure = islemZamani - DateTime.Now;

                if (kalanSure.TotalDays < Convert.ToInt32(row.Cells["UyariBildirimi"].Value))
                {
                    pictureBox1.BackgroundImage = Image.FromFile("C:/Users/gbh/source/repos/PlanlamaOyunu/PlanlamaOyunu/Resources/kırmızızarf.png"); // Kırmızı zarf resmini yükle
                    MessageBox.Show("Tarihi yaklaşmış etkinlikleriniz var.");
                    break; 
                   
                }
                else
                {
                    pictureBox1.BackgroundImage = Image.FromFile("C:/Users/gbh/source/repos/PlanlamaOyunu/PlanlamaOyunu/Resources/beyazzarf.png"); // Beyaz zarf resmini yükle
                }
            }

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

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int olayId = Convert.ToInt32(textBox1.Text);
                veritabani.OlaySil(olayId);
                MessageBox.Show("Kayıt başarıyla silinmiştir.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt silme işlemi sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                olaylar.olayId = Convert.ToInt32(textBox1.Text);
                olaylar.islemzamani =DateTime.Parse(dateTimePicker1.Value.ToString());
                olaylar.baslangicsaat = TimeSpan.Parse(textBox2.Text);
                olaylar.bitissaat = TimeSpan.Parse(textBox3.Text);
                olaylar.olaytipi = textBox4.Text;
                olaylar.olayaciklama = textBox5.Text;
                olaylar.uyaribildirimi = Convert.ToInt32(textBox6.Text);
                veritabani.OlayGuncelle(olaylar);
                MessageBox.Show("Etkinlik başarıyla güncellenmiştir");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt işlemi sırasında bir hata oluştu: " + ex.Message);
            }
        }
    }
}
