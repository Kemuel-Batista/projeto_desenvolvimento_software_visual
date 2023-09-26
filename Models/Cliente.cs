using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
  [Table("clientes")]
  public class Cliente
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    [Key]
    public string CPF { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Password { get; set; }

    public Cliente(){}

    public Cliente(string nome, string cpf, string email, string telefone, string password)
    {
      Nome = nome;
      CPF = cpf;
      Email = email;
      Telefone = telefone;
      Password = password;
    }
  }
}