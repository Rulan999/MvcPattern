using System.Threading;
using System.Threading.Tasks;
using CA.Application.Commands;
using CA.Application.Repositories;
using CA.Domain;
using CA.Domain.Helpers;
using MediatR;

namespace CA.Application.Handlers
{

    public class EditCountryCommandHandler : IRequestHandler<EditCountryCommand, CommandResult<Country>>
    {
        private readonly IRepository<Country> _countryRepository;

        public EditCountryCommandHandler(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<CommandResult<Country>> Handle(EditCountryCommand request, CancellationToken cancellationToken)
        {
            var result = new CommandResult<Country>();
            result.Status = CommandStatus.Success;
            try
            {
                var country = _countryRepository.Update(request.Model);
                await _countryRepository.SaveChangesAsync();
                result.Result = country;
            }
            catch (System.Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Status = CommandStatus.Error;
            }
            return result;
        }
    }
}
