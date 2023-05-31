using ExtratoSalarial.Api.Extensions;
using ExtratoSalarial.Core.Domain.Interfaces.Requests;
using ExtratoSalarial.Core.Domain.UseCases;
using ExtratoSalarial.Core.Domain.UseCases.GetEmployee;
using ExtratoSalarial.Core.Domain.UseCases.GetEmployeeById;
using ExtratoSalarial.Core.Domain.UseCases.PostEmployee;
using Microsoft.AspNetCore.Mvc;

namespace ExtratoSalarial.Api.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IRequestHandler<PostEmployeeInput, ResponseUseCase> _postEmployee;
        private readonly IRequestHandler<GetEmployeeByIdInput, ResponseUseCase> _getEmployeeById;
        private readonly IRequestHandler<GetEmployeeInput, ResponseUseCase> _getEmployee;

        public EmployeeController(ILogger<EmployeeController> logger,
            IRequestHandler<PostEmployeeInput, ResponseUseCase> postEmployee,
            IRequestHandler<GetEmployeeByIdInput, ResponseUseCase> getEmployeeById,
            IRequestHandler<GetEmployeeInput, ResponseUseCase> getEmployee)
        {
            _logger = logger;
            _postEmployee = postEmployee;
            _getEmployeeById = getEmployeeById;
            _getEmployee = getEmployee;
        }

        /// <summary>
        /// Endpoint para obter todos os dados dos funcion�rios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var input = new GetEmployeeInput();
            var useCase = await _getEmployee.Handle(input);
            return this.ResponseFromUseCase(useCase);
        }

        /// <summary>
        /// Endpoint para obter dados do funcion�rio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var input = new GetEmployeeByIdInput { Id = id };
            var useCase = await _getEmployeeById.Handle(input);
            return this.ResponseFromUseCase(useCase);
        }


        /// <summary>
        /// Endpoint para criar um funcion�rio
        /// </summary>
        /// <returns></returns>
        /// /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "nome": "J�lia",
        ///       "sobrenome": "Gomes",
        ///       "documento": "320.513.371-44",
        ///       "setor": "Tecnologia",
        ///       "salarioBruto": 1000,
        ///       "dataDeAdmissao": "2023-08-21",
        ///       "planoDeSaude": true,
        ///       "planoDental": true, 
        ///       "valeTransporte": false
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created employee</response>
        /// <response code="400">If the employee is null</response>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(PostEmployeeInput input)
        {
            var useCase = await _postEmployee.Handle(input);
            return this.ResponseFromUseCase(useCase);
        }
    }
}