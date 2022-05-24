namespace Application._Common.Services
{
    public interface IMessagesHandler
    {
        Task Send(object message, string queueName, CancellationToken cancellationToken = default);
    }
}