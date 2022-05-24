using Application._Common.Services;
using MediatR;

namespace Application.Trophies.Commands.Unlock
{
    public class UnlockTrophyCommandHandler : IRequestHandler<UnlockTrophyCommand, Unit>
    {
        private readonly ICommandMessagesHandler _commandsHandler;

        public UnlockTrophyCommandHandler(ICommandMessagesHandler commandsHandler)
        {
            _commandsHandler = commandsHandler;
        }

        public async Task<Unit> Handle(UnlockTrophyCommand request, CancellationToken cancellationToken)
        {
            await _commandsHandler.Send(request.Command, "trophy.unlock", cancellationToken);

            return Unit.Value;
        }
    }
}