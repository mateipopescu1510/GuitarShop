using GuitarShop.Models.Base;
using GuitarShop.Models.Enums;

namespace GuitarShop.Models
{
    public class Job : BaseEntity
    {
        public JobType JobType { get; set; }
        public int Salary { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
