
namespace Desafio.Domain.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authenticate(User model);
    }
}

