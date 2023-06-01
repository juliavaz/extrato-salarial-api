namespace ExtratoSalarial.Core.Domain.Entities.Tax
{
    public class Fgts : Tax
    {
        public override decimal Calculate(Employee employee)
        {
            var result = employee.SalarioBruto - (employee.SalarioBruto * (8m / 100m));
            return result;
        }
    }
}
