using Microsoft.EntityFrameworkCore;
using GuitarShop.Models;

namespace GuitarShop.Data
{
    public class GuitarShopContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Responsibility> Responsibilities { get; set; }

        public GuitarShopContext(DbContextOptions<GuitarShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to Many Shop - Instrument
            modelBuilder.Entity<Shop>()
                .HasMany(shop => shop.Instruments)
                .WithOne(instrument => instrument.Shop);
            
            //One to Many Job - Employee
            modelBuilder.Entity<Job>()
                .HasMany(job => job.Employees)
                .WithOne(employee => employee.Job);

            //One to One Employee - User
            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.User)
                .WithOne(user => user.Employee);

            //Many to Many Employee - Instrument
            modelBuilder.Entity<Responsibility>()
                .HasKey(r => new { r.EmployeeId, r.InstrumentId });

            modelBuilder.Entity<Responsibility>()
                .HasOne<Employee>(r => r.Employee)
                .WithMany(employee => employee.Responsibilities)
                .HasForeignKey(r => r.EmployeeId);

            modelBuilder.Entity<Responsibility>()
                .HasOne<Instrument>(r => r.Instrument)
                .WithMany(instrument => instrument.Responsibilities)
                .HasForeignKey(r => r.InstrumentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
