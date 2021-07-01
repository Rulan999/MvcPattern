using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CA.Application.Dtos;
using CA.Application.Queries;
using CA.Application.Repositories;
using CA.Domain;
using MediatR;

namespace CA.Application.Handlers
{

    public class GetWeatherHandler : IRequestHandler<GetWeatherQuery, WeatherDto>
    {
        private readonly IRepository<City> _cityRepository;
        private readonly IMapper _mapper;
        public GetWeatherHandler(IRepository<City> cityRepository,
                                         IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<WeatherDto> Handle(GetWeatherQuery request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetAsync(request.CityId);
            var output = new WeatherDto();
            if (city != null)
            {
                output =  new WeatherDto()
                {
                    Base = "Stations",
                    Coord = new Coordinate() { Lat = 37.39, Lon = -122.08 },
                    Weather = new Weather()
                    {
                        Id = 800,
                        Main = "Clear",
                        Description = "Clear Sky",
                        Icon = "01d"
                    },
                    Main = new Main()
                    {
                        Temp = 288.55,
                        Feels_like = 281.86,
                        Temp_Min = 280.37,
                        Temp_Max = 284.26,
                        Pressure = 1023,
                        Humidity = 100
                    },
                    Visibility = 16093,
                    Wind = new Wind { Deg = 350, Speed = 1.5 },

                };
            }
            return output;
        }
    }
}
