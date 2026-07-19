using WarrantyManagement.Domain.Enums;

namespace WarrantyManagement.Domain.Entities;

public class User
{
     public Guid Id {get;private set; }

    public string UserName{get;private set;}

    public string Email{get;private set;}

    public  string PasswordHash  {get;private set;}

    public RoleStatus Role {get;private set;}
    public Guid RefreshToken {get;private set;}=Guid.Empty;


  private User(){}
   public User(
    string userName,
    string email,
    string passwordHash,
    RoleStatus role)
{
    ValidateUserName(userName);
    ValidateEmail(email);
    ValidatePasswordHash(passwordHash);
    ValidateRole(role);

    Id = Guid.NewGuid();

    UserName = userName.Trim();
    Email = email.Trim().ToLowerInvariant();
    PasswordHash = passwordHash;
    Role = role;
}


    public void ChangeUserName(string userName)
    {
        ValidateUserName(userName);
        UserName=userName.Trim();
    }

    
    public void ChangePasswordHash(string passwordHash)
    {
        ValidatePasswordHash(passwordHash);
        PasswordHash=passwordHash;
    }

    
    public void ChangeEmail(string email)
    {
        ValidateEmail(email);
        Email=email.Trim().ToLowerInvariant();
    }
    
    public void ChangeRole(RoleStatus role)
    {
        ValidateRole(role);
        Role=role;
    }
    
    public void ChangeRefreshToken(Guid refreshToken)
    {
        ValidateRefreshToken(refreshToken);
        RefreshToken=refreshToken;
    }
   private static void ValidateUserName(string userName)
    {
        if(string.IsNullOrWhiteSpace(userName))
        throw new ArgumentException("The user name is required",nameof(userName));
    }

    private static void ValidateEmail(string email)
    {
        if(string.IsNullOrWhiteSpace(email))
        throw new ArgumentException("The email is required",nameof(email));
    }

    private static void ValidatePasswordHash(string password)
    {
        if(string.IsNullOrWhiteSpace(password))
        throw new ArgumentException("The password is required",nameof(password));
    }

    private static void ValidateRole(RoleStatus role)
    {
        if(!Enum.IsDefined(typeof(RoleStatus),role))
        throw new ArgumentException("The role is InValid",nameof(role));
    }

      private static void ValidateRefreshToken(Guid refreshToken)
    {
        if(refreshToken ==Guid.Empty)
        throw new ArgumentException("The refreshToken is empty");
    }
}

