using Microsoft.AspNetCore.Mvc;
using server.Views;
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

    [Route("/auth/cliente")]
    [HttpPost]
    public IActionResult AuthCliente([FromBody] LoginView login)
    {
      var client = _context.Cliente.FirstOrDefault(client => client.Email == login.email && client.Password == login.password);

      if (client != null)
      {
        var token = TokenService.GenerateClientToken(client);
        return Ok(token);
      }
      return BadRequest("Email ou senha incorretos");
    }

    [Route("/auth/prestador")]
    [HttpPost]
    public IActionResult AuthPrestador([FromBody] LoginView login)
    {
      var prestador = _context.Prestador.FirstOrDefault(prestador => prestador.Email == login.email && prestador.Password == login.password);

      if (prestador != null)
      {
        var token = TokenService.GenerateClientToken(prestador);
        return Ok(token);
      } 
      return BadRequest("Email ou senha incorretos");
    }
  }
}