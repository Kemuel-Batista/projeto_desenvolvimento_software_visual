using server.Models;

namespace server
{
  public class AvaliacaoRepository : IAvaliacaoRepository
  {
    private readonly ConnectionContext _context = new();

    public async void Add(avaliacao avaliaca)
    {
      await _context.avaliacao.AddAsync(avaliaca);
      await _context.SaveChangesAsync();
    }

    public async void Update(string conta, int id, string avaliacao)
    {
      var avaliaca = _context.avaliacao.Find(id);
      if(avaliaca != null)
      {
        if(conta.Equals("Prestador"))
        {
          avaliaca.avaliacao_prestador = avaliacao;     
        }
        if(conta.Equals("Cliente"))
        {
          avaliaca.avaliacao_cliente= avaliacao;
        }
        _context.avaliacao.Update(avaliaca);
        await _context.SaveChangesAsync();
      }
    }
    public void DeleteAccount(int id)
    {
     var avaliaca = _context.avaliacao.Find(id);
      if(avaliaca != null)
      {
        _context.avaliacao.Remove(avaliaca);
        _context.SaveChanges();
      }
    }

    public IEnumerable<avaliacao> List()
    {
      return _context.avaliacao.ToList();
    }
    public string pesquisarCpf(string cpf)
    {
        var prestador = _context.Prestador.Find(cpf);
        var cliente = _context.Cliente.Find(cpf);
        string conta = "";

        if(prestador != null)
        {
            conta = "Prestador";
            return conta;
        }
        if(cliente != null)
        {   
            conta = "Cliente";
            return conta;
        }
      
        return "Erro ao pesquisar cpf";

    }

        
    }
}