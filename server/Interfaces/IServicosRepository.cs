using Microsoft.AspNetCore.Mvc;

namespace server.Models
{
  public interface IServicosRepository
  {
    void Add(Servicos servicos);
    void Update(int id, string nome, double valor, int idCategoria, string cpfPrestador);
    void DeleteAccount(int id);
    IEnumerable<Servicos> List();
  }
}