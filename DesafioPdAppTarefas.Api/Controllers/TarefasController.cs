using AutoMapper;
using DesafioPdAppTarefas.Aplication.DTOs;
using DesafioPdAppTarefas.Domain.Interfaces;
using DesafioPdAppTarefas.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPdAppTarefas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;
        private IMapper _mapper;

        public TarefasController(ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTarefas()
        {
            return Ok(_mapper.Map<List<TarefaDTO>>(await _tarefaRepository.GetTarefas()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarefaById(int id)
        {
            return Ok(_mapper.Map<TarefaDTO>(await _tarefaRepository.GetTarefaById(id)));
        }

        [HttpGet("tarefas-por-usuario-id")]
        public async Task<IActionResult> GetLisOfTarefaByUserId(int id)
        {
            return Ok(_mapper.Map<List<TarefaDTO>>(await _tarefaRepository.GetTarefasByUserId(id)));
        }

        [HttpPost]
        public IActionResult PostTarefa([FromBody] TarefaDTO tarefaDTO)
        {
            if (tarefaDTO != null)
            {
                var tarefa = _mapper.Map<Tarefa>(tarefaDTO);
                _tarefaRepository.AddTarefa(tarefa);
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult PutTarefa([FromBody] TarefaDTO tarefaDTO)
        {
            if (tarefaDTO.Id > 0)
            {
                var tarefa = _mapper.Map<Tarefa>(tarefaDTO);
                _tarefaRepository.UpdateTarefa(tarefa);
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(int id)
        {
            if (id > 0)
            {               
                var tarefa = _mapper.Map<Tarefa>(await _tarefaRepository.GetTarefaById(id));
                _tarefaRepository.DeleteTarefa(tarefa);
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
