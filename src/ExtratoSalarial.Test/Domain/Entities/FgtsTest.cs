using ExtratoSalarial.Core.Domain.Entities.Tax;
using ExtratoSalarial.Test.Mocks;

namespace ExtratoSalarial.Test.Domain.Entities
{
    public class FgtsTest
    {
        [Theory]
        [InlineData(1000, 920)]
        [InlineData(1500, 1380)]
        [InlineData(2000, 1840)]
        public void Calculated(decimal salarioBruto, decimal salarioBrutoResult)
        {
            var employee = BaseMock.BuildEmployee(salarioBruto: salarioBruto);
            var fgts = new Fgts();

            var result = fgts.Calculate(employee);

            Assert.Equal(salarioBrutoResult, result);
        }
    }
}
