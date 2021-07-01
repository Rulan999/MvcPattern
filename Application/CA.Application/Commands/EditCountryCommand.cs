using CA.Domain;
using CA.Domain.Helpers;
using MediatR;

namespace CA.Application.Commands
{
    public class EditCountryCommand : IRequest<CommandResult<Country>>
    {
        public Country Model { get; set; }
    }
}
