using AutoMapper;
using DesafioPdAppTarefas.Api.ViewModels;
using DesafioPdAppTarefas.Aplication.DTOs;
using DesafioPdAppTarefas.Domain.Interfaces;
using DesafioPdAppTarefas.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace DesafioPdAppTarefas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            return Ok(_mapper.Map<List<UsuarioDTO>>(await _usuarioRepository.GetUsuario()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            return Ok(_mapper.Map<UsuarioDTO>(await _usuarioRepository.GetUsuarioById(id)));
        }

        [HttpGet("obter-usurio-por-nome")]
        public async Task<IActionResult> GetUsuarioByName(string nome)
        {
            return Ok(_mapper.Map<UsuarioDTO>(await _usuarioRepository.GetUsuarioByName(nome)));
        }

        [HttpPost]
        public IActionResult PostUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO != null)
            {
                var usuario = _mapper.Map<Usuario>(usuarioDTO);
                _usuarioRepository.AddUsuario(usuario);
            }
            else
            {
                return BadRequest();
            }

            return Ok();
            
        }

        [HttpPut]
        public IActionResult UpdateUsuario([FromBody] UsuarioViewModel model)
        {
            if (model.Id > 0)
            {
                using var hmac = new HMACSHA512();
                var userDto = new UsuarioDTO
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Senha)),
                    PasswordSalt = hmac.Key,
                    DataAtualizacao = model.DataAtualizacao
                };

                var usuario = _mapper.Map<Usuario>(userDto);
                _usuarioRepository.UpdateUsuario(usuario);
            }
            else
            {
                return BadRequest();
            }

            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (id > 0)
            {
                var usuario = await _usuarioRepository.GetUsuarioById(id);
                _usuarioRepository.DeleteUsuario(usuario);
            }
            else
            {
                return BadRequest();
            }

            return Ok();

        }
    }
}
