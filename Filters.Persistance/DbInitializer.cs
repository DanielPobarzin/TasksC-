using System;

namespace Filters.Persistance
{
    public class DbInitializer
    {
        public static void Initialize(FilterDbContext context) 
        {
            context.Database.EnsureCreated();
        }

        public static void Initialize(FuelDbContext context)
        {
            context.Database.EnsureCreated();
        }

        public static void Initialize(PowerPlantDbContext context)
        {
            context.Database.EnsureCreated();
        }


    }
}
