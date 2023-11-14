using Core.ViewModels;

namespace Core.Interfaces
{
    public interface IEmployeeService
    {

        IEnumerable<EmployeeViewModel> GetAllEmployees();
    }
}
