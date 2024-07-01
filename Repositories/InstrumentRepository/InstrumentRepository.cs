using GuitarShop.Data;
using GuitarShop.Models;
using GuitarShop.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;

namespace GuitarShop.Repositories.InstrumentRepository
{
    public class InstrumentRepository : GenericRepository<Instrument>, IInstrumentRepository
    {
        public InstrumentRepository(GuitarShopContext context) : base(context) { }

        public async Task<List<Instrument>> GetByTypeAndBrand(string type, string brand)
        {
            return await _context.Instruments.
                Where(instr => instr.Type.ToUpper().Equals(type.ToUpper()) 
                && instr.Brand.ToUpper().Equals(brand.ToUpper()))
                .ToListAsync();
        }
    }
}
