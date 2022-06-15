using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Context
{
    public class PaginationDbContext : DbContext
    {
        public PaginationDbContext(DbContextOptions<PaginationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Employee
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Address)
                .WithOne(a => a.Employee)
                .HasForeignKey<Address>(a => a.EmployeeId);
            #endregion
            #region Address

            modelBuilder.Entity<Address>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Address>()
                .Property(a => a.Country)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(a => a.PostalCode)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();
            #endregion
        }
    }
}
