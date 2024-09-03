using GuitarShop.Data;
using GuitarShop.Models;

namespace GuitarShop.Helpers.Seeders
{
    public class EmployeeSeeder
    {
        private readonly GuitarShopContext _context;
        public EmployeeSeeder(GuitarShopContext context)
        {
            _context = context;
        }

        public void SeedInitialEmployees()
        {
            if (!_context.Employees.Any())
            {
                var job1 = _context.Jobs.FirstOrDefault(j => j.JobType == Models.Enums.JobType.REPAIR);
                var job2 = _context.Jobs.FirstOrDefault(j => j.JobType == Models.Enums.JobType.INSTRUCTOR);

                if (job1 != null && job2 != null)
                {
                    var emp1 = new Employee
                    {
                        FirstName = "Matei",
                        LastName = "Popescu",
                        Age = 21,
                        Email = "popescumatei@guitarshop.com",
                        JobId = job2.Id
                    };

                    var emp2 = new Employee
                    {
                        FirstName = "Mircea",
                        LastName = "Bogdan",
                        Age = 20,
                        Email = "mirceabogdan@guitarshop.com",
                        JobId = job1.Id
                    };

                    _context.AddRange(emp1, emp2);
                    _context.SaveChanges();
                }
            }
        }

    }
}
