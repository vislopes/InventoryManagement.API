using System.Globalization;

namespace InventoryManagement.API.DTOs.Products;

public class UpdateProductDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
    public decimal CostPrice { get; set; }
    public decimal SalesPrice { get; set; }
    public int QuantityInStock { get; set; }
    public int CategoryId { get; set; }
    public int SupplierId { get; set; }
    public bool IsActive { get; set; }
}
