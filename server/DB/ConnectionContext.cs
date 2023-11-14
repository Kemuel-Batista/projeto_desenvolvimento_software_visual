using Microsoft.EntityFrameworkCore;
using server.Models;

public class ConnectionContext : DbContext
{
  // O DbSet é responsável por mapear no banco de dados e retornar o mapeamento de acordo com a classe
  public DbSet<Cliente> Cliente { get; set; }
  public DbSet<CategoriaServico> Categoria { get; set; }
  public DbSet<Prestadores> Prestador { get; set; }
  public DbSet<Servicos> Servicos { get; set; }
  public DbSet<Pedido> Pedido { get; set; }
  public DbSet<Avaliacao> avaliacao { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql(
      "Server=localhost;" +
      "Port=5432;" +
      "Database=projeto_ds_visual;" +
      "User Id=postgres;" +
      "Password=01021993;"
    );
  }
}