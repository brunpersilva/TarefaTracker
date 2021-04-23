using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tarefas.Infra.Tarefa.Model;

namespace Tarefas.Infra.Tarefa.Command
{
    public class InsertTarefaCommand : IRequest<TarefaCriada>
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
