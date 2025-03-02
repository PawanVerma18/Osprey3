using Osprey3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserService
{
    Task<bool> RegisterUserAsync(User user);
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User> GetUserAsync(int id);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
    Task SaveUserAsync(User user);

    // New method to check if a user exists
    Task<bool> CheckUserExistsAsync(string email, string password);
}