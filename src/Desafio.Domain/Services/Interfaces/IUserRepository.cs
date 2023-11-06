using System;
namespace Desafio.Domain.Services.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User ObterPorEmail(string email);
    }
}

