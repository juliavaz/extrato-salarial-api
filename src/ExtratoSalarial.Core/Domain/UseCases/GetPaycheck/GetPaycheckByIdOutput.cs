namespace ExtratoSalarial.Core.Domain.UseCases.GetPaycheck
{
    public class GetPaycheckByIdOutput
    {
        public GetPaycheckByIdOutput(
            string funcionarioId,
            DateTime dataDeAdmissao,
            decimal salarioBruto,
            decimal totalDeDescontos,
            decimal salarioLiquido)

        {
            FuncionarioId = funcionarioId;
            MesReferencia = dataDeAdmissao.Month.ToString();
            SalarioBruto = salarioBruto;
            TotalDeDescontos = totalDeDescontos;
            SalarioLiquido = salarioLiquido;
            BuildEntry("Remuneração", SalarioBruto, "Salário Bruto");
        }
        public string FuncionarioId { get; set; }
        public string MesReferencia { get; set; }
        public decimal SalarioBruto { get; set; }
        public decimal TotalDeDescontos { get; set; }
        public decimal SalarioLiquido { get; set; }
        public List<EntryData> Lancamentos { get; set; } = new();

        public void BuildDiscountEntries(decimal inss, decimal ir, decimal dentalInsurance, decimal healthInsurance, decimal fgts, decimal vt)
        {
            BuildEntry("Desconto", inss, "Inss");
            BuildEntry("Desconto", ir, "Imposto de Renda");
            BuildEntry("Desconto", dentalInsurance, "Plano Dental");
            BuildEntry("Desconto", healthInsurance, "Plano de Saúde");
            BuildEntry("Desconto", fgts, "Fgts");
            BuildEntry("Desconto", vt, "Vale Transporte");
        }

        private void BuildEntry(string tipo, decimal valor, string descricao)
        {
            if (valor == 0)
            {
                return;
            }

            Lancamentos.Add(new()
            {
                Tipo = tipo,
                Valor = valor,
                Descricao = descricao
            });
        }
    }

    public class EntryData
    {
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }
}
