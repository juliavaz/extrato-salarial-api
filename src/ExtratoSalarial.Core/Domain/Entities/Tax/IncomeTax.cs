namespace ExtratoSalarial.Core.Domain.Entities.Tax
{
    public class IncomeTax : Tax
    {
        public override decimal Calculate(Employee employee)
        {
            var aliquota = employee.SalarioBruto switch
            {
                <= 1903.89m => 0,
                >= 1903.90m and <= 2826.65m => 7.5m,
                >= 2826.66m and <= 3751.05m => 15m,
                >= 3751.06m and <= 4664.68m => 22.5m,
                _ => 27.5m
            };
            if (aliquota == 0)
            {
                return employee.SalarioBruto;
            }

            var parcela = aliquota switch
            {
                7.5m => 142.8m,
                15m => 354.8m,
                22.5m => 636.13m,
                27.5m => 869.36m
            };

            var desconto = employee.SalarioBruto * (aliquota / 100m);

            if (desconto > parcela)
            {
                desconto = parcela;
            }

            var result = employee.SalarioBruto - desconto;

            return decimal.Round(result, 2);
        }
    }
}
