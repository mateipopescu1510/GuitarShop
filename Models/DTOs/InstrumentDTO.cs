namespace GuitarShop.Models.DTOs
{
    public class InstrumentDTO
    {
        public InstrumentDTO() { }
        public InstrumentDTO(Instrument instrument) {
            Type = instrument.Type;
            Brand = instrument.Brand;
            Price = instrument.Price;
            ShopId = instrument.ShopId;
            Id = instrument.Id;
        }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public Guid ShopId { get; set; }
        public Guid Id { get; set; }
    }
}
