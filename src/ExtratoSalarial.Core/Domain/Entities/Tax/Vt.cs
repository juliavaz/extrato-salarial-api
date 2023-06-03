namespace ExtratoSalarial.Core.Domain.Entities.Tax
{
    public class Vt : Tax
    {
        public override decimal Calculate(Employee employee)
        {
            if (!employee.ValeTransporte)
                return 0;

            if (employee.SalarioBruto < 1500)
                return 0;

            var desconto = employee.SalarioBruto * (6m / 100m);

            return decimal.Round(desconto, 2);
        }
    }
}
