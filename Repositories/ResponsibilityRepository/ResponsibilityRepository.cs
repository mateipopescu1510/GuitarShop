using GuitarShop.Data;
using GuitarShop.Models;
using GuitarShop.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Repositories.ResponsibilityRepository
{
    public class ResponsibilityRepository : GenericRepository<Responsibility>, IResponsibilityRepository
    {
        public ResponsibilityRepository(GuitarShopContext context) : base(context) { }
    }
}
