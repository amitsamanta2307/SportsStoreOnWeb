using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsStoreOnWeb.ApplicationCore.Entities;

namespace SportsStoreOnWeb.Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(p => p.Description)
                .IsRequired(false)
                .HasMaxLength(250);

            builder.Property(p => p.Price)
                .IsRequired(true)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(ct => ct.CategoryId);
        }
    }
}