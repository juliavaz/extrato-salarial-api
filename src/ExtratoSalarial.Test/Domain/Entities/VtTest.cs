using ExtratoSalarial.Core.Domain.Entities.Tax;
using ExtratoSalarial.Test.Mocks;

namespace ExtratoSalarial.Test.Domain.Entities
{
    public class VtTest
    {
        [Theory]
        [InlineData(false, 1000, 0)]
        [InlineData(true, 1000, 0)]
        [InlineData(true, 1500, 90.00)]
        [InlineData(true, 1501, 90.06)]
        [InlineData(true, 2000, 120.00)]
        public void Calculated(bool valeTransporte, decimal salarioBruto, decimal desconto)
        {
            var employee = BaseMock.BuildEmployee(valeTransporte: valeTransporte, salarioBruto: salarioBruto);

            var vt = new Vt();
            var result = vt.Calculate(employee);

            Assert.Equal(desconto, result);
        }
    }
}
