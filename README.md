# ConstructionManagement

Merhaba  projeyi açın migrataion klasörünü silip sırası ile PackageManagerConsole  add-migration name   yazıktan sonra enter tuşuna basmadan doğru katmanda bu işlemi yaptığınızı kontrol edin (ConstructionManagement.Infrastructure) seçiniz .
Migration eklendikten sonra update-database diyerek veritabanında güncellemeleri görebilirisiniz. 

Proje detayları 


Proje Onion Art.  yaklışımı prensibi ile geliştirilmeye çalışıldı .  
1)ConstructionManagement.Infrastructure
Veri işlemlerinin nasıl yürtüldüğünü takip edebilirisiniz 
2)ConstructionManagement.Core
Merkezi Varlıklarımızın bulunduğu bölüm 
3)ConstructionManagement.Application
İş süreçlerimizin yürütüldüğü bölüm .
4)ConstructionManagement.API
bu bölüm de ise RestFull api yer almaktadır. 
İlgili DI yönetimi ve akışı görüntülmek için program.cs klasörüne bakınız
