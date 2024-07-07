using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPdAppTarefas.Domain.Models
{
    public class Tarefa
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public StatusTarefa Status { get; private set; }
        public int IdUsuario { get; private set; }
        public virtual Usuario? Usuario { get; private set; }

        public static Tarefa IncluiTarefa(string titulo, string descricao, StatusTarefa status, int idUsuario)
        {
            var tarefa = new Tarefa
            {
                Id = 0,
                Titulo = titulo,
                Descricao = descricao,
                Status = status,
                IdUsuario = idUsuario
            };

            return tarefa;
        }

        public static Tarefa AtualizaTarefa(int id, string titulo, string descricao, StatusTarefa status, int idUsuario)
        {
            var tarefa = new Tarefa
            {
                Id = id,
                Titulo = titulo,
                Descricao = descricao,
                Status = status,
                IdUsuario = idUsuario
            };

            return tarefa;
        }

        public static Tarefa RemoveTarefa(int id, string titulo, string descricao, StatusTarefa status, int idUsuario)
        {
            var tarefa = new Tarefa
            {
                Id = id,
                Titulo = titulo,
                Descricao = descricao,
                Status = status,
                IdUsuario = idUsuario
            };

            return tarefa;
        }
    }
}
