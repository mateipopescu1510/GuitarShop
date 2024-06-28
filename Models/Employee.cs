using GuitarShop.Models.Base;

namespace GuitarShop.Models
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public Job Job { get; set; }
        public Guid JobId { get; set; }
    }
}
