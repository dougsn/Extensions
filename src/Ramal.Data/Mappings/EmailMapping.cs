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
    public class EmailMapping : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Conta)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Senha)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Caixa_Email");

        }
    }
}
