namespace ExtratoSalarial.Core.Domain.Entities.Tax
{
    public class Inss : Tax
    {
        public override decimal Calculate(Employee employee)
        {
            var aliquota = employee.SalarioBruto switch
            {
                >= 0 and <= 1045m => 7.5m,
                > 1045m and <= 2089.60m => 9m,
                > 2089.60m and <= 3134.40m => 12m,
                > 3134.40m and <= 6101.06m => 14m,
                _ => 14m
            };

            var result = employee.SalarioBruto - (employee.SalarioBruto * (aliquota / 100m));

            return decimal.Round(result, 2);
        }
    }
}
