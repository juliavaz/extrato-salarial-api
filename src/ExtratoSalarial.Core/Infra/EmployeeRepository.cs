using ExtratoSalarial.Core.Domain.Entities;
using ExtratoSalarial.Core.Domain.Interfaces.Repositories;
using MongoDB.Driver;

namespace ExtratoSalarial.Core.Infra
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IMongoDatabase database) : base(database, "employees")
        {
        }
    }
}
