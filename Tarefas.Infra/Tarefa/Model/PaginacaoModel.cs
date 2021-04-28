using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefas.Infra.Tarefa.Model
{
   public class PaginacaoModel
    {
        public int PageSize { get; set; }
        public int CurrentIndex { get; set; }
        public int LastRecord { get; set; }
    }
}
