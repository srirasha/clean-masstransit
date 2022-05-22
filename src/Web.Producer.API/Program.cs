using Domain.Events.Tweets;
using MassTransit;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["Messaging:Host"], host =>
        {
            host.Username(builder.Configuration["Messaging:Username"]);
            host.Password(builder.Configuration["Messaging:Password"]);
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


app.MapPost("/tweet/send", async (TweetPublishedEvent message, ISendEndpointProvider sendEndpointProvider) =>
{
    ISendEndpoint endpoint = await sendEndpointProvider.GetSendEndpoint(new Uri("queue:tweet-published"));

    await endpoint.Send(message);

    return Results.Accepted();
});

app.Run();