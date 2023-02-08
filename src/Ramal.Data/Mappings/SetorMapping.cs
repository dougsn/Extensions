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
    public class SetorMapping : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasMany(s => s.Funcionarios)
              .WithOne(f => f.Setor)
              .HasForeignKey(f => f.SetorId);

            builder.HasMany(s => s.Emails)
              .WithOne(f => f.Setor)
              .HasForeignKey(f => f.SetorId);

            builder.HasMany(s => s.Computadores)
              .WithOne(f => f.Setor)
              .HasForeignKey(f => f.SetorId);
            builder.HasMany(s => s.Impressoras)
             .WithOne(f => f.Setor)
             .HasForeignKey(f => f.SetorId);

            builder.ToTable("Setores");
        }
    }
}
