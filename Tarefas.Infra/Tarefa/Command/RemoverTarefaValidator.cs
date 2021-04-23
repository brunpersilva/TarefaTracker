using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefas.Infra.Tarefa.Command
{
   public class RemoverTarefaValidator: AbstractValidator<RemoverTarefaCommand>
    {
        public RemoverTarefaValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
