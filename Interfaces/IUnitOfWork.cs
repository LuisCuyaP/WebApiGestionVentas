namespace WebApi.Interfaces
{
    public interface IUnitOfWork
    {
        IProveedorRepository ProveedorRepository { get; }
        IUserRepository UserRepository { get; }
        Task<bool> SaveAsync();
    }
}
