namespace Application._Common.Services
{
    public interface IEventMessagesHandler
    {
        Task Publish(object @event, CancellationToken cancellationToken = default);
    }
}