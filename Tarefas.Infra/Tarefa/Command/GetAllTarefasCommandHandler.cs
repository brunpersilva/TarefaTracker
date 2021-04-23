using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tarefas.Infra.Tarefa.Model;
using TarefasDomain.Models;

namespace Tarefas.Infra.Tarefa.Command
{
    public class GetAllTarefasCommandHandler : IRequestHandler<GetAllTarefasCommand, IList<TarefaCriada>>
    {

        private IConfiguration _configuration { get; }
        readonly string _connectionString;

        public GetAllTarefasCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IList<TarefaCriada>> Handle(GetAllTarefasCommand request, CancellationToken cancellationToken)
        {
            var tarefas = new List<TarefaCriada>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = $"SELECT Id, Titulo, Descricao FROM Tarefas";

                var command = new SqlCommand(query, connection);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var tarefa = new TarefaCriada
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Titulo = reader["Titulo"].ToString(),
                        Descricao = reader["Descricao"].ToString()
                    };
                    tarefas.Add(tarefa);
                };

                connection.Close();
            }

            return tarefas;
        }


    }

}
