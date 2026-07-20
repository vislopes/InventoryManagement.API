using InventoryManagement.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.API.Configurations;

public class SalesOrdeerItemConfiguration : IEntityTypeConfiguration<SalesOrderItem>
{
    public void Configure(EntityTypeBuilder<SalesOrderItem> builder)
    {
        builder.ToTable("SalesOrderItems");

        builder.HasKey(soi => soi.Id);

        builder.Property(soi => soi.UnitPrice)
            .HasPrecision(18,2);

        builder.HasOne(soi => soi.SalesOrder)
            .WithMany(so => so.SalesOrderItems)
            .HasForeignKey(soi => soi.SalesOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(soi => soi.Product)
            .WithMany(p => p.SalesOrderItems)
            .HasForeignKey(soi => soi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
