# TravelProject

## Proje Hakkında

TravelProject, katmanlı mimari ile geliştirilen bir seyahat ve blog uygulamasıdır. Ziyaretçiler yazıları okuyabilir, yorum yapabilir ve iletişim formunu kullanabilir. İçerikler yönetim panelinden yönetilir.

## Özellikler

- Ana sayfa, blog listesi ve blog detay sayfası
- Yorum sistemi, iletişim formu ve hakkımızda sayfası
- Admin paneli ve blog CRUD işlemleri
- AboutUs güncelleme ve mesaj görüntüleme
- Yorum görüntüleme / silme
- Admin login / logout
- Cookie Authentication ve role based Authorization

## Kullanılan Teknolojiler

- .NET 8, ASP.NET Core MVC ve ASP.NET Core Web API
- Entity Framework Core 8, SQL Server ve Azure SQL Database
- Azure App Service
- AutoMapper
- Cookie Authentication
- Repository Pattern ve Dependency Injection

## Mimari

```text
TravelProject
├── TravelProject.Entity
├── TravelProject.Dto
├── TravelProject.DataAccess
├── TravelProject.Business
├── TravelProject.WebApi
└── TravelProject.WebUI
```

| Katman | Görev |
| --- | --- |
| Entity | Veritabanı varlıkları |
| Dto | Katmanlar arasında taşınan veri modelleri |
| DataAccess | EF Core DbContext, migration ve repository uygulamaları |
| Business | İş servisleri ve AutoMapper eşlemeleri |
| WebApi | HTTP endpoint'leri ve servis yapılandırması |
| WebUI | MVC controller/view yapısı, API istemcileri ve admin oturumu |

## Uygulama Akışı

```text
WebUI → ApiServices → WebApi → Business → DataAccess → Azure SQL / SQL Server
```

ApiServices sınıfları `api/Blogs`, `api/Comment`, `api/Contact` gibi relative endpoint'ler kullanır. Ortak API adresi WebUI `Program.cs` içinde HttpClient BaseAddress olarak tanımlanır.

## Authentication

WebUI admin oturumları Cookie Authentication ile yönetilir. Yönetim controller'larında `[Authorize(Roles = "Admin")]` kullanılır. Başarılı girişte kullanıcıya Admin rolü atanır; çıkışta cookie oturumu kapatılır.

Bu kontrol WebUI katmanındadır; WebApi endpoint'leri için ayrıca kimlik doğrulama ve yetkilendirme gerekir. Mevcut giriş servisi parolayı doğrudan karşılaştırır; parola hashleme ayrı bir güvenlik iyileştirmesidir.

## Azure Deployment

WebUI ve WebApi ayrı Azure App Service uygulamalarında, veritabanı Azure SQL Database üzerinde çalışır.

WebApi bağlantısı `builder.Configuration.GetConnectionString("DefaultConnection")` ile okunur. Production bağlantısı App Service Environment Variables bölümünde `ConnectionStrings__DefaultConnection` veya Connection Strings bölümünde `DefaultConnection` adıyla yönetilir. Gerçek bağlantı bilgileri ve deployment kimlik bilgileri repoya eklenmez.

## Kurulum

1. .NET 8 SDK, SQL Server / SQL Server Express ve isteğe bağlı Visual Studio 2022 kurun.
2. Solution kökünde bağımlılıkları yükleyin:

   ```powershell
   dotnet restore TravelProject.sln
   ```

3. WebApi `appsettings.json` dosyasındaki Windows kimlik doğrulamalı yerel bağlantıyı kendi SQL Server instance adınıza göre düzenleyin. Alternatif olarak Git tarafından ignore edilen `TravelProject.WebApi/appsettings.Development.json` dosyasında şu ayarı kullanın:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=IBRAHIM\\SQLEXPRESS;Database=TravelProjectDb;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }
   ```

4. Mevcut `InitialCreate` migration'ını yerel veritabanına uygulayın. Visual Studio Package Manager Console içinde:

   ```powershell
   $env:ASPNETCORE_ENVIRONMENT = "Development"
   Update-Database -Project TravelProject.DataAccess -StartupProject TravelProject.WebApi
   ```

   CLI alternatifi (EF Core 8 aracı gerekir):

   ```powershell
   dotnet tool install --global dotnet-ef --version 8.0.16
   $env:ASPNETCORE_ENVIRONMENT = "Development"
   dotnet ef database update --project TravelProject.DataAccess --startup-project TravelProject.WebApi
   ```

   İlk kurulum için yeni migration oluşturmayın. Şema değişikliğinde `Add-Migration MigrationAdi -Project TravelProject.DataAccess -StartupProject TravelProject.WebApi` kullanılabilir. Komutlardan önce hedefin yerel veritabanı olduğunu doğrulayın.

5. Yerel HTTPS geliştirme sertifikasına güvenin ve WebApi'yi çalıştırın:

   ```powershell
   dotnet dev-certs https --trust
   dotnet run --project TravelProject.WebApi --launch-profile https
   ```

   Swagger adresi: `https://localhost:7187/swagger`.

6. WebUI `Program.cs` içindeki `apiBaseUrl` değerini yerel geliştirme için `https://localhost:7187/` olarak ayarlayın. Varsayılan değer canlı Azure API adresidir; yerel veriyle çalışırken bu adımı atlamayın. Ardından başka bir terminalde:

   ```powershell
   dotnet run --project TravelProject.WebUI --launch-profile https
   ```

   Terminalde gösterilen WebUI adresini açın. Migration varsayılan admin hesabı oluşturmaz; yerel admin kaydını kendi geliştirme veritabanınızda hazırlayın ve kimlik bilgilerini kaynak koduna eklemeyin.

7. Solution'ı derleyin:

   ```powershell
   dotnet build TravelProject.sln
   ```

## Güvenlik

Production secret'ları repository'de tutulmaz; Azure App Service Environment Variables / Connection Strings üzerinden yönetilir. Paylaşılan appsettings dosyası yalnızca Windows kimlik doğrulamalı yerel bağlantı içerir.

`.gitignore`; PublishProfiles, Azure yayın yardımcı dosyaları, geliştirme ayarları, `.vs`, `bin`, `obj`, kullanıcıya özel IDE dosyaları, log ve geçici dosyaları dışarıda tutar. Bu dosyalar yerel ortamda kalabilir. Geçmişte paylaşılmış bir secret yalnızca dosyadan silinerek güvenli hale gelmez; ilgili credential yenilenmelidir.
