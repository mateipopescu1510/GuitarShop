using GuitarShop.Data;
using GuitarShop.Repositories.EmployeeRepository;
using GuitarShop.Repositories.InstrumentRepository;
using GuitarShop.Repositories.JobRepository;
using GuitarShop.Repositories.ShopRepository;
using GuitarShop.Repositories.UserRepository;


namespace GuitarShop.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private GuitarShopContext context;
        public UnitOfWork(GuitarShopContext context) { 
            this.context = context;
            Employees = new EmployeeRepository.EmployeeRepository(context);
            Instruments = new InstrumentRepository.InstrumentRepository(context);
            Jobs = new JobRepository.JobRepository(context);
            Users = new UserRepository.UserRepository(context);
            Shops = new ShopRepository.ShopRepository(context);
        }

        public IEmployeeRepository Employees {  get; private set; }
        public IInstrumentRepository Instruments { get; private set; }
        public IJobRepository Jobs { get; private set; }
        public IUserRepository Users { get; private set; }
        public IShopRepository Shops { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }
        public int Save()
        {
            return context.SaveChanges();
        }

    }
}
