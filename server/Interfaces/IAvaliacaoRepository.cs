namespace server.Models
{
  public interface IAvaliacaoRepository
  {
    void Add(Avaliacao avaliaca);
    void Update(string conta, int id, string avaliacao);
    void DeleteAvaliacao(int id);
    string pesquisarCpf(string cpf);
    IEnumerable<Avaliacao> List();
  }
}