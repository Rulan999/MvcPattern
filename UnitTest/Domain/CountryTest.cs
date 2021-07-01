using System;
using System.Linq;
using Ca.Domain.Exceptions;
using CA.Domain;
using Xunit;

namespace Ca.UnitTests.Domain
{
    public class CountryTest
    {
        private readonly Country _country;

        public CountryTest()
        {
            _country = new Country();
        }

        [Fact]
        public void Domain_CreateCountryShouldSuccess()
        {
            //Arrange
            string countryName = "Australia";
            var user = new User();
            //Act

            _country.Create(countryName,  user);

            //Assert

            Assert.NotNull(_country);
            Assert.Equal(_country.CountryName, countryName);
        }

        [Fact]
        public void Domain_CreateCountryShouldFailed()
        {
            //Arrange
            string countryName = "" ;
            var user = new User();
            //Act


            //Assert
            Assert.Throws<DomainException>(() => _country.Create(countryName, user));
        }

        [Fact]
        public void Domain_UpdateCountryShouldSuccess()
        {
            //Arrange
            int id = 1;
            string countryName = "Australia";
            var user = new User();
            //Act

            _country.Update(id, countryName, user);
            
            //Assert
            Assert.NotNull(_country);
            Assert.Equal(_country.CountryName, countryName);
        }

        [Fact]
        public void Domain_UpdateCountryShouldFailed()
        {
            //Arrange
            int id = 0;
            string countryName = "Australia";
            var user = new User();
            //Act


            //Assert
            Assert.Throws<DomainException>(() => _country.Update(id, countryName, user));
        }
    }
}
