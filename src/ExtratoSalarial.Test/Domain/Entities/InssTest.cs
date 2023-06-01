using ExtratoSalarial.Core.Domain.Entities.Tax;
using ExtratoSalarial.Test.Mocks;

namespace ExtratoSalarial.Test.Domain.Entities
{
    public class InssTest
    {
        [Theory]
        [InlineData(1045, 966.62)]
        [InlineData(1045.01, 950.96)]
        [InlineData(2089.60, 1901.54)]
        [InlineData(2089.61, 1838.86)]
        [InlineData(3134.40, 2758.27)]
        [InlineData(3134.41, 2695.59)]
        [InlineData(6101.06, 5246.91)]
        [InlineData(7000, 6020.00)]
        [InlineData(10045.01, 8638.71)]
        public void Calculated(decimal salarioBruto, decimal salarioBrutoResult)
        {
            var employee = BaseMock.BuildEmployee(salarioBruto: salarioBruto);
            var inss = new Inss();

            var result = inss.Calculate(employee);

            Assert.Equal(salarioBrutoResult, result);
        }
    }
}
