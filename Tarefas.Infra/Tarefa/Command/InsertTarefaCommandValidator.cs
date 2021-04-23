using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefas.Infra.Tarefa.Command
{
    public class InsertTarefaCommandValidator : AbstractValidator<InsertTarefaCommand>
    {
        public InsertTarefaCommandValidator()
        {
            RuleFor(x => x.Titulo).NotEmpty();

            RuleFor(x => x.Descricao).NotEmpty();
        }
    }
}
