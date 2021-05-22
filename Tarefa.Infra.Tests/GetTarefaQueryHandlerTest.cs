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
        [Test]
        public void GetTarefaShouldWork()
        {
            IConfiguration configuration = Configure();

            var query = new GetTarefaQuery
            {
                Id = 9
            };
            var handler = new GetTarefaQueryHandler(configuration);

            var result = handler.Handle(query, CancellationToken.None);
            Assert.AreEqual(query.Id, result.Result.Id);
        }
        [Test]
        public void GetTarefaShouldNotWorkWhenIdIsInvalid()
        {
            IConfiguration configuration = Configure();

            var query = new GetTarefaQuery
            {
                Id = -1
            };
            var handler = new GetTarefaQueryHandler(configuration);

            var result = handler.Handle(query, CancellationToken.None);
            Assert.IsNull(result.Result);
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