using GuitarShop.Data;
using GuitarShop.Models;
using GuitarShop.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Repositories.ResponsibilityRepository
{
    public class ResponsibilityRepository : GenericRepository<Responsibility>, IResponsibilityRepository
    {
        public ResponsibilityRepository(GuitarShopContext context) : base(context) { }

        public async Task<Responsibility> GetByIds(Guid employeeId, Guid instrumentId)
        {
            return await _context.Responsibilities
                .FirstOrDefaultAsync(r => r.EmployeeId == employeeId && r.InstrumentId == instrumentId);
        }
    }
}
