using System.Collections.Generic;
using CA.Domain;
using MediatR;

namespace CA.Application.Queries
{
    public class GetCountryByIdQuery : IRequest<Country>
    {
        public int Id { get; set; }
    }
}
