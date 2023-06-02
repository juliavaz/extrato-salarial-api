using ExtratoSalarial.Core.Domain.Interfaces.Repositories;
using ExtratoSalarial.Core.Domain.Interfaces.Requests;

namespace ExtratoSalarial.Core.Domain.UseCases.GetPaycheck
{
    public class GetPaycheckByIdUseCase : IRequestHandler<GetPaycheckByIdInput, ResponseUseCase>
    {
        public readonly IEmployeeRepository _employeeRepository;

        public GetPaycheckByIdUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ResponseUseCase> Handle(GetPaycheckByIdInput request)
        {
            var validation = new GetPaycheckByIdValidation();
            var validationResult = validation.Validate(request);

            if (!validationResult.IsValid)
            {
                return ResponseUseCase.BadRequest(validationResult.Errors);
            }

            var employee = await _employeeRepository.GetByIdAsync(request.FuncionarioId);
            if (employee is null)
            {
                return ResponseUseCase.NotFound("Funcionário não consta na base de dados.");
            }

            var entriesList = new List<EntriesData> {
                new EntriesData{
                    Tipo = Enums.EEntriesType.Desconto, Valor = 10, Descricao = Enums.EDescriptionType.PlanoDeSaude
                }
            };
            GetPaycheckByIdOutput output = new GetPaycheckByIdOutput(
                employee.Id,
                employee.DataDeAdmissao.Month.ToString(),
                employee.SalarioBruto,
                0,
                0,
                employee.CreatedAt,
                entriesList
            ); ;

            return ResponseUseCase.Created(output);
        }
    }
}
