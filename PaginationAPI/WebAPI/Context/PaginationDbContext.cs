using Microsoft.EntityFrameworkCore;

namespace WebAPI.Context
{
    public class PaginationDbContext : DbContext
    {
        public PaginationDbContext(DbContextOptions<PaginationDbContext> options) : base(options)
        {

        }
    }
}
