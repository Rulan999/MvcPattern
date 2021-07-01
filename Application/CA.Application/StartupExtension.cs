using System.Linq;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Application
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatorHandlers(typeof(StartupExtensions).GetTypeInfo().Assembly);
            return services;
        }

        public static IServiceCollection AddMediatorHandlers(this IServiceCollection services, Assembly assembly)
        {
            var classTypes = assembly.ExportedTypes.Select(t => t.GetTypeInfo()).Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in classTypes)
            {
                var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());

                foreach (var handlerType in interfaces.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                {
                    services.AddTransient(handlerType.AsType(), type.AsType());
                }
            }

            return services;
        }
    }
}
