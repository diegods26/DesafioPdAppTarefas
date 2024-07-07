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
        public string Senha { get; private set; } = string.Empty;
        public DateTime? DataCriacao { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }

        public virtual ICollection<Tarefa>? Tarefas { get; set; }

        public static Usuario AdicionaUsuario(string nome, string senha, DateTime? dataCriacao)
        {
            var usuario = new Usuario
            {
                Id = 0,
                Nome = nome,
                Senha = senha,
                DataCriacao = dataCriacao
            };

            return usuario;
        }

        public static Usuario AtualizaUsuario(int id, string nome, string senha, DateTime? dataAtualizacao)
        {
            var usuario = new Usuario
            {
                Id = id,
                Nome = nome,
                Senha = senha,
                DataCriacao = dataAtualizacao
            };

            return usuario;
        }

        public static Usuario RemoveUsuario(int id, string nome, string senha, DateTime? dataAtualizacao)
        {
            var usuario = new Usuario
            {
                Id = id,
                Nome = nome,
                Senha = senha,
                DataCriacao = dataAtualizacao
            };

            return usuario;
        }

    }
}
