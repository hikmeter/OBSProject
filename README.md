# 🎓 Öğrenci Bilgi Sistemi (OBS) – Geliştirilme Aşamasında

Bu proje, modern yazılım geliştirme prensipleri ile geliştirilen, C# dili ve .NET Core 8.0 platformu üzerinde inşa edilen bir **Öğrenci Bilgi Sistemi (OBS)** uygulamasıdır. Proje, ölçeklenebilirlik ve sürdürülebilirlik hedefiyle **Onion Architecture**, **CQRS**, **Swagger**, **DTO yapıları** ve katmanlı mimari yaklaşımları kullanılarak geliştirilmektedir.

> 🚧 Proje halen geliştirilmektedir. Yeni özellikler düzenli olarak eklenmektedir.

---

## 🧱 Proje Mimarisi

OBS projesi, temiz kod ve domain odaklı mimari ilkelerine uygun şekilde yapılandırılmıştır:

- **Onion Architecture**: Katmanlar arası bağımlılıklar dıştan içe doğrudur. İç katmanlar dış katmanlardan bağımsızdır.
- **CQRS Pattern**: Okuma (Query) ve yazma (Command) işlemleri ayrıştırılmıştır.
- **DTO (Data Transfer Object)**: Verilerin dış dünya ile sade ve güvenli şekilde taşınması sağlanır.
- **Swagger UI**: API uç noktaları kolayca test edilebilir hale getirilmiştir.

---

## 🛠️ Kullanılan Teknolojiler

| Teknoloji | Açıklama |
|----------|----------|
| **.NET Core 8.0** | Projenin geliştirme platformu |
| **C#** | Ana programlama dili |
| **Entity Framework Core** | Veritabanı işlemleri için ORM |
| **MSSQL Server** | Veritabanı yönetim sistemi |
| **Swagger / Swashbuckle** | API test ve dökümantasyon aracı |

---

## 📚 Temel Modüller

Proje katmanlı şekilde şu modülleri içerecek şekilde planlanmıştır:

- **Öğrenciler** – Öğrenci kayıtları, güncelleme, silme, listeleme
- **Dersler** – Ders tanımları ve ilişkileri
- **Notlar** – Sınav, ödev ve genel başarı notları
- **Öğretmenler** – Akademik personel yönetimi
- **Sınavlar** – Sınav tanımları, ağırlıklar, sonuçlar

> Geliştirme ilerledikçe yeni modüller eklenecektir.

---

## 📁 Katman Yapısı

Proje aşağıdaki katmanlara sahiptir:

- `OBS.Domain` → Temel varlıklar ve iş kuralları
- `OBS.Application` → CQRS işlemleri, Handler’lar, DTO’lar
- `OBS.Persistence` → Veritabanı bağlantıları, EF Core
- `OBS.Infrastructure` → DI konfigürasyonları, dış servisler
- `OBS.WebAPI` → API uç noktaları ve Swagger arayüzü

---

## 🔧 Kurulum ve Çalıştırma

1. Projeyi Visual Studio 2022 veya üzeri ile açın.
2. `appsettings.json` içinden MSSQL bağlantınızı yapılandırın.
3. NuGet paketlerini geri yükleyin.
4. Migration oluşturun ve veritabanını güncelleyin:

```bash
Add-Migration InitialCreate
Update-Database
