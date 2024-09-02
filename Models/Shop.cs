using GuitarShop.Models.Base;
using GuitarShop.Models.DTOs;

namespace GuitarShop.Models
{
    public class Shop : BaseEntity
    {
        public Shop() { }
        public Shop(ShopDTO shop) { 
            Address = shop.Address;
            Email = shop.Email;
        }
        public string Address { get; set; }
        public string Email { get; set; }
        public ICollection<Instrument> Instruments { get; set; }
    }
}
