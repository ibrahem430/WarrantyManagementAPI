namespace WarrantyManagement.Application.Responses.RefreshToken;

public class RefreshTokenResponse
{
    public string AccessToken { get; set; } = string.Empty;

    public Guid RefreshToken { get; set; }

    public DateTime Expires { get; set; }
}