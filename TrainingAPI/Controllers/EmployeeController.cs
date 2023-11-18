using Core.Interfaces;
using Core.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace TrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IValidator<EmployeeViewModel> _validator;
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(
            IValidator<EmployeeViewModel> validator,
            IEmployeeService employeeService,
            ILogger<EmployeeController> logger
            )
        {
            _validator = validator;
            _employeeService = employeeService;
            _logger = logger;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(EmployeeViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<EmployeeViewModel>> Get()
        { 
            _logger.LogInformation("Reading data from Get Request");
            
            return await _employeeService.GetAllEmployees();
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<EmployeeViewModel> GetById(int id)
        {
            return await _employeeService.GetEmployeeById(id);
        }
        
        [HttpPut]
        public async Task<EmployeeViewModel> Update([FromBody] EmployeeViewModel empModel)
        {
            // implement PUT part
             throw new NotImplementedException("");

           // return await _employeeService.GetEmployeeById(id);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post([FromBody] EmployeeViewModel empModel)
        {
            var response = await _employeeService.InsertEmployee(empModel);
            return Ok(response);
        }
    }
}
