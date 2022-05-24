using Application._Common.Services;
using MediatR;

namespace Application.Players.Commands.NotifyPlayerConnected
{
    public class NotifyPlayerConnectedCommandHandler : IRequestHandler<NotifyPlayerConnectedCommand, Unit>
    {
        private readonly ICommandsHandler _commandsHandler;

        public NotifyPlayerConnectedCommandHandler(ICommandsHandler commandsHandler)
        {
            _commandsHandler = commandsHandler;
        }

        public async Task<Unit> Handle(NotifyPlayerConnectedCommand request, CancellationToken cancellationToken)
        {
            await _commandsHandler.Send(request.Event, "player.connected", cancellationToken);

            return Unit.Value;
        }
    }
}