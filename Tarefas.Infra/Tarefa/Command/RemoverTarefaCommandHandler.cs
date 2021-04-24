using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tarefas.Infra.Tarefa.Command
{
   public class RemoverTarefaCommandHandler : IRequestHandler<RemoverTarefaCommand, Unit>
    {
        private IConfiguration _configuration { get; }
        readonly string _connectionString;

        public RemoverTarefaCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Unit> Handle(RemoverTarefaCommand request, CancellationToken cancellationToken)
        {
            // define INSERT query with parameters
            string query = $"Delete From Tarefas Where Id = @Id";

            // create connection and command
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int, 100).Value = request.Id;

                // open connection, execute INSERT, close connection
                await connection.OpenAsync();
                command.ExecuteNonQuery();
            }

            return Unit.Value;
        }
    }
}
