using DesafioPdAppTarefas.Domain.Interfaces;
using DesafioPdAppTarefas.Domain.Models;
using DesafioPdAppTarefas.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPdAppTarefas.Infra.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppTarefasDb _context;

        public TarefaRepository(AppTarefasDb context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> GetTarefas()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa> GetTarefaById(int id)
        {
            return await _context.Tarefas
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }

        public void AddTarefa(Tarefa tarefa)
        {
            _context.Add(tarefa);
            _context.SaveChanges();
        }

        public void UpdateTarefa(Tarefa tarefa)
        {
            _context.Update(tarefa);
            _context.SaveChanges();
        }

        public void DeleteTarefa(Tarefa tarefa)
        {
            _context.Remove(tarefa);
            _context.SaveChanges();
        }
    }
}
