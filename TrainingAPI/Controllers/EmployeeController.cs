using Core.Interfaces;
using Core.Validators;
using Core.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace TrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IValidator<EmployeeViewModel> validator;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(
            IValidator<EmployeeViewModel> validator,
            IEmployeeService employeeService)
        {
            this.validator = validator;
            _employeeService = employeeService;
        }


        [HttpGet]
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
