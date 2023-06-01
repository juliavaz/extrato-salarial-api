﻿namespace ExtratoSalarial.Core.Domain.Entities.Tax
{
    public class DentalInsurance : Tax
    {
        public override decimal Calculate(Employee employee)
        {
            if (!employee.PlanoDental)
            {
                return employee.SalarioBruto;
            }
            return employee.SalarioBruto - 5;
        }
    }
}
