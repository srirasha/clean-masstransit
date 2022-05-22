using MassTransit;
using Web.Consumer.API.Consumers.Tweets.Published;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumers(typeof(TweetPublishedEventConsumer).Assembly); // auto add all consumers from an assembly

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

app.Run();