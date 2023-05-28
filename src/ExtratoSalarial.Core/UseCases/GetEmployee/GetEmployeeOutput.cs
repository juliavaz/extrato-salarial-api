namespace ExtratoSalarial.Core.UseCases.GetEmployee
{
    public class GetEmployeeOutput
    {
        public GetEmployeeOutput(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public string Setor { get; set; }
        public int SalarioBruto { get; set; }
        public DateTime DataDeAdmissao { get; set; }
        public bool PlanoDeSaude { get; set; }
        public bool PlanoDental { get; set; }
        public bool ValeTransporte { get; set; }
    }
}
