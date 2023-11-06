using Desafio.Domain.Services.Interfaces;
using Desafio.Domain.Services;
using Desafio.Application;
using Desafio.Infra.Repositories;
using FluentValidation;
using Desafio.Domain;

namespace Desafio.api.Configuration
{
    public static class DependencySetup
    {
        public static IServiceCollection InjectDependencies(this IServiceCollection services, IConfiguration config)
        {

            //Dependency Injection
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddScoped<IAuthAppService, AuthAppService>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IValidator<User>, UserValidator>();

            return services;
        }
    }
}

