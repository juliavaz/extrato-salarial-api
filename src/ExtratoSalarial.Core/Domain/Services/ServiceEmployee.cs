using ExtratoSalarial.Core.Domain.Entities;
using ExtratoSalarial.Core.Domain.Interface.Services;
using ExtratoSalarial.Core.Domain.Interfaces.Repositorys;

namespace ExtratoSalarial.Core.Domain.Services
{
    public class ServiceEmployee : Service<Employee>, IServiceEmployee
    {
        private readonly IRepositoryEmployee _repositoryEmployee;

        public ServiceEmployee(IRepositoryEmployee repositoryEmployee) : base(repositoryEmployee)
        {
            repositoryEmployee = _repositoryEmployee;
        }

        public void Add(Employee obj)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Employee> IService<Employee>.GetAll()
        {
            throw new NotImplementedException();
        }

        Employee IService<Employee>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
