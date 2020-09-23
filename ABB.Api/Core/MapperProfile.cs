using ABB.Application.Models.v1.Employee;
using ABB.Domain.Entities;
using AutoMapper;

namespace ABB.Api.Core
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, GetEmployeeByIdResponseModel>().ReverseMap();
            CreateMap<Employee, GetAllEmployeesResponseModel>().ReverseMap();
            CreateMap<CreateEmployeeRequestModel, Employee>().ReverseMap();
        }
    }
}
