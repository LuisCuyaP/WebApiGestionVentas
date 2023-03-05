using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "GestionVentas");
        }

        public DbSet<Proveedor> Proveedores { get; set; }
    }
}
