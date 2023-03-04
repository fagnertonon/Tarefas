using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Tarefas.API.Application;
using Tarefas.Core.Controllers;
using Tarefas.Core.Mediator;
using Tarefas.Data.Models;
using Tarefas.Core.Messages.Integration;

namespace Tarefas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : MainController
    {
        private readonly ITarefaRepository _TarefaRepository;
        private readonly IMediatorHandler _mediator;
        private readonly ILogger<Tarefa> _logger;
        public TarefaController(ITarefaRepository TarefaRepository, IMediatorHandler mediator, ILogger<Tarefa> logger)
        {
            _TarefaRepository = TarefaRepository;
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet()]
        public async Task<IActionResult> ObterTodos()
        {
            var tarefas = await _TarefaRepository.ObterTodos();
            return CustomResponse(tarefas);
        }

        [HttpGet("{TarefaId:guid}")]
        public async Task<IActionResult> ObterTarefaId(Guid TarefaId)
        {
            var tarefa = await _TarefaRepository.ObterPorId(TarefaId);

            return CustomResponse(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarTarefa(RegistrarTarefaCommand Tarefa)
        {
            return CustomResponse(await _mediator.EnviarComando(Tarefa));
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarTarefa(AtualizarTarefaCommand Tarefa)
        {
            return CustomResponse(await _mediator.EnviarComando(Tarefa));
        }

        [HttpPut("concluir/{id:guid}")]
        public async Task<IActionResult> ConcluirTarefa(Guid id)
        {
            ConcluirTarefaCommand Tarefa = new ConcluirTarefaCommand(id);
            return CustomResponse(await _mediator.EnviarComando(Tarefa));
        }

        [HttpPut("desenvolver/{id:guid}")]
        public async Task<IActionResult> DesenvolverTarefa(Guid id)
        {
            DesenvolverTarefaCommand Tarefa = new DesenvolverTarefaCommand(id);
            return CustomResponse(await _mediator.EnviarComando(Tarefa));
        }
        [HttpDelete("{TarefaId:guid}")]
        public async Task<IActionResult> ExcluirTarefa(Guid TarefaId)
        {
            ExcluirTarefaCommand Tarefa = new ExcluirTarefaCommand(TarefaId);
            return CustomResponse(await _mediator.EnviarComando(Tarefa));
        }

        [HttpGet("status")]
        public async Task<IActionResult> ObterStatus()
        {
            var status = await _TarefaRepository.ObterStatus();
            return CustomResponse(status);
        }
    }
}