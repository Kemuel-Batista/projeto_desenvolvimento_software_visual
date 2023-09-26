using Microsoft.AspNetCore.Mvc;

namespace server.Models
{
  public interface IClienteRepository
  {
    void Add(Cliente client);
    void Update(string cpf, string nome, string email, string telefone);
    void DeleteAccount(string cpf);
    void ChangePassword(string cpf, string password);
    IEnumerable<Cliente> List();
  }
}