using System;
using Ca.Domain.Exceptions;

namespace CA.Domain
{
    public class City : Entity
    {
        public String CityName { get; private set; }
        public Country Country { get; private set; }
        public User User { get; private set; }

        public City()
        {

        }

        public void Create(
             string cityName,
             Country country,
             User user)
        {
           
            Id = 0;
            CityName = string.IsNullOrWhiteSpace(cityName)
               ? throw new DomainException("CityName is mandatory")
               : cityName;
            Country = string.IsNullOrWhiteSpace(country.CountryName) ?  throw new DomainException("Coiuntry is mandatory")
               : country;
            User = user;
        }

        public void Update(
             int id,
             string cityName,
             Country country,
             User user)
        {
            Id = id==0 ? throw new DomainException("Id not found") : id;
            CityName = string.IsNullOrWhiteSpace(cityName)
              ? throw new DomainException("CityName is mandatory")
              : cityName;
            Country = string.IsNullOrWhiteSpace(country.CountryName) ? throw new DomainException("Country is mandatory")
              : country;
            User = user;
        }

    }
}
