using Core.ViewModels;
using Domain;

namespace Core.Mapper
{
    public static class EmployeeServiceMappingExtensions
    {

        public static List<EmployeeViewModel> ConvertToEmployeeViewModel(
            this IEnumerable<Employee> employeeList)
        {
            return employeeList.Select(x => x.ConvertToEmployeeViewModel()).ToList();
        }

        public static EmployeeViewModel ConvertToEmployeeViewModel(this Employee employee)
        {
            return new EmployeeViewModel()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                Id = employee.Id,
            };
        }
    }
}
