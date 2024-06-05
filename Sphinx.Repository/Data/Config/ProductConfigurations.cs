using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sphinx.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphinx.Repository.Data.Config
{
    internal class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                 .IsRequired()
                 .HasMaxLength(150);

            builder.Property(p => p.IsActive)
                 .IsRequired();

            // Relation between Product And ClientProducts
            builder.HasMany(p => p.ClientProducts)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);



        }
    }
}
