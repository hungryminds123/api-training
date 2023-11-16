using Core.ViewModels;

namespace Core.Interfaces
{
    public interface IEmployeeService
    {

        Task<IEnumerable<EmployeeViewModel>> GetAllEmployees();

        Task<EmployeeViewModel> GetEmployeeById(int id);

        Task<bool> InsertEmployee(EmployeeViewModel employee);
    }
}
