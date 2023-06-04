using ExtratoSalarial.Core.Domain.Entities;
using ExtratoSalarial.Core.Domain.Interfaces.Repositories;
using ExtratoSalarial.Core.Domain.UseCases.PostEmployee;
using ExtratoSalarial.Test.Mocks;
using Moq;
using System.Net;

namespace ExtratoSalarial.Test.Domain.UseCases
{
    public class PostEmployeeUseCaseTest
    {
        private readonly Mock<IEmployeeRepository> _employeeRepository;
        private PostEmployeeInput _input;

        public PostEmployeeUseCaseTest()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _input = BuildPostEmployeeInput();
        }

        [Fact]
        public async void Given_Paycheck_When_InputIsValid_Then_ExpectedCreated()
        {
            _employeeRepository
                .Setup(x => x.CreateAsync(It.IsAny<Employee>()))
                .Returns(() => Task.FromResult(BaseMock.BuildEmployee()));

            var useCase = new PostEmployeeUseCase(_employeeRepository.Object);
            var response = await useCase.Handle(_input);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            _employeeRepository.Verify(x => x.CreateAsync(It.IsAny<Employee>()), Times.Once);
        }

        [Fact]
        public async void Given_Paycheck_When_InputIsInvalid_Then_ExpectedBadRequest()
        {
            var useCase = new PostEmployeeUseCase(_employeeRepository.Object);
            var response = await useCase.Handle(new PostEmployeeInput());

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            _employeeRepository.Verify(x => x.CreateAsync(It.IsAny<Employee>()), Times.Never);
        }

        #region Mock
        private PostEmployeeInput BuildPostEmployeeInput()
        {
            return new PostEmployeeInput
            {
                Nome = "Júlia",
                Sobrenome = "Gomes",
                Documento = "123.456.789-02",
                Setor = "Tecnologia",
                SalarioBruto = 1000,
                DataDeAdmissao = default(DateTime),
                PlanoDental = true,
                PlanoDeSaude = true,
                ValeTransporte = true
            };
        }
        #endregion
    }
}
