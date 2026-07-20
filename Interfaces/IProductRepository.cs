using InventoryManagement.API.Entities;

namespace InventoryManagement.API.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product?> GetBySkuAsync(string sku);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
    Task<bool> ExistsBySkuAsync(string sku);
    Task<bool> SaveChangesAsync();
    Task<IEnumerable<Product>> SearchByNameAsync(string name);
    Task<IEnumerable<Product>> GetPagedAsync(int page, int pageSize);
    Task<IEnumerable<Product>> GetOrderedAsync();
}