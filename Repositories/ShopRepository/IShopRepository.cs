using GuitarShop.Models;
using GuitarShop.Repositories.GenericRepository;

namespace GuitarShop.Repositories.ShopRepository
{
    public interface IShopRepository : IGenericRepository<Shop>
    {
        Task<Shop?> GetShopByAddress(string address);
    }
}
