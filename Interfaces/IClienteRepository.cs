using Microsoft.AspNetCore.Mvc;

namespace server.Models
{
  public interface IClienteRepository
  {
    void Add(Cliente cliente);
    void Update(Cliente cliente);
    List<Cliente> Get();
  }
}