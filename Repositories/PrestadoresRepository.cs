using server.Models;

namespace server
{
  public class PrestadoresRepository : IPrestadoresRepository
  {
    private readonly ConnectionContext _context = new();

        public async void Add(Prestadores prestadores)
        {
            await _context.Prestador.AddAsync(prestadores);
            await _context.SaveChangesAsync();
        }
         public async void Update(string cpf, string nome, string email, string telefone, string biografia)
        {
            var prestador = _context.Prestador.Find(cpf);
            if(prestador != null){
               prestador.Nome = nome;
               prestador.Email = email;
               prestador.Telefone = telefone;
               prestador.Biografia = biografia;
                _context.Prestador.Update(prestador);
                await _context.SaveChangesAsync();
            }
        }

        public async void ChangePassword(string cpf, string password)
        {
            var prestadores = _context.Prestador.Find(cpf);
            if(prestadores != null){
                prestadores.Password = password;
                _context.Prestador.Update(prestadores);
                await _context.SaveChangesAsync();
            }
        }
        public void DeleteAccount(string cpf)
        {
            var prestador = _context.Prestador.Find(cpf);
            if(prestador != null)
            {
                 _context.Prestador.Remove(prestador);
                 _context.SaveChanges();
            }        
      }

        public IEnumerable<Prestadores> List()
        {
            return _context.Prestador.ToList();
        }

    }
}