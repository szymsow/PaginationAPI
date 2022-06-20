using WebAPI.Context;
using WebAPI.Generator;

namespace WebAPI
{
    public class Seeder
    {
        private readonly PaginationDbContext _dbContext;

        public Seeder(PaginationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Employees.Any())
                {
                    var employees = DataGenerator.GetEmployees(100);

                    await _dbContext.Employees.AddRangeAsync(employees);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
