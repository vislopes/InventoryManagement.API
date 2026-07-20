namespace InventoryManagement.API.Entities
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public ICollection<SalesOrderItem> SalesOrderItems { get; set; } = new List<SalesOrderItem>();
    }
}
