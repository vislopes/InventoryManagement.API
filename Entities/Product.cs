namespace InventoryManagement.API.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public decimal CostPrice { get; set; } 
        public decimal SalesPrice { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public Category Category { get; set; } = null!;
        public Supplier Supplier { get; set; } = null!;
        public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();
        public ICollection<SalesOrderItem> SalesOrderItems { get; set; } = new List<SalesOrderItem>();

    }
}
