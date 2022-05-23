using Application;
using Application.Events.Players;
using Application.Events.Tweets;
using Application.Players.Commands.NotifyPlayerConnected;
using Infrastructure;
using MassTransit;
using MediatR;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/tweet/published", async (TweetPublishedEvent message, ISendEndpointProvider sendEndpointProvider, CancellationToken cancellationToken) =>
{
    ISendEndpoint endpoint = await sendEndpointProvider.GetSendEndpoint(new Uri("queue:tweet.published"));

    await endpoint.Send(message, cancellationToken);

    return Results.Accepted();
});

app.MapPost("/tweet/deleted", async (TweetDeletedEvent message, IBus bus, CancellationToken cancellationToken) =>
{
    await bus.Publish(message, cancellationToken);

    return Results.Accepted();
});

app.MapPost("/player/connected", async (PlayerConnectedEvent message, IMediator mediator, CancellationToken cancellationToken) =>
{
    await mediator.Send(new NotifyPlayerConnectedCommand(message), cancellationToken);

    return Results.Accepted();
});

app.Run();