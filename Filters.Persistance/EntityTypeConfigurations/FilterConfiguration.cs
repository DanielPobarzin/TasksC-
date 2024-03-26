using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Filters.Domain;
namespace Filters.Persistance.EntityTypeConfigurations
{
    public class FilterConfiguration : IEntityTypeConfiguration<Filter>
    {
        public void Configure(EntityTypeBuilder<Filter> builder)
        {
            builder.HasKey(filter => filter.FilterId);
            builder.HasIndex(filter => filter.FilterId).IsUnique();
            builder.Property(filter => filter.ModelFilter).HasMaxLength(50);

        }
    }

    public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
    {
        public void Configure(EntityTypeBuilder<Fuel> builder)
        {
            builder.HasKey(fuel => fuel.FuelId);
            builder.HasIndex(fuel => fuel.FuelId).IsUnique();
            builder.Property(fuel => fuel.NameFuel).HasMaxLength(100);
            builder.Property(fuel => fuel.Brand).HasMaxLength(5);

        }
    }
    public class PowerPlantConfiguration : IEntityTypeConfiguration<PowerPlant>
    {
        public void Configure(EntityTypeBuilder<PowerPlant> builder)
        {
            builder.HasKey(property => property.PowerPlantId);
            builder.HasIndex(property => property.PowerPlantId).IsUnique();
            builder.Property(property => property.NameMill).HasMaxLength(50);
            builder.Property(property => property.SlagRemoval).HasMaxLength(50);

        }
    }
}
