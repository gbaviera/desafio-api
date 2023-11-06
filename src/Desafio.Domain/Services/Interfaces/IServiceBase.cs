using Desafio.Domain.Base;

namespace Desafio.Domain.Services.Interfaces
{
    public interface IServiceBase<T>
    {
        Task<ExecutionResult<T>> Create<TValidator>(T obj);

        Task Delete(T entity);

        Task<T> GetById(Guid id);

        Task<ExecutionResult<T>> Update<TValidator>(T obj);
    }
}

