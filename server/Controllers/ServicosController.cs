using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Views;

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
    public ActionResult Add([FromBody] CreateServiceView service)
    {
      var cpfPrestador = User?.Identity?.Name;
      if(cpfPrestador != null)
      {
        var addServicos = new Servicos(service.nome, service.valor, service.id_categoria, cpfPrestador);
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

    [HttpGet("/servicos/myservices")]
    public ActionResult<IEnumerable<Servicos>> GetMyServices()
    {
      var cpfPrestador = User?.Identity?.Name;
      if (cpfPrestador != null)
      {
        var services = _servicosRepository.GetMyServices(cpfPrestador);
        return Ok(services);
      }
      return BadRequest("Não foi possível obter os serviços!");
    }

    [HttpDelete]
    public ActionResult delete(int id)
    {
      if(id != 0){
        _servicosRepository.delete(id);
        return Ok();
      }
      return BadRequest("nome não existe!");
    }
  }
}