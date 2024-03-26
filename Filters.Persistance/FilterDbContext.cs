using System;
using Filters.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Filters.Domain;
using Filters.Persistance.EntityTypeConfigurations;

namespace Filters.Persistance
{
    public class FilterDbContext : DbContext, IFilterDbContext
    {
        public DbSet<Filter> Filters { get; set;}
        public FilterDbContext(DbContextOptions<FilterDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FilterConfiguration());
            base.OnModelCreating(builder);
        }

    }

    public class FuelDbContext : DbContext, IFuelDbContext
    {
        public DbSet<Fuel> Fuels { get; set; }
        public FuelDbContext(DbContextOptions<FuelDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FuelConfiguration());
            base.OnModelCreating(builder);
        }

    }

    public class PowerPlantDbContext : DbContext, IPowerPlantDbContext
    {
        public DbSet<PowerPlant> PowerPlantsProperties { get; set; }
        public PowerPlantDbContext(DbContextOptions<PowerPlantDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PowerPlantConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
