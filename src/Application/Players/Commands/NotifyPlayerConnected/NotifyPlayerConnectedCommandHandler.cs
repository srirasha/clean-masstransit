using Application._Common.Services;
using MediatR;

namespace Application.Players.Commands.NotifyPlayerConnected
{
    public class NotifyPlayerConnectedCommandHandler : IRequestHandler<NotifyPlayerConnectedCommand, Unit>
    {
        private readonly IMessagesHandler _messagesHandler;

        public NotifyPlayerConnectedCommandHandler(IMessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public async Task<Unit> Handle(NotifyPlayerConnectedCommand request, CancellationToken cancellationToken)
        {
            await _messagesHandler.Send(request.Event, "player.connected", cancellationToken);

            return Unit.Value;
        }
    }
}