using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAPI.Domain.Entities;

namespace ProductAPI.Infrastructure.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.OwnsOne(p => p.Price, price =>
            {
                price.Property(p => p.Value).HasColumnName("Value");
                price.Property(p => p.Currency).HasColumnName("Currency");
            });

            builder.Property(p => p.Stock)
                .IsRequired();
        }
    }
}