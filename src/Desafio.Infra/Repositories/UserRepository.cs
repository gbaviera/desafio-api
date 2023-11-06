using Desafio.Infra.Repositories;

namespace Desafio.Domain.Services.Interfaces
{
    public class UserRepository : RepositoryBase<User>,IUserRepository
    {
        private readonly DesafioDbContext _dbContext;

        public UserRepository(DesafioDbContext dbContext) : base (dbContext)
        {
            _dbContext = dbContext;
        }

        public User ObterPorEmail(string email)
        {
            return _dbContext.Set<User>().FirstOrDefault(u => u.Email == email);
        }
    }
}
        