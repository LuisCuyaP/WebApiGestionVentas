using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Data.Repo
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly DataContext dc;
        public ProveedorRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void AddProveedor(Proveedor proveedor)
        {
            dc.Proveedores.Add(proveedor);
        }

        public async Task<IEnumerable<Proveedor>> GetProveedoresAsync()
        {
            return await dc.Proveedores.ToListAsync();
        }
    }
}
