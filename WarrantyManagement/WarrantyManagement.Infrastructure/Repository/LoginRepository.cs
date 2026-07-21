using Microsoft.EntityFrameworkCore;
using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Domain.Entities;
using WarrantyManagement.Infrastructure.dataBase;

namespace WarrantyManagement.Infrastructure.Repository;


public class LoginRepository(AppDbContext context) : IloginRepository
{
    public async Task<User?> GetByUserNameAsync(string username)
    {
        
       var user= await 
       context.users.FirstOrDefaultAsync(u=>u.UserName==username);
       return user;
    }

    public async Task<User> GetRefreshToken(Guid refrEshToken)
    {
          var user= await 
       context.users.FirstOrDefaultAsync(u=>u.RefreshToken==refrEshToken);
       return user;
    }

  

    public async Task UpdateRefreshTokenAsync()
    {
       await context.SaveChangesAsync();
    }
}