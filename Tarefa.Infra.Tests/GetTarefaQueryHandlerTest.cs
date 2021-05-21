using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Tarefas.Infra.Tarefa.Command;

namespace Tarefa.Infra.Tests
{
    public class GetTarefaQueryHandlerTest
    { 
        [SetUp]
        [Test]
        public void Setup()
        {
            var inMemorySettings = new Dictionary<string, string> {
                        {"ConnectionStrings:DefaultConnection", "Data Source=localhost;Initial Catalog=Tarefas_Banco;Integrated Security=True"},
                    };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();


            var query = CreateCommand();
            var handler = new GetTarefaQueryHandler(configuration);

            var result = handler.Handle(query, CancellationToken.None);
            Assert.AreEqual(result.Result.Id, query.Id);
        }

        private GetTarefaQuery CreateCommand()
        {
            return new GetTarefaQuery
            {
                Id = 9
            };
        }


    }
}