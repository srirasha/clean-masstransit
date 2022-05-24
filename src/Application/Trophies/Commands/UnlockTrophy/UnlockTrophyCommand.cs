using Domain.Messages.Trophies;
using MediatR;

namespace Application.Trophies.Commands.UnlockTrophy
{
    public class UnlockTrophyCommand : IRequest<Unit>
    {
        public UnlockTrophyCommand(UnlockTrophyMessage message)
        {
            Message = message;
        }

        public UnlockTrophyMessage Message { get; set; }
    }
}