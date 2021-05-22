using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Tarefas.Infra.Tarefa.Command;

namespace Tarefas.Infra.Tests
{
    public class InsertTarefaCommandTest
    {
        [Test]
        public void InsertTarefaShouldWork()
        {
            IConfiguration configuration = Configure();

            var command = new InsertTarefaCommand
            {
                Titulo = "Tarefa Teste",
                Descricao = "Descrição teste",
            };
            var handler = new InsertTarefaCommandHandler(configuration);

            var result = handler.Handle(command, CancellationToken.None);

            Assert.AreEqual(command.Titulo, result.Result.Titulo);
            Assert.AreEqual(command.Descricao, result.Result.Descricao);
        }


        private static IConfiguration Configure()
        {
            var inMemorySettings = new Dictionary<string, string> {
                        {"ConnectionStrings:DefaultConnection", "Data Source=localhost;Initial Catalog=Tarefas_Banco;Integrated Security=True"},
                    };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            return configuration;
        }
    }
}
