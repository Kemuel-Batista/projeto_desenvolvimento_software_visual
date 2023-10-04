using server.Models;

namespace server
{
  public class AvaliacaoRepository : IAvaliacaoRepository
  {
    private readonly ConnectionContext _context = new();
    private readonly ILogger<AvaliacaoRepository> _logger;

    public AvaliacaoRepository(ILogger<AvaliacaoRepository> logger) => _logger = logger;

    public async void Add(Avaliacao avaliacao)
    {
      var pedido_exists = await _context.Pedido.FindAsync(avaliacao.id_pedido);

      if (pedido_exists != null)
      {
        _logger.LogInformation("Pedido existe");
        var avaliacaoExists = _context.avaliacao.Find(avaliacao.id_pedido);

        // Se não existe uma avaliacao com o id_pedido então cadastrar 
        if (avaliacaoExists == null)
        {
           _logger.LogInformation("Nao existe avaliacao para esse pedido");
          await _context.avaliacao.AddAsync(avaliacao);
          await _context.SaveChangesAsync();
        }
        else
        {
           _logger.LogInformation("existe avaliacao para esse pedido");
          // Editar avaliacao
          _context.avaliacao.Update(avaliacao);
          await _context.SaveChangesAsync();
        }
      }
    }

    public async void Update(string conta, int id, string avaliacao)
    {
      var avaliacao_exists = await _context.avaliacao.FindAsync(id);
      if (avaliacao_exists != null)
      {
        if (conta.Equals("Prestador"))
        {
          avaliacao_exists.avaliacao_prestador = avaliacao;
        }
        if (conta.Equals("Cliente"))
        {
          avaliacao_exists.avaliacao_cliente = avaliacao;
        }
        _context.avaliacao.Update(avaliacao_exists);
        await _context.SaveChangesAsync();
      }
    }
    public void DeleteAvaliacao(int id)
    {
      var avaliacao = _context.avaliacao.Find(id);
      if (avaliacao != null)
      {
        _context.avaliacao.Remove(avaliacao);
        _context.SaveChanges();
      }
    }

    public IEnumerable<Avaliacao> List()
    {
      return _context.avaliacao.ToList();
    }
    public string pesquisarCpf(string cpf)
    {
      var prestador = _context.Prestador.Find(cpf);
      var cliente = _context.Cliente.Find(cpf);
      string conta = "";

      if (prestador != null)
      {
        conta += "Prestador";
        return conta;
      }
      if (cliente != null)
      {
        conta += "Cliente";
        return conta;
      }
      return "Erro ao pesquisar cpf";
    }
  }
}