using System.Security.Claims;
using System.Text;
using Desafio.Domain.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Desafio.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }

        public async Task<string> Authenticate(User model)
        {
            // Lógica de autenticação
            // Verifique o email e senha no seu sistema de autenticação
            // Gere e retorne o token JWT se a autenticação for bem-sucedida
            User user = _userRepository.ObterPorEmail(model.Email);

            if (user == null || !VerificarSenha(user.Password, model.Password)){
                return null;
            }

            string token = GerarTokenJwt(user);
            return await Task.FromResult(token);
        }

        private string GerarTokenJwt(User usuario)
        {
            // Lógica para gerar o token JWT usando uma biblioteca como o System.IdentityModel.Tokens.Jwt

            // Exemplo básico usando System.IdentityModel.Tokens.Jwt
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("sua-chave-secreta");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, usuario.Email)
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private bool VerificarSenha(string senhaUsuario, string senhaPassada)
        {
            return senhaPassada == senhaUsuario;
        }
    }
}
