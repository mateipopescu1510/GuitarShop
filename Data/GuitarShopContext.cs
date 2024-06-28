using Microsoft.EntityFrameworkCore;
using GuitarShop.Models;

namespace GuitarShop.Data
{
    public class GuitarShopContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Instrument> Instruments { get; set; }

        public GuitarShopContext(DbContextOptions<GuitarShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to Many Shop - Instrument
            modelBuilder.Entity<Shop>()
                .HasMany(shop => shop.Instruments)
                .WithOne(instrument => instrument.Shop);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
