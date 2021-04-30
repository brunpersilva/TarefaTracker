using System.Collections.Generic;

namespace Tarefas.Infra.Tarefa.Model.PaginacaoModels
{
    public class ResultadoBuscaTarefasModel
    {
        public ResultadoBuscaPaginadaModel Paginacao { get; set; }
        public IList<TarefaCriada> Tarefas { get; set; } = new List<TarefaCriada>();
    }
}
