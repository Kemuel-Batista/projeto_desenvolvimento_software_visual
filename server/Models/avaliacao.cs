using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace server.Models
{
  [Table("avaliacao")]
  public class avaliacao 
  {
        [Key]

     public int id {get;set;}
    public int id_pedido {get;set;}
    public string? cpf_cliente {get;set;}

    public string? cpf_prestador {get;set;}
    public string? avaliacao_prestador {get;set;}
    public string?avaliacao_cliente {get;set;}

    [ForeignKey("cpf_cliente"), AllowNull]
    public virtual Cliente Cliente {get;set;}

    [ForeignKey("cpf_prestador"), AllowNull]
    public virtual Prestadores Prestadores {get;set;}

 public avaliacao()
    {
      

    }
    public avaliacao(int codPedido, string cpfPrestador,string avaliacaoPrestador)
    {
        id_pedido = codPedido;
        cpf_prestador = cpfPrestador;
        avaliacao_prestador=avaliacaoPrestador;
    }


    

   
  }
    

}