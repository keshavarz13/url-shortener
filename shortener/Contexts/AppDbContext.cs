using  Microsoft.EntityFrameworkCore;
using shortener.Models;

namespace shortener.Contexts
{
    public class AppDbContext : DbContext { 
        public DbSet<UrlResorce> Urls { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder builder){

            base.OnModelCreating(builder);

            builder.Entity<UrlResorce>().ToTable("url");
            builder.Entity<UrlResorce>().HasKey(p => p.ShortUrl);
            builder.Entity<UrlResorce>().Property(p => p.ShortUrl).IsRequired();
            builder.Entity<UrlResorce>().HasIndex(p => p.ShortUrl).IsUnique();
            builder.Entity<UrlResorce>().Property(p => p.LongUrl).IsRequired();
            
        }
    }
}