using AutoMapper;
using DesafioPdAppTarefas.Api.ViewModels;
using DesafioPdAppTarefas.Aplication.DTOs;
using DesafioPdAppTarefas.Domain.Account;
using DesafioPdAppTarefas.Domain.Interfaces;
using DesafioPdAppTarefas.Domain.Models;
using DesafioPdAppTarefas.Infra.Identity;
using DesafioPdAppTarefas.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;

namespace DesafioPdAppTarefas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITokenServices _tokenServices;
        private readonly IUsuarioRepository _usuarioRepository;

        public AccountController(IUsuarioRepository usuarioRepository, IMapper mapper, ITokenServices tokenServices)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _tokenServices = tokenServices;
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult<UserViewModel>> Register(RegisterViewModel model)
        {
            if (await UsuarioExiste(model.Nome) == false) return BadRequest("Usuário já existe!");

            using var hmac = new HMACSHA512();
            var userDto = new UsuarioDTO
            {
                Nome = model.Nome,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password)),
                PasswordSalt = hmac.Key,
                DataCriacao = DateTime.Now,
                DataAtualizacao = null
            };

            var user = Usuario.AdicionaUsuario(userDto.Nome, userDto.PasswordHash, userDto.PasswordSalt, userDto.DataCriacao, userDto.DataAtualizacao);
            _usuarioRepository.AddUsuario(user);

            var userVM = new UserViewModel
            {
                UserName = user.Nome,
                Token = _tokenServices.CreateToken(user)
            };

            return Ok(userVM);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserViewModel>> Login(LoginViewModel model)
        {
            var user = await _usuarioRepository.GetUsuarioByName(model.Nome);

            if (user == null || user.Nome != model.Nome) return Unauthorized("Nome de usuário inválido!");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Senha));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Senha inválida!");
            }

            var userVM = new UserViewModel
            {
                UserName = user.Nome,
                Token = _tokenServices.CreateToken(user)
            };

            return Ok(userVM);
        }

        private async Task<bool> UsuarioExiste(string nomeUsuario)
        {
            var user = await _usuarioRepository.GetUsuarioByName(nomeUsuario);
            if (user == null)
                return true;
            else
                return false;
        }
    }
}
