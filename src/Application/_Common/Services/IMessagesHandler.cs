namespace Application._Common.Services
{
    public interface IMessagesHandler
    {
        Task Publish(object message, CancellationToken cancellationToken = default);

        Task Send(object message, string queueName, CancellationToken cancellationToken = default);
    }
}