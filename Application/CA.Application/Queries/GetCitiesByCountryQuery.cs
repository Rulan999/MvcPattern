using System.Collections.Generic;
using CA.Application.Dtos;
using CA.Domain;
using MediatR;

namespace CA.Application.Queries
{
    public class GetCitiesByCountryQuery : IRequest<IEnumerable<CityDto>>
    {
        public int CountryId { get; set; }
    }
}
