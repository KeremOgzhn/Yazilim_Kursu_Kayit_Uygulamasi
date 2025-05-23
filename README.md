# 🚀 Yazilim_Kursu_Kayit_Uygulamasi

Bu proje, yazılım kursu kayıtlarını yönetmek için geliştirilmiş bir Windows masaüstü uygulamasıdır.

## 🎯 Projenin Amacı

Bu uygulama, öğrencilerin yazılım kurslarına kaydolmalarını, mevcut kayıtlarını görüntülemelerini, kurs ve öğrenci bilgilerini yönetmelerini sağlar.

## ⚙️ Kurulum

1.  Bu repoyu klonlayın: `git clone https://github.com/KeremOgzhn/Yazilim_Kursu_Kayit_Uygulamasi.git`
2.  Proje dizinine gidin: `cd Yazilim_Kursu_Kayit_Uygulamasi`
3.  `FormdaBilgisayarKayıtUygulaması` klasöründeki `FormdaBilgisayarKayıtUygulaması.sln` dosyasını Visual Studio ile açın.
4.  "veri tabanı dosyaları" klasöründeki veritabanını kurun veya mevcut veritabanı bağlantı ayarlarını projede güncelleyin. (Bu adım projenizin veritabanı kullanım şekline göre değişiklik gösterebilir. Örneğin, `App.config` veya `Web.config` dosyasındaki connection string'i düzenlemeniz gerekebilir.)
5.  Projeyi Visual Studio üzerinden derleyin (Build) ve çalıştırın (Start).

## Veri Tabanı Dosyalarını Açma Rehberi

Bu projede kullanılan MSSQL veri tabanı dosyalarını (.mdf ve .ldf) kendi bilgisayarınızda açmak için aşağıdaki adımları izleyin:

### 1. Gereksinimler
- SQL Server (örn. SQL Server Express veya tam sürümü)
- SQL Server Management Studio (SSMS)

### 2. Veri Tabanını Eklemek (Attach)
1. .mdf ve .ldf dosyalarını bilgisayarınıza indirin.
2. SQL Server Management Studio’yu (SSMS) açın.
3. Sunucuya bağlanın.
4. “Databases” (Veritabanları) kısmına sağ tıklayın ve **Attach** (Ekle) seçeneğini seçin.
5. Açılan pencerede **Add** (Ekle) butonuyla .mdf dosyasını seçin.
6. SQL Server, .ldf dosyasını otomatik olarak bulacaktır. Bulamazsa, elle ekleyin.
7. **OK** diyerek işlemi tamamlayın.

### 3. Bağlantı Dizesini (Connection String) Güncelleyin
Projedeki bağlantı dizesini, kendi bilgisayarınızdaki veri tabanının yoluna göre güncelleyin:

```csharp
Data Source=.\SQLEXPRESS;AttachDbFilename=C:\KendiYolu\Veritabani.mdf;Integrated Security=True
```

> Not: `AttachDbFilename` kısmındaki yolu, kendi bilgisayarınızdaki .mdf dosyasının tam yoluna göre değiştirin.

### 4. Yetki Problemleri
Eğer dosya ile ilgili yetki sorunları yaşarsanız:
- Dosya üzerinde okuma/yazma izni olduğundan emin olun.
- SQL Server'ın çalıştığı kullanıcının bu dosyaya erişim izni olduğundan emin olun.

---

Herhangi bir sorun yaşarsanız veya adımlar hakkında sorunuz olursa lütfen bir issue açın!

## 🛠️ Kullanım

Uygulama başlatıldıktan sonra, aşağıdaki gibi temel işlemleri gerçekleştirebilirsiniz:

*   **Yeni Kayıt Ekleme:**
    *   Ana form üzerinden "Yeni Kayıt", "Öğrenci Ekle" veya benzeri bir butona tıklayın.
    *   Açılan formda gerekli öğrenci ve kurs bilgilerini (Ad, Soyad, Kurs Adı, vb.) girin.
    *   "Kaydet" veya "Ekle" butonu ile kaydı tamamlayın.
*   **Kayıtları Listeleme/Görüntüleme:**
    *   Uygulamanın ana ekranında veya ilgili bölümünde mevcut kayıtların bir listesi (muhtemelen bir tablo veya data grid içerisinde) görüntülenir.
    *   Kayıtlar arasında arama yapabilir veya filtrelleyebilirsiniz.
*   **Kayıt Güncelleme:**
    *   Listeden güncellemek istediğiniz bir kaydı seçin.
    *   "Düzenle", "Güncelle" veya benzeri bir butona tıklayın.
    *   Açılan formda bilgileri değiştirin ve kaydedin.
*   **Kayıt Silme:**
    *   Listeden silmek istediğiniz bir kaydı seçin.
    *   "Sil" veya benzeri bir butona tıklayarak kaydı kaldırın.


## 🤝 Katkıda Bulunma

Katkılarınızı bekliyoruz! Lütfen aşağıdaki adımları izleyin:

1.  Bu repoyu fork'layın.
2.  Yeni bir özellik dalı oluşturun: `git checkout -b yeni-ozellik`
3.  Değişikliklerinizi commit'leyin: `git commit -m 'Yeni bir özellik eklendi'`
4.  Dalınızı push'layın: `git push origin yeni-ozellik`
5.  Bir Pull Request açın.


---
