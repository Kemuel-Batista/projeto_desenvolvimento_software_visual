using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
  [ApiController]
  [Route("/avaliacao")]
  public class AvaliacaoController : ControllerBase
  {
    private readonly IAvaliacaoRepository _avaliacaoRepository;
    public AvaliacaoController(IAvaliacaoRepository avaliacaoRepository)
    {
      _avaliacaoRepository = avaliacaoRepository;
    }

    [Authorize]
    [HttpPost]
    public ActionResult Add(int id_pedido,  string avaliacao_cliente, string avaliacao_prestador)
    {
      var cpf = User?.Identity?.Name;
      string conta = _avaliacaoRepository.pesquisarCpf(cpf);

      if(cpf != null)
      {
          if(conta.Equals("Prestador"))
          {
            var addavaliacaoprestador = new avaliacao(id_pedido, cpf, avaliacao_prestador);
            _avaliacaoRepository.Add(addavaliacaoprestador);
            return Ok();
          }
          if(conta.Equals("Cliente"))
          {      
            avaliacao avaliacaoCliente = new avaliacao();
            avaliacaoCliente.id_pedido = id_pedido;
            avaliacaoCliente.cpf_cliente = cpf;
            avaliacaoCliente.avaliacao_cliente = avaliacao_cliente;
            _avaliacaoRepository.Add(avaliacaoCliente);
            return Ok();
          }
      }  
        return BadRequest("CPF não existe!");

    }

    [HttpPut]
    public ActionResult Alterar(int id, string avaliacao)
    {
      var cpf = User?.Identity?.Name;
      string conta = _avaliacaoRepository.pesquisarCpf(cpf);

      if(id != 0)
      {  
        _avaliacaoRepository.Update(conta, id,avaliacao);
        return Ok();
      }
      return BadRequest("id não existe!");
    }

    [HttpGet]
    public IEnumerable<avaliacao> Get()
    {
      return _avaliacaoRepository.List();
    }

    [HttpDelete]
    public ActionResult DeleteAccount(int id)
    {
      if(id != 0){
        _avaliacaoRepository.DeleteAccount(id);
        return Ok();
      }
      return BadRequest("id não existe!");
    }
  }
}