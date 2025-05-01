using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormdaBilgisayarKayıtUygulaması
{
    public partial class KULLANICI_KAYIT : Form
    {
        SqlConnection con=new SqlConnection("server= .;initial catalog=yazılımKayıtDb;integrated security=sspi");
        SqlCommand cmd;


        public KULLANICI_KAYIT()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();

        }

        private void button1_Click(object sender, EventArgs e) //Kayıt Butonu
        {
            try
            {
                if (textBox4.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("Tüm Alanları Doldurunuz", "Eksik İşlem Ekranı");
                }
                else if (textBox5.Text != textBox6.Text)
                {
                    MessageBox.Show("Parolanız Aynı Değil", "Parola Kayıt Hata Ekranı ");
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("insert into tblLogin (adi,soyadi,telNo,kullaniciAd,parola,parolaTekrar) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "') ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kullanıcı Kayıt Başarılı ", "Kayıt Ekranı");
                    this.Hide();
                    Form1 f1 = new Form1();
                    f1.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata İşlem Yaptınız", "Hata Ekranı");

            }
            finally 
            {
                con.Close() ;
            }
            
        }
    }
}
