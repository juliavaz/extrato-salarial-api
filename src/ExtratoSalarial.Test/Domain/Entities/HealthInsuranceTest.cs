using ExtratoSalarial.Core.Domain.Entities.Tax;
using ExtratoSalarial.Test.Mocks;

namespace ExtratoSalarial.Test.Domain.Entities
{
    public class HealthInsuranceTest
    {
        [Theory]
        [InlineData(true, 10)]
        [InlineData(false, 0)]
        public void Calculated(bool planoDeSaude, decimal desconto)
        {
            var salarioBruto = 1000;
            var employee = BaseMock.BuildEmployee(planoDeSaude: planoDeSaude, salarioBruto: salarioBruto);

            var healthInsurance = new HealthInsurance();
            var result = healthInsurance.Calculate(employee);

            Assert.Equal(desconto, result);
        }
    }
}
