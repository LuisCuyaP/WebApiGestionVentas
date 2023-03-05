using WebApi.Data.Repo;
using WebApi.Interfaces;

namespace WebApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;
        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }
        public IProveedorRepository ProveedorRepository =>
            new ProveedorRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
