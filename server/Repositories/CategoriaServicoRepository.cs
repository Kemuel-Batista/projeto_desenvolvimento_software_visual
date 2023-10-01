using server.Models;

namespace server
{
  public class CategoriaServicoRepository : ICategoriaServicoRepository
  {
    private readonly ConnectionContext _context = new();

        public async void Add(CategoriaServico categoria)
        {
            await _context.Categoria.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }
         public async void Update(int id, string descricao)
        {
            var categoria = _context.Categoria.Find(id);
            if(categoria != null){
               categoria.Descricao = descricao;
                _context.Categoria.Update(categoria);
                await _context.SaveChangesAsync();
            }
        }
        public void Delete(int id)
        {
            var categoria = _context.Categoria.Find(id);
            if(categoria != null)
            {
                 _context.Categoria.Remove(categoria);
                 _context.SaveChanges();
            }        
      }

        public IEnumerable<CategoriaServico> List()
        {
            return _context.Categoria.ToList();
        }

        
    }
}