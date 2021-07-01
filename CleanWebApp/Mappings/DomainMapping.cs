using AutoMapper;
using CA.Application.Dtos;
using CA.Domain;
using CA.WebApp.ViewModels;

namespace CleanWebApp.Mappings
{
    public class DomainMapping : Profile
    {
        public DomainMapping()
        {
            CreateMap<Country, CountryViewModel>();
            CreateMap<City, CityDto>()
                .ForMember(dest => dest.CountryName , opt => opt.MapFrom(src=> src.Country.CountryName));

        }
    }
}
