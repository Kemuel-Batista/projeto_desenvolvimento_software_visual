namespace server.Views {
  public class CreateServiceView {
    public string nome { get; set; }
    public int valor { get; set; }
    public int id_categoria { get; set; }
  }

  public class UpdateServiceView : CreateServiceView {
    public int id { get; set; }
  }
}