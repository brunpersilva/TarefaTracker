﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tarefas.Infra.Tarefa.Model;

namespace Tarefas.Infra.Tarefa.Command
{
    public class GetTarefaCommand : IRequest<TarefaCriada>
    {
        public int Id { get; set; }
    }
}
