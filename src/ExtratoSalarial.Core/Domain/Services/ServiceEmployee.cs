using ExtratoSalarial.Core.Domain.Interface.Services;
using ExtratoSalarial.Core.Domain.Interfaces.Repositorys;

namespace ExtratoSalarial.Core.Domain.Services
{
    public class ServiceEmployee : IServiceEmployee
    {
        private readonly IEmployeeRepository _repositoryEmployee;

        public ServiceEmployee(IEmployeeRepository repositoryEmployee)
        {
            _repositoryEmployee = repositoryEmployee;
        }
    }
}
