using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
  [Table("pedidos")]
  public class Pedido
  {
    private int _id;
    private int _id_servico;
    private char _status;
    private DateTime _created_at;

    [Key]
    public int id { get => _id; set => _id = value; }
    public int id_servico { get => _id_servico; set => _id_servico = value; }

    [ForeignKey("id_servico")]
    public virtual Servicos Servicos { get; set; }
    public char status { get => _status; set => _status = value; }
    public DateTime created_at { get => _created_at; set => _created_at = value; }

    public Pedido(int id, int id_servico, char status)
    {
      _id = id;
      _id_servico = id_servico;
      _status = status;
      _created_at = DateTime.Now;
    }
  }
}