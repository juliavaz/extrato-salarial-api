using ExtratoSalarial.Core.Domain.Entities;
using ExtratoSalarial.Core.Domain.Interfaces.Repositories;
using ExtratoSalarial.Core.Domain.UseCases.GetEmployeeById;
using ExtratoSalarial.Test.Mocks;
using Moq;
using System.Net;

namespace ExtratoSalarial.Test.Domain.UseCases
{
    public class GetEmployeeByIdUseCaseTest
    {
        private readonly Mock<IEmployeeRepository> _employeeRepository;
        private GetEmployeeByIdInput _input;

        public GetEmployeeByIdUseCaseTest()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _input = new GetEmployeeByIdInput();
        }

        [Fact]
        public async void Given_Employee_When_InputIsValid_Then_ExpectedCreated()
        {
            _employeeRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<string>()))
                .Returns(() => Task.FromResult(BaseMock.BuildEmployee()));

            _input.Id = "647a91808b643cfecf0b1f38";

            var useCase = new GetEmployeeByIdUseCase(_employeeRepository.Object);
            var response = await useCase.Handle(_input);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            _employeeRepository.Verify(x => x.GetByIdAsync(It.Is<string>(x => x.Equals(_input.Id))), Times.Once);
        }

        [Fact]
        public async void Given_Employee_When_InputIsInvalid_Then_ExpectedBadRequest()
        {
            var useCase = new GetEmployeeByIdUseCase(_employeeRepository.Object);
            var response = await useCase.Handle(_input);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            _employeeRepository.Verify(x => x.GetByIdAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async void Given_Employee_When_InputIsInvalid_Then_ExpectedNotFound()
        {
            _employeeRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<string>()))
                .Returns(() => Task.FromResult<Employee>(null));

            _input.Id = "647a91808b643cfecf0b1f38";

            var useCase = new GetEmployeeByIdUseCase(_employeeRepository.Object);
            var response = await useCase.Handle(_input);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            _employeeRepository.Verify(x => x.GetByIdAsync(It.Is<string>(x => x.Equals(_input.Id))), Times.Once);
        }
    }
}