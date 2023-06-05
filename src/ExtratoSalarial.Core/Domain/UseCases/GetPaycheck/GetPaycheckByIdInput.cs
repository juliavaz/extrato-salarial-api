using ExtratoSalarial.Core.Domain.Interfaces.Requests;
using FluentValidation;

namespace ExtratoSalarial.Core.Domain.UseCases.GetPaycheck
{
    public class GetPaycheckByIdInput : IRequest<ResponseUseCase>
    {
        public GetPaycheckByIdInput() { }

        public string FuncionarioId { get; set; }
    }

    public class GetPaycheckByIdValidation : AbstractValidator<GetPaycheckByIdInput>
    {
        public GetPaycheckByIdValidation()
        {
            RuleFor(x => x.FuncionarioId)
                .NotEmpty().WithMessage("Informe o Id do funcionário")
                .Length(24).WithMessage("A propriedade deve ter 24 caracteres.");
        }
    }
}
