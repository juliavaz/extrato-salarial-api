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
            var employees = await _employeeRepository.GetAllAsync();

            var employeeDatas = employees.Select(x =>
                new EmployeeData()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Sobrenome = x.Sobrenome,
                    Documento = x.Documento,
                    Setor = x.Setor,
                    SalarioBruto = x.SalarioBruto,
                    DataDeAdmissao = x.DataDeAdmissao,
                    PlanoDeSaude = x.PlanoDeSaude,
                    PlanoDental = x.PlanoDental,
                    ValeTransporte = x.ValeTransporte,
                    CreatedAt = x.CreatedAt
                });

            var output = new GetEmployeeOutput(employeeDatas.ToList());

            return ResponseUseCase.Ok(output);
        }
    }
}
