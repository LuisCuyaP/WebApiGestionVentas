namespace WebApi.Interfaces
{
    public interface IUnitOfWork
    {
        IProveedorRepository ProveedorRepository { get; }
        Task<bool> SaveAsync();
    }
}
