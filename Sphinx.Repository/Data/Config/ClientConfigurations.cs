using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sphinx.Core.Entities;
using Sphinx.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sphinx.Repository.Data.Config
{
    internal class ClientConfigurations : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Code)
                 .IsRequired()
                 .HasMaxLength(9);
                
            builder.HasIndex(c => c.Code).IsUnique().HasName("IX_Code");

            builder.Property(c => c.Class)
                   .IsRequired();

            builder.Property(c => c.Class)
                .HasConversion(
            cClass => cClass.ToString(),
            cClass => (ClientClass)Enum.Parse(typeof(ClientClass), cClass)
            );

            builder.Property(c => c.State)
                   .IsRequired();

            builder.Property(c => c.State)
                .HasConversion(
                cState => cState.ToString(),
                cState => (ClientState)Enum.Parse(typeof(ClientState), cState)
                );


            // Relation between Client And ClientProducts
            builder.HasMany(c => c.ClientProducts)
                .WithOne(c => c.Client)
                .HasForeignKey(c => c.ClientId);
        }
    }
}
