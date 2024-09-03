using GuitarShop.Data;
using GuitarShop.Models;

namespace GuitarShop.Helpers.Seeders
{
    public class JobSeeder
    {
        public readonly GuitarShopContext _context;
        public JobSeeder(GuitarShopContext context)
        {
            _context = context;
        }

        public void SeedInitialJobs()
        {
            if (!_context.Jobs.Any())
            {
                var job1 = new Job
                {
                    JobType = Models.Enums.JobType.REPAIR,
                    Salary = 5000
                };

                var job2 = new Job
                {
                    JobType= Models.Enums.JobType.INSTRUCTOR,
                    Salary = 7500
                };

                _context.Add(job1);
                _context.Add(job2);

                _context.SaveChanges();
            }

        }
    }
}
