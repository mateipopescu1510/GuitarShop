using GuitarShop.Models;
using GuitarShop.Models.Enums;
using GuitarShop.Repositories.GenericRepository;

namespace GuitarShop.Repositories.InstrumentRepository
{
    public interface IInstrumentRepository : IGenericRepository<Instrument>
    {
        Task<List<Instrument>> GetByTypeAndBrand(string type, string brand);        
    }
}
