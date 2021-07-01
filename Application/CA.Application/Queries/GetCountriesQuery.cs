using System.Collections.Generic;
using CA.Domain;
using MediatR;

namespace CA.Application.Queries
{
    public class GetCountriesQuery : IRequest<IEnumerable<Country>>
    {
        
    }
}
