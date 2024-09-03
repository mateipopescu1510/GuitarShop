using GuitarShop.Data;
using GuitarShop.Models;

namespace GuitarShop.Helpers.Seeders
{
    public class ShopSeeder
    {
        public readonly GuitarShopContext _context;
        public ShopSeeder(GuitarShopContext context) {
            _context = context;
        }

        public void SeedInitialShops()
        {
            if (!_context.Shops.Any())
            {
                var shop1 = new Shop
                {
                    Address = "Calea Victoriei 150",
                    Email = "guitarshop150@gmail.com"
                };

                var shop2 = new Shop
                {
                    Address = "Piata Romana 23",
                    Email = "guitarshop23@gmail.com"
                };

                _context.Add(shop1);
                _context.Add(shop2);

                _context.SaveChanges();
            }
        }
    }
}
