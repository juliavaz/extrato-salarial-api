using ExtratoSalarial.Core.Domain.Entities;
using ExtratoSalarial.Core.Domain.Interfaces.Repositories;
using ExtratoSalarial.Core.Domain.UseCases.GetPaycheck;
using ExtratoSalarial.Test.Mocks;
using FluentValidation;
using Moq;
using System.Net;

namespace ExtratoSalarial.Test.Domain.UseCases
{
    public class GetPaycheckByIdUseCaseTest
    {
        private readonly Mock<IEmployeeRepository> _employeeRepository;
        private readonly IValidator<GetPaycheckByIdInput> _validator;
        private GetPaycheckByIdInput _input;

        public GetPaycheckByIdUseCaseTest()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _input = new GetPaycheckByIdInput();
            _validator = new GetPaycheckByIdValidation();
        }

        [Fact]
        public async void Given_Paycheck_When_InputIsValid_Then_ExpectedOk()
        {
            _employeeRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<string>()))
                .Returns(() => Task.FromResult(BaseMock.BuildEmployee()));

            _input.FuncionarioId = "647a91808b643cfecf0b1f38";

            var useCase = new GetPaycheckByIdUseCase(_employeeRepository.Object, _validator);
            var response = await useCase.Handle(_input);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            _employeeRepository.Verify(x => x.GetByIdAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async void Given_Paycheck_When_EntryIsValid_Then_ExpectedOk()
        {
            _employeeRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<string>()))
                .Returns(() => Task.FromResult(BaseMock.BuildEmployee()));

            _input.FuncionarioId = "647a91808b643cfecf0b1f38";

            var useCase = new GetPaycheckByIdUseCase(_employeeRepository.Object, _validator);
            var response = await useCase.Handle(_input);

            var result = response.Result as GetPaycheckByIdOutput;
            var entries = result.Lancamentos;

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains(entries, x => x.Descricao == "Plano de Saúde");
            _employeeRepository.Verify(x => x.GetByIdAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async void Given_Paycheck_When_InputIsInvalid_Then_ExpectedBadRequest()
        {
            var useCase = new GetPaycheckByIdUseCase(_employeeRepository.Object, _validator);
            var response = await useCase.Handle(_input);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            _employeeRepository.Verify(x => x.GetByIdAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async void Given_Paycheck_When_InputIsInvalid_Then_ExpectedNotFound()
        {
            _employeeRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<string>()))
                .Returns(() => Task.FromResult<Employee>(null));

            _input.FuncionarioId = "647a91808b643cfecf0b1f38";

            var useCase = new GetPaycheckByIdUseCase(_employeeRepository.Object, _validator);
            var response = await useCase.Handle(_input);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            _employeeRepository.Verify(x => x.GetByIdAsync(It.Is<string>(x => x.Equals(_input.FuncionarioId))), Times.Once);
        }
    }
}
