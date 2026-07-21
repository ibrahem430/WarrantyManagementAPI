using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml.Xsl;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Application.Requests.Login;
using WarrantyManagement.Application.Responses.Login;
using WarrantyManagement.Application.Responses.RefreshToken;
using WarrantyManagement.Domain.Entities;


namespace WarrantyManagement.Application.Services;


public class LoginService(IloginRepository repository,IConfiguration configuration)
{
    
    public async Task<LoginResponse> LoginUserAsync(LoginRequest request)
    {

        var login=await repository.GetByUserNameAsync(request.UserName);

        if(login is null)
        throw new ArgumentNullException();

        if(login.Email!=request.Email)
        throw new KeyNotFoundException();

        var passwordHash=new PasswordHasher<User>();

        var result= passwordHash.VerifyHashedPassword(
            login,
            login.PasswordHash,
            request.Password
            
        );
        if(result!=PasswordVerificationResult.Success)
         throw new InvalidOperationException();
          
         var jwtSettings=configuration.GetSection("jwtInformation");

       var issuer=jwtSettings["Issuer"]!;

       var audience=jwtSettings["Audience"]!;

       var key= jwtSettings["Key"]!;

      var expires = DateTime.UtcNow.AddMinutes(
    int.Parse(jwtSettings["TokenExpirationInMinutes"]!)
      );
     
       var claims = new List<Claim>
    {
        new Claim( JwtRegisteredClaimNames.Sub, login.Id.ToString()),

        new Claim( JwtRegisteredClaimNames.Name, login.UserName),

        new Claim( JwtRegisteredClaimNames.Email, login.Email),

        new Claim( ClaimTypes.Role, login.Role.ToString()),

        new Claim( JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    var refreshToken=Guid.NewGuid();

    login.ChangeRefreshToken(refreshToken);

    await repository.UpdateRefreshTokenAsync();


     var TokenDescriptor=new SecurityTokenDescriptor{

        Subject=new ClaimsIdentity(claims),
        Expires=expires,
        Issuer=issuer,
        Audience=audience,
        SigningCredentials=new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            SecurityAlgorithms.HmacSha256Signature
        )
     };

     var tokenHandler=new JwtSecurityTokenHandler();

     var token=tokenHandler.CreateToken(TokenDescriptor);

     return new LoginResponse
     {
         AccessToken=tokenHandler.WriteToken(token),
         RefreshToken=refreshToken,
         Expires=expires

     };
    }



    public async Task<RefreshTokenResponse> RefreshTokenAsync(
    RefreshTokenRequest request)
{
    var user = await repository.GetRefreshToken(request.RefreshJWTToken);

 var claims = new List<Claim>
    {
        new Claim(
            JwtRegisteredClaimNames.Sub,
            user.Id.ToString()),

        new Claim(
            JwtRegisteredClaimNames.Name,
            user.UserName),

        new Claim(
            JwtRegisteredClaimNames.Email,
            user.Email),

        new Claim(
            ClaimTypes.Role,
            user.Role.ToString()),

        new Claim(
            JwtRegisteredClaimNames.Jti,
            Guid.NewGuid().ToString())
    };

    var jwtSettings = configuration.GetSection("jwtInformation");

var issuer = jwtSettings["Issuer"]!;

var audience = jwtSettings["Audience"]!;

var key = jwtSettings["Key"]!;

var expires = DateTime.UtcNow.AddMinutes(
    int.Parse(jwtSettings["TokenExpirationInMinutes"]!)
);
var tokenDescriptor = new SecurityTokenDescriptor
{
    Subject = new ClaimsIdentity(claims),

    Expires = expires,

    Issuer = issuer,

    Audience = audience,

    SigningCredentials = new SigningCredentials(
        new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key)),
        SecurityAlgorithms.HmacSha256Signature)
};

var tokenHandler = new JwtSecurityTokenHandler();

var token = tokenHandler.CreateToken(tokenDescriptor);

return new RefreshTokenResponse
{
    AccessToken = tokenHandler.WriteToken(token),
    RefreshToken = request.RefreshJWTToken,
    Expires = expires
};
}

  
}