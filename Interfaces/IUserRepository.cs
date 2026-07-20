using InventoryManagement.API.Entities;

namespace InventoryManagement.API.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
    Task<bool> EmailExistsAsync(string email);
    Task<bool> SaveChangesAsync();
}
