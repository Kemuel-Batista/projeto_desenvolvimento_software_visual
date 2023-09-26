using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using server.Models;

namespace server.Controllers
{
  [Authorize]
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
    public ActionResult Add(Cliente cliente)
    {
      var addCliente = new Cliente(cliente.Nome, cliente.CPF, cliente.Email, cliente.Telefone, cliente.Password);
      _clienteRepository.Add(addCliente);
      return Ok();
    }

    /*

    [HttpPatch()]
    [Route("MudarDescricao/{placa}")]
    public async Task<ActionResult> MudarDescricao(string placa, [FromForm] string descricao)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Carro is null) return NotFound();
        var carroTemp = await _dbContext.Carro.FindAsync(placa);
        if(carroTemp is null) return NotFound();
        carroTemp.Descricao = descricao;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    
    */
    [HttpPut]
    public ActionResult Alterar(Cliente cliente)
    {
      var updatedCliente = new Cliente(cliente.Nome, cliente.CPF, cliente.Email, cliente.Telefone, cliente.Password);
      _clienteRepository.Update(updatedCliente);
      return Ok();
    }
    
    [HttpGet]
    public IActionResult Get()
    {
      var clientes = _clienteRepository.Get();
      return Ok(clientes);
    }
  }
}