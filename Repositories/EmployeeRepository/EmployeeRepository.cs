using GuitarShop.Data;
using GuitarShop.Models;
using GuitarShop.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Repositories.EmployeeRepository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(GuitarShopContext context) : base(context) { }

        public async Task<Employee?> GetEmployeeByName(string firstName,  string lastName)
        {
            if (firstName == null || lastName == null)
                return null;

            return await _context.Employees.Where(emp => emp.FirstName.ToUpper().Equals(firstName.ToUpper())
                && emp.LastName.ToUpper().Equals(lastName.ToUpper())).FirstOrDefaultAsync();
        }
    }
}
