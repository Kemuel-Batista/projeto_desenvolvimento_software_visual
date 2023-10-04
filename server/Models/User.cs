using System.ComponentModel.DataAnnotations;

namespace server.Models
{
  public class User
  {
    private string _nome;
    private string _cpf;
    private string _email;
    private string _telefone;
    private string _password;

    public string Nome { get => _nome; set => _nome = value; }
    [Key]
    public string Cpf { get => _cpf; set => _cpf = value; }
    public string Email { get => _email; set => _email = value.ToLower(); }
    public string Telefone { get => _telefone; set => _telefone = value; }
    public string Password { get => _password; set => _password = value; }

    public User()
    {
      _nome = string.Empty;
      _cpf = string.Empty;
      _email = string.Empty;
      _telefone = string.Empty;
      _password = string.Empty;
    }
    
    public User(string nome, string cpf, string email, string telefone, string password)
    {
      _nome = nome;
      _cpf = cpf;
      _email = email;
      _telefone = telefone;
      _password = password;
    }
  }
}