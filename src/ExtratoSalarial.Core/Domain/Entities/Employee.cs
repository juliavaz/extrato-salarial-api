using ExtratoSalarial.Core.Seedwork;

namespace ExtratoSalarial.Core.Domain.Entities
{
    public class Employee : Entity
    {
        public Employee() { }
        public Employee(
            string nome,
            string sobrenome,
            string documento,
            string setor,
            decimal salarioBruto,
            DateTime dataDeAdmissao,
            bool planoDeSaude,
            bool planoDental,
            bool valeTransporte)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Documento = documento;
            Setor = setor;
            SalarioBruto = salarioBruto;
            DataDeAdmissao = dataDeAdmissao;
            PlanoDeSaude = planoDeSaude;
            PlanoDental = planoDental;
            ValeTransporte = valeTransporte;
            Initialize();
        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Documento { get; private set; }
        public string Setor { get; private set; }
        public decimal SalarioBruto { get; private set; }
        public DateTime DataDeAdmissao { get; private set; }
        public bool PlanoDeSaude { get; private set; }
        public bool PlanoDental { get; private set; }
        public bool ValeTransporte { get; private set; }
    }
}
