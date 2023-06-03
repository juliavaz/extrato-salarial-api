using ExtratoSalarial.Core.Domain.Entities.Tax;
using ExtratoSalarial.Test.Mocks;

namespace ExtratoSalarial.Test.Domain.Entities
{
    public class FgtsTest
    {
        [Theory]
        [InlineData(1000, 80)]
        [InlineData(1500, 120)]
        [InlineData(2000, 160)]
        public void Calculated(decimal salarioBruto, decimal desconto)
        {
            var employee = BaseMock.BuildEmployee(salarioBruto: salarioBruto);

            var fgts = new Fgts();
            var result = fgts.Calculate(employee);

            Assert.Equal(desconto, result);
        }
    }
}
