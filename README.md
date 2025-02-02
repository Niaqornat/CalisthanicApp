# CalisthanicApp

Bu projede, kullanıcıların kayıt olup giriş yapabileceği ve
koşu kulüpleri ile bölgesel koşu yarışları oluşturabileceği bir uygulama geliştirilmiştir.
Külüplere ve koşu yarışlarınına görüntü yüklenebiliyor ve açıklama yazılabiliyor.
Kullanıcılar, kendi profillerini oluşturabilir ve profil fotoğraflarını yükleyebilirler.
Yüklenen profil fotoğrafları, bulut ortamında saklanmaktadır. Kullanıcılar, kendi
sayfalarından katıldıkları egzersizleri ve oluşturdukları kulüpleri görüntüleyebilirler. Giriş
yapan kullanıcılar ayrıca, sisteme kayıtlı olan kullanıcıların sayısını görebilir ve
profillerine erişebilirler. Uygulamanın ana ekranında, giriş yapan kullanıcının IP adresi
kullanılarak, bulunduğu konumdaki kulüpler listelenir. Admin giriş yaptıktan
sonra kulüpler ve egzersizler düzenlenebilir ve silinebilir. Projenin temel amacı, calisthanic egzersizi yapmak
isteyen bireyleri kulüpler altında bir araya getirerek, egzersizler düzenlemektir. 

## Veritabanı Diyagramı

![Veritabanı Diyagramı](https://github.com/user-attachments/assets/bbf89983-6f42-4f40-a0d9-fc89e5c134ab)

## Ana Ekran

Ana ekran, kullanıcıların giriş yaptıktan sonra karşılaştığı ilk ekrandır. Bu ekranda kullanıcılar, Konumlarındaki mevcut külüpleri görüntüleyebilir.

![Ana Ekran](https://github.com/user-attachments/assets/96bd7a78-d74f-468a-941f-cf9e1068cf16)

## Egzersiz Ekranı

Egzersiz ekranı, kullanıcıların belirli bir egzersizi detaylı olarak görüntüleyebileceği ve düzenleyebileceği ekrandır.

![Egzersiz Ekranı](https://github.com/user-attachments/assets/391dfde6-49b7-4de0-8957-057aa31cc444)

## Giriş Ekranı

Giriş ekranı, kullanıcıların uygulamaya erişmek için giriş yapabileceği ekrandır.

![Giriş Ekranı](https://github.com/user-attachments/assets/c297f9d7-894e-4725-ba6e-3f3937e0a9ca)

## Kayıt Ekranı

Kayıt ekranı, yeni kullanıcıların uygulamaya kaydolabileceği ekrandır.

![Kayıt Ekranı](https://github.com/user-attachments/assets/f6ff5de4-fba9-42b6-866d-b043242bd155)

## Kullanıcılar Ekranı

Kullanıcılar ekranı, giriş yapanların tüm kullanıcıları görüntüleyebileceği ekrandır.

![Kullanıcılar Ekranı](https://github.com/user-attachments/assets/fea6127c-8b3e-4b48-852b-83e9528ff078)

## Projenin Teknik Detayları

Bu projede ASP.NET Core MVC framework'ü kullanılarak bir web uygulaması
geliştirilmiştir. MVC (Model-View-Controller) mimarisi, uygulamanın daha modüler,
bakımı kolay ve test edilebilir olmasını sağlar. Bu mimaride, Model verileri ve iş
Şekil 1: Veri Tabanı Diagramı
mantığını, View kullanıcı arayüzünü, Controller ise kullanıcıdan gelen talepleri
işleyip verileri yöneten katmanı temsil eder.
Backend Teknolojileri:
Proje, Entity Framework Core (EF Core) kullanılarak veritabanı işlemlerini yönetmektedir.
EF Core, veritabanı ile etkileşime geçmek için bir ORM (Object-Relational Mapping) aracıdır
ve bu sayede SQL sorguları yazmadan veri işlemleri yapılabilmektedir. SQL Server
veritabanı kullanılarak veriler saklanmakta ve yönetilmektedir.
ASP.NET Core Identity, kullanıcı yönetimi için projeye dahil edilmiştir. Bu, kullanıcıların
sisteme kaydolması, giriş yapması ve rollerinin yönetilmesi gibi işlemleri güvenli bir şekilde
gerçekleştiren bir yapıdır. Kullanıcılar, kimlik doğrulama işlemleri için Cookie
Authentication sistemiyle oturum açar.
Ayrıca, Cloudinary servisi ile kullanıcıların profil fotoğrafları bulutta güvenli bir şekilde
saklanır ve yönetilir.
Frontend Teknolojileri:
Frontend tarafında, ASP.NET Core MVC kullanılarak dinamik web sayfaları
oluşturulmuştur. Kullanıcı etkileşimi ve görsel öğeler için standart web teknolojileri olan
HTML kullanılmıştır. Görsel tasarımı güçlendirmek ve responsive (duyarlı) bir arayüz
sağlamak için Bootstrap framework'ü kullanılmıştır. Ayrıca, dinamik içerik yönetimi ve
kullanıcı etkileşimlerini kolaylaştırmak için jQuery kütüphanesi entegrasyonu yapılmıştır. Bu
teknolojiler sayesinde kullanıcı dostu ve modern bir arayüz oluşturulmuştur.
MVC Yapısı ve Repository Pattern:
Proje, veri erişim katmanında Repository Pattern kullanarak veritabanı işlemlerini
soyutlamaktadır. Bu sayede, her bir işlev (örneğin, kulüp ve yarış yönetimi) için ayrı
repository sınıfları oluşturulmuş ve bağımlılık enjeksiyonu (Dependency Injection)
yöntemiyle yönetilmiştir. Bu yapı, uygulamanın esnekliğini ve test edilebilirliğini artırır.
Veritabanı Yapısı ve Bağlantı:
Veritabanı bağlantısı için SQL Server kullanılmış ve Entity Framework Core aracılığıyla
veritabanı ile etkileşim sağlanmıştır. DbContext sınıfı, veritabanı işlemleri için merkezi bir
yapıdır ve uygulamanın veritabanı ile olan ilişkisini yönetir.
Diğer Teknolojiler:
• Session ve MemoryCache: Kullanıcı oturum bilgilerini geçici olarak saklamak ve
hızlı erişim sağlamak için kullanılmıştır.
• NuGet Paketleri: Projeye entegre edilen bazı NuGet paketleri, fotoğraf yükleme
(Cloudinary), kullanıcı yönetimi (ASP.NET Core Identity) ve veritabanı işlemleri
(EF Core) gibi işlemleri kolaylaştıran araçlardır.
• Bootstrap: Responsive tasarım ve modern kullanıcı arayüzü sağlamak için
kullanılmıştır.
• jQuery: Dinamik içerik ve kullanıcı etkileşimlerini kolaylaştıran işlemler için projeye
dahil edilmiştir.
