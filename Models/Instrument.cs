using GuitarShop.Models.Base;
using GuitarShop.Models.Enums;

namespace GuitarShop.Models
{
    public class Instrument : BaseEntity
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }

        public Shop Shop { get; set; }
        public Guid ShopId { get; set; }

        public ICollection<Responsibility> Responsibilities { get; set; }
    }
}
