using Entities;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication
{
    public interface IUserService
    {
        string Authenticate(UsuarioAcceso usuarioAcceso);
    }
    public class UserService : IUserService
    {

        public string Authenticate(UsuarioAcceso usuarioAcceso)
        {
            UsuarioAccesoRepository usuarioAccesoRepository = new UsuarioAccesoRepository();
            UsuarioAcceso? response = usuarioAccesoRepository.ValidateUser(usuarioAcceso);
            if(response != null)
            {
                return GenerateJWToken(response);
            }
            return string.Empty;
        }
        private string GenerateJWToken(UsuarioAcceso usuarioAcceso)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("Z1#sVr08#48cZ1#sVr08#48cZ1#sVr08#48c");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", usuarioAcceso.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    
    }
}
