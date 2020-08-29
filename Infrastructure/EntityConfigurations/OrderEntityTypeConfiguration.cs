using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).UseHiLo("orderseq");

            builder.Property(b => b.CreatedDate).IsRequired();

            builder.HasMany(b => b.OrderLines)
                .WithOne();

            builder.Metadata
                .FindNavigation(nameof(Order.OrderLines))
                .SetPropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
