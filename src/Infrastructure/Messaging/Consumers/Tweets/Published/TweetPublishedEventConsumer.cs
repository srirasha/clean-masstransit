using Application.Events.Tweets;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Messaging.Consumers.Tweets.Published
{
    public class TweetPublishedEventConsumer : IConsumer<TweetPublishedEvent>
    {
        private readonly ILogger _logger;

        public TweetPublishedEventConsumer(ILogger<TweetPublishedEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<TweetPublishedEvent> context)
        {
            _logger.LogInformation("Tweet published: {Tweet}", context.Message.Text);

            return Task.CompletedTask;
        }
    }
}