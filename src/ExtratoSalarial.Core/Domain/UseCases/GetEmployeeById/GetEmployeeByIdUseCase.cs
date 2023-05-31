using ExtratoSalarial.Core.Domain.Interfaces.Repositories;
using ExtratoSalarial.Core.Domain.Interfaces.Requests;

namespace ExtratoSalarial.Core.Domain.UseCases.GetEmployeeById
{
    public class GetEmployeeByIdUseCase : IRequestHandler<GetEmployeeByIdInput, ResponseUseCase>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ResponseUseCase> Handle(GetEmployeeByIdInput request)
        {
            var validation = new GetEmployeeByIdInputValidation();
            var validationResult = validation.Validate(request);

            if (!validationResult.IsValid)
            {
                return ResponseUseCase.BadRequest(validationResult.Errors);
            }

            var employee = await _employeeRepository.GetByIdAsync(request.Id);

            var output = new GetEmployeeByIdOutput(
                employee.Id,
                employee.Nome,
                employee.Sobrenome,
                employee.Documento,
                employee.Setor,
                employee.SalarioBruto,
                employee.DataDeAdmissao,
                employee.PlanoDeSaude,
                employee.PlanoDental,
                employee.ValeTransporte,
                employee.CreatedAt
            );

            return ResponseUseCase.Created(output);
        }
    }
}
