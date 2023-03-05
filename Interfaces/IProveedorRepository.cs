using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<Proveedor>> GetProveedoresAsync();
        void AddProveedor(Proveedor proveedor);
    }
}
