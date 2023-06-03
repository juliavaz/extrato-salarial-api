namespace ExtratoSalarial.Core.Domain.Entities.Tax
{
    public class Fgts : Tax
    {
        public override decimal Calculate(Employee employee)
        {
            var desconto = employee.SalarioBruto * (8m / 100m);
            return decimal.Round(desconto, 2);
        }
    }
}
