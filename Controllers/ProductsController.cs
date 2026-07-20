using InventoryManagement.API.DTOs.Products;
using InventoryManagement.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // Público: consultar produtos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAll()
    {
        var products = await _productService.GetAllAsync();

        return Ok(products);
    }

    // Público: buscar produto por ID
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductResponseDto>> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);

        return Ok(product);
    }

    // Apenas Admin: criar produto
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ProductResponseDto>> Create(CreateProductDto dto)
    {
        var product = await _productService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = product.Id },
            product);
    }

    // Apenas Admin: atualizar produto
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ProductResponseDto>> Update(
        int id,
        [FromBody] UpdateProductDto dto)
    {
        var product = await _productService.UpdateAsync(id, dto);

        return Ok(product);
    }

    // Apenas Admin: deletar produto
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _productService.DeleteAsync(id);

        return NoContent();
    }

    // Público: buscar por SKU
    [HttpGet("sku/{sku}")]
    public async Task<ActionResult<ProductResponseDto>> GetBySku(string sku)
    {
        var product = await _productService.GetBySkuAsync(sku);

        return Ok(product);
    }

    // Público: pesquisa por nome
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<ProductResponseDto>>> Search(string name)
    {
        var products = await _productService.SearchByNameAsync(name);

        return Ok(products);
    }

    // Público: paginação
    [HttpGet("paged")]
    public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetPaged(
        int page = 1,
        int pageSize = 10)
    {
        var products = await _productService.GetPagedAsync(page, pageSize);

        return Ok(products);
    }

    // Público: produtos ordenados
    [HttpGet("ordered")]
    public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetOrdered()
    {
        var products = await _productService.GetOrderedAsync();

        return Ok(products);
    }
}