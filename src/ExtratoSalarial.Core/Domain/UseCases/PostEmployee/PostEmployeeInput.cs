using ExtratoSalarial.Core.Domain.Interfaces.Requests;
using FluentValidation;

namespace ExtratoSalarial.Core.Domain.UseCases.PostEmployee
{
    public class PostEmployeeInput : IRequest<ResponseUseCase>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public string Setor { get; set; }
        public decimal SalarioBruto { get; set; }
        public DateTime DataDeAdmissao { get; set; }
        public bool? PlanoDeSaude { get; set; }
        public bool? PlanoDental { get; set; }
        public bool? ValeTransporte { get; set; }
    }

    public class PostEmployeeValidation : AbstractValidator<PostEmployeeInput>
    {
        public PostEmployeeValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Informe o nome do funcionário")
                .MaximumLength(150);

            RuleFor(x => x.Sobrenome)
                .NotEmpty().WithMessage("Informe o sobrenome do funcionário")
                .MaximumLength(150);

            RuleFor(x => x.Documento)
                .NotEmpty().WithMessage("Informe o CPF do funcionário com formato válido")
                .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$").WithMessage("CPF inválido");

            RuleFor(x => x.Setor)
                .NotEmpty().WithMessage("Informe o setor do funcionário")
                .MaximumLength(100);

            RuleFor(x => x.SalarioBruto)
                .NotNull().WithMessage("Informe o salário do funcionário");

            RuleFor(x => x.DataDeAdmissao)
                .NotNull().WithMessage("Informe a data de admissão do funcionário");

            RuleFor(x => x.PlanoDeSaude)
                .NotNull().WithMessage("Informe se o funcionário possui plano de saúde");

            RuleFor(x => x.PlanoDental)
                .NotNull().WithMessage("Informe se o funcionário possui plano dental");

            RuleFor(x => x.ValeTransporte)
                .NotNull().WithMessage("Informe se o funcionário possui vale transporte");
        }
    }
}
