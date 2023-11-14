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

        public  IEnumerable<EmployeeViewModel> GetAllEmployees()
        {
            var response = _employeeRepository.GetAll();

            return response.ConvertToEmployeeViewModel();
        }
    }
}
