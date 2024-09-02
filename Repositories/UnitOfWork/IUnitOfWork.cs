using GuitarShop.Repositories.EmployeeRepository;
using GuitarShop.Repositories.InstrumentRepository;
using GuitarShop.Repositories.JobRepository;
using GuitarShop.Repositories.ShopRepository;
using GuitarShop.Repositories.UserRepository;

namespace GuitarShop.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IInstrumentRepository Instruments { get; }
        IJobRepository Jobs { get; }
        IUserRepository Users { get; }
        IShopRepository Shops { get; }
        int Save();

    }
}
