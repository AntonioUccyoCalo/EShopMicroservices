using Marten;

var builder = WebApplication.CreateBuilder(args);

//Add services
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(config =>
{
    config.Connection(builder.Configuration.GetConnectionString("Database")!);
    
}).UseLightweightSessions();

var app = builder.Build();

//Map Http request
app.MapCarter();

app.Run();
