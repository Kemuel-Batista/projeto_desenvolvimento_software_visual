namespace server.Models
{
  public interface IPedidoRepository
  {
    void Add(Pedido pedido);
    void Update(int id, int id_servico);
    void CancelarPedido(int id);
    IEnumerable<Pedido> List();
  }
}