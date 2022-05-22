using MassTransit;
using Web.Consumer.API;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumers(typeof(MessageConsumer).Assembly); // auto add all consumers from an assembly

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });

        //cfg.ReceiveEndpoint("yes", e =>
        //{
        //    e.ConfigureConsumer<MessageConsumer>(context);
        //});

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