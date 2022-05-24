using Application;
using Application.Players.Commands.NotifyPlayerConnected;
using Application.Trophies.Commands.UnlockTrophy;
using Domain.Events.Players;
using Domain.Messages.Trophies;
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

app.MapPost("/players/connected", async (PlayerConnectedEvent @event, IMediator mediator, CancellationToken cancellationToken) =>
{
    await mediator.Send(new NotifyPlayerConnectedCommand(@event), cancellationToken);

    return Results.Accepted();
})
.WithTags("Players");

app.MapPost("/trophies/unlock", async (UnlockTrophyMessage message, IMediator mediator, CancellationToken cancellationToken) =>
{
    await mediator.Send(new UnlockTrophyCommand(message), cancellationToken);

    return Results.Accepted();
})
.WithTags("Trophies");

app.Run();