using InventoryManagement.API.DTOs.Products;
using InventoryManagement.API.Entities;

namespace InventoryManagement.API.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductResponseDto>> GetAllAsync();
    Task<ProductResponseDto?> GetByIdAsync(int id);
    Task<ProductResponseDto> GetBySkuAsync(string sku);
    Task<ProductResponseDto> CreateAsync(CreateProductDto dto);
    Task<ProductResponseDto> UpdateAsync(int id, UpdateProductDto dto);
    Task DeleteAsync(int id);
    Task<IEnumerable<ProductResponseDto>> SearchByNameAsync(string name);
    Task<IEnumerable<ProductResponseDto>> GetPagedAsync(int page, int pageSize);
    Task<IEnumerable<ProductResponseDto>> GetOrderedAsync();

}
