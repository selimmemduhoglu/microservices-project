using Marten;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddMarten(options =>
{
    // Establish the connection string to your Marten database
    options.Connection(builder.Configuration.GetConnectionString("Database")!);

}).UseLightweightSessions();

WebApplication app = builder.Build();

app.MapCarter();

app.Run();
