using Microsoft.AspNetCore.Mvc;

namespace server.Models
{
  public interface IPrestadoresRepository
  {
    void Add(Prestadores prestadores);
    void Update(string cpf, string nome, string email, string telefone, string biografia);
    void DeleteAccount(string cpf);
    void ChangePassword(string cpf, string password);
    IEnumerable<Prestadores> List();
  }
}