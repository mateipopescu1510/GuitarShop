using GuitarShop.Data;
using GuitarShop.Models;
using GuitarShop.Models.Enums;
using GuitarShop.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Repositories.JobRepository
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        public JobRepository(GuitarShopContext context) : base(context) { }

        public async Task<Job?> GetJobByType(JobType jobType)
        {
            return await _context.Jobs.FirstOrDefaultAsync(job => job.JobType.Equals(jobType));
        }
    }
}
