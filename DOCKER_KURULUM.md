# 🐳 Docker SQL Server ile KitapMVC Kurulum Rehberi

## Adım 1 — Docker SQL Server şifresini öğren

Docker Desktop'ta **sql_server_demo** container'ına tıkla → **Inspect** sekmesini aç →
`Env` bölümünde `MSSQL_SA_PASSWORD` değerini bul.

Ya da terminalde:
```bash
docker inspect sql_server_demo | grep -A1 "SA_PASSWORD\|MSSQL_SA_PASSWORD"
```

Şifreyi öğrendikten sonra **KitapDbContext.cs** dosyasında şu satırdaki
`YourStrong!Passw0rd` kısmını kendi şifrenle değiştir:

```csharp
optionsBuilder.UseSqlServer(
  "Server=localhost,1433;Database=KitapDbSube2MVC;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=true"
);
```

---

## Adım 2 — Eğer container şifreni bilmiyorsan, yeniden başlat

```bash
# Eskisini durdur
docker stop sql_server_demo
docker rm sql_server_demo

# Bilinen şifreyle yeniden başlat
docker run -e "ACCEPT_EULA=Y" \
           -e "MSSQL_SA_PASSWORD=YourStrong!Passw0rd" \
           -p 1433:1433 \
           --name sql_server_demo \
           -d mcr.microsoft.com/mssql/server:2022-latest
```

---

## Adım 3 — Projeyi çalıştır

```bash
cd /Users/beste/Desktop/Sube2.KitapMVC

# 1. NuGet paketlerini yükle (project.assets.json hatası bu adımla çözülür)
dotnet restore

# 2. Veritabanını oluştur
dotnet ef database update

# 3. Uygulamayı başlat
dotnet run
```

Tarayıcıda aç: `http://localhost:5000`

---

## Sık Karşılaşılan Hatalar

| Hata | Çözüm |
|------|-------|
| `project.assets.json bulunamadı` | `dotnet restore` çalıştır |
| `Login failed for user 'sa'` | KitapDbContext.cs'deki şifreyi kontrol et |
| `Cannot open server` | Docker container'ının çalıştığını kontrol et (STATUS: Running) |
| `Connection refused` | Port 1433:1433 açık mı? `docker ps` ile kontrol et |
