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

    public async void Update(string cpf, string nome, string email, string telefone)
    {
      var client = _context.Cliente.Find(cpf);
      if(client != null){
        client.Nome = nome;
        client.Email = email;
        client.Telefone = telefone;
        _context.Cliente.Update(client);
        await _context.SaveChangesAsync();
      }
    }
    public async void ChangePassword(string cpf, string password)
    {
      var client = _context.Cliente.Find(cpf);
      if(client != null){
        client.Password = password;
        _context.Cliente.Update(client);
        await _context.SaveChangesAsync();
      }
    }
    public void DeleteAccount(string Cpf)
    {
     var client = _context.Cliente.Find(Cpf);
      if(client != null)
      {
        _context.Cliente.Remove(client);
        _context.SaveChanges();
      }
    }

    public IEnumerable<Cliente> List()
    {
      return _context.Cliente.ToList();
    }
  }
}