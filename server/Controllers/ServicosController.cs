using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
  [ApiController]
  [Route("/servicos")]
  public class ServicosController : ControllerBase
  {
    private readonly IServicosRepository _servicosRepository;
    public ServicosController(IServicosRepository servicosRepository)
    {
      _servicosRepository = servicosRepository;
    }
    
    [HttpPost]
    public ActionResult Add(string nome, double valor, int idCategoria)
    {
      var cpfPrestador = User?.Identity?.Name;
      if(cpfPrestador != null)
      {
        var addServicos = new Servicos(nome,valor,idCategoria,cpfPrestador);
        _servicosRepository.Add(addServicos);
        return Ok();
      }
      return BadRequest("Cpf não existe!");
    }

    [HttpPut]
    public ActionResult Alterar(int id, string nome, double valor, int idCategoria)
    {
      var cpfPrestador = User?.Identity?.Name;
      if(cpfPrestador != null)
      {
        if(id != 0)
        {
          _servicosRepository.Update(id, nome, valor, idCategoria, cpfPrestador);
          return Ok();
        } else {
          return BadRequest("ID não pode ser nulo!");
        }
      }
      return BadRequest("Não foi possível alterar o serviço!");
    }

    [HttpGet]
    public IEnumerable<Servicos> Get()
    {
      return _servicosRepository.List();
    }

    [HttpDelete]
    public ActionResult DeleteAccount(int id)
    {
      if(id != 0){
        _servicosRepository.DeleteAccount(id);
        return Ok();
      }
      return BadRequest("nome não existe!");
    }
  }
}