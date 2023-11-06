using Desafio.Domain;
using Microsoft.EntityFrameworkCore;


namespace Desafio
{
    public class DesafioDbContext : DbContext
    {
        public DesafioDbContext(DbContextOptions<DesafioDbContext> options) : base(options)
        {
        }

        // Adicione as DbSet correspondentes às suas entidades
        public DbSet<User> Users { get; set; }
    }
}
