using AutoMapper;
using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.Mapping
{
    public class PaginationMappingProfile : Profile
    {
        public PaginationMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
