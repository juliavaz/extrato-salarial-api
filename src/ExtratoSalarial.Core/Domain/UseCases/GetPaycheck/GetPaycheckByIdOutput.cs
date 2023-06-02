using ExtratoSalarial.Core.Domain.Enums;

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
            DateTime createdAt,
            List<EntriesData> lancamentos)

        {
            FuncionarioId = funcionarioId;
            MesReferencia = mesReferencia;
            SalarioBruto = salarioBruto;
            TotalDeDescontos = totalDeDescontos;
            SalarioLiquido = salarioLiquido;
            CreatedAt = createdAt;
            Lancamentos = lancamentos;
        }
        public string FuncionarioId { get; set; }
        public string MesReferencia { get; set; }
        public decimal SalarioBruto { get; set; }
        public decimal TotalDeDescontos { get; set; }
        public decimal SalarioLiquido { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<EntriesData> Lancamentos { get; set; }
    }

    public class EntriesData
    {
        public EEntriesType Tipo { get; set; }
        public decimal Valor { get; set; }
        public EDescriptionType Descricao { get; set; }
    }
}
