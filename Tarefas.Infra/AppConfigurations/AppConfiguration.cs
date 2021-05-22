using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefas.Infra.AppConfigurations
{
    public class AppConfiguration : IAppConfiguration
    {
        public string ConnectionString { get; set; }
    }
}
