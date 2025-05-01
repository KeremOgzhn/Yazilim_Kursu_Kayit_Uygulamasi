using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FormdaBilgisayarKayıtUygulaması
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("server= .;initial catalog=yazılımKayıtDb;integrated security=sspi");
        SqlCommand cmd;
        public static string isim;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KULLANICI_KAYIT kk= new KULLANICI_KAYIT();
            this.Hide();
            kk.Show();
        }

        private void button1_Click(object sender, EventArgs e) //Giriş Butonu
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from tblLogin", con);
                SqlDataReader dr = cmd.ExecuteReader();
                bool sonuc = false;

                while (dr.Read())
                {
                    if (dr[4].ToString().Trim() == textBox1.Text && dr[5].ToString().Trim() == textBox2.Text)
                    {
                        isim = dr[1].ToString();
                        sonuc = true;
                        MessageBox.Show("Giriş Başarılı", "Giriş Ekranı");
                        break;
                    }
                }
                if (sonuc)
                {
                    sonuc = false;
                    KURS_KAYIT_İŞLEMLERİ kki = new KURS_KAYIT_İŞLEMLERİ();
                    this.Hide();
                    kki.Show();
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı Veya Parola!!!", "Hatalı Giriş Deneme Ekranı");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem ", "Hata Ekranı");

            }
            finally
            {
             con.Close();
            }
            




        }
    }
}
