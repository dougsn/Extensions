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
    public class ComputadorMapping : IEntityTypeConfiguration<Computador>
    {
        public void Configure(EntityTypeBuilder<Computador> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Hostname)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(e => e.Modelo)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(e => e.Cpu)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(e => e.Memoria)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(e => e.Disco)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(e => e.SistemaOperacional)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(e => e.Observacao)
                .IsRequired(false)
                .HasColumnType("longtext");



            builder.ToTable("Computadores");

        }
    }
}
