using ExtratoSalarial.Core.Domain.Interfaces.Repositories;
using ExtratoSalarial.Core.Domain.Interfaces.Requests;
using FluentValidation;

namespace ExtratoSalarial.Core.Domain.UseCases.GetEmployeeById
{
    public class GetEmployeeByIdUseCase : IRequestHandler<GetEmployeeByIdInput, ResponseUseCase>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IValidator<GetEmployeeByIdInput> _validator;

        public GetEmployeeByIdUseCase(IEmployeeRepository employeeRepository, IValidator<GetEmployeeByIdInput> validator)
        {
            _employeeRepository = employeeRepository;
            _validator = validator;
        }

        public async Task<ResponseUseCase> Handle(GetEmployeeByIdInput request)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return ResponseUseCase.BadRequest(validationResult.Errors);
            }

            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee is null)
            {
                return ResponseUseCase.NotFound("Funcionário não consta na base de dados.");
            }

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
