using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    class OrderLineEntityTypeConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).UseHiLo("orderlineseq");

            builder.Property(b => b.ProductId).IsRequired();
            builder.Property(b => b.Price).IsRequired();
            builder.Property(b => b.Quantity).IsRequired();
            builder.Property<long>("OrderId").IsRequired();
        }
    }
}
