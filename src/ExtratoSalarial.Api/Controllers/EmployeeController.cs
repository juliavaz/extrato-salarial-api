using ExtratoSalarial.Api.Extensions;
using ExtratoSalarial.Core.Domain.Entities;
using ExtratoSalarial.Core.Domain.Interfaces.Requests;
using ExtratoSalarial.Core.Domain.UseCases;
using ExtratoSalarial.Core.Domain.UseCases.PostEmployee;
using Microsoft.AspNetCore.Mvc;

namespace ExtratoSalarial.Api.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IRequestHandler<PostEmployeeInput, ResponseUseCase> _postEmployee;

        public EmployeeController(ILogger<EmployeeController> logger, IRequestHandler<PostEmployeeInput, ResponseUseCase> postEmployee)
        {
            _logger = logger;
            _postEmployee = postEmployee;
        }

        /// <summary>
        /// Endpoint para obter os dados de todos os funcionários
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<Employee> GetEmployees()
        {
            return null;
        }

        /// <summary>
        /// Endpoint para obter dados do funcionário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> GetById(string id)
        {
            return Ok();
        }


        /// <summary>
        /// Endpoint para criar um funcionário
        /// </summary>
        /// <returns></returns>
        /// /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "nome": "Júlia",
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