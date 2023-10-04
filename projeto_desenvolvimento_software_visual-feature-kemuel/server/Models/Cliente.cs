using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
  [Table("clientes")]
  public class Cliente : User
  {
    private string _cep;
    private string _endereco;
    public string Cep { get => _cep; set => _cep = value; }
    public string Endereco { get => _endereco; set => _endereco = value; }

    public Cliente() : base()
    {
      _cep = string.Empty;
      _endereco = string.Empty;
    }
    
    public Cliente(string nome, string cpf, string email, string telefone, string password, string cep, string endereco) : base(nome, cpf, email, telefone, password)
    {
      _cep = cep;
      _endereco = endereco;
    }
  }
}