using AutoMapper;
using System.Reflection;

namespace Notes.Aplication.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
              .Any (i => i.IsGenericType && 
              i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var metodInfo = type.GetMethod("mapping");
                metodInfo?.Invoke(instance, new object[] {this});
            }
        }
    }
}
