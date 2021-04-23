using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarefas.Domain.Interfaces;
using TarefasDomain.Models;

namespace TarefasDomain.Controllers
{
    [ApiController]
    [Route("api/tarefas")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefasRepository _tarefasRepository;

        public TarefasController(ITarefasRepository tarefasRepository)
        {
            _tarefasRepository = tarefasRepository;
        }

        [HttpGet]
        [Route("GetTarefa/{Id}")]
        public IActionResult GetTarefaPorId([FromRoute] int id)
        {
            var tarefa = _tarefasRepository.ObterTarefaPorId(id);

            if (tarefa == null)
                return NotFound();

            return Ok(tarefa);
        }

        [HttpGet]
        [Route("GetTarefas")]
        public IActionResult Get()
        {
            var result = _tarefasRepository.ObterTodasTarefas();

            return Ok(result);
        }

        [HttpPost]
        [Route("InserirTarefa")]
        public IActionResult InserirTarefa([FromBody] TarefasModel tarefas)
        {
            var novaTarefa = new TarefasModel { Titulo = tarefas.Titulo, Descricao = tarefas.Descricao };

            var result = _tarefasRepository.InsertTarefa(novaTarefa);

            return Ok(result);
        } 

        [HttpPost]
        [Route("AtualizarTarefa")]
        public IActionResult AtualizarTarefa([FromBody] TarefasModel tarefas)
        {
            var status = _tarefasRepository.AtualizarTarefa(tarefas);

            if (status != 1)
                return StatusCode(500, "Error ao excluir tarefa");

            return NoContent();
        }

        [HttpDelete]
        [Route("ExcluirTarefa/{Id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var status = _tarefasRepository.ExcluirTarefa(id);

            if (status != 1)
                return StatusCode(500, "Error ao excluir tarefa");

            return NoContent();
        }

    }
}

