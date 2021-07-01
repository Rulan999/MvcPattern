using System;
using System.Collections.Generic;
using Ca.Domain.Exceptions;

namespace CA.Domain
{
    public class Country : Entity
    {
        public String CountryName { get; private set; }
        public List<City> Cities { get; set; }
        public User User { get; private set; }

        public Country()
        {

        }

        public void Create(
             string countryName,
             User user)
        {
           
            Id = 0;
            CountryName = string.IsNullOrWhiteSpace(countryName)
               ? throw new DomainException("CountryName is mandatory")
               : countryName;
            User = user;
        }

        public void Update(
             int id,
             string countryName,
             User user)
        {
            Id = id==0 ? throw new DomainException("Id not found") : id;
            CountryName = string.IsNullOrWhiteSpace(countryName)
              ? throw new DomainException("CountryName is mandatory")
              : countryName;
            User = user;
        }

    }
}
