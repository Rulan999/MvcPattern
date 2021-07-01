using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CA.Application.Queries;
using CA.Application.Repositories;
using CA.Domain;
using MediatR;

namespace CA.Application.Handlers
{

    public class GetCountriesHandler : IRequestHandler<GetCountriesQuery, IEnumerable<Country>>
    {
        private readonly IRepository<Country> _countryRepository;

        public GetCountriesHandler(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IEnumerable<Country>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await _countryRepository.AllAsync();
            return countries;
        }
    }
}
