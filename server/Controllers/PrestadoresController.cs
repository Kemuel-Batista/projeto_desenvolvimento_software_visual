using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
  [ApiController]
  [Route("/prestadores")]
  public class PrestadoresController : ControllerBase
  {
    private readonly IPrestadoresRepository _prestadoresRepository;
    public PrestadoresController(IPrestadoresRepository prestadoresRepository)
    {
      _prestadoresRepository = prestadoresRepository;
    }
    
    [HttpPost]
    [AllowAnonymous]
    public ActionResult Add(Prestadores prestador)
    {
      var addPrestador = new Prestadores(prestador.Nome, prestador.Cpf, prestador.Email, prestador.Telefone, prestador.Password, prestador.Biografia);
      _prestadoresRepository.Add(addPrestador);
      return Ok();
    }

    [Authorize]
    [HttpPut]
    public ActionResult Alterar(string nome, string email, string telefone, string biografia)
    {
      var cpf = User?.Identity?.Name;
      if(cpf != null){
        _prestadoresRepository.Update(cpf, nome, email, telefone, biografia);
        return Ok();
      }
      return BadRequest("Erro ao alterar");
    }

    [Authorize]
    [HttpPatch]
    public ActionResult ChangePassword(string password)
    {
      var cpf = User?.Identity?.Name;
      if(cpf != null){
        _prestadoresRepository.ChangePassword(cpf, password);
        return Ok();
      }
      return BadRequest("Erro ao alterar");
    }

    [Authorize]
    [HttpGet]
    public IEnumerable<Prestadores> Get()
    {
      return _prestadoresRepository.List();
    }

    [Authorize]
    [HttpDelete]
    public ActionResult DeleteAccount()
    {
      var cpf = User?.Identity?.Name;
      if(cpf != null){
        _prestadoresRepository.DeleteAccount(cpf);
        return Ok();
      }
      return BadRequest("CPF não existe!");
    }
  }
}