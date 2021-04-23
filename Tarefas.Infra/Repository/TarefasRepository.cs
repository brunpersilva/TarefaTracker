using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tarefas.Domain.Interfaces;
using TarefasDomain.Models;

namespace TarefasDomain.Repository
{
    public class TarefasRepository : ITarefasRepository
    {
        readonly string _connectionString;
        private IConfiguration _configuration { get; }
        public TarefasRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public int InsertTarefa(TarefasModel tarefa)
        {
         
            string query = "INSERT INTO Tarefas (Titulo, Descricao) " +
                           "VALUES (@Titulo, @Descricao) ";

            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                
                command.Parameters.Add("@Titulo", SqlDbType.NVarChar, 100).Value = tarefa.Titulo;
                command.Parameters.Add("@Descricao", SqlDbType.VarChar, 300).Value = tarefa.Descricao;

                
                connection.Open();
                return command.ExecuteNonQuery();
            }

        }

        public int ExcluirTarefa(int Id)
        {
            // define INSERT query with parameters
            string query = $"Delete From Tarefas Where Id = @Id";

            // create connection and command
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int, 100).Value = Id;

                // open connection, execute INSERT, close connection
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public int AtualizarTarefa(TarefasModel tarefa)
        {
            // define INSERT query with parameters
            string query = "Update Tarefas  set Titulo = @Titulo,  Descricao = @Descricao Where Id = @Id";                          

            // create connection and command
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // define parameters and their values
                command.Parameters.Add("@Id", SqlDbType.Int, 100).Value = tarefa.Id;
                command.Parameters.Add("@Titulo", SqlDbType.NVarChar, 100).Value = tarefa.Titulo;
                command.Parameters.Add("@Descricao", SqlDbType.VarChar, 300).Value = tarefa.Descricao;

                // open connection, execute INSERT, close connection
                connection.Open();
                return command.ExecuteNonQuery();
            }

        }

        public TarefasModel ObterTarefaPorId(int id)
        {
            var tarefa = new TarefasModel();

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = $"SELECT Id, Titulo, Descricao FROM Tarefas WHERE Id = {id}";

                var command = new SqlCommand(query, connection);

                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tarefa.Id = Convert.ToInt32(reader["Id"]);
                        tarefa.Titulo = reader["Titulo"].ToString();
                        tarefa.Descricao = reader["Descricao"].ToString();                        
                    }
                }
                else
                    return null;
            }
            return tarefa;
        }

        public IEnumerable<TarefasModel> ObterTodasTarefas()
        {
            var tarefas = new List<TarefasModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = $"SELECT Id, Titulo, Descricao FROM Tarefas";

                var command = new SqlCommand(query, connection);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var tarefa = new TarefasModel
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
