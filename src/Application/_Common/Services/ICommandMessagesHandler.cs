namespace Application._Common.Services
{
    public interface ICommandMessagesHandler
    {
        Task Send(object command, string queueName, CancellationToken cancellationToken = default);
    }
}