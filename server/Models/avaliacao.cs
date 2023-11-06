using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace server.Models
{
  [Table("avaliacao")]
  public class Avaliacao
  {
    [Key]
    public int id { get; set; }
    public int id_pedido { get; set; }
    public string? cpf_cliente { get; set; }
    public string? cpf_prestador { get; set; }
    public string? avaliacao_prestador { get; set; }
    public string? avaliacao_cliente { get; set; }
    
    [ForeignKey("id_pedido")]
    public virtual Pedido Pedido { get; set; }

    [ForeignKey("cpf_cliente"), AllowNull]
    public virtual Cliente Cliente { get; set; }

    [ForeignKey("cpf_prestador"), AllowNull]
    public virtual Prestadores Prestadores { get; set; }

    public Avaliacao(){}
  }
}