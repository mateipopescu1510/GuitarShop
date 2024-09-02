using GuitarShop.Models.Enums;

namespace GuitarShop.Models.DTOs
{
    public class JobDTO
    {
        public JobDTO() { }
        public JobDTO(Job job)
        {
            JobType = job.JobType;
            Salary = job.Salary;
        }
        public JobType JobType { get; set; }
        public int Salary { get; set; }
    }
}
