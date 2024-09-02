using GuitarShop.Models.Base;
using GuitarShop.Models.DTOs;
using GuitarShop.Models.Enums;

namespace GuitarShop.Models
{
    public class Job : BaseEntity
    {
        public Job() { }
        public Job(JobDTO job)
        {
            JobType = job.JobType;
            Salary = job.Salary;
        }
        public JobType JobType { get; set; }
        public int Salary { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
