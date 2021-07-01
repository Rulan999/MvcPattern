using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Domain;
using Microsoft.AspNetCore.Identity;

namespace CA.Infrastructure
{
    public class DataSeeder
    {
        private readonly BaseDBContext _appDbContext;
        private readonly UserManager<User> _userManager;

        public DataSeeder(BaseDBContext appDbContext, UserManager<User> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _appDbContext.Database.EnsureDeleted();
            _appDbContext.Database.EnsureCreated();

            User user = await _userManager.FindByEmailAsync("rulan999@gmail.com");
            if (user == null)
            {
                user = new User()
                {
                    LastName = "Rulan",
                    FirstName = "Dono",
                    Email = "rulan999@gmail.com",
                    UserName = "rulan999@gmail.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd99");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create user in Seeding");
                }
            }
            var countries = new List<Country>();
            var country = _appDbContext.CountryEntities.Where(o => o.Id == 1).FirstOrDefault();
            if (country == null)
            {
                country = new Country();
                country.Create( "Australia",
                   user);
                countries.Add(country);
                country = new Country();
                country.Create("Indonesia",
                   user);
                countries.Add(country);
            }

            _appDbContext.CountryEntities.AddRange(countries);
            _appDbContext.SaveChanges();

            var cities = new List<City>();
            var country1 = _appDbContext.CountryEntities.Where(o => o.Id == 1).FirstOrDefault();
            if (country1 != null)
            {
                var city = new City();
                city.Create("Melbourne",
                    country1,
                   user);
                cities.Add(city);
                city = new City();
                city.Create("Sydney",
                    country1,
                   user);
                cities.Add(city);
            }

            _appDbContext.CityEntities.AddRange(cities);
            _appDbContext.SaveChanges();

            cities = new List<City>();
            var country2 = _appDbContext.CountryEntities.Where(o => o.Id == 2).FirstOrDefault();
            if (country2 != null)
            {
                var city = new City();
                city.Create("Jakarta",
                    country2,
                   user);
                cities.Add(city);
                city = new City();
                city.Create("Bali",
                    country2,
                   user);
                cities.Add(city);
            }

            _appDbContext.CityEntities.AddRange(cities);
            _appDbContext.SaveChanges();

        }
    }
    
}
