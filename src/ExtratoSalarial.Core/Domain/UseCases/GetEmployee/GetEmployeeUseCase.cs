using ExtratoSalarial.Core.Domain.Interfaces.Repositories;
using ExtratoSalarial.Core.Domain.Interfaces.Requests;

namespace ExtratoSalarial.Core.Domain.UseCases.GetEmployee
{
    public class GetEmployeeUseCase : IRequestHandler<GetEmployeeInput, ResponseUseCase>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ResponseUseCase> Handle(GetEmployeeInput request)
        {
            var output = await _employeeRepository.GetAllAsync();

            return ResponseUseCase.Ok(output);
        }
    }
}
