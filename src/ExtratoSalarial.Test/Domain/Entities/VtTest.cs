using ExtratoSalarial.Core.Domain.Entities.Tax;
using ExtratoSalarial.Test.Mocks;

namespace ExtratoSalarial.Test.Domain.Entities
{
    public class VtTest
    {
        [Theory]
        [InlineData(false, 1000, 1000)]
        [InlineData(true, 1000, 1000)]
        [InlineData(true, 1500, 1410.00)]
        [InlineData(true, 1501, 1410.94)]
        [InlineData(true, 2000, 1880)]
        public void Calculated(bool valeTransporte, decimal salarioBruto, decimal salarioBrutoResult)
        {
            var employee = BaseMock.BuildEmployee(valeTransporte: valeTransporte, salarioBruto: salarioBruto);
            var vt = new Vt();

            var result = vt.Calculate(employee);

            Assert.Equal(salarioBrutoResult, result);
        }
    }
}
