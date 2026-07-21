using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Application.Interfaces;

public interface IRegisterRepository
{
    Task AddUserAsync(User user);

    Task<User> GetUserByUserNameAsync (string userName);

    Task<User> GetUserByEmailAsync (string userName);


    

}