using Microsoft.AspNetCore.Mvc;
using server.Services;

namespace server.Controllers
{
  [ApiController]
  [Route("/auth")]
  public class AuthController : Controller
  {
    private readonly ConnectionContext _context;

    public AuthController(ConnectionContext context)
    {
      _context = context;
    }

    [Route("/cliente")]
    [HttpPost]
    public IActionResult AuthCliente(string email, string password)
    {
      var client = _context.Cliente.FirstOrDefault(client => client.Email == email && client.Password == password);

      if (client != null)
      {
        var token = TokenService.GenerateClientToken(client);
        return Ok(token);
      }
      return BadRequest("Email ou senha incorretos");
    }

    [Route("/prestador")]
    [HttpPost]
    public IActionResult AuthPrestador(string email, string password)
    {
      var prestador = _context.Prestador.FirstOrDefault(prestador => prestador.Email == email && prestador.Password == password);

      if (prestador != null)
      {
        var token = TokenService.GenerateClientToken(prestador);
        return Ok(token);
      } 
      return BadRequest("Email ou senha incorretos");
    }
  }
}