using DesafioPdAppTarefas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPdAppTarefas.Infra.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("TB_TAREFA");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(t => t.Titulo)
                .HasColumnName("TITULO")
                .IsRequired();

            builder.Property(t => t.Descricao)
                .HasColumnName("DESCRICAO")
                .IsRequired();

            builder.Property(t => t.Status)
                .HasColumnName("STATUS_TAREFA")
                .IsRequired();

            builder.Property(t => t.DataCriacao)
                .HasColumnName("DATA_CRIACAO");

            builder.Property(t => t.DataAtualizacao)
                .HasColumnName("DATA_ATUALIZACAO");

            builder.Property(t => t.IdUsuario)
                .HasColumnName("USUARIO_ID")
                .IsRequired();

            builder.HasOne(t => t.Usuario)
                .WithMany(t => t.Tarefas)
                .HasForeignKey(t => t.IdUsuario);
        }
    }
}
