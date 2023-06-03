using ExtratoSalarial.Core.Domain.Entities.Tax;
using ExtratoSalarial.Test.Mocks;

namespace ExtratoSalarial.Test.Domain.Entities
{
    public class DentalInsuranceTest
    {
        [Theory]
        [InlineData(true, 5)]
        [InlineData(false, 0)]
        public void Calculated(bool planoDental, decimal desconto)
        {
            var salarioBruto = 1000;
            var employee = BaseMock.BuildEmployee(planoDental: planoDental, salarioBruto: salarioBruto);

            var dentalInsurance = new DentalInsurance();
            var result = dentalInsurance.Calculate(employee);

            Assert.Equal(desconto, result);
        }
    }
}