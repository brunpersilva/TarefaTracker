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
using System.Data;

namespace Tarefas.Infra.Tarefa.Command
{
    public class GetAllTarefasCommandHandler : IRequestHandler<GetAllTarefasCommand, TarefasModel>
    {

        private IConfiguration _configuration { get; }
        readonly string _connectionString;

        public GetAllTarefasCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<TarefasModel> Handle(GetAllTarefasCommand request, CancellationToken cancellationToken)
        {
            var tarefas = new TarefasModel {Tarefas = new List<TarefaCriada>(),  Pagina = new PaginacaoModel() };
            tarefas.Pagina.CurrentIndex = request.Page.CurrentIndex;
            tarefas.Pagina.LastRecord = request.Page.LastRecord;
            tarefas.Pagina.PageSize = request.Page.PageSize;

            using (var connection = new SqlConnection(_connectionString))
            {              
                var query = $"SELECT TOP {tarefas.Pagina.PageSize} Id, Titulo, Descricao FROM Tarefas WHERE Id > {tarefas.Pagina.LastRecord} ORDER BY Id";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.CommandText = query;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Tarefas");
                var command = new SqlCommand(query, connection);

                string lastRecord = dataSet.Tables["Tarefas"].Rows[tarefas.Pagina.PageSize - 1]["Id"].ToString();

                tarefas.Pagina.CurrentIndex += tarefas.Pagina.PageSize;

                dataSet.Tables["Tarefas"].Rows.Clear();

                adapter.Fill(dataSet, tarefas.Pagina.CurrentIndex, tarefas.Pagina.PageSize, "Tarefas");

                await connection.OpenAsync();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var tarefa = new TarefaCriada
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Titulo = reader["Titulo"].ToString(),
                        Descricao = reader["Descricao"].ToString()
                    };
                    tarefas.Tarefas.Add(tarefa);
                };

                connection.Close();
            }

            return tarefas;
        }


    }

}
