using server.Models;

namespace server
{
  public class ClienteRepository : IClienteRepository
  {
    private readonly ConnectionContext _context = new();

    public async void Add(Cliente cliente)
    {
      await _context.Cliente.AddAsync(cliente);
      await _context.SaveChangesAsync();
    }

    public async void Update(Cliente cliente)
    {
      _context.Cliente.Update(cliente);
      await _context.SaveChangesAsync();
    }

    public List<Cliente> Get()
    {
      return _context.Cliente.ToList();
    }
  }
}