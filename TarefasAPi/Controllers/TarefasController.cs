using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarefas.Domain.Interfaces;
using Tarefas.Infra.Tarefa.Command;
using TarefasDomain.Models;

namespace Tarefas.APi.Controllers
{
    [ApiController]
    [Route("api/tarefas")]
    public class TarefasController : BaseController
    {        

        [HttpGet]
        [Route("GetTarefa/{id}")]
        public async Task<IActionResult> GetTarefaPorId([FromRoute] int id) =>
            Ok(await Mediator.Send(new GetTarefaCommand {Id = id }));

        [HttpGet]
        [Route("GetAllTarefas")]
        public async Task<IActionResult> GetAllTarefas() =>
            Ok(await Mediator.Send(new GetAllTarefasCommand { }));

        [HttpPost]
        [Route("InserirTarefa")]
        public async Task<IActionResult> InserirTarefa([FromBody] InsertTarefaCommand request) =>
            Ok(await Mediator.Send(request));

        [HttpPost]
        [Route("AtualizarTarefa")]
        public async Task<IActionResult> AtualizarTarefa([FromBody] AtualizarTarefaCommand request) =>
            Ok(await Mediator.Send(request));

        [HttpDelete]
        [Route("ExcluirTarefa/{Id}")]
        public async Task<IActionResult> RemoverTarefa([FromRoute] int id) =>
            Ok(await Mediator.Send(new RemoverTarefaCommand { Id = id }));        

    }
}

