using ExtratoSalarial.Core.Domain.Entities.Tax;
using ExtratoSalarial.Test.Mocks;

namespace ExtratoSalarial.Test.Domain.Entities
{
    public class InssTest
    {
        [Theory]
        [InlineData(1045, 78.38)]
        [InlineData(1045.01, 94.05)]
        [InlineData(2089.60, 188.06)]
        [InlineData(2089.61, 250.75)]
        [InlineData(3134.40, 376.13)]
        [InlineData(3134.41, 438.82)]
        [InlineData(6101.06, 854.15)]
        [InlineData(7000, 980)]
        [InlineData(10045.01, 1406.30)]
        public void Calculated(decimal salarioBruto, decimal desconto)
        {
            var employee = BaseMock.BuildEmployee(salarioBruto: salarioBruto);

            var inss = new Inss();
            var result = inss.Calculate(employee);

            Assert.Equal(desconto, result);
        }
    }
}
