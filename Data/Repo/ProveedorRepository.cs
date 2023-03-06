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

        public async Task<Proveedor> GetProveedorDetailAsync(int id)
        {
            var proveedorDetail = await dc.Proveedores.FindAsync(id);
            return proveedorDetail;
        }

        public async Task<IEnumerable<Proveedor>> GetProveedoresAsync()
        {
            return await dc.Proveedores.ToListAsync();
        }
  
        public async Task<Proveedor> GetProveedorByIdAsync(int id)
        {
            var proveedor = await dc.Proveedores.FindAsync(id);
            return proveedor;
        }

        public void DeleteProveedor(Proveedor proveedor)
        {
            dc.Proveedores.Remove(proveedor);
        }

    }
}
