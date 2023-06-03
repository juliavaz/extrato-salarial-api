namespace ExtratoSalarial.Core.Domain.Entities.Tax
{
    public class HealthInsurance : Tax
    {
        public override decimal Calculate(Employee employee)
        {
            if (!employee.PlanoDeSaude)
            {
                return 0;
            }
            return 10;
        }
    }
}
