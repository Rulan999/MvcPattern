using CA.Domain;
using CA.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CA.Infrastructure
{
    public class BaseDBContext : IdentityDbContext<User>
    {
        public BaseDBContext(DbContextOptions<BaseDBContext> options)
            :base(options)
        {
           
        }
        public DbSet<Country> CountryEntities { get; set; }
        public DbSet<City> CityEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.Entity<Country>()
               .HasMany(t => t.Cities)
               .WithOne(i => i.Country);

            base.OnModelCreating(modelBuilder);
        }
    }
}
