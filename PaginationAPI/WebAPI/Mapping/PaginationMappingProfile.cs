using AutoMapper;
using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.Mapping
{
    public class PaginationMappingProfile : Profile
    {
        public PaginationMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(e => e.Address, opt => opt.MapFrom(x => new AddressDto()
                {
                    Country = x.Address.Country,
                    City = x.Address.City,
                    PostalCode = x.Address.PostalCode,
                    Street = x.Address.Street
                }));
        }
    }
}
