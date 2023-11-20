using Microsoft.AspNetCore.Mvc;

namespace server.Models
{
  public interface ICategoriaServicoRepository
  {
    void Add(CategoriaServico categoria);
    void Update(int id, string descricao);
    void Delete(int id);
    IEnumerable<CategoriaServico> List();
    CategoriaServico ListId(int id);

  }
}