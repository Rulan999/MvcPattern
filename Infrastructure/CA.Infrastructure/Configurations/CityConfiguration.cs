using CA.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Configurations
{
    public static class CityFieldLength
    {
        public const int CityNameMaxLeghth = 100;
        
    }
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.CityName).IsRequired().HasMaxLength(CityFieldLength.CityNameMaxLeghth);
        }
    }

}
