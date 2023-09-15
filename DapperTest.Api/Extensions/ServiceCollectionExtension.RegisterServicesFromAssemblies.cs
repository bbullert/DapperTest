using DapperTest.Core.Services;
using DapperTest.Core.Validators;
using DapperTest.Data.Repositories;
using DapperTest.Data.Utilities.Dependency;
using FluentValidation;
using System.Reflection;

namespace DapperTest.Api.Extensions
{
    internal static partial class ServiceCollectionExtension
    {
        public static void RegisterServicesFromAssemblies(this IServiceCollection services, IEnumerable<Assembly> assemblyList)
        {
            var typeList = assemblyList
                .SelectMany(assembly => assembly.GetTypes())
                .Where(t =>
                    typeof(IDependency).IsAssignableFrom(t) &&
                    !t.IsAbstract &&
                    !t.IsGenericTypeDefinition &&
                    !t.IsInterface
                ).Distinct();

            foreach (var type in typeList)
            {
                var interfaces = type.GetInterfaces();

                // Ignore interfaces of the base class
                if (type.BaseType != null)
                {
                    var baseTypeInterfaces = type.BaseType.GetInterfaces();
                    interfaces = interfaces.Where(i => !baseTypeInterfaces.Any(bi => bi.FullName == i.FullName)).ToArray();
                }

                var ignore = new List<Type>()
                {
                    typeof(IDependency),
                    typeof(ITransientDependency),
                    typeof(IScopedDependency),
                    typeof(ISingletonDependency)
                };

                interfaces = interfaces.Where(x => !ignore.Any(y => y.FullName == x.FullName)).ToArray();
                var typeInterface = interfaces.FirstOrDefault();

                if (typeof(ITransientDependency).IsAssignableFrom(type))
                    services.AddTransient(typeInterface, type);
                else if (typeof(IScopedDependency).IsAssignableFrom(type))
                    services.AddScoped(typeInterface, type);
                else if (typeof(ISingletonDependency).IsAssignableFrom(type))
                    services.AddSingleton(typeInterface, type);
            }
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddValidatorsFromAssemblyContaining<EmployeeCreateValidator>();
        }
    }
}
