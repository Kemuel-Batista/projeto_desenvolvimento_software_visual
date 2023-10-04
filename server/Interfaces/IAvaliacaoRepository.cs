using Microsoft.AspNetCore.Mvc;

namespace server.Models
{
  public interface IAvaliacaoRepository
  {
    void Add(avaliacao avaliaca);
    void Update(string conta, int id, string avaliacao);
    void DeleteAccount(int id);
    string pesquisarCpf(string cpf);
    IEnumerable<avaliacao> List();
  }
}