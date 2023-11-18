using AutoMapper;
using Core.ViewModels;
using Domain;

namespace Core.AutoMapperFiles;


public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<Employee, EmployeeViewModel>().ReverseMap();
    }
}