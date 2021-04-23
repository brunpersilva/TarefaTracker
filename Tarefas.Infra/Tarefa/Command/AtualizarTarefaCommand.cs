using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tarefas.Infra.Tarefa.Model;

namespace Tarefas.Infra.Tarefa.Command
{
    public class AtualizarTarefaCommand : IRequest<TarefaCriada>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
