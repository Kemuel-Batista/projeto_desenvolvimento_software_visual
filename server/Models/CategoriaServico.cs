using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
  [Table("categoriaservico")]
  public class CategoriaServico
  {
    private int _id;
    private string _descricao;
    [Key]
    public int Id { get => _id; set => _id = value; }
    public string Descricao { get => _descricao; set => _descricao = value; }
    

    public CategoriaServico(string descricao)
    {
      _descricao = descricao;
    }
    
  }
}

