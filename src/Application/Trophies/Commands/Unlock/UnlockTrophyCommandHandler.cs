using Application._Common.Services;
using Application.Trophies.Commands.Unlock;
using MediatR;

namespace Application.Trophies.Commands.Unlock
{
    public class UnlockTrophyCommandHandler : IRequestHandler<UnlockTrophyCommand, Unit>
    {
        private readonly IEventsHandler _messagesHandler;

        public UnlockTrophyCommandHandler(IEventsHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public async Task<Unit> Handle(UnlockTrophyCommand request, CancellationToken cancellationToken)
        {
            await _messagesHandler.Publish(request.Command, cancellationToken);

            return Unit.Value;
        }
    }
}