using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tarefas.Infra.Tarefa.Model;

namespace Tarefas.Infra.Tarefa.Command
{
    public class GetAllTarefasCommand : IRequest<TarefasModel>
    {
        public PaginacaoModel Page { get; set; }
    }
}
