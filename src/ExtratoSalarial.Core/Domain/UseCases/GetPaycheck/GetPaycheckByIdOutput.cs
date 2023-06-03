namespace ExtratoSalarial.Core.Domain.UseCases.GetPaycheck
{
    public class GetPaycheckByIdOutput
    {
        public GetPaycheckByIdOutput(
            string funcionarioId,
            string mesReferencia,
            decimal salarioBruto,
            decimal totalDeDescontos,
            decimal salarioLiquido,
            List<EntriesData> lancamentos)

        {
            FuncionarioId = funcionarioId;
            MesReferencia = mesReferencia;
            SalarioBruto = salarioBruto;
            TotalDeDescontos = totalDeDescontos;
            SalarioLiquido = salarioLiquido;
            Lancamentos = lancamentos;
        }
        public string FuncionarioId { get; set; }
        public string MesReferencia { get; set; }
        public decimal SalarioBruto { get; set; }
        public decimal TotalDeDescontos { get; set; }
        public decimal SalarioLiquido { get; set; }
        public List<EntriesData> Lancamentos { get; set; }
    }

    public class EntriesData
    {
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }
}
