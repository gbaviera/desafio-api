using System;
using AutoMapper;
using Desafio.Domain;

namespace Desafio.Application.AutoMapper
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
            CreateMap<User, UserDto>();
        }
    }
}

