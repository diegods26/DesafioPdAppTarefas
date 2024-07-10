using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPdAppTarefas.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; private set; } = string.Empty;
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public DateTime? DataCriacao { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }

        public virtual ICollection<Tarefa>? Tarefas { get; set; }

        public static Usuario AdicionaUsuario(string nome, byte[] passwordHash, byte[] passwordSalt, DateTime? dataCriacao, DateTime? dataAtualizacao)
        {
            var usuario = new Usuario
            {
                Id = 0,
                Nome = nome,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                DataCriacao = dataCriacao,
                DataAtualizacao = dataAtualizacao
            };

            return usuario;
        }

        public static Usuario AtualizaUsuario(int id, string nome, byte[] passwordHash, byte[] passwordSalt, DateTime? dataCriacao, DateTime? dataAtualizacao)
        {
            var usuario = new Usuario
            {
                Id = id,
                Nome = nome,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                DataCriacao = dataAtualizacao,
                DataAtualizacao = dataAtualizacao
            };

            return usuario;
        }

        public static Usuario RemoveUsuario(int id, string nome, byte[] passwordHash, byte[] passwordSalt, DateTime? dataAtualizacao)
        {
            var usuario = new Usuario
            {
                Id = id,
                Nome = nome,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                DataCriacao = dataAtualizacao
            };

            return usuario;
        }

    }
}
