namespace Application._Common.Services
{
    public interface ICommandsHandler
    {
        Task Send(object command, string queueName, CancellationToken cancellationToken = default);
    }
}