using ExtratoSalarial.Core.Domain.Entities.Tax;
using ExtratoSalarial.Test.Mocks;

namespace ExtratoSalarial.Test.Domain.Entities
{
    public class IncomeTaxTest
    {
        [Theory]
        [InlineData(1903.90, 1761.11)]
        [InlineData(1903.89, 1903.89)]
        [InlineData(2826.65, 2683.85)]
        [InlineData(2826.66, 2471.86)]
        [InlineData(3751.05, 3396.25)]
        [InlineData(3751.06, 3114.93)]
        [InlineData(4664.68, 4028.55)]
        [InlineData(5000, 4130.64)]
        public void Calculate(decimal salarioBruto, decimal salarioBrutoResult)
        {
            var employee = BaseMock.BuildEmployee(salarioBruto: salarioBruto);
            var incomeTax = new IncomeTax();

            var result = incomeTax.Calculate(employee);

            Assert.Equal(salarioBrutoResult, result);
        }
    }
}
