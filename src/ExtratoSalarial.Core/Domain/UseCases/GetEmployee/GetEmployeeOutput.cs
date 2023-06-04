namespace ExtratoSalarial.Core.Domain.UseCases.GetEmployee
{
    public class GetEmployeeOutput
    {
        public GetEmployeeOutput(List<EmployeeData> data)
        {
            Data = data;
        }

        public List<EmployeeData> Data { get; set; }
    }

    public class EmployeeData
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public string Setor { get; set; }
        public decimal SalarioBruto { get; set; }
        public DateTime DataDeAdmissao { get; set; }
        public bool? PlanoDeSaude { get; set; }
        public bool? PlanoDental { get; set; }
        public bool? ValeTransporte { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
