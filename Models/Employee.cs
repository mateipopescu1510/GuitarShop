using GuitarShop.Models.Base;
using GuitarShop.Models.DTOs;

namespace GuitarShop.Models
{
    public class Employee : BaseEntity
    {
        public Employee() { }
        public Employee(EmployeeDTO employee)
        {
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Age = employee.Age;
            Email = employee.Email;
            JobId = employee.JobId;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public Job Job { get; set; }
        public Guid JobId { get; set; }

        public User User { get; set; }

        public ICollection<Responsibility> Responsibilities { get; set; }
    }
}
