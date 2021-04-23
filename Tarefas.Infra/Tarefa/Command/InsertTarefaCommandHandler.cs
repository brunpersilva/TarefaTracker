using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tarefas.Infra.Tarefa.Model;

namespace Tarefas.Infra.Tarefa.Command
{
    public class InsertTarefaCommandHandler : IRequestHandler<InsertTarefaCommand, TarefaCriada>
    {
        private IConfiguration _configuration { get; }
        readonly string _connectionString;

        public InsertTarefaCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<TarefaCriada> Handle(InsertTarefaCommand request, CancellationToken cancellationToken)
        {
            string query = "INSERT INTO Tarefas (Titulo, Descricao) " +
                           "VALUES (@Titulo, @Descricao); SELECT CAST(scope_identity() AS int)";

            int newID;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@Titulo", SqlDbType.NVarChar, 100).Value = request.Titulo;
                command.Parameters.Add("@Descricao", SqlDbType.VarChar, 300).Value = request.Descricao;
                
                connection.Open();
                newID = (int)command.ExecuteScalar();
                command.ExecuteNonQuery();
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
