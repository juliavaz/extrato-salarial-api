using ExtratoSalarial.Core.Domain.Entities;
using ExtratoSalarial.Core.Domain.Interfaces.Repositories;
using ExtratoSalarial.Core.Domain.UseCases.GetPaycheck;
using ExtratoSalarial.Test.Mocks;
using Moq;
using System.Net;

namespace ExtratoSalarial.Test.Domain.UseCases
{
    public class GetPaycheckByIdUseCaseTest
    {
        private readonly Mock<IEmployeeRepository> _employeeRepository;
        private GetPaycheckByIdInput _input;

        public GetPaycheckByIdUseCaseTest()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _input = new GetPaycheckByIdInput();
        }

        [Fact]
        public async void Given_Paycheck_When_InputIsValid_Then_ExpectedOk()
        {
            _employeeRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<string>()))
                .Returns(() => Task.FromResult(BaseMock.BuildEmployee()));

            _input.FuncionarioId = "647a91808b643cfecf0b1f38";

            var useCase = new GetPaycheckByIdUseCase(_employeeRepository.Object);
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

            var useCase = new GetPaycheckByIdUseCase(_employeeRepository.Object);
            var response = await useCase.Handle(_input);

            var entry = BuildEntries();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Plano de Saúde", entry[3].Descricao);
            _employeeRepository.Verify(x => x.GetByIdAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async void Given_Paycheck_When_InputIsInvalid_Then_ExpectedBadRequest()
        {
            var useCase = new GetPaycheckByIdUseCase(_employeeRepository.Object);
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

            var useCase = new GetPaycheckByIdUseCase(_employeeRepository.Object);
            var response = await useCase.Handle(_input);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            _employeeRepository.Verify(x => x.GetByIdAsync(It.Is<string>(x => x.Equals(_input.FuncionarioId))), Times.Once);
        }

        #region Mocks
        private static List<EntriesData> BuildEntries()
        {
            var entriesData = new List<EntriesData> {
                new EntriesData
                {
                    Tipo = "Remuneração",
                    Valor = 1000,
                    Descricao = "Salário Bruto"
                },
                new EntriesData
                {
                    Tipo = "Desconto",
                    Valor = 75,
                    Descricao = "Inss"
                },
                new EntriesData
                {
                    Tipo = "Desconto",
                    Valor = 5,
                    Descricao = "Plano Dentário"
                },
                new EntriesData
                {
                    Tipo = "Desconto",
                    Valor = 10,
                    Descricao = "Plano de Saúde"
                },
                new EntriesData
                {
                    Tipo = "Desconto",
                    Valor = 80,
                    Descricao = "Fgts"
                }
            };

            return entriesData;
        }
        #endregion
    }
}
