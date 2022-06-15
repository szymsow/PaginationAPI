namespace WebAPI.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}
