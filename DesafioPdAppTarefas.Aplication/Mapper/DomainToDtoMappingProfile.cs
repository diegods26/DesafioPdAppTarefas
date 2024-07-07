using AutoMapper;
using DesafioPdAppTarefas.Aplication.DTOs;
using DesafioPdAppTarefas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPdAppTarefas.Aplication.Mapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Tarefa, TarefaDTO>();
        }
    }
}
