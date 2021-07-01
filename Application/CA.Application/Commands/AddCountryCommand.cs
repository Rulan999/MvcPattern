using CA.Domain;
using CA.Domain.Helpers;
using MediatR;

namespace CA.Application.Commands
{
    public class AddCountryCommand : IRequest<CommandResult<int>>
    {
        public Country Model { get; set; }
    }
}
