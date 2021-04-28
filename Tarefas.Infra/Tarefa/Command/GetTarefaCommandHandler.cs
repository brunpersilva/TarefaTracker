using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tarefas.Infra.Tarefa.Model;
using TarefasDomain.Models;

namespace Tarefas.Infra.Tarefa.Command
{
    public class GetTarefaCommandHandler : IRequestHandler<GetTarefaCommand, TarefaCriada>
    {

        private IConfiguration _configuration { get; }
        readonly string _connectionString;

        public GetTarefaCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<TarefaCriada> Handle(GetTarefaCommand request, CancellationToken cancellationToken)
        {
            var tarefa = new TarefaModel();

            using (var connection = new SqlConnection(_connectionString))
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
