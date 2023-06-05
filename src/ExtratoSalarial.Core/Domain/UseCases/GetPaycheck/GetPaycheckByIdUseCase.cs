using ExtratoSalarial.Core.Domain.Entities.Tax;
using ExtratoSalarial.Core.Domain.Interfaces.Repositories;
using ExtratoSalarial.Core.Domain.Interfaces.Requests;
using FluentValidation;

namespace ExtratoSalarial.Core.Domain.UseCases.GetPaycheck
{
    public class GetPaycheckByIdUseCase : IRequestHandler<GetPaycheckByIdInput, ResponseUseCase>
    {
        public readonly IEmployeeRepository _employeeRepository;
        private readonly IValidator<GetPaycheckByIdInput> _validator;

        public GetPaycheckByIdUseCase(IEmployeeRepository employeeRepository, IValidator<GetPaycheckByIdInput> validator)
        {
            _employeeRepository = employeeRepository;
            _validator = validator;
        }

        public async Task<ResponseUseCase> Handle(GetPaycheckByIdInput request)
        {
            var validationResult = _validator.Validate(request);

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
            var irrfResult = new Irrf().Calculate(employee);
            var dentalInsuranceResult = new DentalInsurance().Calculate(employee);
            var healthInsuranceResult = new HealthInsurance().Calculate(employee);
            var fgtsResult = new Fgts().Calculate(employee);
            var vtResult = new Vt().Calculate(employee);

            var totalDeDescontos = CalculateTotalDesconto(inssResult, irrfResult, dentalInsuranceResult, healthInsuranceResult, fgtsResult, vtResult);
            var salarioLiquidoResult = CalculateSalarioLiquido(employee.SalarioBruto, totalDeDescontos);

            var output = new GetPaycheckByIdOutput(
                employee.Id,
                employee.DataDeAdmissao,
                employee.SalarioBruto,
                -totalDeDescontos,
                salarioLiquidoResult
            );

            output.BuildDiscountEntries(inssResult, irrfResult, dentalInsuranceResult, healthInsuranceResult, fgtsResult, vtResult);

            return ResponseUseCase.Ok(output);
        }

        static decimal CalculateTotalDesconto(decimal inss, decimal ir, decimal dentalInsurance, decimal healthInsurance, decimal fgts, decimal vt)
        {
            return inss + ir + dentalInsurance + healthInsurance + fgts + vt;
        }

        static decimal CalculateSalarioLiquido(decimal salarioBruto, decimal totalDescontos)
        {
            return salarioBruto - totalDescontos;
        }
    }
}
