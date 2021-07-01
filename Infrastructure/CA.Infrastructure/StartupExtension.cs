using CA.Application;
using CA.Application.Repositories;
using CA.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Infrastructure
{
    public static class StartupExtensions
    {
        private static readonly InMemoryDatabaseRoot InMemoryDatabaseRoot = new InMemoryDatabaseRoot();

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            })
             .AddEntityFrameworkStores<BaseDBContext>();

           
            services.AddDbContext<BaseDBContext>(options => options.UseInMemoryDatabase(databaseName: "dbMusic", InMemoryDatabaseRoot));

            services.AddScoped<IRepository<City>, CityRepository>();
            services.AddScoped<IRepository<Country>, CountryRepository>();
            services.AddTransient<DataSeeder>();
            return services;
        }
    }
}
