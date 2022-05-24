using Application._Common.Services;
using MediatR;

namespace Application.Players.Commands.NotifyPlayerConnected
{
    public class NotifyPlayerConnectedCommandHandler : IRequestHandler<NotifyPlayerConnectedCommand, Unit>
    {
        private readonly IEventMessagesHandler _eventsHandler;

        public NotifyPlayerConnectedCommandHandler(IEventMessagesHandler eventsHandler)
        {
            _eventsHandler = eventsHandler;
        }

        public async Task<Unit> Handle(NotifyPlayerConnectedCommand request, CancellationToken cancellationToken)
        {
            await _eventsHandler.Publish(request.Event, cancellationToken);

            return Unit.Value;
        }
    }
}