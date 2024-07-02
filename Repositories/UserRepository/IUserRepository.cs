using GuitarShop.Models;
using GuitarShop.Repositories.GenericRepository;

namespace GuitarShop.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetUserByEmail(string email);
    }
}
