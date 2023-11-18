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

        public EmployeeController(
            IValidator<EmployeeViewModel> validator,
            IEmployeeService employeeService
            )
        {
            _validator = validator;
            _employeeService = employeeService;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(EmployeeViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<EmployeeViewModel>> Get()
        { 
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
        public async Task<IActionResult> Post([FromBody] EmployeeViewModel empModel)
        {
            var response = await _employeeService.InsertEmployee(empModel);
            return Ok(response);
        }
    }
}
