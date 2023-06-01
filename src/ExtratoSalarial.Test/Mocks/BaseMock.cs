using ExtratoSalarial.Core.Domain.Entities;

namespace ExtratoSalarial.Test.Mocks
{
    public class BaseMock
    {
        public static Employee BuildEmployee(
            string nome = "Júlia",
            string sobrenome = "Gomes",
            string documento = "123.456.789-00",
            string setor = "Tecnologia",
            decimal salarioBruto = 1000,
            DateTime dataDeAdmissao = default(DateTime),
            bool planoDeSaude = true,
            bool planoDental = true,
            bool valeTransporte = true
            )
        {
            return new Employee(
                nome,
                sobrenome,
                documento,
                setor,
                salarioBruto,
                dataDeAdmissao,
                planoDeSaude,
                planoDental,
                valeTransporte
           );
        }
    }
}
