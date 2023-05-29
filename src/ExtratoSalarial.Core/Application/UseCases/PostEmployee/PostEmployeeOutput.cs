namespace ExtratoSalarial.Core.Application.UseCases.PostEmployee
{
    public class PostEmployeeOutput
    {
        public PostEmployeeOutput(
            string id,
            string nome,
            string sobrenome,
            string documento,
            string setor,
            decimal salarioBruto,
            DateTime dataDeAdmissao,
            bool planoDeSaude,
            bool planoDental,
            bool valeTransporte,
            DateTime createdAt)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Documento = documento;
            Setor = setor;
            SalarioBruto = salarioBruto;
            DataDeAdmissao = dataDeAdmissao;
            PlanoDeSaude = planoDeSaude;
            PlanoDental = planoDental;
            ValeTransporte = valeTransporte;
            CreatedAt = createdAt;
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public string Setor { get; set; }
        public decimal SalarioBruto { get; set; }
        public DateTime DataDeAdmissao { get; set; }
        public bool PlanoDeSaude { get; set; }
        public bool PlanoDental { get; set; }
        public bool ValeTransporte { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
