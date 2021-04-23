using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasDomain.Models;

namespace Tarefas.Domain.Interfaces
{
    public interface ITarefasRepository
    {
        int InsertTarefa(TarefasModel tarefa);
        int ExcluirTarefa(int id);
        int AtualizarTarefa(TarefasModel tarefa);
        TarefasModel ObterTarefaPorId(int id);
        IEnumerable<TarefasModel> ObterTodasTarefas();

    }
}
