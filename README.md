# EducationPortal

Bu proje, bir eğitim portalı oluşturmayı amaçlar. Portal üzerinden eğitimlerin tanımlanması, katılımcıların kaydolması ve tamamlanan eğitimlerin takibi sağlanır.
  
## Kullanılan Teknolojiler

- ASP.NET MVC 
- **ORM:** Entity Framework Core
- **Veritabanı:** MSSQL
- **Kullanıcı Yönetimi:** ASP.NET Core Identity
  
## Projeyi Çalıştırma
- Projeyi çalıştırmak için klonladığınız projenin appsettings.Development dosyasındaki SqlServer bağlantı dizesini kendi local veritabanı bağlantınızla değiştirmeniz gerekmektedir. Ayrıca, EducationPortalWebApp projesini başlangıç projesi olarak ayarlayın ve Package Manager Console'da Default Project kısmını DataAccess olarak değiştirerek update-database komutu ile veritabanını kurunuz.

- Veritabanı kurulduktan sonra varsayılan olarak admin kullanıcısı oluşturulacaktır. Admin giriş bilgileri:

- UserName, Email = "admin@admin.com"
-  Password = Test1234,
    



