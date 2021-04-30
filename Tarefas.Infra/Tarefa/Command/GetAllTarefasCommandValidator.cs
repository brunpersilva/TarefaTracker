using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefas.Infra.Tarefa.Command
{
    public class GetAllTarefasCommandValidator : AbstractValidator<GetAllTarefasCommand>
    {
        public GetAllTarefasCommandValidator()
        {
            RuleFor(x => x.ItensPorPagina).NotEmpty().NotNull();

            RuleFor(x => x.PaginaAtual).NotEmpty().NotNull();
        }
    }

}
