using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
  [ApiController]
  [Route("/clientes")]
  public class ClienteController : ControllerBase
  {
    private readonly IClienteRepository _clienteRepository;
    public ClienteController(IClienteRepository clienteRepository)
    {
      _clienteRepository = clienteRepository;
    }
    
    [HttpPost]
    [AllowAnonymous]
    public ActionResult Add(Cliente cliente)
    {
      var addCliente = new Cliente(cliente.Nome, cliente.Cpf, cliente.Email, cliente.Telefone, cliente.Password, cliente.Cep, cliente.Endereco);
      _clienteRepository.Add(addCliente);
      return Ok();
    }

    [Authorize]
    [HttpPut]
    public ActionResult Alterar(string nome, string email, string telefone)
    {
      var cpf = User?.Identity?.Name;
      if(cpf != null){
        _clienteRepository.Update(cpf, nome, email, telefone);
        return Ok();
      }
      return BadRequest("CPF não existe!");
    }

    [Authorize]
    [HttpPatch]
    public ActionResult ChangePassword(string password)
    {
      var cpf = User?.Identity?.Name;
      if(cpf != null){
        _clienteRepository.ChangePassword(cpf, password);
        return Ok();
      }
      return BadRequest("CPF não existe!");
    }

    [Authorize]
    [HttpGet]
    public IEnumerable<Cliente> Get()
    {
      return _clienteRepository.List();
    }

    [Authorize]
    [HttpDelete]
    public ActionResult DeleteAccount()
    {
      var cpf = User?.Identity?.Name;
      if(cpf != null){
        _clienteRepository.DeleteAccount(cpf);
        return Ok();
      }
      return BadRequest("CPF não existe!");
    }
  }
}