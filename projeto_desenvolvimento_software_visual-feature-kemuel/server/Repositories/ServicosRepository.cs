using server.Models;

namespace server
{
  public class ServicosRepository : IServicosRepository
  {
    private readonly ConnectionContext _context = new();

    public async void Add(Servicos servico)
    {
      await _context.Servicos.AddAsync(servico);
      await _context.SaveChangesAsync();
    }

    public async void Update(int id, string nome, double valor, int idCategoria, string cpfPrestador)
    {
      var servic = _context.Servicos.Find(id);
      if(servic != null){
        servic.Nome = nome;
        servic.Valor = valor;
        servic.id_categoria_servico = idCategoria;
        servic.cpf_prestador = cpfPrestador;
        _context.Servicos.Update(servic);
        await _context.SaveChangesAsync();
      }
    }
    public void DeleteAccount(int id)
    {
     var servic = _context.Servicos.Find(id);
      if(servic != null)
      {
        _context.Servicos.Remove(servic);
        _context.SaveChanges();
      }
    }

    public IEnumerable<Servicos> List()
    {
      return _context.Servicos.ToList();
    }
  }
}