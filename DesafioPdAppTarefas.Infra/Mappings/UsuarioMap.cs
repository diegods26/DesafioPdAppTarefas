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
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_USURIO");
            
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("USUARIO_ID")
                .IsRequired();

            builder.HasIndex(u => u.Nome)
                .IsUnique();

            builder.Property(u => u.Nome)
                .HasColumnName("NOME")                
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.PasswordHash)
                .HasColumnName("PASSWORD_HASH")
                .IsRequired();

            builder.Property(u => u.PasswordSalt)
                .HasColumnName("PASSWORD_SALT")
                .IsRequired();

            builder.Property(u => u.DataCriacao)
                .HasColumnName("DATA_CRIACAO");

            builder.Property(u => u.DataAtualizacao)
                .HasColumnName("DATA_ATUALIZACAO");

            builder.HasMany(u => u.Tarefas)
                .WithOne(u => u.Usuario);
        }
    }
}
