using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefas.Infra.Tarefa.Command
{
    public class RemoverTarefaCommand : IRequest
    {
        public int Id { get; set; }
    }
}
