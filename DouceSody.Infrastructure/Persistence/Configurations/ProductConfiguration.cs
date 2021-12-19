using DouceSody.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DouceSody.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        //builder.Property(t => t.Title)
        //    .HasMaxLength(200)
        //    .IsRequired();

        //builder
        //    .OwnsOne(b => b.Colour);
    }
}
