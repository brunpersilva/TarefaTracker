using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefas.Infra.Tarefa.Command
{
    public class GetTarefaCommandValidator : AbstractValidator<GetTarefaCommand>
    {
        public GetTarefaCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
  
}
