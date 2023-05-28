using ExtratoSalarial.Core.Domain.Enums;
using ExtratoSalarial.Core.Seedwork;

namespace ExtratoSalarial.Core.Domain.Entities
{
    public class Paycheck : Entity
    {
        public DateTime MesReferencia { get; set; }
        public List<EntriesResult> Lancamentos { get; set; }
        public int SalarioBruto { get; set; }
        public int TotalDeDescontos { get; set; }
        public int SalarioLiquido { get; set; }
    }

    public class EntriesResult
    {
        public EEntriesType Tipo { get; set; }
        public int Valor { get; set; }
        public EDescriptionType Descricao { get; set; }
    }
}
