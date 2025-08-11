using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOJ.Domain.Entities;
using MOJ.Infrastructure.Persistence.Contracts;

namespace MOJ.Infrastructure.Persistence.Entity_Configurations
{
    internal sealed class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable(EntityNames.Supplier);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(250)
                .IsRequired();

        }
    }
}