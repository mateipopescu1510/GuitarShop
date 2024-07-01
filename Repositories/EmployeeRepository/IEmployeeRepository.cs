using GuitarShop.Models;
using GuitarShop.Repositories.GenericRepository;

namespace GuitarShop.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee?> GetEmployeeByName(string firstName, string lastName);
    }
}
