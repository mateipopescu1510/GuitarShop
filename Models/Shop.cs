using GuitarShop.Models.Base;

namespace GuitarShop.Models
{
    public class Shop : BaseEntity
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public ICollection<Instrument> Instruments { get; set; }
    }
}
