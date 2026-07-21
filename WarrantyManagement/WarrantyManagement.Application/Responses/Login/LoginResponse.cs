namespace WarrantyManagement.Application.Responses.Login;



public class LoginResponse
{

    public string? AccessToken { get; set; }
    public Guid RefreshToken { get; set; }
    public DateTime Expires { get; set; }
}