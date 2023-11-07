namespace server.Views {
  public class LoginView
  {
    public string email { get; set; }
    public string password { get; set; }

    public LoginView() {
      email = string.Empty;
      password = string.Empty;
    }
  }
}