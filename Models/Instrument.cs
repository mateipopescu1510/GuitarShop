using GuitarShop.Models.Base;
using GuitarShop.Models.Enums;

namespace GuitarShop.Models
{
    public class Instrument : BaseEntity
    {
        public InstrumentType Type { get; set; }
        public InstrumentBrand Brand { get; set; }
        public int Price { get; set; }

        public Shop Shop { get; set; }
        public Guid ShopId { get; set; }
    }
}
