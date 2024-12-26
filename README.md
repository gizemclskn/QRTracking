# QR Çalışan Takip Sistemi

## Genel Bakış
**QR Çalışan Takip Sistemi**, çalışanların ve şubelerin giriş-çıkış işlemlerini QR kodları aracılığıyla izleyen bir API'dir. Bu sistem, her çalışan ve şube için benzersiz QR kodları oluşturarak, personel hareketlerini etkin bir şekilde takip etmeyi sağlar.

## Özellikler
- **Şube Yönetimi**: Şubelerin bilgilerini ekleme, güncelleme ve silme.
- **QR Kod Oluşturma**: Her çalışan ve şube için benzersiz QR kodları oluşturma.
- **Giriş/Çıkış Takibi**: Çalışanların QR kodlarını tarayarak giriş ve çıkış işlemlerini kaydetme.

## Kullanılan Teknolojiler ve Kütüphaneler
- **.NET Framework**: Uygulamanın temel yapısı için.
- **Entity Framework Core**: Veritabanı işlemleri ve ORM için.
- **QRCodeGenerator**: QR kodlarının oluşturulması için.
- **ASP.NET Web API**: API geliştirme için.
- **Swagger**: API dokümantasyonu için.

## Kurulum ve Kullanım

### Gereksinimler
- SQL Server veya uyumlu bir veritabanı sunucusu.

### Adımlar
1. **Depoyu Klonlayın**:
   ```bash
   git clone https://github.com/gizemclskn/QRTracking.git
