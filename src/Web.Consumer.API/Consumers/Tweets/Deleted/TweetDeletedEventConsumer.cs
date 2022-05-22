using Domain.Events.Tweets;
using MassTransit;

namespace Web.Consumer.API.Consumers.Tweets.Deleted
{
    public class TweetDeletedEventConsumer : IConsumer<TweetDeletedEvent>
    {
        private readonly ILogger _logger;

        public TweetDeletedEventConsumer(ILogger<TweetDeletedEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<TweetDeletedEvent> context)
        {
            _logger.LogInformation("Tweet deleted: {Tweet}", context.Message.Id);

            return Task.CompletedTask;
        }
    }
}