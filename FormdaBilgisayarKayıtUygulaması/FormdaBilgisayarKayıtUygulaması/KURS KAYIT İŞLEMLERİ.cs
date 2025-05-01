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
    public partial class KURS_KAYIT_İŞLEMLERİ : Form
    {

        SqlConnection con = new SqlConnection("server= .;initial catalog=yazılımKayıtDb;integrated security=sspi");
        SqlCommand cmd;

        public void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            pictureBox1.ImageLocation = "";
        }
        public void listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from tblKursiyer", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public KURS_KAYIT_İŞLEMLERİ()
        {
            InitializeComponent();
        }

        private void KURS_KAYIT_İŞLEMLERİ_Load(object sender, EventArgs e)
        {
            label2.Text = "Hoş Geldiniz" + " " + Form1.isim;
            listele();
        }



        private void button5_Click(object sender, EventArgs e) //Temizleme
        {
            temizle();
        }

        private void button1_Click(object sender, EventArgs e) //Fotograf Ekleme
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyaları |*.jpg;*.jpeg;*.png|Tüm Dosyalar|*.*";

            if (dosya.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = dosya.FileName;
                textBox6.Text = dosya.FileName; // Dosya yolunu textBox'a yazdırma
            }
        }

        private void button2_Click(object sender, EventArgs e) //ekleme
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Tüm Alanları Doldurunuz.", "Eksik Kayıt Uyarısı");
                }
                else
                {
                    cmd = new SqlCommand("insert into tblKursiyer (adi,soyadi,telNo,adres,mail,foto) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "') ", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Öğrenci Kaydı Başarılı", "Kayıt EKranı");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem Yaptınız!!!", "Hata ekranı");
            }
            finally 
            {
                con.Close();
                listele();
            }
           

            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text=dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e) // Güncelleme
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Tüm Alanları Doldurunuz.", "Eksik Kayıt Uyarısı");
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE tblKursiyer SET adi=@adi, soyadi=@soyadi, telNo=@telNo, adres=@adres, mail=@mail, foto=@foto WHERE kursiyerNo=@kursiyerNo", con))
                    {
                        cmd.Parameters.AddWithValue("@adi", textBox1.Text);
                        cmd.Parameters.AddWithValue("@soyadi", textBox2.Text);
                        cmd.Parameters.AddWithValue("@telNo", textBox3.Text);
                        cmd.Parameters.AddWithValue("@adres", textBox4.Text);
                        cmd.Parameters.AddWithValue("@mail", textBox5.Text);
                        cmd.Parameters.AddWithValue("@foto", textBox6.Text);
                        cmd.Parameters.AddWithValue("@kursiyerNo", int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    MessageBox.Show("Kursiyer Güncelleme Başarılı", "Güncelleme Ekranı");

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem Yaptınız!!!", "Hata ekranı");
            }
            finally
            {
                con.Close();
                listele();
            }

        }

        private void button4_Click(object sender, EventArgs e) //Silme
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Silmek İstediğiniz Kişiyi Seçiniz", "Silme Uyarısı");
                }
                else
                {
                    cmd = new SqlCommand("DELETE from  tblKursiyer where kursiyerNo='" + int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())+"' ", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Silme Başarılı", "Silme EKranı");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem Yaptınız!!!", "Hata ekranı");
            }
            finally
            {
                con.Close();
                listele();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e) //Arama
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from tblKursiyer where adi like '"+textBox7.Text+"%' ", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        
    }
}
