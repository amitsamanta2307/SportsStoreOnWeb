using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsStoreOnWeb.ApplicationCore.Entities;

namespace SportsStoreOnWeb.Infrastructure.Data.Config
{
    public class CategoryTypeConfiguration : IEntityTypeConfiguration<CategoryType>
    {
        public void Configure(EntityTypeBuilder<CategoryType> builder)
        {
            builder.HasKey(ct => ct.Id);

            builder.Property(ct => ct.Id)
               .UseHiLo("category_type_hilo")
               .IsRequired();

            builder.Property(ct => ct.Type)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}