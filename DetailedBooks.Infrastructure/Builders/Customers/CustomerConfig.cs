﻿using DetailedBooks.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DetailedBooks.Infrastructure.Builders.Customers
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasOne(e => e.Avatar)
                   .WithOne(e => e.Customer)
                   .HasForeignKey<Customer>(e => e.AvatarId)
                   .IsRequired(false);

            builder.HasMany(e => e.CreatedBooks)
                   .WithOne(e => e.Owner)
                   .HasForeignKey(e => e.OwnerId);

            builder.HasMany(e => e.BookRatings)
                   .WithOne(e => e.Customer)
                   .HasForeignKey(e => e.CustomerId);
        }
    }
}
