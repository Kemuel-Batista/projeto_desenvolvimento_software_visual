namespace server.Models
{
  public interface IAvaliacaoRepository
  {
    Task Add(int id_pedido, string avaliacao, string cpf);
    Task Update(string conta, int id, string avaliacao);
    void DeleteAvaliacao(int id);
    string pesquisarCpf(string cpf);
    IEnumerable<Avaliacao> List();
  }
}