using GuitarShop.Data;
using GuitarShop.Models;
using GuitarShop.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Repositories.ShopRepository
{
    public class ShopRepository : GenericRepository<Shop>, IShopRepository
    {
        public ShopRepository(GuitarShopContext context) : base(context) { }

        public async Task<Shop?> GetShopByAddress(string address)
        {
            return await _context.Shops.Where(shop => shop.Address == address).FirstOrDefaultAsync();
        }
    }
}
