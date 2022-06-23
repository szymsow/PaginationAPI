﻿namespace WebAPI.Models
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }

        public AddressDto Address { get; set; }
    }
}
