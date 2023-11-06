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
    private readonly ILogger<AvaliacaoController> _logger;
    public AvaliacaoController(IAvaliacaoRepository avaliacaoRepository, ILogger<AvaliacaoController> logger)
    {
      _avaliacaoRepository = avaliacaoRepository;
      _logger = logger;
    }

    [Authorize]
    [HttpPost]
    public ActionResult Add(int id_pedido, string avaliacao)
    {
      var cpf = User?.Identity?.Name;

      if (cpf != null)
      {
        _avaliacaoRepository.Add(id_pedido, avaliacao, cpf);
        return Ok();
      }
      return BadRequest("CPF não existe!");

    }

    [Authorize]
    [HttpPut]
    public ActionResult Alterar(int id, string avaliacao)
    {
      var cpf = User?.Identity?.Name;

      if(cpf != null){
        string conta = _avaliacaoRepository.pesquisarCpf(cpf);

        if (id != 0)
        {
          _avaliacaoRepository.Update(conta, id, avaliacao);
          return Ok();
        }
      }
      return BadRequest("id não existe!");
    }

    [Authorize]
    [HttpGet]
    public IEnumerable<Avaliacao> Get()
    {
      return _avaliacaoRepository.List();
    }

    [Authorize]
    [HttpDelete]
    public ActionResult DeleteAvaliacao(int id)
    {
      if (id != 0)
      {
        _avaliacaoRepository.DeleteAvaliacao(id);
        return Ok();
      }
      return BadRequest("id não existe!");
    }
  }
}