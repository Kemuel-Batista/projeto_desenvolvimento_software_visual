using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
  [Table("prestadores")]
  public class Prestadores : User
  {
    private string _biografia;
    public string Biografia { get => _biografia; set => _biografia = value; }

    public Prestadores() : base()
    {
        _biografia = string.Empty;
    }
    
    public Prestadores(string nome, string cpf, string email, string telefone, string password, string biografia) : base(nome, cpf, email, telefone, password)
    {
        _biografia = biografia;
    }
  }
}