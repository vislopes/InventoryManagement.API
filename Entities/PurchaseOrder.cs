namespace InventoryManagement.API.Entities
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;
        public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();

    }
}
