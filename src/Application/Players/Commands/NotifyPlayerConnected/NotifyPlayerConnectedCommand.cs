using Domain.Events.Players;
using MediatR;

namespace Application.Players.Commands.NotifyPlayerConnected
{
    public class NotifyPlayerConnectedCommand : IRequest<Unit>
    {
        public NotifyPlayerConnectedCommand(PlayerConnectedEvent @event)
        {
            Event = @event;
        }

        public PlayerConnectedEvent Event { get; set; }
    }
}