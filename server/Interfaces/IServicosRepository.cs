using Microsoft.AspNetCore.Mvc;

namespace server.Models
{
  public interface IServicosRepository
  {
    void Add(Servicos servicos);
    void Update(int id, string nome, double valor, int idCategoria, string cpfPrestador);
    void delete(int id);
    IEnumerable<Servicos> List();
    IEnumerable<Servicos> GetMyServices(string cpf);
  }
}