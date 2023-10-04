using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using server.Models;

namespace server.Services
{
  public class TokenService
  {
    public static object GenerateClientToken(User user)
    {
      var key = Encoding.ASCII.GetBytes(Key.Secret);
      // Configuração do Token (Informações do payload e etc)
      var tokenConfig = new SecurityTokenDescriptor
      {
        // Configurando o Payload passando o id do cliente
        Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, user.Cpf.ToString())
        }),
        // Passando tempo de expiração para o token
        Expires = DateTime.UtcNow.AddHours(3),
        // Definindo que tipo de criptografia irá ser usada no Token
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };

      // Gerando o token
      var tokenHandler = new JwtSecurityTokenHandler();
      // Criando o token com as configurações que foi passada
      var token = tokenHandler.CreateToken(tokenConfig);
      var tokenString = tokenHandler.WriteToken(token);

      return new
      {
        token = tokenString
      };
    }
  }
}