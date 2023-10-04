using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
[Table("servicos")]
  public class Servicos
  {
    [Key]
    public int Id {get;set;}
    public string Nome {get;set;}
    public double Valor {get;set;}
    public int id_categoria_servico {get;set;}
    public string cpf_prestador {get;set;}

    [ForeignKey("id_categoria_servico")]
    public virtual CategoriaServico CategoriaServico {get;set;}
    [ForeignKey("cpf_prestador")]
    public virtual Prestadores Prestadores {get;set;}

     public Servicos()
    {
      Id = 0;
      Nome = string.Empty;
      Valor = 0;
      id_categoria_servico = 0;
      cpf_prestador = string.Empty;
    }
    
    public Servicos(string nome, double valor, int idCategoria, string cpfPrestador)
    {
        Nome = nome;
        Valor = valor;
        id_categoria_servico = idCategoria;
        cpf_prestador = cpfPrestador;
    }
   
  }
}