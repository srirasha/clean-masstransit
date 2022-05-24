﻿using Application._Common.Services;
using MassTransit;

namespace Infrastructure.Services
{
    public class EventsHandler : IEventMessagesHandler
    {
        private readonly IBus _bus;

        public EventsHandler(IBus bus)
        {
            _bus = bus;
        }

        public async Task Publish(object @event, CancellationToken cancellationToken)
        {
            await _bus.Publish(@event, cancellationToken);
        }
    }
}