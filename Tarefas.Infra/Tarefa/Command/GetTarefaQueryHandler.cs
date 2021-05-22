using MediatR;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tarefas.Infra.AppConfigurations;
using Tarefas.Infra.Tarefa.Model;
using TarefasDomain.Models;

namespace Tarefas.Infra.Tarefa.Command
{
    public class GetTarefaQueryHandler : IRequestHandler<GetTarefaQuery, TarefaCriada>
    {

        private IAppConfiguration _configuration { get; }


        public GetTarefaQueryHandler(IAppConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<TarefaCriada> Handle(GetTarefaQuery request, CancellationToken cancellationToken)
        {
            var tarefa = new TarefaModel();

            using (var connection = new SqlConnection(_configuration.ConnectionString))
            {
                var query = $"SELECT Id, Titulo, Descricao FROM Tarefas WHERE Id = {request.Id}";

                var command = new SqlCommand(query, connection);

                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        tarefa.Id = Convert.ToInt32(reader["Id"]);
                        tarefa.Titulo = reader["Titulo"].ToString();
                        tarefa.Descricao = reader["Descricao"].ToString();
                    }
                }
                else
                    return null; //Retornar excessao personalizada
            }

            return (new TarefaCriada
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao
            });
        }
    }
}
