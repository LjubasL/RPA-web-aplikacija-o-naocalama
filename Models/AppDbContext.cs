using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppOptika.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Naocale> Naocale { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Naocale>().Property(f => f.Cijena).HasPrecision(10, 2);

            builder.Entity<Kategorija>().HasData(
                new Kategorija() { Id = 1, VrstaNaocala = "Dioptrijske naocale" },
                new Kategorija() { Id = 2, VrstaNaocala = "Suncane naocale s dioptrijom" },
                new Kategorija() { Id = 3, VrstaNaocala = "Suncane naoale" },
                new Kategorija() { Id = 4, VrstaNaocala = "Naocale za plavo svjetlo" },
                new Kategorija() { Id = 5, VrstaNaocala = "Sportke naocale" }
                );

            builder.Entity<Naocale>().HasData(
                new Naocale() { Id = 1, NazivNaocala = "Crullé TR1726 C5", MarkaNaocala = "Crullé", Cijena = 179.99m, SlikaUrl = "https://cdn.adrialece.hr/imagesCdn/16735/21232-400x300.webp", KategorijaId = 1 },
                new Naocale() { Id = 2, NazivNaocala = "Crullé Fort C5", MarkaNaocala = "Crullé", Cijena = 179.99m, SlikaUrl = "https://cdn.adrialece.hr/imagesCdn/30290/45450-400x300.webp", KategorijaId = 2 },
                new Naocale() { Id = 3, NazivNaocala = "Marc Jacobs Marc 493/S MVU/3J", MarkaNaocala = "Marc Jacobs", Cijena = 586.99m, SlikaUrl = "https://cdn.adrialece.hr/imagesCdn/32427/49942-400x300.webp", KategorijaId = 3},
                new Naocale() { Id = 4, NazivNaocala = "Naočale za plavo svjetlo Dolce & Gabbana DG5090 3068", MarkaNaocala = "Dolce & Gabbana", Cijena = 1023.99m, SlikaUrl = "https://cdn.adrialece.hr/imagesCdn/51484/76600-400x300.webp", KategorijaId = 4 },
                new Naocale() { Id = 5, NazivNaocala = "Arena Spider Junior Green", MarkaNaocala = "Arena", Cijena = 172.99m, SlikaUrl = "https://cdn.adrialece.hr/imagesCdn/23590/52185-400x300.webp", KategorijaId = 5}
           
                );

        
        }

       
        
    }
}
