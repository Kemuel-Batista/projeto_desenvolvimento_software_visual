using Microsoft.AspNetCore.Authorization;
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
    public ActionResult Add(string nome, double valor, int idCategoria, string cpfPrestador)
    {
      var addServicos = new Servicos(nome,valor,idCategoria,cpfPrestador);
      _servicosRepository.Add(addServicos);
      return Ok();
    }

    [HttpPut]
    public ActionResult Alterar(int id, string nome, double valor, int idCategoria, string cpfPrestador)
    {
      if(id != 0){
        _servicosRepository.Update(id, nome, valor, idCategoria, cpfPrestador);
        return Ok();
      }
      return BadRequest("nome não existe!");
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