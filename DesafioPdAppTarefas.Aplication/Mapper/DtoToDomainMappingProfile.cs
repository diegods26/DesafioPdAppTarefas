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
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            #region Usuario
            CreateMap<UsuarioDTO, Usuario>()
                    .ConstructUsing(vm => Usuario.AdicionaUsuario(vm.Nome, vm.Senha, vm.DataCriacao));

            CreateMap<UsuarioDTO, Usuario>()
                    .ConstructUsing(vm => Usuario.AtualizaUsuario(vm.Id, vm.Nome, vm.Senha, vm.DataAtualizacao));

            CreateMap<UsuarioDTO, Usuario>()
                    .ConstructUsing(vm => Usuario.RemoveUsuario(vm.Id, vm.Nome, vm.Senha, vm.DataAtualizacao));
            #endregion

            #region Tarefas
            CreateMap<TarefaDTO, Tarefa>()
                .ConstructUsing(vm => Tarefa.IncluiTarefa(vm.Titulo, vm.Descricao, vm.Status, vm.IdUsuario));

            CreateMap<TarefaDTO, Tarefa>()
                .ConstructUsing(vm => Tarefa.AtualizaTarefa(vm.Id, vm.Titulo, vm.Descricao, vm.Status, vm.IdUsuario));

            CreateMap<TarefaDTO, Tarefa>()
                .ConstructUsing(vm => Tarefa.RemoveTarefa(vm.Id, vm.Titulo, vm.Descricao, vm.Status, vm.IdUsuario));
            #endregion
        }
    }
}
