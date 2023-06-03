using ExtratoSalarial.Core.Domain.Interfaces.Requests;
using FluentValidation;

namespace ExtratoSalarial.Core.Domain.UseCases.GetEmployeeById
{
    public class GetEmployeeByIdInput : IRequest<ResponseUseCase>
    {
        public string Id { get; set; }
        public GetEmployeeByIdInput() { }
    }

    public class GetEmployeeByIdValidation : AbstractValidator<GetEmployeeByIdInput>
    {
        public GetEmployeeByIdValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Informe o Id do funcionário")
                .Length(24, 24).WithMessage("A propriedade deve ter 24 caracteres.");
        }
    }
}
