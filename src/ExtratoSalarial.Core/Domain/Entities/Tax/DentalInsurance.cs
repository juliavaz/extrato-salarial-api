namespace ExtratoSalarial.Core.Domain.Entities.Tax
{
    public class DentalInsurance : Tax
    {
        public override decimal Calculate(Employee employee)
        {
            if (!employee.PlanoDental)
            {
                return 0;
            }
            return 5;
        }
    }
}
