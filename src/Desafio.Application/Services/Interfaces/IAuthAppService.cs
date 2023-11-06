using Desafio.Application.Dtos;
using Desafio.Domain.Base;

namespace Desafio.Application
{
	public interface IAuthAppService
	{
        Task<ExecutionResult<AuthResponseDto>> Authenticate<TValidator>(UserDto obj);
    }
}

