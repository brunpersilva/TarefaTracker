namespace Tarefas.Infra.AppConfigurations
{
    public interface IAppConfiguration
    {
        string ConnectionString { get; set; }
    }
}