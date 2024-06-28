using GuitarShop.Models.Base;

namespace GuitarShop.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }

    }
}
