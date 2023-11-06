using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Desafio.Infra.Data
{
    public class DesafioDbContextFactory : IDesignTimeDbContextFactory<DesafioDbContext>
    {
        public DesafioDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Desafio.Api"))
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<DesafioDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new DesafioDbContext(optionsBuilder.Options);
        }
    }
}
