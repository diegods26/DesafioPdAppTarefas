using DesafioPdAppTarefas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPdAppTarefas.Infra.Services
{
    public interface ITokenServices
    {
        string CreateToken(Usuario user);
    }
}
