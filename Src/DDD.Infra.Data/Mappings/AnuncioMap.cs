using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infra.Data.Mappings
{
    public class AnuncioMap : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Marca)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Modelo)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.Versao)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.Ano)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(c => c.Quilometragem)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(c => c.Observacao)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
