﻿using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).UseHiLo("customerseq");

            builder.OwnsOne(m => m.Email, e => { e.Property(e => e.Value).HasColumnName("Email").IsRequired(true); });
            builder.OwnsOne(m => m.Name, e => { e.Property(e => e.Value).HasColumnName("Name").IsRequired(true); });

            //   builder.Property<CustomerName>("Value").HasField("_name").IsRequired();

            // builder.Property<string>("Email").IsRequired();
        }
    }
}
