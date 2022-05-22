﻿using Application._Common.Services;
using Infrastructure.Configurations;
using Infrastructure.Messaging.Consumers.Tweets.Published;
using Infrastructure.Messaging.Producers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MessagingConfiguration>(configuration.GetSection("Messaging"));

            services.AddScoped<IMessagesHandler, MessagesHandler>();

            AddMassTransit(services, configuration);
        }

        private static void AddMassTransit(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumers(typeof(TweetPublishedEventConsumer).Assembly); // auto add all consumers from an assembly

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["Messaging:Host"], host =>
                    {
                        host.Username(configuration["Messaging:Username"]);
                        host.Password(configuration["Messaging:Password"]);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });
        }
    }
}