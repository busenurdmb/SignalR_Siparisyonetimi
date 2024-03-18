#  SignalR
Bu proje My Yazılım Akademi Bünyesinde Murat Yücedağ Eğitmenliği tarafından  Udemy üzerinde yayınlnamış SignalR Projesidir.
 ASP.NET Core 8.0 Web API ve MVC kullanılarak geliştirdiğim proje, tüm CRUD işlemlerini API üzerinden gerçekleştirir ve bu işlemler MVC tarafında consume edilir. Dinamik veritabanı yönetimi için Entity Framework Code First kullanılmıştır.
Onion Architecture mimari yapısı ve Repository design pattern ,CQRS ,Mediator kullanılarak projede uygulanarak kodun daha modüler ve sürdürülebilir olmasına öncelik verilmiştir.


# Projeye Genel Bakış

- 🖱️ Admin Paneli: CRUD işlemlerine sahip olan admin paneli, Adminin  rezervasyonları onaylama veya iptal etme,rezervasyon istatistik ,bildirim kısımlarını SignalR ile anlık olarak çekme aktif ve pasif yapabilme,mail gönderebilme ayarlar ,hakkımda,kategoriler vb. kolayca girebilecekleri ve güncelleyebilecekleri bir ortam sağlar.
- 👤 Kullanıcı Arayüzü: Şık ve duyarlı bir tasarım, ziyaretçilere yemek sipariş etmek, admin ile mesajlaşmak,rezervasyon oluşturmak,be özel mesaj göndermek için  için gerekli işlemleri etkileyici bir şekilde sunuyor.


# Projenin Amacı
Müşteriler web üzerinden yemek sipariş verebilir,sipariş özetini görebilir.
Rezervasyon oluşturabilir ve Bize ulaşın alanı ile mesaj yollayabilir, SignalR sayesinde admin ile anlık mesajlaşabilir.
 Adminle SignalR ile anlık olarak Rezervasyonları,Bildirimleri,İstatislikleri görebilir,ve müşteriyle mesajlaşabilir..
 Diğer sayfalarla alakalı crud işlemleri gerçekleştirebillir.



# Kullanılan Teknolojiler ve Uygulamalar

- 🤖 .NET Core 8.0 MVC ve API - ✅
- 🖼️ CQRS, Mediator ve Repository tasarım desenleri - ✅
- 🎡 Onion Architecture ile katmanlı mimari - ✅
-👨🏻💻 Dinamik Admin Paneli - ✅
- ☑️ Auto Mapper -(nesne eşlemesi (object-to-object mapping) işlemini kolaylaştırmak için kullanılan bir kütüphanedir) ✅
- 🔐 Identity -(NET Core tabanlı web uygulamalarında kullanıcı kimlik doğrulama ve yetkilendirme işlemlerini sağlayan bir çerçevedir) ✅
- 📡 SignalR -(gerçek zamanlı web uygulamaları geliştirmek için kullanılan bir ASP.NET Core kütüphanesidir) ✅
- 🗃️  Microsoft SQL Server (MSSQL) Veritabanı->Veritabanı yönetimi ve depolama için kullanıldı. ✅
- 🎨 HTML-CSS-Bootstrap (Arayüz tasarımı için) - ✅
- 🖌️ JS - ✅
- ⌨️ LINQ - ✅
- 📃 MailKit- ✅
- 🛠️ Projede ek olarak;
- ♦️ Real-Time Mesajlaşma✅
- ♦️ Real-Time İstatistik✅
- ♦️ Real-Time Bildirim✅
- ♦️ Ajax ile hızlı ve etkileşimli kullanıcı deneyimi(sepete ürün eklerken,admine mesaj yollarken kullanıldı.)✅
- ♦️ Basket ve Rezervasyon İşlemleri✅
- ♦️ Mail Gönderme İşlemleri bulunmaktadır.✅

  # Veriabanı
   ![Veriabanı](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/veri%20taban%C4%B1.png)
  # Default
   ![Portfolio](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/Default.jpeg)
   # Menu
   ![Dashboard](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/Menu.jpeg)
  # sipariş
   ![Proje](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/Sipari%C5%9F.jpeg)
  # Mesaj
   ![Proje](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/Mesaj.jpeg)
  
   # Rezervasyon
   ![Proje](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/Rezervasyon.jpeg)
  
  
  # Admin&Kullanıcı Giriş
   ![İstatislikler](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/Login.jpeg)
  # Admin ayar
   ![İstatislikler](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/Ayarlar.jpeg)
  # Admin İstatislik
   ![Kategori Listesi](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/%C4%B0statislik.jpeg)
   # Admin Mail
   ![İstatislikler](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/Mail2.jpeg)
  # Admin Mails
   ![Kategori Listesi](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/Mail.png)
   # Admin indirimler
   ![İstatislikler](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/%C4%B0ndirimler.jpeg)
  # Admin İstatislik
   ![Kategori Listesi](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/Progresbar.jpeg)
   # Admin bildirim
   ![İstatislikler](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/bildirimler.jpeg)
  # Admin bildirims
   ![Kategori Listesi](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/bildirimnavbar.jpeg)
 # Admin QRCode
   ![Dashboard](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/QRCode.jpeg)
# Admin Masa Durumu
   ![Proje](https://github.com/busenurdmb/SignalR_Siparisyonetimi/blob/master/WebUI/wwwroot/img/MasaDurumu.jpeg)
