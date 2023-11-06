using System;
using AutoMapper;
using Desafio.Application.Dtos;
using Desafio.Domain.Base;
using Desafio.Domain.Services.Interfaces;
using Desafio.Infra;

namespace Desafio.Application
{
	public class AuthAppService : IAuthAppService
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly DesafioDbContext _context;

        public AuthAppService(IAuthService service, IMapper mapper, DesafioDbContext context)
		{
            _authService = service;
            _mapper = mapper;
            _context = context;
		}

        public Task<ExecutionResult<AuthResponseDto>> Authenticate<TValidator>(UserDto obj)
        {
            throw new NotImplementedException();
        }
    }
}

