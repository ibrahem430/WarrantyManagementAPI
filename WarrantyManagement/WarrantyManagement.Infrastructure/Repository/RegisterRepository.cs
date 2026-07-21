using Microsoft.EntityFrameworkCore;
using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Domain.Entities;
using WarrantyManagement.Infrastructure.dataBase;

namespace WarrantyManagement.Infrastructure.Repository;


public class RegisterRepository(AppDbContext context) : IRegisterRepository
{
    public async Task AddUserAsync(User user)
    {
      await context.users.AddAsync(user);
      await context.SaveChangesAsync();
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await context.users.FirstOrDefaultAsync(u=>u.Email==email);
    }

    public async Task<User?> GetUserByUserNameAsync(string userName)
    {
        return await context.users.FirstOrDefaultAsync(u=>u.UserName==userName);
    }
}