using ExtratoSalarial.Core.Domain.Entities;
using ExtratoSalarial.Core.Domain.Interfaces.Repositories;
using ExtratoSalarial.Core.Domain.UseCases.GetEmployee;
using ExtratoSalarial.Test.Mocks;
using Moq;
using System.Net;

namespace ExtratoSalarial.Test.Domain.UseCases
{
    public class GetEmployeeUseCaseTest
    {
        private readonly Mock<IEmployeeRepository> _employeeRepository;
        private GetEmployeeInput _input;

        public GetEmployeeUseCaseTest()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _input = new GetEmployeeInput();
        }

        [Fact]
        public async void Given_Employee_When_InputIsValid_Then_ExpectedOk()
        {
            IEnumerable<Employee> employees = new List<Employee>() { BaseMock.BuildEmployee() };
            _employeeRepository
                .Setup(x => x.GetAllAsync())
                .Returns(() => Task.FromResult(employees));

            var useCase = new GetEmployeeUseCase(_employeeRepository.Object);
            var response = await useCase.Handle(_input);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Single(((GetEmployeeOutput)response.Result).Data);
            _employeeRepository.Verify(x => x.GetAllAsync(), Times.Once);
        }
    }
}
