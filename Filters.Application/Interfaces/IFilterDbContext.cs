using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Filters.Domain;


namespace Filters.Application.Interfaces
{
    public interface IFilterDbContext
    {
        DbSet<Filter> Filters { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

    public interface IFuelDbContext
    {
        DbSet<Fuel> Fuels { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

    public interface IPowerPlantDbContext
    {
        DbSet<PowerPlant> PowerPlantsProperties { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

}
