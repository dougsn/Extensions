using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ramal.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Data.Mappings
{
    public class ImpressoraMapping : IEntityTypeConfiguration<Impressora>
    {
        public void Configure(EntityTypeBuilder<Impressora> builder)
        {
            
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Marca)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(i => i.Modelo)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(i => i.Ip)
                .IsRequired(false)
                .HasColumnType("varchar(50)");

            builder.Property(i => i.Tonner)
                .IsRequired()
                .HasColumnType("longtext");

            builder.Property(i => i.Observacao)
                .IsRequired(false)
                .HasColumnType("longtext");

            builder.ToTable("Impressoras");
        }
    }
}
