using Domain.Commands.Trophies;
using MediatR;

namespace Application.Trophies.Commands.Unlock
{
    public class UnlockTrophyCommand : IRequest<Unit>
    {
        public UnlockTrophyCommand(UnlockTrophy command)
        {
            Command = command;
        }

        public UnlockTrophy Command { get; set; }
    }
}