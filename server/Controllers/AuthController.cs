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

    [HttpPost]
    public IActionResult Auth(string email, string password)
    {
      var client = _context.Cliente.FirstOrDefault(client => client.Email == email && client.Password == password);

      if (client != null)
      {
        var token = TokenService.GenerateClientToken(client);
        return Ok(token);
      }
      if(client == null)
      {
        var prestador = _context.Prestador.FirstOrDefault(prestador => prestador.Email == email && prestador.Password == password);
        var token = TokenService.GenerateClientToken(prestador);
        return Ok(token);
      }

      return BadRequest("Email ou senha incorretos");
    }
  }
}