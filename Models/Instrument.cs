using GuitarShop.Models.Base;

namespace GuitarShop.Models
{
    public class Instrument : BaseEntity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }

        public Shop Shop { get; set; }
        public Guid ShopId { get; set; }
    }
}
