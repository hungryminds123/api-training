using Core.Interfaces;
using Core.Mapper;
using Core.ViewModels;
using Persistence.Repositories.Interface;

namespace Core.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAllEmployees()
        {
            var response = await _employeeRepository.GetAll();

            return response.ConvertToEmployeeViewModel();
        }

        public async Task<EmployeeViewModel> GetEmployeeById(int id)
        {
            var data = await _employeeRepository.Get(id);

            return data.ConvertToEmployeeViewModel();

        }

        public async Task<bool> InsertEmployee(EmployeeViewModel employee)
        {
          var data =   await _employeeRepository.Add(employee.ConvertToEmployee());

            if(data != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

       
    }
}
