using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
  [ApiController]
  [Route("/pedido")]
  public class PedidoController : ControllerBase
  {
    private readonly IPedidoRepository _pedido_repository;
    public PedidoController(IPedidoRepository pedidoRepository)
    {
      _pedido_repository = pedidoRepository;
    }
    
    [Authorize]
    [HttpPost]
    public ActionResult Add(int id_servico)
    {
      var cpf = User?.Identity?.Name;
      if(cpf == null){
        return BadRequest("Logue-se no sistema!");
      }

      // Status inicialmente irá se P (Pendente)
      var addPedido = new Pedido(id_servico, cpf, "P");
      _pedido_repository.Add(addPedido);
      return Ok();
    }

    [Authorize]
    [HttpPut]
    public ActionResult Alterar(int id_pedido, int id_servico)
    {
      _pedido_repository.Update(id_pedido, id_servico);
      return Ok();
    }

    [Authorize]
    [HttpGet]
    public IEnumerable<Pedido> Get()
    {
      return _pedido_repository.List();
    }

    [Authorize]
    [HttpDelete]
    public ActionResult CancelarPedido(int id_pedido)
    {
      _pedido_repository.CancelarPedido(id_pedido);
      return Ok();
    }
  }
}