using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefas.Infra.Tarefa.Command
{
    public class AtualizarTarefaCommandValidator : AbstractValidator<AtualizarTarefaCommand>
    {
        public AtualizarTarefaCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
