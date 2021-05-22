using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tarefas.Infra.AppConfigurations;
using Tarefas.Infra.Tarefa.Model;

namespace Tarefas.Infra.Tarefa.Command
{
    public class AtualizarTarefaCommandHandler : IRequestHandler<AtualizarTarefaCommand, TarefaCriada>
    {
        private IAppConfiguration _configuration { get; }


        public AtualizarTarefaCommandHandler(IAppConfiguration configuration)
        {
            _configuration = configuration;           
        }

        public async Task<TarefaCriada> Handle(AtualizarTarefaCommand request, CancellationToken cancellationToken)
        {
            // define INSERT query with parameters
            string query = "Update Tarefas  set Titulo = @Titulo,  Descricao = @Descricao Where Id = @Id";

            // create connection and command
            using (SqlConnection connection = new SqlConnection(_configuration.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // define parameters and their values
                command.Parameters.Add("@Id", SqlDbType.Int, 100).Value = request.Id;
                command.Parameters.Add("@Titulo", SqlDbType.NVarChar, 100).Value = request.Titulo;
                command.Parameters.Add("@Descricao", SqlDbType.VarChar, 300).Value = request.Descricao;

                // open connection, execute INSERT, close connection
                await connection.OpenAsync();
                var result = command.ExecuteNonQuery();
    

                return result == 1 ? new TarefaCriada
                {
                    Id = request.Id,
                    Descricao = request.Descricao,
                    Titulo = request.Titulo,
                } : throw new Exception("Erro ao atualizar dados da tarefa");

            }

        }
    }
}
