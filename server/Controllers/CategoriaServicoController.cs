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
      var addCategoria = new CategoriaServico(categoriaServico.Descricao);
      _categoriaRepository.Add(addCategoria);
      return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Alterar(int id, CategoriaServico categoriaServico)
    {
      if(id != 0){
        _categoriaRepository.Update(categoriaServico.Id, categoriaServico.Descricao);
        return Ok();
      }
      return BadRequest("Erro ao alterar");
    }

    [HttpDelete]
    [Route("{id}")]
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
    [HttpGet("{id}")]
    public ActionResult ListId(int id)
    {
      var categoria = _categoriaRepository.ListId(id);
      return Ok(categoria);
    }
  }
}