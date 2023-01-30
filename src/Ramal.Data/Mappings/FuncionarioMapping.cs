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
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(f => f.Ramal)
                .IsRequired()
                .HasColumnType("varchar(7)");

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            

            builder.ToTable("Funcionarios");
        }
    }
}
