using ExtratoSalarial.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExtratoSalarial.Api.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<Employee> Employees = new List<Employee>()
        {
            new Employee() {
                Id = Guid.NewGuid(),
                Nome = "Júlia",
                Sobrenome = "Gomes",
                Documento = "1234567890",
                Setor = "Tecnologia",
                SalarioBruto = 1000,
                DataDeAdmissao = DateTime.Today.Date,
                PlanoDeSaude = true,
                PlanoDental = true,
                ValeTransporte = false
            },
            new Employee() {
                Id = Guid.NewGuid(),
                Nome = "Paula",
                Sobrenome = "Gomes",
                Documento = "0987654321",
                Setor = "Museologia",
                SalarioBruto = 5000,
                DataDeAdmissao = DateTime.Now.Date,
                PlanoDeSaude = true,
                PlanoDental = true,
                ValeTransporte = true
            },
        };

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Endpoint para obter os dados de todos os funcionários
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<Employee> GetEmployees()
        {
            return Employees.ToArray();
        }

        /// <summary>
        /// Endpoint para obter dados do funcionário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> GetById(Guid id)
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
        ///     POST /Employee
        ///     {
        ///        "Nome": "Júlia",
        ///        "Sobrenome": "Gomes",
        ///        "Documento" : "32051337144",
        ///        "Setor": "Tecnologia",
        ///        "SalarioBruto": 1000,
        ///        "DataDeAdmissao": "2023-08-21",
        ///        "PlanoDeSaude": true,
        ///        "PlanoDental": true,
        ///        "ValeTransporte": false
        ///     }
        ///     
        /// </remarks>
        /// <response code="201">Returns the newly created employee</response>
        /// <response code="400">If the employee is null</response>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }
    }
}