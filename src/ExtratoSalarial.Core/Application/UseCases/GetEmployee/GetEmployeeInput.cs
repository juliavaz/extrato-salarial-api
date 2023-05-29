using FluentValidation;

namespace ExtratoSalarial.Core.Application.UseCases.GetEmployee
{
    public class GetEmployeeInput
    {
        public string Id { get; set; }
        public GetEmployeeInput() { }

    }

    public class GetEmployeeInputValidation : AbstractValidator<GetEmployeeInput>
    {
        public GetEmployeeInputValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Informe o Id do funcionário");
        }
    }
}
