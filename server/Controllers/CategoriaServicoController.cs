using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
  [ApiController]
  [Route("/categoria")]
  public class CategoriaServicoController : ControllerBase
  {
    private readonly ICategoriaServicoRepository _categoriaRepository;
    public CategoriaServicoController(ICategoriaServicoRepository categoriaRepository)
    {
      _categoriaRepository = categoriaRepository;
    }
    
    [HttpPost]
    public ActionResult Add(CategoriaServico categoriaServico)
    {
      var addCategoria = new CategoriaServico(categoriaServico.Id,categoriaServico.Descricao);
      _categoriaRepository.Add(addCategoria);
      return Ok();
    }

    [HttpPut]
    public ActionResult Alterar(int id, string descricao)
    {
      if(id != 0){
        _categoriaRepository.Update(id, descricao);
        return Ok();
      }
      return BadRequest("Erro ao alterar");
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
      if(id != 0){
        _categoriaRepository.Delete(id);
        return Ok();
      }
      return BadRequest("Erro ao excluir");
    }

    [HttpGet]
    public IEnumerable<CategoriaServico> Get()
    {
      return _categoriaRepository.List();
    }
  }
}