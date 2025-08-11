using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOJ.Domain.Entities;
using MOJ.Domain.Enums;
using MOJ.Infrastructure.Persistence.Contracts;

namespace MOJ.Infrastructure.Persistence.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(EntityNames.Product);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Quantity)
                .IsRequired();

            builder.Property(e => e.UnitsInStock)
                .IsRequired();

            builder.Property(e => e.UnitsOnOrder)
                .IsRequired();

            builder.Property(e => e.SupplierId)
                .IsRequired();

            builder.OwnsOne(e => e.ProductBasicInfo, owned =>
            {
                owned.Property(c => c.ProductUnit).HasConversion(x => x.Value, x => ProductUnit.FromValue(x)).HasColumnName("ProductUnit");
                owned.Property(c => c.ReorderLevel).IsRequired();
                owned.Property(c => c.UnitPrice).IsRequired();
            });


            builder.HasOne(e => e.Supplier)
                .WithMany(c => c.Products)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}