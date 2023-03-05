using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<Proveedor>> GetProveedoresAsync();
        Task<Proveedor> GetProveedorDetailAsync(int id);
        void AddProveedor(Proveedor proveedor);
    }
}
