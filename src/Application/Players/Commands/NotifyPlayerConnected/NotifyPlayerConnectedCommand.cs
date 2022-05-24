using Domain.Events.Players;
using MediatR;

namespace Application.Players.Commands.NotifyPlayerConnected
{
    public class NotifyPlayerConnectedCommand : IRequest<Unit>
    {
        public NotifyPlayerConnectedCommand(PlayerConnected @event)
        {
            Event = @event;
        }

        public PlayerConnected Event { get; set; }
    }
}