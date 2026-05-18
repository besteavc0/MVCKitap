using Microsoft.EntityFrameworkCore;

namespace Sube2.KitapMVC.Models
{
    public class KitapDbContext : DbContext
    {
        public DbSet<Kitap> Kitaplar { get; set; }
        //docker

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=KitapDbSube2MVC;User Id=sa;Password=Mssql123!;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //fluent apı
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Kitap>().Property(k => k.Ad).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Kitap>().Property(k => k.Yazar).HasColumnType("varchar").HasMaxLength(80).IsRequired();

            modelBuilder.Entity<Kitap>().Property(k => k.Tur).HasColumnType("varchar").HasMaxLength(30);

            modelBuilder.Entity<Kitap>().Property(k => k.Fiyat).HasColumnType("decimal(8,2)");
        }
    }
}
