using ExtratoSalarial.Core.Domain.Entities.Tax;
using ExtratoSalarial.Test.Mocks;

namespace ExtratoSalarial.Test.Domain.Entities
{
    public class IrrfTest
    {
        [Theory]
        [InlineData(1903.89, 0)]
        [InlineData(2826.65, 142.80)]
        [InlineData(2826.66, 354.80)]
        [InlineData(3751.05, 354.80)]
        [InlineData(3751.06, 636.13)]
        [InlineData(4664.68, 636.13)]
        [InlineData(5000, 869.36)]
        public void Calculate(decimal salarioBruto, decimal desconto)
        {
            var employee = BaseMock.BuildEmployee(salarioBruto: salarioBruto);

            var incomeTax = new Irrf();
            var result = incomeTax.Calculate(employee);

            Assert.Equal(desconto, result);
        }
    }
}
