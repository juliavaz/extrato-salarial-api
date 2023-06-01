using ExtratoSalarial.Core.Domain.Entities.Tax;
using ExtratoSalarial.Test.Mocks;

namespace ExtratoSalarial.Test.Domain.Entities
{
    public class HealthInsuranceTest
    {
        [Theory]
        [InlineData(true, 990)]
        [InlineData(false, 1000)]
        public void Calculated(bool planoDeSaude, decimal salarioBruto)
        {
            var employee = BaseMock.BuildEmployee(planoDeSaude: planoDeSaude, salarioBruto: 1000);
            var healthInsurance = new HealthInsurance();

            var result = healthInsurance.Calculate(employee);

            Assert.Equal(salarioBruto, result);
        }
    }
}
