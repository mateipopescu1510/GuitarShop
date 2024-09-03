namespace GuitarShop.Models.DTOs
{
    public class EmployeeDTO
    {
        public EmployeeDTO() { }
        public EmployeeDTO(Employee employee) {
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Age = employee.Age;
            Email = employee.Email;
            JobId = employee.JobId;
            Id = employee.Id;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public Guid JobId { get; set; }
        public Guid Id { get; set; }
    }
}
