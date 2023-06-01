namespace ExtratoSalarial.Core.Domain.Entities.Tax
{
    public class Vt : Tax
    {
        public override decimal Calculate(Employee employee)
        {
            if (!employee.ValeTransporte)
                return employee.SalarioBruto;

            if (employee.SalarioBruto < 1500)
                return employee.SalarioBruto;

            var result = employee.SalarioBruto - (employee.SalarioBruto * (6m / 100m));

            return result;
        }
    }
}
