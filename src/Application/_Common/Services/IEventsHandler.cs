namespace Application._Common.Services
{
    public interface IEventsHandler
    {
        Task Publish(object @event, CancellationToken cancellationToken = default);
    }
}