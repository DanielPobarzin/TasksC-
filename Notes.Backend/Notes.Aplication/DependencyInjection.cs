using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Notes.Aplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
            
        }
    }
}
