namespace ExtratoSalarial.Core.Domain.Entities.Tax
{
    public class HealthInsurance : Tax
    {
        public override decimal Calculate(Employee employee)
        {
            if (!employee.PlanoDeSaude)
            {
                return employee.SalarioBruto;
            }
            return employee.SalarioBruto - 10;
        }
    }
}
