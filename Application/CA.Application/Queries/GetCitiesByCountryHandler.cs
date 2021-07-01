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

    public class GetCitiesByCountryHandler : IRequestHandler<GetCitiesByCountryQuery, IEnumerable<CityDto>>
    {
        private readonly IRepository<City> _cityRepository;
        private readonly IMapper _mapper;
        public GetCitiesByCountryHandler(IRepository<City> cityRepository,
                                         IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDto>> Handle(GetCitiesByCountryQuery request, CancellationToken cancellationToken)
        {
            var cities = await _cityRepository.FindAsync(x=>x.Country.Id == request.CountryId);
            return _mapper.Map<List<CityDto>>(cities);
        }
    }
}
