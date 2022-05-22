using Domain.Events.Tweets;
using MassTransit;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/message/send", async (TweetPublishedEvent message, ISendEndpointProvider sendEndpointProvider) =>
{
    ISendEndpoint endpoint = await sendEndpointProvider.GetSendEndpoint(new Uri("queue:tweet-published"));

    await endpoint.Send(message);
});

app.Run();