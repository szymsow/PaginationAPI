using Bogus;
using WebAPI.Entities;

namespace PaginationAPI.Core.DataGenerator
{
    public static class EmployeeGenerator
    {
        public static IEnumerable<Employee> GetEmployees(int count)
        {
            var addressGenerator = new Faker<Address>()
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Country, f => f.Address.Country())
                .RuleFor(a => a.PostalCode, f => f.Address.ZipCode())
                .RuleFor(a => a.Street, f => f.Address.StreetName());

            var employeeGenerator = new Faker<Employee>()
                .RuleFor(e => e.FirstName, f => f.Person.FirstName)
                .RuleFor(e => e.LastName, f => f.Person.LastName)
                .RuleFor(e => e.Email, f => f.Person.Email)
                .RuleFor(e => e.Salary, f => f.Finance.Amount(1000, 10000))
                .RuleFor(e => e.Address, f => addressGenerator.Generate());

            var employees = employeeGenerator.Generate(count);

            return employees;
        }
    }
}
