using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
  [Table("pedidos")]
  public class Pedido
  {
    private int _id;
    private int _id_servico;
    private string _cpf_cliente;
    private string _status;
    private DateTime _created_at;

    [Key]
    [Column("id")]
    public int Id { get => _id; set => _id = value; }

    [Column("id_servico")]
    public int Id_Servico { get => _id_servico; set => _id_servico = value; }

    [ForeignKey("Id_Servico")]
    public virtual Servicos Servicos { get; set; }

    [Column("cpf_cliente")]
    public string Cpf_Cliente { get => _cpf_cliente; set => _cpf_cliente = value; }

    [ForeignKey("Cpf_Cliente")]
    public virtual Cliente Cliente { get; set; }

    [Column("status")]
    public string Status { get => _status; set => _status = value; }

    [Column("created_at")]
    public DateTime Created_At { get => _created_at; set => _created_at = value; }

    public Pedido()
    {
      Id = 0;
      Status = string.Empty;
      Cpf_Cliente = string.Empty;
      Id_Servico = 0;
      Created_At = DateTime.UtcNow;
    }
    public Pedido(int id_servico, string cpf_cliente, string status)
    {
      _id_servico = id_servico;
      _status = status;
      _cpf_cliente = cpf_cliente;
      _created_at = DateTime.UtcNow;
    }
  }
}