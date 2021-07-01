using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CA.Application.Queries;
using CA.Application.Repositories;
using CA.Domain;
using MediatR;

namespace CA.Application.Handlers
{

    public class GetCountryByIdHandler : IRequestHandler<GetCountryByIdQuery, Country>
    {
        private readonly IRepository<Country> _countryRepository;

        public GetCountryByIdHandler(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<Country> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetAsync(request.Id);
            return country;
        }
    }
}
