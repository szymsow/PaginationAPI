using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using WebAPI.Entities;

namespace WebAPI.Sieve
{
    public class PaginationSieveProcessor : SieveProcessor
    {
        public PaginationSieveProcessor(IOptions<SieveOptions> options) : base(options)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<Employee>(e => e.Salary)
                .CanSort()
                .CanFilter();

            mapper.Property<Employee>(e => e.Address.Country)
                .CanSort()
                .CanFilter();

            mapper.Property<Employee>(e => e.Address.City)
                .CanSort()
                .CanFilter();

            return mapper;
        }
    }
}
