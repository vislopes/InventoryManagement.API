using InventoryManagement.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.API.Configurations;

public class PurchaseOrderItemConfiguration : IEntityTypeConfiguration<PurchaseOrderItem>
{
    public void Configure(EntityTypeBuilder<PurchaseOrderItem> builder)
    {
        builder.ToTable("PurchaseOrderItems");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.UnitPrice)
            .HasPrecision(18,2);

        builder.HasOne(i => i.PurchaseOrder)
            .WithMany(po => po.PurchaseOrderItems)
            .HasForeignKey(i => i.PurchaseOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.Product)
            .WithMany(p => p.PurchaseOrderItems)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(i => i.ProductId);
    }
}
