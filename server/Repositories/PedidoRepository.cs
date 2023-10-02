using server.Models;

namespace server
{
  public class PedidoRepository : IPedidoRepository
  {
    private readonly ConnectionContext _context = new();

    public async void Add(Pedido pedido)
    {
      await _context.Pedido.AddAsync(pedido);
      await _context.SaveChangesAsync();
    }

    public async void CancelarPedido(int id)
    {
      var pedido = _context.Pedido.Find(id);
      if (pedido != null)
      {
        _context.Pedido.Remove(pedido);
        _context.SaveChanges();
      }
    }

    public IEnumerable<Pedido> List()
    {
      return _context.Pedido.ToList();
    }

    public async void Update(int id, int id_servico)
    {
      var pedido = _context.Pedido.Find(id);
      if (pedido != null)
      {
        pedido.Id_Servico = id_servico;
        _context.Pedido.Update(pedido);
        await _context.SaveChangesAsync();
      }
    }
  }
}