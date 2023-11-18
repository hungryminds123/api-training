using AutoMapper;
using Core.Interfaces;
using Core.Mapper;
using Core.ViewModels;
using Persistence.Repositories.Interface;

namespace Core.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAllEmployees()
        {
            var response = await _employeeRepository.GetAll();
            return _mapper.Map<IEnumerable<EmployeeViewModel>>(response);
        }

        public async Task<EmployeeViewModel> GetEmployeeById(int id)
        {
            var data = await _employeeRepository.Get(id);

            return _mapper.Map<EmployeeViewModel>(data);
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
