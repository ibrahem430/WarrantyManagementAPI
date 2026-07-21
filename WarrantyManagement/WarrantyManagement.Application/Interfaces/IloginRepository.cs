using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Application.Interfaces;


public interface IloginRepository
{
   
    Task<User?> GetByUserNameAsync(string username);

    Task UpdateRefreshTokenAsync();

    Task<User> GetRefreshToken(Guid refrEshToken);

    
    
   
  
}
