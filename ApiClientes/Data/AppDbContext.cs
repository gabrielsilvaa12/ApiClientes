using ApiClientes.Models; // Não se esqueça de adicionar esta linha!
using Microsoft.EntityFrameworkCore;

namespace ApiClientes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<Cliente> Clientes { get; set; }
    }
}