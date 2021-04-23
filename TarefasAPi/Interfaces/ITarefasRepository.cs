using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasAPi.Models;

namespace TarefasAPi.Interfaces
{
    public interface ITarefasRepository
    {
        int InsertTarefa(TarefasModel tarefa);
        int DeleteTarefa(int id);
        int UpdateTarefa(TarefasModel tarefa); 
        TarefasModel ObterTarefaPorId(int id);
        IEnumerable<TarefasModel> GetTarefas();
       
    }
}
