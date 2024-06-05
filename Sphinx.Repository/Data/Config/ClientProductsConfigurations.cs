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
    internal class ClientProductsConfigurations : IEntityTypeConfiguration<ClientProducts>
    {
        public void Configure(EntityTypeBuilder<ClientProducts> builder)
        {
            builder.HasKey(cp => cp.Id);

            builder.Property(cp => cp.StartDate)
                .IsRequired();

            builder.Property(cp => cp.EndDate)
                .IsRequired(false);

            builder.Property(cp => cp.License)
                 .IsRequired()
                 .HasMaxLength(255);

            // Relation between Client And ClientProducts
            builder.HasOne(cp => cp.Client)
                  .WithMany(cp => cp.ClientProducts)
                  .HasForeignKey(cp => cp.ClientId);

            // Relation between Product And ClientProducts
            builder.HasOne(cp => cp.Product)
                  .WithMany(cp => cp.ClientProducts)
                  .HasForeignKey(cp => cp.ProductId);



        }
    }
}

