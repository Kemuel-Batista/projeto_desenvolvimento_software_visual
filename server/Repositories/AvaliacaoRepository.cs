using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server
{
  public class AvaliacaoRepository : IAvaliacaoRepository
  {
    private readonly ConnectionContext _context = new();
    public async Task Add(int id_pedido, string avaliacao, string cpf)
    {
      var pedidoExists = await _context.Pedido.FindAsync(id_pedido);

      if (pedidoExists != null)
      {
        var avaliacaoExists = await _context.avaliacao
            .Where(a => a.id_pedido == id_pedido)
            .FirstOrDefaultAsync();
        
        string conta = pesquisarCpf(cpf);

        if (avaliacaoExists == null)
        {
          if(conta.Equals("Prestador")){
            Avaliacao avaliacaoPrestador = new()
            {
              avaliacao_prestador = avaliacao,
              cpf_prestador = cpf,
              id_pedido = id_pedido
            };
            await _context.avaliacao.AddAsync(avaliacaoPrestador);
          } else {
            Avaliacao avaliacaoCliente = new()
            {
              avaliacao_cliente = avaliacao,
              cpf_cliente = cpf,
              id_pedido = id_pedido
            };
            await _context.avaliacao.AddAsync(avaliacaoCliente);
          }
        }
        else
        {
          if(conta.Equals("Prestador")){
            avaliacaoExists.avaliacao_prestador = avaliacao;
            avaliacaoExists.cpf_prestador = cpf;
          } else {
            avaliacaoExists.avaliacao_cliente = avaliacao;
            avaliacaoExists.cpf_cliente = cpf;
          }
          // Atualizar a avaliação
          _context.avaliacao.Update(avaliacaoExists);
        }

        await _context.SaveChangesAsync();
      }
    }
    public async Task Update(string conta, int id, string avaliacao)
    {
      var avaliacao_exists = await _context.avaliacao.Where(a => a.id_pedido == id).FirstOrDefaultAsync();

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