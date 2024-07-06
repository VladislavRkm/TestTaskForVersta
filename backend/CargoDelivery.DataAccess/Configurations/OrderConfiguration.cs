using CargoDelivery.Core.Models;
using CargoDelivery.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CargoDelivery.DataAccess.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(o => o.SenderCity).HasMaxLength(Order.MAX_GEO_LENGTH).IsRequired();
        builder.Property(o => o.SenderAddress).HasMaxLength(Order.MAX_GEO_LENGTH).IsRequired();
        builder.Property(o => o.RecipientCity).HasMaxLength(Order.MAX_GEO_LENGTH).IsRequired();
        builder.Property(o => o.RecipientAddress).HasMaxLength(Order.MAX_GEO_LENGTH).IsRequired();
        builder.Property(o => o.Weight).IsRequired();
        builder.Property(o => o.PickUpDate).IsRequired();

    }
}
