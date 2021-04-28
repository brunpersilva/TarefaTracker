using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefas.Infra.Tarefa.Model
{
   public class TarefasModel
    {
        public IList<TarefaCriada> Tarefas { get; set; }
        public PaginacaoModel Pagina { get; set; }
    }
}
