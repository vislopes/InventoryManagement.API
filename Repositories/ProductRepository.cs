using InventoryManagement.API.Data;
using InventoryManagement.API.Entities;
using InventoryManagement.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.API.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<Product?> GetBySkuAsync(string sku)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .FirstOrDefaultAsync(p => p.SKU == sku);
    }

    public async Task<bool> ExistsBySkuAsync(string sku) 
    { 
        return await _context.Products
            .AnyAsync(p => p.SKU == sku);
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        return Task.CompletedTask;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .Where(p => p.Name.ToLower().Contains(name.ToLower()))
            .ToListAsync();
    }
    public async Task<IEnumerable<Product>> GetPagedAsync(int page, int pageSize)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    public async Task<IEnumerable<Product>> GetOrderedAsync()
    {
        return await _context.Products
            .OrderBy(p => p.Name)
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .ToListAsync();
    }
}
