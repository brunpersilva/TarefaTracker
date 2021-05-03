using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefas.Infra.Tarefa.Command
{
    public class GetTarefaQueryValidator : AbstractValidator<GetTarefaQuery>
    {
        public GetTarefaQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
  
}
