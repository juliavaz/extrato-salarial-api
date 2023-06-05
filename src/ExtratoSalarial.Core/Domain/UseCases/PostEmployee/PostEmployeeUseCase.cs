using ExtratoSalarial.Core.Domain.Entities;
using ExtratoSalarial.Core.Domain.Interfaces.Repositories;
using ExtratoSalarial.Core.Domain.Interfaces.Requests;
using FluentValidation;

namespace ExtratoSalarial.Core.Domain.UseCases.PostEmployee
{
    public class PostEmployeeUseCase : IRequestHandler<PostEmployeeInput, ResponseUseCase>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IValidator<PostEmployeeInput> _validator;

        public PostEmployeeUseCase(IEmployeeRepository employeeRepository, IValidator<PostEmployeeInput> validator)
        {
            _employeeRepository = employeeRepository;
            _validator = validator;
        }

        public async Task<ResponseUseCase> Handle(PostEmployeeInput request)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return ResponseUseCase.BadRequest(validationResult.Errors);
            }

            var employee = new Employee(
                request.Nome,
                request.Sobrenome,
                request.Documento,
                request.Setor,
                request.SalarioBruto,
                request.DataDeAdmissao,
                request.PlanoDeSaude.Value,
                request.PlanoDental.Value,
                request.ValeTransporte.Value
            );

            await _employeeRepository.CreateAsync(employee);

            var output = new PostEmployeeOutput(
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
