using GuitarShop.Models;
using GuitarShop.Repositories.GenericRepository;

namespace GuitarShop.Repositories.ResponsibilityRepository
{
    public interface IResponsibilityRepository : IGenericRepository<Responsibility>
    {
        Task<Responsibility> GetByIds(Guid employeeId, Guid instrumentId);
    }
}
