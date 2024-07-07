using DesafioPdAppTarefas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPdAppTarefas.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> GetTarefas();
        Task<Tarefa> GetTarefaById(int id);
        void AddTarefa(Tarefa tarefa);
        void UpdateTarefa(Tarefa tarefa);
        void DeleteTarefa(Tarefa tarefa);
    }
}
