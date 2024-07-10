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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppTarefasDb _context;

        public UsuarioRepository(AppTarefasDb context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _context.Usuarios
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetUsuarioByName(string nome)
        {
            return await _context.Usuarios
                .Where(u => u.Nome == nome)
                .FirstOrDefaultAsync();
        }

        public void AddUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                var addUsuario = Usuario.AdicionaUsuario(usuario.Nome, usuario.PasswordHash, usuario.PasswordSalt, usuario.DataCriacao, usuario.DataAtualizacao);
                _context.Add(addUsuario);
                _context.SaveChanges();
            }
        }

        public void UpdateUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                var addUsuario = Usuario.AtualizaUsuario(usuario.Id, usuario.Nome, usuario.PasswordHash, usuario.PasswordSalt, usuario.DataCriacao, usuario.DataAtualizacao);
                _context.Update(addUsuario);
                _context.SaveChanges();
            }
        }

        public void DeleteUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                var addUsuario = Usuario.RemoveUsuario(usuario.Id , usuario.Nome, usuario.PasswordHash, usuario.PasswordSalt, usuario.DataAtualizacao);
                _context.Add(addUsuario);
                _context.SaveChanges();
            }
        }
    }
}
