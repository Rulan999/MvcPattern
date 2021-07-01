using System.Threading;
using System.Threading.Tasks;
using CA.Application.Commands;
using CA.Application.Repositories;
using CA.Domain;
using CA.Domain.Helpers;
using MediatR;

namespace CA.Application.Handlers
{

    public class AddCountryCommandHandler : IRequestHandler<AddCountryCommand, CommandResult<int>>
    {
        private readonly IRepository<Country> _countryRepository;

        public AddCountryCommandHandler(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<CommandResult<int>> Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {
            var result = new CommandResult<int>();
            result.Status = CommandStatus.Success;
            try
            {
                var country = _countryRepository.Add(request.Model);
                await _countryRepository.SaveChangesAsync();
                result.Result = country.Id;
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
