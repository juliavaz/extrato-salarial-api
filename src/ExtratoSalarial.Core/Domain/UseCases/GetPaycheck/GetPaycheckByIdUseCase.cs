using ExtratoSalarial.Core.Domain.Entities.Tax;
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

            var inssResult = new Inss().Calculate(employee);
            var irResult = new IncomeTax().Calculate(employee);
            var dentalInsuranceResult = new DentalInsurance().Calculate(employee);
            var healthInsuranceResult = new HealthInsurance().Calculate(employee);
            var fgtsResult = new Fgts().Calculate(employee);
            var vtResult = new Vt().Calculate(employee);

            var totalDeDescontos = -(inssResult + irResult + dentalInsuranceResult + healthInsuranceResult + fgtsResult + vtResult);
            var salarioLiquidoResult = employee.SalarioBruto - totalDeDescontos;

            var entriesList = new List<EntriesData> {
                new EntriesData { Tipo = "Remuneração", Valor = employee.SalarioBruto, Descricao = "Salário Bruto" }
            };

            AddEntry(inssResult, "Inss", entriesList);
            AddEntry(irResult, "Imposto de Renda", entriesList);
            AddEntry(dentalInsuranceResult, "Plano Dentário", entriesList);
            AddEntry(healthInsuranceResult, "Plano de Saúde", entriesList);
            AddEntry(fgtsResult, "Fgts", entriesList);
            AddEntry(vtResult, "Vale Transporte", entriesList);

            GetPaycheckByIdOutput output = new GetPaycheckByIdOutput(
                employee.Id,
                employee.DataDeAdmissao.Month.ToString(),
                employee.SalarioBruto,
                totalDeDescontos,
                salarioLiquidoResult,
                entriesList
            ); ;

            return ResponseUseCase.Ok(output);
        }

        public void AddEntry(decimal valor, string descricao, List<EntriesData> entriesData)
        {
            if (valor != 0)
            {
                entriesData.Add(new EntriesData { Tipo = "Desconto", Valor = valor, Descricao = descricao });
            }
        }
    }
}
