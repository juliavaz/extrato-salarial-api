using ExtratoSalarial.Core.Domain.Entities;
using ExtratoSalarial.Core.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;

namespace ExtratoSalarial.Core.Infra
{
    [ExcludeFromCodeCoverage]
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IMongoDatabase database) : base(database, "employees")
        {
        }
    }
}
