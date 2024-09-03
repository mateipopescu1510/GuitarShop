using GuitarShop.Models.Base;
using GuitarShop.Models.DTOs;
using GuitarShop.Models.Enums;

namespace GuitarShop.Models
{
    public class Instrument : BaseEntity
    {
        public Instrument() { }
        public Instrument(InstrumentDTO instrument)
        {
            Type = instrument.Type;
            Brand = instrument.Brand;
            Price = instrument.Price;
            ShopId = instrument.ShopId;
        }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }

        public Shop Shop { get; set; }
        public Guid ShopId { get; set; }

        public ICollection<Responsibility> Responsibilities { get; set; }
    }
}
