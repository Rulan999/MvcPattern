using CA.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Configurations
{
    public static class CountryFieldLength
    {
        public const int CountryNameMaxLength = 50;
    }
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.CountryName).IsRequired().HasMaxLength(CountryFieldLength.CountryNameMaxLength);
           
        }
    }

}
