using GuitarShop.Data;
using GuitarShop.Models;
using GuitarShop.Models.Enums;

namespace GuitarShop.Helpers.Seeders
{
    public class InstrumentSeeder
    {
        private readonly GuitarShopContext _context;

        public InstrumentSeeder (GuitarShopContext context)
        {
            _context = context;
        }

        public void SeedInitialInstruments()
        {
            if (!_context.Instruments.Any())
            {
                var shop1 = _context.Shops.FirstOrDefault(s => s.Address == "Calea Victoriei 150");
                var shop2 = _context.Shops.FirstOrDefault(s => s.Address == "Piata Romana 23");

                if (shop1 != null && shop2 != null)
                {
                    var instrument1 = new Instrument
                    {
                        Type = InstrumentType.ELECTRIC_GUITAR,
                        Brand = InstrumentBrand.IBANEZ,
                        Price = 3600,
                        ShopId = shop1.Id
                    };

                    var instrument2 = new Instrument
                    {
                        Type = InstrumentType.ELECTRIC_BASS,
                        Brand = InstrumentBrand.FENDER,
                        Price = 5100,
                        ShopId = shop2.Id
                    };

                    var instrument3 = new Instrument
                    {
                        Type = InstrumentType.KEYBOARD,
                        Brand = InstrumentBrand.YAMAHA,
                        Price = 2700,
                        ShopId = shop1.Id
                    };

                    var instrument4 = new Instrument
                    {
                        Type = InstrumentType.ACOUSTIC_GUITAR,
                        Brand = InstrumentBrand.EPIPHONE,
                        Price = 3100,
                        ShopId = shop1.Id
                    };

                    _context.AddRange(instrument1, instrument2, instrument3, instrument4);
                    _context.SaveChanges();
                }


            }
        }
    }
}
