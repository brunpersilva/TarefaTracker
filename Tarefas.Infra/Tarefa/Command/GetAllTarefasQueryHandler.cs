using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tarefas.Infra.Tarefa.Model;
using TarefasDomain.Models;
using System.Data;
using Tarefas.Infra.Tarefa.Model.PaginacaoModels;
using Tarefas.Infra.AppConfigurations;

namespace Tarefas.Infra.Tarefa.Command
{
    public class GetAllTarefasQueryHandler : IRequestHandler<GetAllTarefasQuery, ResultadoBuscaTarefasModel>
    {

        private IAppConfiguration _configuration { get; }


        public GetAllTarefasQueryHandler(IAppConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResultadoBuscaTarefasModel> Handle(GetAllTarefasQuery request, CancellationToken cancellationToken)
        {
            var result = new ResultadoBuscaTarefasModel { Tarefas = new List<TarefaCriada>(), Paginacao = new ResultadoBuscaPaginadaModel() };
            result.Paginacao.PaginaAtual = request.PaginaAtual;

            using (SqlConnection connection = new SqlConnection(_configuration.ConnectionString))
            using (SqlCommand command = new SqlCommand("spGetAllTarefas", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ItensPorPagina", request.ItensPorPagina);
                command.Parameters.AddWithValue("@PaginaAtual", request.PaginaAtual);
                connection.Open();

                var reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {

                    var tarefa = new TarefaCriada
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Titulo = reader["Titulo"].ToString(),
                        Descricao = reader["Descricao"].ToString()
                    };
                    result.Tarefas.Add(tarefa);

                };

                reader.NextResult();
                reader.Read();

                result.Paginacao.TotalItens = Convert.ToInt32(reader["TotalItens"]);
                result.Paginacao.TotalPaginas = Convert.ToInt32(reader["TotalPages"]);

            }

            return result;
        }


    }

}
