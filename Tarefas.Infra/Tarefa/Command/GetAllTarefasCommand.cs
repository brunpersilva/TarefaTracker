using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tarefas.Infra.Tarefa.Model;
using Tarefas.Infra.Tarefa.Model.PaginacaoModels;

namespace Tarefas.Infra.Tarefa.Command
{
    public class GetAllTarefasCommand : IRequest<ResultadoBuscaTarefasModel>
    {
        public int PaginaAtual { get; set; }

        public int ItensPorPagina { get; set; }
    }
}
