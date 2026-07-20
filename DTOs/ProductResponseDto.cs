namespace InventoryManagement.API.DTOs.Products;

public class ProductResponseDto
{
    public string Name { get; set; } = string.Empty;
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
    public decimal SalesPrice { get; set; }
    public int QuantityInStock { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Supplier { get; set; } = string.Empty;
    public bool IsActive { get; set; }

}
