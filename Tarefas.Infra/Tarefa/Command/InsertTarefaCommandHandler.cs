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
    public class InsertTarefaCommandHandler : IRequestHandler<InsertTarefaCommand, TarefaCriada>
    {
        private IAppConfiguration _configuration { get; }

        public InsertTarefaCommandHandler(IAppConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<TarefaCriada> Handle(InsertTarefaCommand request, CancellationToken cancellationToken)
        {
            string query = "INSERT INTO Tarefas (Titulo, Descricao) " +
                           "VALUES (@Titulo, @Descricao); SELECT CAST(scope_identity() AS int)";

            int newID;
            using (SqlConnection connection = new SqlConnection(_configuration.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@Titulo", SqlDbType.NVarChar, 100).Value = request.Titulo;
                command.Parameters.Add("@Descricao", SqlDbType.VarChar, 300).Value = request.Descricao;

                connection.Open();
                newID = (int)command.ExecuteScalar();
                await command.ExecuteNonQueryAsync();
            }

            return new TarefaCriada
            {
                Id = newID,
                Titulo = request.Titulo,
                Descricao = request.Descricao
            };
        }
    }
}
