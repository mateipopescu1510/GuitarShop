using GuitarShop.Models;
using GuitarShop.Models.Enums;
using GuitarShop.Repositories.GenericRepository;

namespace GuitarShop.Repositories.JobRepository
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        Task<Job?> GetJobByType(JobType jobType);
    }
}
