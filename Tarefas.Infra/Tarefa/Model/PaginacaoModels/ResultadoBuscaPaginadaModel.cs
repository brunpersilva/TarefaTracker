namespace Tarefas.Infra.Tarefa.Model.PaginacaoModels
{
    public class ResultadoBuscaPaginadaModel
    {
        public int PaginaAtual { get; set; }
        public int TotalItens { get; set; }
        public int TotalPaginas { get; set; }

    }
}
