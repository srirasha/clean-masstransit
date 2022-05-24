using Application;
using Application.Players.Commands.NotifyPlayerConnected;
using Application.Trophies.Commands.Unlock;
using Domain.Commands.Trophies;
using Domain.Events.Players;
using Infrastructure;
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

app.MapPost("/players/connected", async (PlayerConnected @event, IMediator mediator, CancellationToken cancellationToken) =>
{
    await mediator.Send(new NotifyPlayerConnectedCommand(@event), cancellationToken);

    return Results.Accepted();
})
.WithTags("Players");

app.MapPost("/trophies/unlock", async (UnlockTrophy command, IMediator mediator, CancellationToken cancellationToken) =>
{
    await mediator.Send(new UnlockTrophyCommand(command), cancellationToken);

    return Results.Accepted();
})
.WithTags("Trophies");

app.Run();