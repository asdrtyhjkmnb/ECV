using AutoMapper;
using System.Reflection;

namespace Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly) => ApplyMappingsFromAssembly(assembly);

        /// <summary>
        /// Сканирует сборку и ищет любые типы, которые реализуют интерфейс IMapWith, затем вызывает у унаследованного от IMapWith<> типа метод Mapping
        /// </summary>
        /// <param name="assembly"></param>
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            Type[]? types = assembly.GetExportedTypes()
                .Where(type => type
                    .GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToArray();
            foreach (Type type in types)
            {
                object? instance = Activator.CreateInstance(type);
                MethodInfo? methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
