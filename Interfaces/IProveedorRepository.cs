using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<Proveedor>> GetProveedoresAsync();
        Task<Proveedor> GetProveedorDetailAsync(int id);
        Task<Proveedor> GetProveedorByIdAsync(int id);       
        void AddProveedor(Proveedor proveedor);
        void DeleteProveedor(Proveedor proveedor);
    }
}
