using AutoMapper;
using InventoryManagement.API.DTOs.Products;
using InventoryManagement.API.Entities;
using InventoryManagement.API.Exceptions;
using InventoryManagement.API.Interfaces;

namespace InventoryManagement.API.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
    }
    public async Task<ProductResponseDto> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product is null)
            throw new NotFoundException("Product not found.");

        return _mapper.Map<ProductResponseDto>(product);
    }
    public async Task<ProductResponseDto> CreateAsync(CreateProductDto dto)
    {
        if (await _productRepository.ExistsBySkuAsync(dto.SKU))
        {
            throw new ConflictException("A product with this SKU already exists.");
        }

        if (dto.SalesPrice < dto.CostPrice)
        {
            throw new BusinessRuleException("Sale price cannot be lower than cost price.");
        }

        var product = _mapper.Map<Product>(dto);

        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();

        var createdProduct = await _productRepository.GetByIdAsync(product.Id);

        return _mapper.Map<ProductResponseDto>(createdProduct);
    }
    public async Task<ProductResponseDto> UpdateAsync(int id, UpdateProductDto dto)
    {
        var existingProduct = await _productRepository.GetByIdAsync(id);

        if (existingProduct is null)
        {
            throw new NotFoundException("Product not found.");
        }

        if (dto.SalesPrice < dto.CostPrice)
        {
            throw new BusinessRuleException("Sale price cannot be lower than cost price.");
        }

        _mapper.Map(dto, existingProduct);

        await _productRepository.UpdateAsync(existingProduct);

        await _productRepository.SaveChangesAsync();

        return _mapper.Map<ProductResponseDto>(existingProduct);
    }
    public async Task DeleteAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product is null)
        {
            throw new NotFoundException("Product not found.");
        }
        await _productRepository.DeleteAsync(product);

        await _productRepository.SaveChangesAsync();
    }
    private async Task<Product> GetExistingProductAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product is null)
            throw new NotFoundException("Product not found.");

        return product;
    }
    public async Task<ProductResponseDto> GetBySkuAsync(string sku)
    {
        var product = await _productRepository.GetBySkuAsync(sku);

        if (product is null)
            throw new NotFoundException("Product not found.");

        return _mapper.Map<ProductResponseDto>(product);
    }
    public async Task<IEnumerable<ProductResponseDto>> SearchByNameAsync(string name)
    {
        var products = await _productRepository.SearchByNameAsync(name);

        return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
    }
    public async Task<IEnumerable<ProductResponseDto>> GetPagedAsync(int page, int pageSize)
    {
        var products = await _productRepository.GetPagedAsync(page, pageSize);

        return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
    }
    public async Task<IEnumerable<ProductResponseDto>> GetOrderedAsync()
    {
        var products = await _productRepository.GetOrderedAsync();

        return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
    }
}
