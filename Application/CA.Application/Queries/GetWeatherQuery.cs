using System.Collections.Generic;
using CA.Application.Dtos;
using CA.Domain;
using MediatR;

namespace CA.Application.Queries
{
    public class GetWeatherQuery : IRequest<WeatherDto>
    {
        public int CityId { get; set; }
    }
}
