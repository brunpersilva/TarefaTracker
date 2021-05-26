using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Tarefas.Infra.AppConfigurations;
using Tarefas.Infra.Tarefa.Command;

namespace Tarefas.Infra.Tests
{
    public class InsertTarefaCommandHandlerTest
    {
        [Test]
        public void InsertTarefaShouldWork()
        {
            AppConfiguration configuration = new AppConfiguration { ConnectionString = "Data Source=localhost;Initial Catalog=Tarefas_Banco;Integrated Security=True" };

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
    }
}
