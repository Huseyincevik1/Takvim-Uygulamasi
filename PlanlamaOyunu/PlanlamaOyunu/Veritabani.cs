using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PlanlamaOyunu
{
    public class Veritabani
    {
        private SqlConnection baglanti;
        public Veritabani()
        {
            baglanti = new SqlConnection("Data Source=.;Initial Catalog=TakvimDB;Integrated Security=True");
        }
       
        public bool KullaniciKontrol(string kullaniciAdi, string sifre)
        {
            bool sonuc = false;
            string sorgu = "SELECT COUNT(*) FROM tbl_Kisiler WHERE KullaniciAdi=@kullaniciAdi AND Sifre=@sifre";

            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                int sayi = (int)cmd.ExecuteScalar();
                if (sayi > 0)
                {
                    sonuc = true;
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                baglanti.Close();
            }

            return sonuc;
        }

        public void KullaniciEkle(Kisiler kisi)
        {
            string sorgu = "INSERT INTO tbl_Kisiler (Ad, Soyad, KullaniciAdi, Sifre, Tckn, Telefon, Email, Adres, Ktipi) VALUES (@ad, @soyad, @kullaniciAdi, @sifre, @tckn, @tel, @email, @adres, @ktipi)";
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@ad", kisi.ad);
                cmd.Parameters.AddWithValue("@soyad", kisi.soyad);
                cmd.Parameters.AddWithValue("@kullaniciAdi", kisi.kadi);
                cmd.Parameters.AddWithValue("@sifre", kisi.sifre);
                cmd.Parameters.AddWithValue("@tckn", kisi.tckn);
                cmd.Parameters.AddWithValue("@tel", kisi.telefon);
                cmd.Parameters.AddWithValue("@email", kisi.email);
                cmd.Parameters.AddWithValue("@adres", kisi.adres);
                cmd.Parameters.AddWithValue("@ktipi", kisi.ktipi);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                baglanti.Close();
            }
        }

        public Kisiler KullaniciGetir(string kullaniciAdi, string sifre)
        {
            Kisiler kisi = null;
            string sorgu = "SELECT * FROM tbl_Kisiler WHERE KullaniciAdi=@kullaniciAdi AND Sifre=@sifre";

            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    kisi = new Kisiler();
                    kisi.kisiId = reader.GetInt32(reader.GetOrdinal("kisiId"));
                    kisi.ad = reader.GetString(reader.GetOrdinal("Ad"));
                    kisi.soyad = reader.GetString(reader.GetOrdinal("Soyad"));
                    kisi.kadi = reader.GetString(reader.GetOrdinal("KullaniciAdi"));
                    kisi.sifre = reader.GetString(reader.GetOrdinal("Sifre"));
                    kisi.tckn = reader.GetString(reader.GetOrdinal("Tckn"));
                    kisi.telefon = reader.GetString(reader.GetOrdinal("Telefon"));
                    kisi.email = reader.GetString(reader.GetOrdinal("Email"));
                    kisi.adres = reader.GetString(reader.GetOrdinal("Adres"));
                    kisi.ktipi = reader.GetInt32(reader.GetOrdinal("Ktipi"));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                baglanti.Close();
            }

            return kisi;
        }

        public void OlayEkle(Olaylar olay)
        {
            string sorgu = "INSERT INTO tbl_Olay (IslemZamani, BaslangicSaat, BitisSaat, OlayTipi, OlayAciklama, KisiId, UyariBildirimi) VALUES (@izamani, @baslangicSaat, @bitisSaat, @olayTipi, @olayAciklama,@kisiId,@uyari)";
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@izamani", olay.islemzamani);
                cmd.Parameters.AddWithValue("@baslangicSaat", olay.baslangicsaat);
                cmd.Parameters.AddWithValue("@bitisSaat", olay.bitissaat);
                cmd.Parameters.AddWithValue("@olayTipi", olay.olaytipi);
                cmd.Parameters.AddWithValue("@olayAciklama", olay.olayaciklama);
                cmd.Parameters.AddWithValue("@kisiId", olay.kisiId);
                cmd.Parameters.AddWithValue("@uyari", olay.uyaribildirimi);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                baglanti.Close();
            }
        }


        public void KisiGuncelle(Kisiler kisi)
        {
            string sorgu = "update tbl_Kisiler set KullaniciAdi=@kullaniciAdi, Sifre =@sifre, Telefon =@tel, Email=@email, Adres=@adres where KisiId =@kisiId";
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kullaniciAdi", kisi.kadi);
                cmd.Parameters.AddWithValue("@sifre", kisi.sifre);
                cmd.Parameters.AddWithValue("@tel", kisi.telefon);
                cmd.Parameters.AddWithValue("@email", kisi.email);
                cmd.Parameters.AddWithValue("@adres", kisi.adres);
                cmd.Parameters.AddWithValue("@kisiId", kisi.kisiId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                baglanti.Close();
            }
        }

        public DataTable OlayGoruntule(int kisiId)
        {
            string sorgu = "SELECT OlayId, IslemZamani,BaslangicSaat,BitisSaat,OlayTipi,OlayAciklama, UyariBildirimi FROM tbl_Olay WHERE KisiID = @kisiId";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(baglanti.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@kisiId", kisiId);
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }



        public void OlaySil(int olayId)
        {
            string sorgu = "delete from tbl_Olay where OlayId=@olayId";
            try
            {
                using (SqlConnection conn = new SqlConnection(baglanti.ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@olayId", olayId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                baglanti.Close();
            }
        }

        public void OlayGuncelle(Olaylar olay)
        {
            string sorgu = "update tbl_Olay set IslemZamani=@izamani, BaslangicSaat =@basaat, BitisSaat =@bisaat, OlayTipi=@otipi, OlayAciklama=@oaciklama, UyariBildirimi=@uyari where OlayId =@olayId";
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@izamani",olay.islemzamani);
                cmd.Parameters.AddWithValue("@basaat", olay.baslangicsaat);
                cmd.Parameters.AddWithValue("@bisaat", olay.bitissaat);
                cmd.Parameters.AddWithValue("@otipi", olay.olaytipi);
                cmd.Parameters.AddWithValue("@oaciklama", olay.olayaciklama);
                cmd.Parameters.AddWithValue("@olayId", olay.olayId);
                cmd.Parameters.AddWithValue("@uyari", olay.uyaribildirimi);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}
