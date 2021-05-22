using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tarefas.Infra.AppConfigurations;

namespace Tarefas.Infra.Tarefa.Command
{
   public class RemoverTarefaCommandHandler : IRequestHandler<RemoverTarefaCommand, Unit>
    {
        private IAppConfiguration _configuration { get; }

        public RemoverTarefaCommandHandler(IAppConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Unit> Handle(RemoverTarefaCommand request, CancellationToken cancellationToken)
        {
            // define INSERT query with parameters
            string query = $"Delete From Tarefas Where Id = @Id";

            // create connection and command
            using (SqlConnection connection = new SqlConnection(_configuration.ConnectionString))
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
