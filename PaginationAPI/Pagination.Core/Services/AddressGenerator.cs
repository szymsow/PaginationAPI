using Bogus;
using WebAPI.Entities;

namespace Pagination.Core.Services
{
    public class AddressGenerator : IDataGenerator<Address>
    {
        public IEnumerable<Address> Generate(int count)
        {
            var addressGenerator = new Faker<Address>()
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Country, f => f.Address.Country())
                .RuleFor(a => a.PostalCode, f => f.Address.ZipCode())
                .RuleFor(a => a.Street, f => f.Address.StreetName());

            var addresses = addressGenerator.Generate(count);

            return addresses;
        }

    }
}
