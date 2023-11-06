using Desafio.Domain;
using Desafio.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infra.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected DesafioDbContext _repository { get; set; }

        public RepositoryBase(DesafioDbContext context)
        {
            this._repository = context;
        }

        public virtual async Task Create(T entity)
        {
            await this._repository.Set<T>().AddAsync(entity);
        }

        public virtual async Task Delete(T entity)
        {
            if (entity != null) await Task.FromResult(this._repository.Set<T>().Remove(entity));
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await this._repository.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
