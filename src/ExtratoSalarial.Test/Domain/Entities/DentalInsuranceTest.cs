using ExtratoSalarial.Core.Domain.Entities.Tax;
using ExtratoSalarial.Test.Mocks;

namespace ExtratoSalarial.Test.Domain.Entities
{
    public class DentalInsuranceTest
    {
        [Theory]
        [InlineData(true, 995)]
        [InlineData(false, 1000)]
        public void Calculated(bool planoDental, decimal salarioBruto)
        {
            var employee = BaseMock.BuildEmployee(planoDental: planoDental, salarioBruto: 1000);
            var dentalInsurance = new DentalInsurance();

            var result = dentalInsurance.Calculate(employee);

            Assert.Equal(salarioBruto, result);
        }
    }
}