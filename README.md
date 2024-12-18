Hastane Randevu Sistemi API
Hastane Randevu Sistemi API, hastaların randevu almasını, geçmiş ve gelecek randevularını takip etmelerini ve doktorlarla kolayca iletişim kurmalarını sağlayan kullanıcı dostu bir hastane randevu sistemidir.

Özellikler
Hasta Yönetimi: Hastalar, randevu alabilir, geçmiş ve gelecek randevularını görüntüleyebilir ve doktorlarla iletişim kurabilir.
Doktor Yönetimi: Doktorlar, çalışma takvimlerini oluşturabilir, randevularını yönetebilir ve hastalara raporlar oluşturabilir.
Yönetici Paneli: Yöneticiler, hasta ve doktor bilgilerini yönetebilir, branş ekleyebilir ve sistem istatistiklerini görüntüleyebilir.
Kullanılan Teknolojiler
Backend: ASP.NET Web API, Entity Framework
Veritabanı: MS SQL Server
Dokümantasyon: Swagger
Mimari: Katmanlı Mimari
Diğer: AutoMapper, FluentValidation
Kurulum
Projeyi klonlayın:

bash
Kodu kopyala
git clone https://github.com/muhammedsafatur/HastaneRandevuSistemiAPI.git
Veritabanı bağlantı ayarlarını appsettings.json dosyasında yapılandırın.

Gerekli bağımlılıkları yükleyin ve projeyi derleyin.

Veritabanı migrasyonlarını uygulayın:

bash
Kodu kopyala
Update-Database
Uygulamayı çalıştırın.

Katkıda Bulunma
Projeyi forklayın.
Kendi dalınızı oluşturun: (git checkout -b ozellik/YeniOzellik)
Değişikliklerinizi yapın ve commit edin: (git commit -m 'Yeni özellik eklendi')
Dalınıza push edin: (git push origin ozellik/YeniOzellik)
Bir Pull Request oluşturun.
Lisans
Bu proje MIT Lisansı ile lisanslanmıştır. Daha fazla bilgi için LICENSE dosyasına bakabilirsiniz.
