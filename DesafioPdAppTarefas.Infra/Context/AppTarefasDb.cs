using DesafioPdAppTarefas.Domain.Models;
using DesafioPdAppTarefas.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPdAppTarefas.Infra.Context
{
    public class AppTarefasDb : DbContext
    {
        public AppTarefasDb(DbContextOptions<AppTarefasDb> options) : base(options)
        {            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
        }
    }
}
